Imports System.IO
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.DataLayer
Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class Lab_InvoiceGroupPresenter(Of TM As New)
        Inherits CommonPresenterNew(Of ILab_InvoiceGroupView, TM)

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
            CreateDataTables()
            AddHandler View.RetrieveLabResultRequested, AddressOf RetrievelabResult
            AddHandler View.SaveResultRequested, AddressOf SaveResult
        End Sub

        Protected Sub CreateDataTables()
            CreateDataTable(DtLab_InvoiceDetailsUpdateTable, {{"SlNo", GetType(Decimal)},
                                             {"InvestigationID", GetType(String)},
                                             {"Diagnosis1", GetType(String)},
                                             {"Result1", GetType(String)},
                                             {"Suffix1", GetType(String)}
                                            })
            CreateDataTable(DtLab_InvoiceDetailsInsertTable,
                   {{"Diagnosis1", GetType(String)},
                    {"IdNo", GetType(Int32)},
                    {"InvestigationID", GetType(String)},
                    {"Result1", GetType(String)},
                    {"SlNo", GetType(Decimal)},
                    {"Suffix1", GetType(String)}})
        End Sub

        Private Sub PhoneFillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("SlNo") = itemDataView.AreaCode
            workRow("InvestigationID") = itemDataView.InvestigationID
            workRow("Diagnosis1") = itemDataView.Diagnosis1
            workRow("Result1") = itemDataView.Result1
            workRow("Suffix1") = itemDataView.Suffix1
        End Sub

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            retVal = UpdateChildData(_labInvoiceDetailsService, DtLab_InvoiceDetailsUpdateTable, DtLab_InvoiceDetailsInsertTable, passedValue, "Group_Key")
        End Sub

        Public Sub RetrieveLabResult()
            _idNo = Service.GetRecordFieldWith2KeyG(Of Decimal, String, Decimal)(View.InvoiceNo, "CBCNK", "Lab_InvoiceGroup", "InvoiceNo", "InvestigationId", "Trans_Key")
            'Dim labInvoiceGroupDao = New Lab_InvoiceGroupDao

            Dim labInvoiceGroup As New Lab_InvoiceGroupModel
            labInvoiceGroup = Service.GetRecordByIdNo(Of Lab_InvoiceGroupModel)(_idNo)
            GlobalVariables.Mapper.Map(labInvoiceGroup, View)
        End Sub

        Private _idNo As Decimal

        Public Sub SaveResult()

            Dim idNo As Decimal = Service.GetRecordFieldWith2KeyG(Of Decimal, String, Decimal)(View.InvoiceNo, "CBCNK", "Lab_InvoiceGroup", "InvoiceNo", "InvestigationId", "Trans_Key")
            'Dim labInvoiceGroupDao = New Lab_InvoiceGroupDao
            Dim labInvoiceGroup As New Lab_InvoiceGroupModel
            labInvoiceGroup = Service.GetRecordByIdNo(Of Lab_InvoiceGroupModel)(idNo)
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
            Service.DataDao.UpdateTable(DtLab_InvoiceDetailsUpdateTable, _idNo)
            Service.DataDao.UpdateRecordWithKey(Of Decimal, String)("Lab_InvoiceGroup", "Trans_Key", _idNo, "Remarks", View.Remarks) 
        End Sub

        Private Sub AddResult(result As String, normalValue As String, serialNo As Decimal)
            Dim R As DataRow = DtLab_InvoiceDetailsUpdateTable.NewRow
            R("Result1") = result
            R("Suffix1") = normalValue
            R("SlNo") = serialNo
            DtLab_InvoiceDetailsUpdateTable.Rows.Add(R)
        End Sub

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
        '    GlobalVariables.Mapper.Map(lab_InvoiceGroup, View)
        'End Sub

    End Class

End Namespace