param([switch]$ExpectRegression)

$ErrorActionPreference = 'Stop'
$root = Split-Path -Parent $PSScriptRoot
$formSource = Get-Content -LiteralPath (Join-Path $root 'Accounts\PresentationLayer\Views\Forms\MedicalFitnessReportForm.vb') -Raw
$baseSource = Get-Content -LiteralPath (Join-Path $root 'PresentationLayer\Forms\BFMain.vb') -Raw
# Exercise the actual source handlers with synthetic controls; no application
# constructor, database connection, patient data, or deployed file is used.
$validation = [regex]::Match($formSource, '(?ms)^        Private Sub txtInvoiceNo_Validated\(.*?^        End Sub').Value
$focus = [regex]::Match($baseSource, '(?ms)^    Public Sub ForceLooseFocusOnCurrentControl\(.*?^    End Sub').Value
if (-not $validation -or -not $focus) { throw 'Source handlers not found.' }
$source = @'
Imports System
Imports System.Windows.Forms
Public Class RemarksFocusProbe
    Inherits Form
    Private WithEvents txtInvoiceNo As New TextBox With {.TabIndex = 0}
    Private txtRemarks As New TextBox With {.TabIndex = 0}
    Private Event RetrieveRequested()
    Private retrievals As Integer
    Private preserveExpected As Boolean
    Public Property Failure As Exception
    Private ReadOnly Property InvoiceNo As Integer
        Get
            Return Integer.Parse(txtInvoiceNo.Text)
        End Get
    End Property
    Public Sub New(expectPreserved As Boolean, rtl As Boolean)
        preserveExpected = expectPreserved
        ShowInTaskbar = False
        Opacity = 0
        If rtl Then RightToLeft = RightToLeft.Yes
        Dim header As New FlowLayoutPanel With {.TabIndex = 0, .Top = 0}
        Dim footer As New FlowLayoutPanel With {.TabIndex = 1, .Top = 110}
        header.Controls.Add(txtInvoiceNo)
        footer.Controls.Add(txtRemarks)
        Controls.Add(header)
        Controls.Add(footer)
        txtInvoiceNo.Text = "73404"
        AddHandler RetrieveRequested, Sub()
            retrievals += 1
            txtRemarks.Text = ""
        End Sub
    End Sub
    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
        BeginInvoke(New Action(AddressOf CheckFocus))
    End Sub
    Private Sub CheckFocus()
        Try
            txtRemarks.Focus()
            retrievals = 0
            txtRemarks.Text = "Synthetic final remarks " & Convert.ToChar(&H633)
            Dim expected = txtRemarks.Text
            ForceLooseFocusOnCurrentControl()
            Dim preserved = txtRemarks.Text = expected AndAlso retrievals = 0
            If preserved <> preserveExpected Then Throw New Exception("Unexpected save focus result: retrievals=" & retrievals)
            Console.WriteLine(If(preserved, "PASS: Save focus preserves final remarks", "REPRODUCED: Save focus reloads invoice and erases final remarks"))
            If preserveExpected Then
                txtInvoiceNo_Validated(txtInvoiceNo, EventArgs.Empty)
                If retrievals <> 0 Then Throw New Exception("Unchanged invoice reloaded")
                txtInvoiceNo.Text = "73405"
                txtInvoiceNo.Modified = True
                txtInvoiceNo_Validated(txtInvoiceNo, EventArgs.Empty)
                If retrievals <> 1 Then Throw New Exception("Edited invoice did not retrieve")
                txtInvoiceNo_Validated(txtInvoiceNo, EventArgs.Empty)
                If retrievals <> 1 Then Throw New Exception("Edited invoice retrieved twice")
                Console.WriteLine("PASS: Edited invoice retrieves once; repeated validation preserves edits")
            End If
        Catch ex As Exception
            Failure = ex
        Finally
            Close()
        End Try
    End Sub
__VALIDATION__
__FOCUS__
End Class
'@
$source = $source.Replace('__VALIDATION__', $validation).Replace('__FOCUS__', $focus)
$compiler = New-Object Microsoft.VisualBasic.VBCodeProvider
$options = New-Object System.CodeDom.Compiler.CompilerParameters
$options.GenerateInMemory = $true
$options.ReferencedAssemblies.AddRange([string[]]@('System.dll', 'System.Windows.Forms.dll', 'System.Drawing.dll'))
try {
    $result = $compiler.CompileAssemblyFromSource($options, $source)
    if ($result.Errors.HasErrors) { throw (($result.Errors | ForEach-Object ToString) -join [Environment]::NewLine) }
    foreach ($rtl in @($false, $true)) {
        $probe = [Activator]::CreateInstance($result.CompiledAssembly.GetType('RemarksFocusProbe'), @(-not $ExpectRegression.IsPresent, $rtl))
        try {
            [System.Windows.Forms.Application]::Run($probe)
            if ($probe.Failure) { throw $probe.Failure }
        } finally { $probe.Dispose() }
    }
} finally { $compiler.Dispose() }
