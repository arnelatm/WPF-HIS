param(
    [string]$AccountsAssembly = (Join-Path $PSScriptRoot '..\Accounts\bin\Debug\Accounts.exe')
)

$ErrorActionPreference = 'Stop'
$assembly = [Reflection.Assembly]::LoadFrom((Resolve-Path -LiteralPath $AccountsAssembly))
$sequencer = $assembly.GetType('AATM.Accounts.JournalItemSequencing', $true)

function New-JournalList([string]$TypeName) {
    $itemType = $assembly.GetType($TypeName, $true)
    $listType = [Collections.Generic.List``1].MakeGenericType($itemType)
    return ,([Activator]::CreateInstance($listType))
}

function Add-JournalItem($Items, [int16]$Account, [decimal]$Debit, [decimal]$Credit,
                         [int16]$Sequence, [int]$Id) {
    $itemType = $Items.GetType().GetGenericArguments()[0]
    $item = [Activator]::CreateInstance($itemType)
    $item.AccountIdNo = $Account
    $item.Debit = $Debit
    $item.Credit = $Credit
    $item.Sequence = $Sequence
    $item.IdNo = $Id
    $item.PayIdNo = 2107
    $item.OpenInvoiceIdNo = 2821
    [void]$Items.Add($item)
}

function Normalize-Items($Items, $HeaderAccount) {
    $method = $sequencer.GetMethods([Reflection.BindingFlags]'Public,NonPublic,Static') |
        Where-Object { $_.Name -eq 'Normalize' -and $_.GetParameters()[0].ParameterType -eq $Items.GetType() }
    [void]$method.Invoke($null, [object[]]@($Items, $HeaderAccount))
}

foreach ($typeName in @('AATM.Accounts.BusinessLayer.JournalItem',
                        'AATM.Accounts.PresentationLayer.Models.JournalItemModel',
                        'AATM.Accounts.PresentationLayer.Views.JournalItemView')) {
    $items = New-JournalList $typeName
    Add-JournalItem $items 128 0 956.52 0 3030
    Add-JournalItem $items 110 956.52 0 1 3029
    Normalize-Items $items 110
    if ($items[0].IdNo -ne 3029 -or $items[0].Sequence -ne 1 -or
        $items[1].IdNo -ne 3030 -or $items[1].Sequence -ne 2 -or
        $items[0].Debit -ne 956.52 -or $items[1].Credit -ne 956.52 -or
        $items[1].PayIdNo -ne 2107 -or $items[1].OpenInvoiceIdNo -ne 2821) {
        throw "Bank-line ordering or financial identity preservation failed: $typeName"
    }
    Normalize-Items $items 110
    if ($items[0].IdNo -ne 3029 -or $items[1].Sequence -ne 2) { throw 'Normalization is not idempotent.' }

    $items = New-JournalList $typeName
    Add-JournalItem $items 112 0 51.75 0 10210
    Add-JournalItem $items 112 51.75 0 1 10209
    Normalize-Items $items 112
    if ($items[0].IdNo -ne 10209 -or $items[1].IdNo -ne 10210 -or $items[1].Sequence -ne 2) {
        throw 'An existing header line was lost when multiple lines use the same account.'
    }

    $items = New-JournalList $typeName
    Add-JournalItem $items 112 10 0 9 1
    Add-JournalItem $items 128 0 0 9 2
    Add-JournalItem $items 110 0 10 0 3
    Normalize-Items $items $null
    if ($items[0].IdNo -ne 1 -or $items[2].IdNo -ne 3 -or
        $items[0].Sequence -ne 1 -or $items[1].Sequence -ne 0 -or $items[2].Sequence -ne 2) {
        throw 'Manual line order or zero-placeholder filtering failed.'
    }
    Write-Output "PASS: $typeName bank order, identities, same-account header, idempotence and placeholders."
}

foreach ($test in @(
    @{ Service = 'ArJournalTransactionService'; Model = 'ArJournalModel' },
    @{ Service = 'ApJournalTransactionService'; Model = 'ApJournalModel' },
    @{ Service = 'CashReceiptJournalTransactionService'; Model = 'CashReceiptJournalModel' },
    @{ Service = 'CashDisbursementJournalTransactionService'; Model = 'DisbursementJournalModel' },
    @{ Service = 'PettyCashJournalTransactionService'; Model = 'DisbursementJournalModel' },
    @{ Service = 'GeneralJournalTransactionService'; Model = 'GeneralJournalModel' }
)) {
    $model = [Activator]::CreateInstance($assembly.GetType('AATM.Accounts.PresentationLayer.Models.' + $test.Model, $true))
    If ($model.GetType().GetProperty('AccountIdNo') -ne $null) {
        $model.AccountIdNo = [int16]110
    }
    $items = New-JournalList 'AATM.Accounts.PresentationLayer.Models.JournalItemModel'
    Add-JournalItem $items 110 10 0 1 1
    Add-JournalItem $items 112 0 0 0 2
    Add-JournalItem $items 128 0 10 0 3
    $model.JournalItems = $items
    $service = $assembly.GetType('AATM.Accounts.ServiceLayer.' + $test.Service, $true)
    $method = $service.GetMethod('CreateItems', [Reflection.BindingFlags]'NonPublic,Static')
    $table = $method.Invoke($null, [object[]]@($model))
    if ($table.Rows.Count -ne 2 -or $table.Rows[0].Sequence -ne 1 -or $table.Rows[1].Sequence -ne 2 -or
        $table.Rows[0].Debit -ne 10 -or $table.Rows[1].Credit -ne 10) {
        throw ('Atomic detail serialization failed: ' + $test.Service)
    }
    Write-Output ('PASS: ' + $test.Service + ' consecutive nonzero detail sequences.')
}

Write-Output 'All journal sequencing checks passed without a database connection.'
