param(
    [string]$AccountsAssembly = (Join-Path $PSScriptRoot '..\Accounts\bin\Debug\Accounts.exe')
)

# Offline regression checks: no connection strings, database calls or application startup.
$ErrorActionPreference = 'Stop'
$assembly = [Reflection.Assembly]::LoadFrom((Resolve-Path -LiteralPath $AccountsAssembly))
$serviceType = $assembly.GetType('AATM.Accounts.ServiceLayer.OpenInvoiceCorrectionService', $true)
$service = [Activator]::CreateInstance($serviceType)
$itemType = $assembly.GetType('AATM.Accounts.PresentationLayer.Models.OpenInvoiceCorrectionItem', $true)
$listType = [Collections.Generic.List``1].MakeGenericType($itemType)

function New-Invoices($Rows) {
    $items = [Activator]::CreateInstance($listType)
    $id = 0
    foreach ($row in $Rows) {
        $item = [Activator]::CreateInstance($itemType)
        $item.OpenInvoiceIdNo = ++$id
        $item.AccountIdNo = [int16]$row[0]
        $item.CurrentBalance = [decimal]$row[1]
        $item.TransactionDate = [datetime]'2026-09-09'
        [void]$items.Add($item)
    }
    return ,$items
}

function Assert-Rejected($Items) {
    try {
        [void]$serviceType.GetMethod('CreateArJournalItems').Invoke($null, [object[]](,$Items))
    } catch {
        $exception = $_.Exception
        while ($exception.InnerException) { $exception = $exception.InnerException }
        if ($exception -is [InvalidOperationException]) { return }
        throw
    }
    throw 'Invalid correction was accepted.'
}

foreach ($case in @(
    @{ Name = 'same account'; Rows = @(@(112, -35200), @(112, 35200)); Offset = 35200; Remaining = 0 },
    @{ Name = 'several invoices'; Rows = @(@(112, -100), @(112, -50), @(112, 120), @(112, 80)); Offset = 150; Remaining = 0 },
    @{ Name = 'partial negative'; Rows = @(@(112, -150), @(112, 60)); Offset = 60; Remaining = 90 },
    @{ Name = 'different accounts'; Rows = @(@(112, -100), @(113, 100)); Offset = 100; Remaining = 0 }
)) {
    $items = New-Invoices $case.Rows
    $remaining = $service.ApplyNegativeFirst($items)
    if ($remaining -ne $case.Remaining) { throw "Wrong remaining balance: $($case.Name)" }
    if (($items | Measure-Object ProposedAmount -Sum).Sum -ne 0) { throw 'Allocations are not balanced.' }
    foreach ($item in $items) {
        if ($item.ProjectedBalance -ne ($item.CurrentBalance - $item.ProposedAmount)) {
            throw 'Incorrect projected invoice balance.'
        }
    }
    foreach ($ledger in @('Ar', 'Ap')) {
        $journal = $serviceType.GetMethod("Create${ledger}JournalItems").Invoke($null, [object[]](,$items))
        $debit = ($journal | Measure-Object Debit -Sum).Sum
        $credit = ($journal | Measure-Object Credit -Sum).Sum
        if ($debit -ne $case.Offset -or $credit -ne $case.Offset) { throw 'Offset was netted away.' }
        for ($index = 0; $index -lt $journal.Count; $index++) {
            $line = $journal[$index]
            if ($line.Sequence -ne ($index + 1) -or ($line.Debit -eq 0 -and $line.Credit -eq 0) -or
                ($line.Debit -ne 0 -and $line.Credit -ne 0)) { throw 'Invalid journal line or sequence.' }
        }
        $negativeLine = $journal | Where-Object { $_.AccountIdNo -eq 112 } | Select-Object -First 1
        if (($ledger -eq 'Ar' -and $negativeLine.Debit -ne $case.Offset) -or
            ($ledger -eq 'Ap' -and $negativeLine.Credit -ne $case.Offset)) { throw 'Wrong offset direction.' }

        $modelName = if ($ledger -eq 'Ar') { 'CashReceiptJournalModel' } else { 'DisbursementJournalModel' }
        $transactionName = if ($ledger -eq 'Ar') { 'CashReceiptJournalTransactionService' } else { 'CashDisbursementJournalTransactionService' }
        $model = [Activator]::CreateInstance($assembly.GetType("AATM.Accounts.PresentationLayer.Models.$modelName", $true))
        $model.Amount = 0
        $model.AccountIdNo = 112
        $model.JournalItems = $journal
        $transactionType = $assembly.GetType("AATM.Accounts.ServiceLayer.$transactionName", $true)
        $table = $transactionType.GetMethod('CreateItems', [Reflection.BindingFlags]'NonPublic,Static').Invoke($null, [object[]]@($model))
        if ($table.Rows.Count -ne $journal.Count -or
            $table.Compute('SUM(Debit)', '') -ne $case.Offset -or
            $table.Compute('SUM(Credit)', '') -ne $case.Offset) { throw 'Save detail rows lost the offset.' }

        $oi = $serviceType.GetMethod("Create${ledger}OiItems", [Reflection.BindingFlags]'NonPublic,Static').Invoke($null, [object[]](,$items))
        for ($index = 0; $index -lt $oi.Count; $index++) {
            if ($oi[$index].Sequence -ne ($index + 1)) { throw 'Invoice allocation sequence must start at 1.' }
        }
    }
    Write-Output "PASS: $($case.Name), AR/AP direction, amounts, sequences and save detail rows."
}

$offsetMethod = $serviceType.GetMethod('IsInvoiceOffset')
foreach ($case in @(
    @{ Amount = 0; Values = @(-100, 100); Discounts = @(0, 0); Expected = $true },
    @{ Amount = 100; Values = @(-100, 100); Discounts = @(0, 0); Expected = $false },
    @{ Amount = 0; Values = @(-100, 90); Discounts = @(0, 0); Expected = $false },
    @{ Amount = 0; Values = @(-100, 100); Discounts = @(1, -1); Expected = $false },
    @{ Amount = 0; Values = @(0, 0); Discounts = @(0, 0); Expected = $false }
)) {
    $actual = $offsetMethod.Invoke($null, [object[]]@([decimal]$case.Amount, [decimal[]]$case.Values, [decimal[]]$case.Discounts))
    if ($actual -ne $case.Expected) { throw 'Incorrect offset identification.' }
}
$invalid = New-Invoices @(@(0, -100), @(112, 100))
[void]$service.ApplyNegativeFirst($invalid)
Assert-Rejected $invalid
$invalid[0].AccountIdNo = 112
$invalid[1].ProposedAmount = 90
Assert-Rejected $invalid
$invalid[0].ProposedAmount = 0
$invalid[1].ProposedAmount = 0
Assert-Rejected $invalid
Write-Output 'PASS: offset identification and rejection of missing accounts, unbalanced and empty corrections.'
