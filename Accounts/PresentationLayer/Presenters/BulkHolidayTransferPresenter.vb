Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Presenters

    Public Class HolidayTransferPresenter(Of TM As New)
        Inherits AccountsPresenterNew(Of IHolidayTransferView, HolidayTransferModel)

        Protected DtInsertTable As New DataTable
        Protected DtUpdateTable As New DataTable
        Private _htItemService

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
                                            {"IdNo", GetType(Int32)}
                                           })
            _htItemService = New AccountsService("HolidayTransferItem")
        End Sub

        Public Property ChangesMadeInHolidayTransfer As Boolean = False

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Holiday", "HolidayIdNo", {"IdNo", "Description"}, "DateStart", Nothing)
            CreateDataSource("User", "AppliedBy", {"IdNo", "UserName"})
            CreateLookupData("Employee", "EmployeeList", "Active=1")
        End Sub

        ''' <summary>
        '''     Displays list of  Journal Items.
        ''' </summary>
        ''' <param name="journalIdNo">JournalIdNo id to display.</param>
        Public Overloads Sub Display(journalIdNo As Int32)
            View.HolidayTransferItems = Service.GetRecordsWithGroupIdNo(Of HolidayTransferItemModel)(journalIdNo, "Sequence")
        End Sub

        Public Sub OnNewRecordInitialized() Handles MyBase.NewRecordInitialized
            Dim holidayTransferItems As New List(Of HolidayTransferItemModel)
            Dim activeEmployees = Service.GetRecords("Employee", "EmployeeName", {"IdNo"}, "Active=1")
            For Each item In activeEmployees
                Dim cHt = New HolidayTransferItemModel
                cHt.EmployeeIdNo = item
                holidayTransferItems.Add(cHt)
            Next
            View.AppliedBy = GlobalVariables.UserIdNo
            GlobalVariables.Mapper.Map(holidayTransferItems, View.HolidayTransferItems)
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If Not CancelSave Then
                ViewToDataTables(View.HolidayTransferItems, DtInsertTable, DtUpdateTable, AddressOf FillData, AddressOf ItemFilter, "IdNo", "")
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
            updateReturnValue = Service.DelUpdateTvp(dtUpdate, journalIdNo)
            If updateReturnValue >= 0 AndAlso dtInsert.Rows.Count > 0 Then
                insertReturnValue = Service.InsertTvp(dtInsert)
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
            UpdateChildData(Service, DtUpdateTable, DtInsertTable, passedValue, "HolidayTransferIdNo")
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