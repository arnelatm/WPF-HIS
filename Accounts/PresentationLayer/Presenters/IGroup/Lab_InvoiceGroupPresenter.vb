Imports System.IO
Imports System.Text.RegularExpressions
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Presenters

    Public Class Lab_InvoiceGroupPresenter(Of TM As New)
        Inherits CommonPresenter(Of ILab_InvoiceGroupView, TM)

        Protected DtLab_InvoiceDetailsUpdateTable As New DataTable
        Protected DtLab_InvoiceDetailsInsertTable As New DataTable

        Private ReadOnly _labInvoiceDetailsService As New AccountsService("Lab_InvoiceDetails")

        Public Sub New(itemView As ILab_InvoiceGroupView)
            MyBase.New(itemView)
            Service = New AccountsService("Lab_InvoiceGroup") ', Nothing ,Nothing, "IGROUPCLINIC")
            Service.SaveConnectionString()
            Service.SetConnectionString("IGROUPCLINIC")
            TableName = "Lab_InvoiceGroup"
            SortOrderKey = "SlNo"
            Service.RestoreConnectionString()
            WithTreeView = False
            'CreateDataTables()
            AddHandler View.RetrieveLabResultRequested, AddressOf RetrieveLabResult
            AddHandler View.SaveResultRequested, AddressOf SaveResult
        End Sub

        'Protected Sub CreateDataTables()
        '    CreateDataTable(DtLab_InvoiceDetailsUpdateTable, {{"SlNo", GetType(Decimal)},
        '                                     {"InvestigationID", GetType(String)},
        '                                     {"Diagnosis1", GetType(String)},
        '                                     {"Result1", GetType(String)},
        '                                     {"Suffix1", GetType(String)}
        '                                    })
        '    CreateDataTable(DtLab_InvoiceDetailsInsertTable,
        '           {{"Diagnosis1", GetType(String)},
        '            {"IdNo", GetType(Int32)},
        '            {"InvestigationID", GetType(String)},
        '            {"Result1", GetType(String)},
        '            {"SlNo", GetType(Decimal)},
        '            {"Suffix1", GetType(String)}})
        'End Sub

        'Private Sub PhoneFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
        '    workRow("SlNo") = itemDataView.AreaCode
        '    workRow("InvestigationID") = itemDataView.InvestigationID
        '    workRow("Diagnosis1") = itemDataView.Diagnosis1
        '    workRow("Result1") = itemDataView.Result1
        '    workRow("Suffix1") = itemDataView.Suffix1
        'End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_labInvoiceDetailsService, DtLab_InvoiceDetailsUpdateTable, DtLab_InvoiceDetailsInsertTable, passedValue, "Group_Key")
        End Sub

        Public Sub RetrieveLabResult()
            If View.InvoiceNoF Is Nothing Or View.InvoiceNoF = "" Then
                MessageBox.Show("Sorry you must enter the invoice number to be retrieved.")
                BlankOutResults()
            Else
                If RetrieveCbcMachineResults() Then
                    RetrieveCurrentSystemResult()
                    If View.LabInvoiceDetails.Count() <> 0 Then
                        MessageBox.Show("Data successfully retrieved!")
                    Else
                        MessageBox.Show("No CBC result generated for that invoice number. Please generate first a blank CBC Report before attempting to transfer result!")
                        View.LabInvoiceDetails.Clear()
                    End If
                End If
            End If
        End Sub

        Private Sub BlankOutResults()
            EmptyResults()
        End Sub

        Private Function RetrieveCbcMachineResults()
            Dim retVal As Boolean = False
            
            Dim sFiles As String()
            Dim pattern As String = "*_" + View.InvoiceNoF + ".csv"
            Dim mySettings = AppSettings.Load()
            Dim filePath As String = IIf(mySettings.LaboratoryResultDirectory Is Nothing Or mySettings.LaboratoryResultDirectory="","\\laboratory5\drivec\NihonKohden",mySettings.LaboratoryResultDirectory)
            mySettings = Nothing

            View.InvoiceNo = Val(StripNonNumbers(View.InvoiceNoF))
            sFiles = Directory.GetFileSystemEntries(filePath, pattern)
            If sFiles.Length > 0 Then
                If CopyFileResultsToView(sFiles, filePath) Then
                    retVal = True
                End If
            End If
            If Not retVal Then
                BlankOutResults()
                MessageBox.Show("No result with that invoice number was found on [" + filePath + "]")
            End If
            Return retVal
        End Function

        Private Sub RetrieveCurrentSystemResult()
            'Dim invNo As Decimal
            'invNo = Val(View.InvoiceNoF)
            'View.InvoiceNo = invNo
            _idNo = Service.GetRecordFieldWith2KeyG(Of Decimal, String, Decimal)(View.InvoiceNo, "CBCNK", "Lab_InvoiceGroup", "InvoiceNo", "InvestigationId", "Trans_Key")
            Dim labInvoiceGroup As New Lab_InvoiceGroupModel
            labInvoiceGroup = Service.GetRecordByIdNo(Of Lab_InvoiceGroupModel)(_idNo)
            GlobalFUnctions.ManualMap(labInvoiceGroup, View)
            AssigValuesToDisplay()
        End Sub

        Private Function CopyFileResultsToView(sFiles() As String, filePath As String) As Boolean
            Dim success As Boolean
            Dim aFileResults(146) As String
            Dim aCBCResults(19) As String

            'sFiles = Folder.GetFiles(cFilePath + "*.csv",IO.SearchOption.AllDirectories)
            If sFiles.Count() = 1 Then
                GetResultOnFile(sFiles, aFileResults, aCBCResults)
                success = True
            ElseIf sFiles.Count() > 1 Then
                Messaging.Show("MsgMultiResultCBCFound")
                Dim cbcReportSelector As New CbcReportSelector(sFiles, filePath, View.InvoiceNo)
                Dim result = cbcReportSelector.ShowDialog()
                If result = DialogResult.OK Then
                    Dim cPatern = sFiles(cbcReportSelector.SelectedIndex).Substring(filePath.Length + 1)
                    Dim cFile = Directory.GetFileSystemEntries(filePath, cPatern)
                    GetResultOnFile(cFile, aFileResults, aCBCResults)
                    success = True
                Else
                    success = False
                End If
            Else
                success = False
            End If
            Return success
        End Function

        Private Sub GetResultOnFile(sFiles() As String, aFileResults() As String, aCBCResults() As String)
            Dim lineCount = File.ReadAllLines(sFiles(0)).Length
            Using file As New IO.StreamReader(sFiles(0))
                For i As Integer = 1 To 146
                    aFileResults(i) = file.ReadLine()
                Next
            End Using
            FileResultsToCbcResults(aFileResults, aCBCResults)
            View.PatientName = aFileResults(143)
            View.SexF = aFileResults(144)
            View.AgeF = aFileResults(146)
        End Sub

        Private Sub EmptyResults()
            Dim aCBCResults(19) As String
            For i As Integer = 1 To 19
                aCBCResults(i) = ""
            Next
            CbcResultsToView(aCBCResults)
            View.PatientName = ""
            View.Sex = ""
            View.Age = 0
            View.WbcNv = ""
            View.NENv = ""
            View.LyNv = ""
            View.MoNv = ""
            View.EoNv = ""
            View.BaNv = ""
            View.RbcNv = ""
            View.HgbNv = ""
            View.HctNv = ""
            View.McvNv = ""
            View.MchNv = ""
            View.MchcNv = ""
            View.RdwcvNv = ""
            View.RdwsdNv = ""
            View.PltNv = ""
            View.PctNv = ""
            View.MpvNv = ""
            View.PdwNv = ""
            View.Wbc = ""
            View.NE = ""
            View.Ly = ""
            View.Mo = ""
            View.Eo = ""
            View.Ba = ""
            View.Rbc = ""
            View.Hgb = ""
            View.Hct = ""
            View.Mcv = ""
            View.Mch = ""
            View.Mchc = ""
            View.Rdwcv = ""
            View.Rdwsd = ""
            View.Plt = ""
            View.Pct = ""
            View.Mpv = ""
            View.Pdw = ""
            View.WbcRNv = ""
            View.NeRNv = ""
            View.LyRNv = ""
            View.MoRNv = ""
            View.EoRNv = ""
            View.BaRNv = ""
            View.RbcRNv = ""
            View.HgbRNv = ""
            View.HctRNv = ""
            View.McvRNv = ""
            View.MchRNv = ""
            View.MchcRNv = ""
            View.RdwcvRNv = ""
            View.RdwsdRNv = ""
            View.PltRNv = ""
            View.PctRNv = ""
            View.MpvRNv = ""
            View.PdwRNv = ""
            View.WbcR = ""
            View.NeR = ""
            View.LyR = ""
            View.MoR = ""
            View.EoR = ""
            View.BaR = ""
            View.RbcR = ""
            View.HgbR = ""
            View.HctR = ""
            View.McvR = ""
            View.MchR = ""
            View.MchcR = ""
            View.RdwcvR = ""
            View.RdwsdR = ""
            View.PltR = ""
            View.PctR = ""
            View.MpvR = ""
            View.PdwR = ""
            View.Remarks = ""
            View.Status = 0
            View.InvoiceType = ""
            View.SampleNo = ""
            View.InvoiceDate = Nothing
            View.RegistrationNo = 0
            View.PatientNameEnglish = ""
            View.SexF = ""
            View.AgeF = ""
        End Sub

        Private Sub FileResultsToCbcResults(aFileResults() As String, aCBCResults() As String)
            aCBCResults(CBCEnum.Wbc) = aFileResults(15)
            aCBCResults(CBCEnum.NE) = aFileResults(16)
            aCBCResults(CBCEnum.LY) = aFileResults(17)
            aCBCResults(CBCEnum.MO) = aFileResults(18)
            aCBCResults(CBCEnum.EO) = aFileResults(19)
            aCBCResults(CBCEnum.BA) = aFileResults(20)
            aCBCResults(CBCEnum.Rbc) = aFileResults(26)
            aCBCResults(CBCEnum.Hgb) = aFileResults(27)
            aCBCResults(CBCEnum.Hct) = aFileResults(28)
            aCBCResults(CBCEnum.Mcv) = aFileResults(29)
            aCBCResults(CBCEnum.Mch) = aFileResults(30)
            aCBCResults(CBCEnum.Mchc) = aFileResults(31)
            aCBCResults(CBCEnum.Rdwcv) = aFileResults(32)
            aCBCResults(CBCEnum.Rdwsd) = aFileResults(49)
            aCBCResults(CBCEnum.Plt) = aFileResults(33)
            aCBCResults(CBCEnum.Pct) = aFileResults(34)
            aCBCResults(CBCEnum.Mpv) = aFileResults(35)
            aCBCResults(CBCEnum.Pdw) = aFileResults(36)
            CbcResultsToView(aCBCResults)
        End Sub

        Private Function StripNonNumbers(value As String)
            Dim num As String
            If value Is Nothing Then
                Return Nothing
            Else
                num = Regex.Replace(value, "[^0-9.]", "")
            End If
            Return num
        End Function

        Private Function StripAsterisk(value As String)
            If value Is Nothing Then
                Return Nothing
            End If
            Dim num As String
            num = value.Replace("*", String.Empty)
            Return num
        End Function

        Private Function RemoveDigits(ByVal value As String) As String
            If value Is Nothing Then
                Return Nothing
            End If
            Dim txt As String
            txt = Regex.Replace(value, "\d", "")
            txt = txt.Replace(".", String.Empty)
            Return txt
        End Function

        Private Function Transform(ByVal value As String, suffix As String) As String
            If value Is Nothing Then
                Return Nothing
            End If
            Dim retVal As String
            retVal = StripNonNumbers(value)
            retVal = (retVal + suffix).PadRight(25, " ")
            retVal = retVal + RemoveDigits(value)
            retVal = Trim(StripAsterisk(retVal))
            Return retVal
        End Function

        Private Sub CbcResultsToView(aCBCResults() As String)
            View.Wbc = Transform(aCBCResults(CBCEnum.Wbc), " 10^3/µL")
            View.NE = Transform(aCBCResults(CBCEnum.NE), "%")
            View.Ly = Transform(aCBCResults(CBCEnum.LY), "%")
            View.Mo = Transform(aCBCResults(CBCEnum.MO), "%")
            View.Eo = Transform(aCBCResults(CBCEnum.EO), "%")
            View.Ba = Transform(aCBCResults(CBCEnum.BA), "%")
            View.Rbc = Transform(aCBCResults(CBCEnum.Rbc), " 10^6/µL")
            View.Hgb = Transform(aCBCResults(CBCEnum.Hgb), " g/dL")
            View.Hct = Transform(aCBCResults(CBCEnum.Hct), "%")
            View.Mcv = Transform(aCBCResults(CBCEnum.Mcv), " fL")
            View.Mch = Transform(aCBCResults(CBCEnum.Mch), " pg")
            View.Mchc = Transform(aCBCResults(CBCEnum.Mchc), " g/dL")
            View.Rdwcv = Transform(aCBCResults(CBCEnum.Rdwcv), "%")
            View.Rdwsd = Transform(aCBCResults(CBCEnum.Rdwsd), " fL")
            View.Plt = Transform(aCBCResults(CBCEnum.Plt), " 10^3/µL")
            View.Pct = Transform(aCBCResults(CBCEnum.Pct), "%")
            View.Mpv = Transform(aCBCResults(CBCEnum.Mpv), " fL")
            View.Pdw = Transform(aCBCResults(CBCEnum.Pdw), "%")
        End Sub

        Public Enum CBCEnum
            Wbc
            LY
            NE
            MO
            EO
            BA
            Rbc
            Hgb
            Hct
            Mcv
            Mch
            Mchc
            Rdwcv
            Rdwsd
            Plt
            Pct
            Mpv
            Pdw
        End Enum

        Private _idNo As Decimal

        Public Function SaveResult() As Int32
            Dim retVal As Int32
            Dim idNo As Decimal = Service.GetRecordFieldWith2KeyG(Of Decimal, String, Decimal)(View.InvoiceNo, "CBCNK", "Lab_InvoiceGroup", "InvoiceNo", "InvestigationId", "Trans_Key")
            retVal = UpdateLabInvoiceGroup()
            If retVal >= 0 Then
                retVal = UpdateLabInvoiceDetails()
            End If
            If retVal >= 0 Then
                RetrieveCurrentSystemResult()
                MessageBox.Show("CBC Results successfully transferred!")
            End If
            Return retVal
        End Function

        Private Function UpdateLabInvoiceDetails() As Int32
            Dim retVal As Int32
            retVal = Service.DataDao.UpdateRecordWithKey(Of Decimal, String)("Lab_InvoiceGroup", "Trans_Key", _idNo, "Remarks", View.Remarks)
            If retVal >= 0 Then
                retVal = Service.DataDao.UpdateRecordWithKey(Of Decimal, String)("Lab_InvoiceGroup", "Trans_Key", _idNo, "Remark", View.Remarks)
            End If
            If retVal >= 0 Then
                retVal = Service.DataDao.UpdateRecordWithKey(Of Decimal, Integer)("Lab_InvoiceGroup", "Trans_Key", _idNo, "Status", 2)
            End If
            If retVal >= 0 Then
                View.Status = 2I
            End If
            Return retVal
        End Function

        Private Function UpdateLabInvoiceGroup() As Int32
            Dim retVal As Int32
            Dim labInvoiceGroup As New Lab_InvoiceGroupModel
            labInvoiceGroup = Service.GetRecordByIdNo(Of Lab_InvoiceGroupModel)(_idNo)
            DtLab_InvoiceDetailsUpdateTable.Clear()
            AddResult(View.Wbc, View.WbcNv, 1)
            AddResult(View.NE, View.NENv, 2)
            AddResult(View.Ly, View.LyNv, 3)
            AddResult(View.Mo, View.MoNv, 4)
            AddResult(View.Eo, View.EoNv, 5)
            AddResult(View.Ba, View.BaNv, 6)
            AddResult("", "", 7)
            AddResult(View.Rbc, View.RbcNv, 8)
            AddResult(View.Hgb, View.HgbNv, 9)
            AddResult(View.Hct, View.HctNv, 10)
            AddResult(View.Mcv, View.McvNv, 11)
            AddResult(View.Mch, View.MchNv, 12)
            AddResult(View.Mchc, View.MchcNv, 13)
            AddResult(View.Rdwcv, View.RdwcvNv, 14)
            AddResult(View.Rdwsd, View.RdwsdNv, 15)
            AddResult("", "", 16)
            AddResult(View.Plt, View.PltNv, 17)
            AddResult(View.Pct, View.PctNv, 18)
            AddResult(View.Mpv, View.MpvNv, 19)
            AddResult(View.Pdw, View.PdwNv, 20)
            Dim labInvoiceDetailsDao As New Lab_InvoiceDetailsDao()
            Dim labInvoiceDetailsModel = New List(Of Lab_InvoiceDetailsModel)
            Dim labInvoiceDetails = New List(Of Lab_InvoiceDetails)
            GlobalFUnctions.ManualMap(View.LabInvoiceDetails, labInvoiceDetailsModel)
            GlobalFUnctions.ManualMap(labInvoiceDetailsModel, labInvoiceDetails)
            retVal = labInvoiceDetailsDao.UpdateTable(Of Int32)(labInvoiceDetails, _idNo)
            Return retVal
        End Function

        Private Sub AddResult(result As String, normalValue As String, serialNo As Decimal)
            Dim item As New Lab_InvoiceDetailsView With {
                .Result1 = result,
                .Suffix1 = normalValue,
                .SlNo = serialNo
            }
            View.LabInvoiceDetails.Add(item)
        End Sub

        'Private Sub AddResult(result As String, normalValue As String, serialNo As Decimal)
        '    Dim R As DataRow = DtLab_InvoiceDetailsUpdateTable.NewRow
        '    R("Result1") = result
        '    R("Suffix1") = normalValue
        '    R("SlNo") = serialNo
        '    DtLab_InvoiceDetailsUpdateTable.Rows.Add(R)
        'End Sub

        'Private Sub OnBeforeSave() Handles MyBase.BeforeSave
        '    If View.ItemDetailsCode Is Nothing Or View.ItemDetailsCode = "" Then
        '        View.ItemDetailsCode = Service.GenerateCode(View.IdNo)
        '    End If
        'End Sub

        ''Public Function GenerateCode(idNo As Integer) As String Implements IDaoAutoCode2.GenerateCode
        ''    Return Service.UpdateCode("ItemDetails", idNo)
        ''End Function

        'Public Sub OnAfterSaveItemDetails() Handles Me.AfterSave
        '    Service.InsertRecord("StockPOsitionCurrent", {"BranchID", "Item_Code", "Batch", "Expiry", "WarehouseID", "PCSQty", "CashPrice", "CreditPrice", "CostPrice", "PurchaseNo", "TmpStock"},
        '                                                {"String", "String", "String", "DateTime", "String", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal", "Decimal"},
        '                                                {"01", View.ItemDetailsCode, "000", Now(), "01", 0, 0, 0, 0, 0, 0})
        'End Sub

        'Public Sub GetServerResults(invoiceNo As Integer)
        '    Dim cbcRetrievalDao As New CbcRetrievalDao
        '    Dim lab_InvoiceGroup As Lab_InvoiceGroup = cbcRetrievalDao.GetRecordByIdNo(invoiceNo)
        '    GlobalFUnctions.ManualMap(lab_InvoiceGroup, View)
        'End Sub

        Private Sub AssigValuesToDisplay()
            If View.LabInvoiceDetails IsNot Nothing Then
                For Each item In View.LabInvoiceDetails
                    Select Case item.SlNo
                        Case 1
                            View.WbcR = item.Result1
                            View.WbcRNv = item.Suffix1
                        Case 2
                            View.NeR = item.Result1
                            View.NeRNv = item.Suffix1
                        Case 3
                            View.LyR = item.Result1
                            View.LyRNv = item.Suffix1
                        Case 4
                            View.MoR = item.Result1
                            View.MoRNv = item.Suffix1
                        Case 5
                            View.EoR = item.Result1
                            View.EoRNv = item.Suffix1
                        Case 6
                            View.BaR = item.Result1
                            View.BaRNv = item.Suffix1
                        Case 8
                            View.RbcR = item.Result1
                            View.RbcRNv = item.Suffix1
                        Case 9
                            View.HgbR = item.Result1
                            View.HgbRNv = item.Suffix1
                        Case 10
                            View.HctR = item.Result1
                            View.HctRNv = item.Suffix1
                        Case 11
                            View.McvR = item.Result1
                            View.McvRNv = item.Suffix1
                        Case 12
                            View.MchR = item.Result1
                            View.MchRNv = item.Suffix1
                        Case 13
                            View.MchcR = item.Result1
                            View.MchcRNv = item.Suffix1
                        Case 14
                            View.RdwcvR = item.Result1
                            View.RdwcvRNv = item.Suffix1
                        Case 15
                            View.RdwsdR = item.Result1
                            View.RdwsdRNv = item.Suffix1
                        Case 17
                            View.PltR = item.Result1
                            View.PltRNv = item.Suffix1
                        Case 18
                            View.PctR = item.Result1
                            View.PctRNv = item.Suffix1
                        Case 19
                            View.MpvR = item.Result1
                            View.MpvRNv = item.Suffix1
                        Case 20
                            View.PdwR = item.Result1
                            View.PdwRNv = item.Suffix1
                    End Select
                Next
                SetNormalValues()
            End If
        End Sub

        Private Sub SetNormalValues()
            Dim nAge As Decimal
            Select Case View.AgeYMD
                Case "Y"
                    nAge = View.Age
                Case "M"
                    nAge = View.Age / 12
                Case = "D"
                    nAge = View.Age / 365.25
                Case = "W"
                    nAge = View.Age * 7 / 365.25
                Case Else
                    nAge = 12
            End Select
            Select Case nAge
                Case <= 1
                    View.WbcNv = "4.5 - 20.0 (10^3/µL)"
                    View.NENv = "37 - 70 %"
                    View.LyNv = "40 - 65 %"
                    View.MoNv = "0 - 12 %"
                    View.EoNv = "0 - 8 %"
                    View.BaNv = "0 - 3 %"

                    View.RbcNv = "3.9 - 5.9 (10^6 /µL)"
                    View.HgbNv = "14 - 18 g/dL"
                    View.HctNv = "32 - 55 %"
                    View.McvNv = "80 - 100 fL"
                    View.MchNv = "31 - 37 pg"
                    View.MchcNv = "31 - 35 g/dL"
                    View.RdwcvNv = "11.5 - 18.7 %"
                    View.RdwsdNv = "39 - 46 fL"

                    View.PltNv = "150 - 450 (10^3/µL)"
                    View.PctNv = "0.16 - 0.33 %"
                    View.MpvNv = "6.2 - 12.4 fL"
                    View.PdwNv = "12.5 - 17 %"
                Case <= 11
                    View.WbcNv = "4.5 - 13.0 (10^3/µL)"
                    View.NENv = "30 - 65 %"
                    View.LyNv = "20 - 65 %"
                    View.MoNv = "0 - 12 %"
                    View.EoNv = "0 - 8 %"
                    View.BaNv = "0 - 3 %"

                    View.RbcNv = "3.8 - 5.4 (10^6/µL)"
                    View.HgbNv = "11 - 16 g/dL"
                    View.HctNv = "32 - 42 %"
                    View.McvNv = "72 - 86.6 fL"
                    View.MchNv = "25 - 32 pg"
                    View.MchcNv = "32 - 36 g/dL"
                    View.RdwcvNv = "11.5 - 15.0 %"
                    View.RdwsdNv = "39 - 46 fL"

                    View.PltNv = "150 - 400 (10^3/µL)"
                    View.PctNv = "0.16 - 0.33"
                    View.MpvNv = "7 - 11 fL"
                    View.PdwNv = "15 - 17"

                Case >= 12
                    If View.Sex = "F" Then
                        View.WbcNv = "4 - 10 (10^3/µL)"
                        View.NENv = "37 - 65 %"
                        View.LyNv = "16 - 51 %"
                        View.MoNv = "0 - 12 %"
                        View.EoNv = "0 - 8 %"
                        View.BaNv = "0 - 3 %"

                        View.RbcNv = "3.85 - 5.2 (10^6/µL)"
                        View.HgbNv = "11.5 - 16 g/dL"
                        View.HctNv = "34.7 - 46 %"
                        View.McvNv = "80 - 97 fL"
                        View.MchNv = "26 - 34 pg"
                        View.MchcNv = "31 - 36 g/dL"
                        View.RdwcvNv = "11.5 - 15.0 %"
                        View.RdwsdNv = "39 - 46 fL"

                        View.PltNv = "150 - 350 (10^3/µL)"
                        View.PctNv = "0.16 - 0.33 %"
                        View.MpvNv = "6.5 - 12.4 fL"
                        View.PdwNv = "15 - 17 %"
                    Else
                        View.WbcNv = "4 - 10 (10^3/µL)"
                        View.NENv = "37 - 65 %"
                        View.LyNv = "16 - 51 %"
                        View.MoNv = "0 - 12 %"
                        View.EoNv = "0 - 8 %"
                        View.BaNv = "0 - 3 %"

                        View.RbcNv = "4.31 - 6.4 (10^6/µL)"
                        View.HgbNv = "13.6 - 18.0 g/dL"
                        View.HctNv = "39.8 - 52.0 %"
                        View.McvNv = "80 - 97 fL"
                        View.MchNv = "26 - 34 pg"
                        View.MchcNv = "31 - 36 g/dL"
                        View.RdwcvNv = "11.5 - 15.0 %"
                        View.RdwsdNv = "39 - 46 fL"

                        View.PltNv = "150 - 350 (10^3/µL)"
                        View.PctNv = "0.16 - 0.33 %"
                        View.MpvNv = "6.5 - 12.4 fL"
                        View.PdwNv = "15 - 17 %"
                    End If
            End Select
        End Sub

    End Class

End Namespace