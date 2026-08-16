param(
    [string]$WorkspaceRoot = 'D:\AATM',
    [string]$ExistingSchemaReportPath = ''
)

$ErrorActionPreference = 'Stop'

$engineAssembly = 'C:\Windows\Microsoft.NET\assembly\GAC_MSIL\CrystalDecisions.CrystalReports.Engine\v4.0_13.0.4000.0__692fbea5521e1304\CrystalDecisions.CrystalReports.Engine.dll'
$sharedAssembly = 'C:\Windows\Microsoft.NET\assembly\GAC_MSIL\CrystalDecisions.Shared\v4.0_13.0.4000.0__692fbea5521e1304\CrystalDecisions.Shared.dll'
$reportDefinitionAssembly = 'C:\Windows\Microsoft.NET\assembly\GAC_MSIL\CrystalDecisions.ReportAppServer.ReportDefModel\v4.0_13.0.4000.0__692fbea5521e1304\CrystalDecisions.ReportAppServer.ReportDefModel.dll'

Add-Type -Path $sharedAssembly
Add-Type -Path $reportDefinitionAssembly
Add-Type -Path $engineAssembly

function Get-Utf8Text([string]$base64) {
    return [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($base64))
}

$reportPath = Join-Path $WorkspaceRoot 'Accounts\Reports\Medical Fitness Report.rpt'
$configurationPath = Join-Path $WorkspaceRoot 'Accounts\app.config'
$temporaryDirectory = Join-Path $WorkspaceRoot '.tmp\medical-fitness-crystal-update'
$schemaReportPath = if ([string]::IsNullOrWhiteSpace($ExistingSchemaReportPath)) {
    Join-Path $temporaryDirectory 'Medical Fitness Report schema.rpt'
} else {
    $ExistingSchemaReportPath
}
$updatedReportPath = Join-Path $temporaryDirectory 'Medical Fitness Report updated.rpt'

if (-not (Test-Path -LiteralPath $temporaryDirectory)) {
    New-Item -ItemType Directory -Path $temporaryDirectory | Out-Null
}

[xml]$configuration = Get-Content -LiteralPath $configurationPath
$connectionString = ($configuration.configuration.connectionStrings.add |
    Where-Object name -IEQ 'ISPDATA' |
    Select-Object -First 1).connectionString
if ([string]::IsNullOrWhiteSpace($connectionString)) {
    throw 'The ISPDATA connection string was not found.'
}
$connectionBuilder = New-Object System.Data.SqlClient.SqlConnectionStringBuilder($connectionString)

# Refresh the saved Crystal table definition. SetTableLocation causes Crystal
# to import the current ISPData columns without changing the underlying table.
if ([string]::IsNullOrWhiteSpace($ExistingSchemaReportPath)) {
    $schemaDocument = New-Object CrystalDecisions.CrystalReports.Engine.ReportDocument
    try {
        'Crystal update: refreshing saved database schema...'
        $schemaDocument.Load($reportPath)
        $databaseController = $schemaDocument.ReportClientDocument.DatabaseController
        $databaseController.LogonEx(
            $connectionBuilder.DataSource,
            $connectionBuilder.InitialCatalog,
            $connectionBuilder.UserID,
            $connectionBuilder.Password)
        $medicalReportTable = $databaseController.Database.Tables[0]
        if ($null -eq $medicalReportTable -or $medicalReportTable.Alias -ine 'MedicalFitnessReport') {
            throw 'The MedicalFitnessReport table was not found in the Crystal report.'
        }
        $refreshedTable = $medicalReportTable.Clone($true)
        $databaseController.SetTableLocation($medicalReportTable, $refreshedTable)
        $schemaDocument.SaveAs($schemaReportPath)
        'Crystal update: schema refresh complete.'
    } finally {
        $schemaDocument.Close()
        $schemaDocument.Dispose()
    }
} elseif (-not (Test-Path -LiteralPath $schemaReportPath)) {
    throw 'The supplied schema-refreshed Crystal report was not found.'
}

$document = New-Object CrystalDecisions.CrystalReports.Engine.ReportDocument
try {
    'Crystal update: constructing the new report layout...'
    $document.Load($schemaReportPath)
    $clientDocument = $document.ReportClientDocument
    $reportDefinition = $clientDocument.ReportDefController.ReportDefinition
    $objectController = $clientDocument.ReportDefController.ReportObjectController
    $sectionController = $clientDocument.ReportDefController.ReportSectionController
    $pageHeaderArea = $reportDefinition.PageHeaderArea
    $firstPageHeader = $pageHeaderArea.Sections[0]

    # ECG, Audiometry and Spirometry are stored with a required internal
    # DETAIL section code. Suppress that group heading while retaining the
    # detail rows and the database's NOT NULL integrity rule.
    $detailHeader = $reportDefinition.Areas |
        ForEach-Object Sections |
        Where-Object Name -EQ 'GroupHeaderSection1' |
        Select-Object -First 1
    if ($null -eq $detailHeader) {
        throw 'The result group-header section was not found in the Crystal report.'
    }
    $detailHeaderFormat = $detailHeader.Format.Clone($true)
    $detailHeaderFormulas = $detailHeaderFormat.ConditionFormulas.Clone($true)
    $suppressDetailHeader = New-Object CrystalDecisions.ReportAppServer.ReportDefModel.ConditionFormulaClass
    $suppressDetailHeader.Text = @'
Sum(
    {@PrintableRow},
    {MedicalFitnessReportTestResult.SectionCode}
) = 0 Or
UpperCase(Trim({MedicalFitnessReportTestResult.SectionCode})) = "DETAIL"
'@
    $suppressDetailHeader.Syntax = [CrystalDecisions.ReportAppServer.DataDefModel.CrFormulaSyntaxEnum]::crFormulaSyntaxCrystal
    $detailHeaderFormulas.Formula(
        [CrystalDecisions.ReportAppServer.ReportDefModel.CrSectionAreaFormatConditionFormulaTypeEnum]::crSectionAreaConditionFormulaTypeEnableSuppress) = $suppressDetailHeader
    $detailHeaderFormat.ConditionFormulas = $detailHeaderFormulas
    $sectionController.SetProperty(
        $detailHeader,
        [CrystalDecisions.ReportAppServer.Controllers.CrReportSectionPropertyEnum]::crReportSectionPropertyFormat,
        $detailHeaderFormat)

    $generatedSections = @($pageHeaderArea.Sections | Where-Object {
        $_.Name -in @('PageHeaderSectionPatientAdditional', 'PageHeaderSectionGeneralExam', 'PageHeaderSectionResultHeadings')
    })
    foreach ($generatedSection in $generatedSections) {
        $sectionController.Remove($generatedSection)
    }

    $labelTemplate = $firstPageHeader.ReportObjects |
        Where-Object Name -EQ 'Text28' |
        Select-Object -First 1
    $titleTemplate = $firstPageHeader.ReportObjects |
        Where-Object Name -EQ 'Text27' |
        Select-Object -First 1
    $fieldTemplate = $firstPageHeader.ReportObjects |
        Where-Object Name -EQ 'PatientName1' |
        Select-Object -First 1
    if ($null -eq $labelTemplate -or $null -eq $titleTemplate -or $null -eq $fieldTemplate) {
        throw 'The expected Crystal report template objects were not found.'
    }

    # Keep every page-header object within the 11,520-twip printable width.
    # The legacy background image and page-count field extended past the
    # boundary, which generated a blank horizontal overflow page and clipped
    # the final digit from "Page N of M" in PDF exports.
    function Set-ExistingObjectWidth([string]$objectName, [int]$width) {
        $reportObject = $firstPageHeader.ReportObjects |
            Where-Object Name -EQ $objectName |
            Select-Object -First 1
        if ($null -eq $reportObject) {
            throw "The Crystal report object $objectName was not found."
        }

        $replacement = $reportObject.Clone($true)
        $replacement.Width = $width
        $objectController.Modify($reportObject, $replacement)
    }

    Set-ExistingObjectWidth 'Picture1' 11235
    Set-ExistingObjectWidth 'PageNofM1' 2470

    # Correct the legacy I.D. No. object, which was bound to the report IdNo.
    $identityObject = $firstPageHeader.ReportObjects |
        Where-Object Name -EQ 'IdNo1' |
        Select-Object -First 1
    if ($null -ne $identityObject) {
        $identityFormula = '{MedicalFitnessReport.IdentityNo}'
        $identityField = $clientDocument.DataDefController.FindFieldByFormulaForm($identityFormula)
        if ($null -eq $identityField) {
            throw "Crystal field $identityFormula was not found after the schema refresh."
        }
        $identityReplacement = $identityObject.Clone($true)
        $identityReplacement.DataSource = $identityFormula
        $identityReplacement.DataSourceName = $identityFormula
        $identityReplacement.FieldValueType = $identityField.Type
        $identityIndex = 0
        for ($objectIndex = 0; $objectIndex -lt $firstPageHeader.ReportObjects.Count; $objectIndex++) {
            if ($firstPageHeader.ReportObjects[$objectIndex].Name -eq $identityObject.Name) {
                $identityIndex = $objectIndex
                break
            }
        }
        $objectController.Remove($identityObject)
        $objectController.Add($identityReplacement, $firstPageHeader, $identityIndex)
    }

    # Remove the previous dynamic-table heading from the first page header.
    $oldHeadingNames = @('Text35', 'Text36', 'Text37', 'Text38', 'Line2', 'Line3', 'Line4', 'Line5', 'Line6', 'Line7', 'Line8')
    foreach ($objectName in $oldHeadingNames) {
        $oldObject = $firstPageHeader.ReportObjects |
            Where-Object Name -EQ $objectName |
            Select-Object -First 1
        if ($null -ne $oldObject) {
            $objectController.Remove($oldObject)
        }
    }
    $sectionController.SetProperty(
        $firstPageHeader,
        [CrystalDecisions.ReportAppServer.Controllers.CrReportSectionPropertyEnum]::crReportSectionPropertyHeight,
        4100)

    $patientAdditionalSection = New-Object CrystalDecisions.ReportAppServer.ReportDefModel.SectionClass
    $patientAdditionalSection.Name = 'PageHeaderSectionPatientAdditional'
    $patientAdditionalSection.Kind = [CrystalDecisions.ReportAppServer.ReportDefModel.CrAreaSectionKindEnum]::crAreaSectionKindPageHeader
    $patientAdditionalSection.Height = 650
    $sectionController.Add($patientAdditionalSection, $pageHeaderArea, $pageHeaderArea.Sections.Count)
    $patientAdditionalSection = $pageHeaderArea.Sections |
        Where-Object Name -EQ 'PageHeaderSectionPatientAdditional' |
        Select-Object -First 1
    if ($null -eq $patientAdditionalSection) {
        $patientAdditionalSection = $pageHeaderArea.Sections[$pageHeaderArea.Sections.Count - 1]
    }

    $generalSection = New-Object CrystalDecisions.ReportAppServer.ReportDefModel.SectionClass
    $generalSection.Name = 'PageHeaderSectionGeneralExam'
    $generalSection.Kind = [CrystalDecisions.ReportAppServer.ReportDefModel.CrAreaSectionKindEnum]::crAreaSectionKindPageHeader
    $generalSection.Height = 4700
    $sectionController.Add($generalSection, $pageHeaderArea, $pageHeaderArea.Sections.Count)
    $generalSection = $pageHeaderArea.Sections |
        Where-Object Name -EQ 'PageHeaderSectionGeneralExam' |
        Select-Object -First 1
    if ($null -eq $generalSection) {
        $generalSection = $pageHeaderArea.Sections[$pageHeaderArea.Sections.Count - 1]
    }

    $generalSectionFormat = $generalSection.Format.Clone($true)
    $generalSectionFormulas = $generalSectionFormat.ConditionFormulas.Clone($true)
    $suppressAfterFirstPage = New-Object CrystalDecisions.ReportAppServer.ReportDefModel.ConditionFormulaClass
    $suppressAfterFirstPage.Text = 'PageNumber > 1'
    $suppressAfterFirstPage.Syntax = [CrystalDecisions.ReportAppServer.DataDefModel.CrFormulaSyntaxEnum]::crFormulaSyntaxCrystal
    $generalSectionFormulas.Formula(
        [CrystalDecisions.ReportAppServer.ReportDefModel.CrSectionAreaFormatConditionFormulaTypeEnum]::crSectionAreaConditionFormulaTypeEnableSuppress) = $suppressAfterFirstPage
    $generalSectionFormat.ConditionFormulas = $generalSectionFormulas
    $sectionController.SetProperty(
        $generalSection,
        [CrystalDecisions.ReportAppServer.Controllers.CrReportSectionPropertyEnum]::crReportSectionPropertyFormat,
        $generalSectionFormat)

    $headingSection = New-Object CrystalDecisions.ReportAppServer.ReportDefModel.SectionClass
    $headingSection.Name = 'PageHeaderSectionResultHeadings'
    $headingSection.Kind = [CrystalDecisions.ReportAppServer.ReportDefModel.CrAreaSectionKindEnum]::crAreaSectionKindPageHeader
    $headingSection.Height = 390
    $sectionController.Add($headingSection, $pageHeaderArea, $pageHeaderArea.Sections.Count)
    $headingSection = $pageHeaderArea.Sections |
        Where-Object Name -EQ 'PageHeaderSectionResultHeadings' |
        Select-Object -First 1
    if ($null -eq $headingSection) {
        $headingSection = $pageHeaderArea.Sections[$pageHeaderArea.Sections.Count - 1]
    }
    'Crystal update: report sections created.'

    $singleLine = [CrystalDecisions.ReportAppServer.ReportDefModel.CrLineStyleEnum]::crLineStyleSingle
    $center = [CrystalDecisions.ReportAppServer.ReportDefModel.CrAlignmentEnum]::crAlignmentHorizontalCenter
    $verticalCenter = [CrystalDecisions.ReportAppServer.ReportDefModel.CrAlignmentEnum]::crAlignmentVerticalCenter
    $white = [System.Drawing.ColorTranslator]::ToOle([System.Drawing.Color]::White)
    $yellow = [System.Drawing.ColorTranslator]::ToOle([System.Drawing.Color]::Yellow)

    function Set-ObjectBorder($reportObject, [int]$backgroundColor) {
        $border = $reportObject.Border.Clone($true)
        $border.LeftLineStyle = $singleLine
        $border.RightLineStyle = $singleLine
        $border.TopLineStyle = $singleLine
        $border.BottomLineStyle = $singleLine
        $border.BackgroundColor = $backgroundColor
        $reportObject.Border = $border
    }

    function Set-ObjectAlignment($reportObject) {
        $format = $reportObject.Format.Clone($true)
        $format.HorizontalAlignment = $center
        $format.VerticalAlignment = $verticalCenter
        $format.EnableCanGrow = $true
        $reportObject.Format = $format
    }

    function Add-TextObject(
        [string]$name,
        [string]$text,
        [int]$left,
        [int]$top,
        [int]$width,
        [int]$height,
        $section,
        [bool]$withBorder = $true,
        [int]$backgroundColor = $white) {
        $textObject = $labelTemplate.Clone($true)
        $textObject.Name = $name
        $textObject.Left = $left
        $textObject.Top = $top
        $textObject.Width = $width
        $textObject.Height = $height
        $textObject.Paragraphs[0].ParagraphElements[0].Text = $text
        Set-ObjectAlignment $textObject
        if ($withBorder) {
            Set-ObjectBorder $textObject $backgroundColor
        }
        $objectController.Add($textObject, $section, $section.ReportObjects.Count)
    }

    function Add-FieldObject(
        [string]$name,
        [string]$fieldName,
        [int]$left,
        [int]$top,
        [int]$width,
        [int]$height,
        $section,
        [int]$backgroundColor = $yellow) {
        $formulaName = '{MedicalFitnessReport.' + $fieldName + '}'
        $dataField = $clientDocument.DataDefController.FindFieldByFormulaForm($formulaName)
        if ($null -eq $dataField) {
            throw "Crystal field $formulaName was not found after the schema refresh."
        }
        # Crystal does not render a database field object for NULL values.
        # Keep a backing cell so empty fields retain their border and fill.
        Add-TextObject ('box' + $name) ' ' $left $top $width $height $section $true $backgroundColor
        $fieldObject = $fieldTemplate.Clone($true)
        $fieldObject.Name = $name
        $fieldObject.DataSource = $formulaName
        $fieldObject.DataSourceName = $formulaName
        $fieldObject.FieldValueType = $dataField.Type
        $fieldObject.Left = $left
        $fieldObject.Top = $top
        $fieldObject.Width = $width
        $fieldObject.Height = $height
        Set-ObjectAlignment $fieldObject
        Set-ObjectBorder $fieldObject $backgroundColor
        $objectController.Add($fieldObject, $section, $section.ReportObjects.Count)
    }

    function Add-ExamPair(
        [string]$objectPrefix,
        [string]$label,
        [string]$fieldName,
        [int]$left,
        [int]$top) {
        Add-TextObject ('lbl' + $objectPrefix) $label $left $top 1850 600 $generalSection
        Add-FieldObject ('fld' + $objectPrefix) $fieldName ($left + 1850) $top 1850 600 $generalSection
    }

    Add-TextObject 'lblCompanyName' 'Company Name' 225 25 1600 550 $patientAdditionalSection
    Add-FieldObject 'fldCompanyName' 'CompanyName' 1825 25 5550 550 $patientAdditionalSection $white
    Add-TextObject 'lblPassportNo' 'Passport No.' 7375 25 1800 550 $patientAdditionalSection
    Add-FieldObject 'fldPassportNo' 'PassportNo' 9175 25 2150 550 $patientAdditionalSection $white

    $title = $titleTemplate.Clone($true)
    $title.Name = 'txtGeneralMedicalExaminationTitle'
    $title.Left = 225
    $title.Top = 0
    $title.Width = 11100
    $title.Height = 360
    $title.Paragraphs[0].ParagraphElements[0].Text = 'General Medical Examination / ' + (Get-Utf8Text '2KfZhNmB2K3YtSDYp9mE2LfYqNmKINin2YTYudin2YU=')
    Set-ObjectAlignment $title
    $objectController.Add($title, $generalSection, $generalSection.ReportObjects.Count)

    Add-ExamPair 'ExamTemperature' ('Temp / ' + (Get-Utf8Text '2K/Ysdis2Kkg2KfZhNit2LHYp9ix2Kk=')) 'ExamTemperature' 225 400
    Add-ExamPair 'ExamBloodPressure' ('B.P / ' + (Get-Utf8Text '2LbYuti3INin2YTYr9mF')) 'ExamBloodPressure' 3925 400
    Add-ExamPair 'ExamPulse' ('Pulse / ' + (Get-Utf8Text '2KfZhNmG2KjYtg==')) 'ExamPulse' 7625 400

    Add-TextObject 'lblExamRespiratorySystem' ('Resp System / ' + (Get-Utf8Text '2YHYrdi1INin2YTYrNmH2KfYsiDYp9mE2KrZhtmB2LPZig==')) 225 1000 1850 600 $generalSection
    Add-FieldObject 'fldExamRespiratorySystem' 'ExamRespiratorySystem' 2075 1000 3700 600 $generalSection
    Add-TextObject 'lblExamCardiovascularSystem' ('CVS / ' + (Get-Utf8Text '2YHYrdi1INin2YTZgtmE2Kg=')) 5775 1000 1850 600 $generalSection
    Add-FieldObject 'fldExamCardiovascularSystem' 'ExamCardiovascularSystem' 7625 1000 3700 600 $generalSection

    Add-TextObject 'lblExamNervousSystem' ('Nervous System / ' + (Get-Utf8Text '2YHYrdi1INin2YTYrNmH2KfYsiDYp9mE2LnYtdio2Yo=')) 225 1600 1850 600 $generalSection
    Add-FieldObject 'fldExamNervousSystem' 'ExamNervousSystem' 2075 1600 3700 600 $generalSection
    Add-TextObject 'lblExamAbdomen' ('Abdomen / ' + (Get-Utf8Text '2KfZhNmB2K3YtSDYp9mE2KjYp9i32YbZig==')) 5775 1600 1850 600 $generalSection
    Add-FieldObject 'fldExamAbdomen' 'ExamAbdomen' 7625 1600 3700 600 $generalSection

    Add-ExamPair 'ExamWeight' ('Weight / ' + (Get-Utf8Text '2KfZhNmI2LLZhg==')) 'ExamWeight' 225 2200
    Add-ExamPair 'ExamHeight' ('Height / ' + (Get-Utf8Text '2KfZhNi32YjZhA==')) 'ExamHeight' 3925 2200
    Add-ExamPair 'ExamExtremities' ('Extremities / ' + (Get-Utf8Text '2YHYrdi1INin2YTYo9i32LHYp9mB')) 'ExamExtremities' 7625 2200

    Add-FieldObject 'fldExamChestXRay' 'ExamChestXRay' 225 2800 7400 600 $generalSection
    Add-TextObject 'lblExamChestXRay' ('Chest X-ray / ' + (Get-Utf8Text '2KfZhNij2LTYudipINin2YTYtdiv2LHZitip')) 7625 2800 3700 600 $generalSection

    Add-ExamPair 'ExamRightEye' ('Right Eye / ' + (Get-Utf8Text '2KfZhNi52YrZhiDYp9mE2YrZhdmG2Yk=')) 'ExamRightEye' 225 3400
    Add-ExamPair 'ExamLeftEye' ('Left Eye / ' + (Get-Utf8Text '2KfZhNi52YrZhiDYp9mE2YrYs9ix2Yk=')) 'ExamLeftEye' 3925 3400
    Add-TextObject 'lblEyeExamination' ('Eye examination / ' + (Get-Utf8Text '2YHYrdi1INin2YTYudmK2YjZhg==')) 7625 3400 3700 600 $generalSection

    Add-ExamPair 'ExamRightEar' ('Right Ear / ' + (Get-Utf8Text '2KfZhNij2LDZhiDYp9mE2YrZhdmG2Yk=')) 'ExamRightEar' 225 4000
    Add-ExamPair 'ExamLeftEar' ('Left Ear / ' + (Get-Utf8Text '2KfZhNij2LDZhiDYp9mE2YrYs9ix2Yk=')) 'ExamLeftEar' 3925 4000
    Add-TextObject 'lblEarExamination' ('Ear examination / ' + (Get-Utf8Text '2YHYrdi1INin2YTYo9iw2YY=')) 7625 4000 3700 600 $generalSection

    # Recreate the repeating result-table headings in their own page-header section.
    Add-TextObject 'txtResultHeadingTest' 'Test Name' 225 35 6924 320 $headingSection
    Add-TextObject 'txtResultHeadingFit' 'Fit' 7149 35 575 320 $headingSection
    Add-TextObject 'txtResultHeadingUnfit' 'Unfit' 7724 35 715 320 $headingSection
    Add-TextObject 'txtResultHeadingRemarks' 'Remarks' 8439 35 2986 320 $headingSection

    'Crystal update: saving the new layout...'
    $document.SaveAs($updatedReportPath)
    'Crystal update: layout saved.'
} finally {
    $document.Close()
    $document.Dispose()
}

$verificationDocument = New-Object CrystalDecisions.CrystalReports.Engine.ReportDocument
try {
    'Crystal update: verifying the saved report...'
    $verificationDocument.Load($updatedReportPath)
    $fieldNames = @(
        'CompanyName', 'PassportNo',
        'ExamTemperature', 'ExamBloodPressure', 'ExamPulse', 'ExamRespiratorySystem',
        'ExamCardiovascularSystem', 'ExamNervousSystem', 'ExamAbdomen', 'ExamWeight',
        'ExamHeight', 'ExamExtremities', 'ExamChestXRay', 'ExamRightEye', 'ExamLeftEye',
        'ExamRightEar', 'ExamLeftEar')
    foreach ($fieldName in $fieldNames) {
        $formulaName = '{MedicalFitnessReport.' + $fieldName + '}'
        if ($null -eq $verificationDocument.ReportClientDocument.DataDefController.FindFieldByFormulaForm($formulaName)) {
            throw ('The saved Crystal report is missing ' + $formulaName + '.')
        }
    }
    $generalObjects = $verificationDocument.ReportClientDocument.ReportDefController.ReportObjectController.GetAllReportObjects() |
        Where-Object Name -Like 'fldExam*'
    $generalObjectCount = @($generalObjects).Count
    if ($generalObjectCount -ne 15) {
        throw ('Expected 15 examination fields in the Crystal layout; found ' + $generalObjectCount + '.')
    }
    'Crystal update: verification complete.'
} finally {
    $verificationDocument.Close()
    $verificationDocument.Dispose()
}

Copy-Item -LiteralPath $updatedReportPath -Destination $reportPath -Force
'Updated Crystal report: ' + $reportPath
