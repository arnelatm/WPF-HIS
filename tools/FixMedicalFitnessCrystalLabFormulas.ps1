param(
    [string]$ReportPath = 'D:\AATM\Accounts\Reports\Medical Fitness Report.rpt'
)

$ErrorActionPreference = 'Stop'

$assemblyPaths = @(
    'CrystalDecisions.Shared',
    'CrystalDecisions.ReportAppServer.ReportDefModel',
    'CrystalDecisions.CrystalReports.Engine') |
    ForEach-Object {
        Get-ChildItem -Path 'C:\Windows\Microsoft.NET\assembly\GAC_MSIL' -Recurse -Filter ($_.ToString() + '.dll') |
            Where-Object FullName -like '*13.0.4000.0*' |
            Select-Object -First 1 -ExpandProperty FullName
    }
Add-Type -Path $assemblyPaths

$temporaryPath = $ReportPath + '.labformula.tmp.rpt'
$document = New-Object CrystalDecisions.CrystalReports.Engine.ReportDocument
try {
    $document.Load((Resolve-Path -LiteralPath $ReportPath))
    $controller = $document.ReportClientDocument.DataDefController.FormulaFieldController

    $printableRow = $document.ReportClientDocument.DataDefController.DataDefinition.FormulaFields |
        Where-Object Name -EQ 'PrintableRow' |
        Select-Object -First 1
    if ($null -eq $printableRow) {
        throw 'The Crystal report does not contain the PrintableRow formula.'
    }
    $printableReplacement = $printableRow.Clone($true)
    $printableReplacement.Text = @'
Local StringVar sectionCode := "";
Local StringVar resultText := "";
Local StringVar resultStatus := "";
Local StringVar resultStatusSource := "";

If Not IsNull({MedicalFitnessReportTestResult.SectionCode}) Then
    sectionCode := UpperCase(Trim({MedicalFitnessReportTestResult.SectionCode}));

If Not IsNull({MedicalFitnessReportTestResult.ResultText}) Then
    resultText := Trim({MedicalFitnessReportTestResult.ResultText});

If Not IsNull({MedicalFitnessReportTestResult.ResultStatus}) Then
    resultStatus := Trim({MedicalFitnessReportTestResult.ResultStatus});

If Not IsNull({MedicalFitnessReportTestResult.ResultStatusSource}) Then
    resultStatusSource := UpperCase(Trim({MedicalFitnessReportTestResult.ResultStatusSource}));

If sectionCode = "LAB" Then
    If resultText <> "" Then
        1
    Else If resultStatusSource = "M" And (resultStatus = "F" Or resultStatus = "U") Then
        1
    Else
        0
Else If resultText = "" And resultStatus = "" Then
    0
Else
    1
'@
    $printableReplacement.Syntax = [CrystalDecisions.ReportAppServer.DataDefModel.CrFormulaSyntaxEnum]::crFormulaSyntaxCrystal
    $controller.Modify($printableRow, $printableReplacement)

    $resultTextDisplay = $document.ReportClientDocument.DataDefController.DataDefinition.FormulaFields |
        Where-Object Name -EQ 'ResultTextDisplay' |
        Select-Object -First 1
    if ($null -eq $resultTextDisplay) {
        throw 'The Crystal report does not contain the ResultTextDisplay formula.'
    }
    $resultReplacement = $resultTextDisplay.Clone($true)
    $resultReplacement.Text = @'
Local StringVar sectionCode := "";
Local StringVar resultText := "";

If Not IsNull({MedicalFitnessReportTestResult.SectionCode}) Then
    sectionCode := UpperCase(Trim({MedicalFitnessReportTestResult.SectionCode}));

If sectionCode = "LAB" And Not IsNull({MedicalFitnessReportTestResult.ResultText}) Then
    resultText := Trim({MedicalFitnessReportTestResult.ResultText});

If sectionCode <> "LAB" And Not IsNull({MedicalFitnessReportTestResult.ResultText}) Then
    resultText := Trim({MedicalFitnessReportTestResult.ResultText});

resultText
'@
    $resultReplacement.Syntax = [CrystalDecisions.ReportAppServer.DataDefModel.CrFormulaSyntaxEnum]::crFormulaSyntaxCrystal
    $controller.Modify($resultTextDisplay, $resultReplacement)

    # LAB tests are dynamic Kizen rows and do not have matching records in
    # MedicalFitnessReportExamTemplate.  The old TestNameDisplay formula
    # dereferenced ExamTemplate.Unit for every detail row; Crystal then
    # silently dropped the LAB group when the template row was absent.  Use
    # only the fields that belong to the detail row.  Clinical results already
    # contain their unit in ResultText, while LAB units are appended by
    # ResultTextDisplay above.
    $testNameDisplay = $document.ReportClientDocument.DataDefController.DataDefinition.FormulaFields |
        Where-Object Name -EQ 'TestNameDisplay' |
        Select-Object -First 1
    if ($null -eq $testNameDisplay) {
        throw 'The Crystal report does not contain the TestNameDisplay formula.'
    }
    $testNameReplacement = $testNameDisplay.Clone($true)
    $testNameReplacement.Text = @'
Local StringVar EnglishName := "";
Local StringVar ArabicName := "";
Local StringVar DisplayName := "";

If Not IsNull({MedicalFitnessReportTestResult.TestNameEnglish}) Then
    EnglishName := Trim({MedicalFitnessReportTestResult.TestNameEnglish});

If Not IsNull({MedicalFitnessReportTestResult.TestNameArabic}) Then
    ArabicName := Trim({MedicalFitnessReportTestResult.TestNameArabic});

If EnglishName <> "" And ArabicName <> "" Then
    DisplayName := "(" + EnglishName + ") " + ArabicName
Else If EnglishName <> "" Then
    DisplayName := "(" + EnglishName + ")"
Else
    DisplayName := ArabicName;

DisplayName;
'@
    $testNameReplacement.Syntax = [CrystalDecisions.ReportAppServer.DataDefModel.CrFormulaSyntaxEnum]::crFormulaSyntaxCrystal
    $controller.Modify($testNameDisplay, $testNameReplacement)

    $detailSection = $document.ReportClientDocument.ReportDefController.ReportDefinition.Areas |
        ForEach-Object Sections |
        Where-Object Name -EQ 'DetailSection1' |
        Select-Object -First 1
    if ($null -ne $detailSection -and $detailSection.Format.ConditionFormulas.Count -gt 0) {
        $detailFormat = $detailSection.Format.Clone($true)
        $detailFormulas = $detailFormat.ConditionFormulas.Clone($true)
        # Suppress every row that has neither a saved result nor a Fit/Unfit
        # status.  This keeps blank Clinical, X-Ray, and LAB rows out of the
        # certificate while retaining rows explicitly marked Fit/Unfit.
        $detailFormulas[0].Text = @'
{@PrintableRow} = 0
'@
        $detailFormulas[0].Syntax = [CrystalDecisions.ReportAppServer.DataDefModel.CrFormulaSyntaxEnum]::crFormulaSyntaxCrystal
        $detailFormat.EnableSuppress = $true
        $detailFormat.ConditionFormulas = $detailFormulas
        $document.ReportClientDocument.ReportDefController.ReportSectionController.SetProperty(
            $detailSection,
            [CrystalDecisions.ReportAppServer.Controllers.CrReportSectionPropertyEnum]::crReportSectionPropertyFormat,
            $detailFormat)
    }

    $document.SaveAs($temporaryPath)
} finally {
    $document.Close()
    $document.Dispose()
}

Copy-Item -LiteralPath $temporaryPath -Destination $ReportPath -Force
Remove-Item -LiteralPath $temporaryPath -Force
Write-Output ('Updated Crystal report formulas: ' + $ReportPath)
