Imports System.Threading
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.MessagingLibrary
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

    Public Class DepartmentPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDepartmentView, TM)

        Public ParentViewList As List(Of TM)

        Public Sub New(view As IDepartmentView)
            MyBase.New(view)
            Service = New CommonService("Department")
            TableName = "Department_View"
            TableBaseName = "Department"
            ParentFieldName = "ParentIdNo"
            TreeViewMainField = "DepartmentName"
            ParentFieldName = "ParentIdNo"
            TreeViewSecondaryField = "DepartmentCode"
            SortOrderKey = "SortKey"
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Department", "ParentIdNo")


            'Dim Task1, Task2 As Task
            'Task1 = Task.Factory.StartNew(Sub() Method1("Department", GetControlName("ParentIdNo")))
            ''Task1 = Task.Factory.StartNew(Sub() CreateDataSource("Department", "ParentIdNo"))
            'Task2 = Task.Factory.StartNew(Sub() Method1("RevCostCenter", GetControlName("RevCostCenterIdNo")))          
            'Task.WaitAll(Task1,Task2)

        End Sub

        Private Shared Sub Method1(ByVal Param1 As String, ByRef control As Control)
            Dim cd As New DataCreator()
            cd.CreateData(Param1, control)
        End Sub

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

    Public Class DataCreator
        'Public Sub New()
        '    Dim data As List(Of Lookup.LookupData)
        'End Sub

        Public Sub CreateData(dataTableName As String, ByRef control As Control)
            Dim lookupObj
            Dim data As List(Of Lookup.LookupData)
            Dim sv = New CommonService("Department")
            lookupObj = SetLookupObject(dataTableName, control)
            data = sv.GetLookup(lookupObj)
            Invoker.SetPropertyR(control, "DataSource", {data})
        End Sub

        Public Function SetLookupObject(dataTableName As String, ByRef control As Control, Optional dataFields As String() = Nothing, Optional sortKey As String = Nothing, Optional filter As String = Nothing) As Lookup
            Dim lookupObj As New Lookup(dataTableName)
            If dataFields IsNot Nothing Then
                lookupObj.FieldsToShow = dataFields
            End If
            If Not (sortKey Is Nothing OrElse sortKey = "") Then
                lookupObj.SortKey = sortKey
            End If
            'If Not (Filter() Is Nothing OrElse Filter() = "") Then
            '    lookupObj.FilterKey = Filter()
            'End If
            Return lookupObj
        End Function

    End Class

End Namespace