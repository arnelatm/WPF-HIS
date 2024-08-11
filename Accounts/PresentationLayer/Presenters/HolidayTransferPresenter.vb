Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports Autofac.Core

Namespace PresentationLayer.Presenters

    Public Class HolidayTransferPresenter(Of TM As New)
        Inherits AccountsPresenter(Of IHolidayTransferView, HolidayTransferModel)
        'Implements ISubscriber(Of ViewButtonClicked)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private _htItemService
        Private ReadOnly _holidayService As New AccountsService("Holiday")

        Public Sub New(view As IHolidayTransferView)
            MyBase.New(view)
            Service = New AccountsService("HolidayTransfer")
            TableName = "HolidayTransfer"
            SortOrderKey = "IdNo"
            WithTreeView = False
            CreateDataTable(DtInsertTable, {{"EmployeeIdNo", GetType(Integer)},
                                            {"HolidayTransferIdNo", GetType(Integer)}
                                           })

            CreateDataTable(DtUpdateTable, {{"EmployeeIdNo", GetType(Integer)},
                                            {"HolidayTransferIdNo", GetType(Integer)},
                                            {"IdNo", GetType(Integer)}
                                           })
            _htItemService = New AccountsService("HolidayTransferItem")
            AddHandler view.HolidayIdChangedEvent, AddressOf OnHolidayIdChangedEvent
        End Sub

        Public Property ChangesMadeInHolidayTransfer As Boolean = False

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"Holiday_View", "HolidayIdNo", "IdNo,HolidayName,HolidayCode", Nothing, "HolidayName"},
                                    New Object() {"User", "EnteredBy", Nothing, Nothing, "UserName"}})
            MakeVarDataSources({New Object() {"Employee", "EmployeeList", Nothing, "Active=1"}})
        End Sub

        ''' <summary>
        '''     Displays list of  Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIdNo id to display.</param>
        Public Overloads Sub Display(journalIdNo As Int32)
            View.HolidayTransferItems = Service.GetRecordsWithGroupIdNo(Of HolidayTransferItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            View.EnteredBy = GlobalVariables.UserIdNo
        End Sub

        Private Sub GetUnTransferredHolidays()
            Dim holidayTransferItems As New List(Of HolidayTransferItemModel)
            Dim activeEmployees As DataSet = Service.GetDataSet("spGetUnTransferredHolidays", {"HolidayIdNo", View.HolidayIdNo})
            Dim employeeIdNo As Int32
            For Each item As HolidayTransferItemView In View.HolidayTransferItems
                If item.Transfer Then
                    Dim cHt = New HolidayTransferItemModel
                    cHt.EmployeeIdNo = item.EmployeeIdNo
                    cHt.Transfer = item.Transfer
                    holidayTransferItems.Add(cHt)
                End If
            Next
            For Each row As DataRow In activeEmployees.Tables(0).Rows()
                employeeIdNo = row("IdNo")
                Dim currentItem As HolidayTransferItemModel = holidayTransferItems.Find(Function(cc As HolidayTransferItemModel) cc.EmployeeIdNo = employeeIdNo)
                If currentItem Is Nothing Then
                    Dim cHt = New HolidayTransferItemModel
                    cHt.EmployeeIdNo = employeeIdNo
                    holidayTransferItems.Add(cHt)
                End If
            Next
            View.EnteredBy = GlobalVariables.UserIdNo
            GlobalFunctions.ManualMap(holidayTransferItems, View.HolidayTransferItems)
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                CustomObjToDataTables(View.HolidayTransferItems, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf ItemFilter, "IdNo", "")
            End If
        End Sub

        Private Sub FillData(ByRef itemDataView As Object, ByRef workRow As DataRow)
            workRow("EmployeeIdNo") = itemDataView.EmployeeIdNo
            workRow("HolidayTransferIdNo") = View.IdNo
        End Sub

        Public Overloads Function Save(ByRef dtInsert As DataTable, ByRef dtUpdate As DataTable,
                                       journalIdNo As Int32)
            Dim insertReturnValue
            Dim updateReturnValue
            Dim retVal
            updateReturnValue = _htItemService.DelUpdateTvp(dtUpdate, journalIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = _htItemService.InsertTvp(dtInsert)
                If insertReturnValue >= 0 Then
                    retVal = updateReturnValue + insertReturnValue
                Else
                    retVal = insertReturnValue
                End If
            Else
                retVal = updateReturnValue
            End If
            Return retVal
        End Function

        Public Function ItemFilter(ByVal obj As Object) As Boolean
            If Not obj.Transfer Then
                Return False
            End If
            Return True
        End Function

        Public Sub SaveChildren(ByRef retVal As Integer) Handles MyBase.RecordAddedSuccessfully, MyBase.RecordUpdatedSuccessfully
            Dim passedValue As Integer = retVal
            UpdateChildData(_htItemService, DtUpdateTable, DtInsertTable, passedValue, "HolidayTransferIdNo")
        End Sub

        Public Sub OnHolidayIdChangedEvent()
            Dim holidayModel As New HolidayModel
            holidayModel = _holidayService.GetRecordByIdNo(Of HolidayModel)(View.HolidayIdNo)
            'View.HolidayDate = holidayModel.HolidayDate
            If EditMode Or AddMode Then
                GetUnTransferredHolidays()
            End If
        End Sub

        'Protected Function UpdateChildData(updateTable As DataTable, insertTable As DataTable, passedValue As Integer, parentIdFieldName As String) As Integer
        '    Dim retVal As Integer
        '    Dim updateReturnValue As Object
        '    Dim insertReturnValue As Object
        '    Dim parentIdNo As Integer
        '    If AddMode Then
        '        parentIdNo = passedValue
        '    Else
        '        parentIdNo = Invoker.GetProperty(View, IdFieldName)
        '    End If
        '    updateReturnValue = childDataService.DelUpdateTvp(updateTable, parentIdNo)
        '    If updateReturnValue >= 0 AndAlso insertTable.Rows.Count > 0 Then
        '        If passedValue <> 0 Then
        '            For Each row As DataRow In insertTable.Rows
        '                row.Item(parentIdFieldName) = parentIdNo
        '            Next
        '        End If
        '        insertReturnValue = childDataService.InsertTvp(insertTable)
        '        If insertReturnValue >= 0 Then
        '            retVal = updateReturnValue + insertReturnValue
        '        Else
        '            retVal = insertReturnValue
        '        End If
        '    Else
        '        retVal = updateReturnValue
        '    End If
        '    Return retVal
        'End Function

    End Class

End Namespace