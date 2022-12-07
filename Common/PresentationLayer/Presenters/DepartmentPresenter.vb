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
            'CreateDataSource("Department", "ParentIdNo")
            'CreateDataSource("RevCostCenter", "RevCostCenterIdNo")
            ', GetControlName("RevCostCenterIdNo")
            Try
                Dim Task1, Task2
                Task1 = Task(Of List(Of Lookup.LookupData)).Factory.StartNew(Function() Method1("Department"))
                Task2 = Task(Of List(Of Lookup.LookupData)).Factory.StartNew(Function() Method1("RevCostCenter"))
                'Task.WaitAll(Task1,Task2)

                Invoker.SetPropertyR(GetControlName("ParentIdNo"), "DataSource", Task1.Result)
                Invoker.SetPropertyR(GetControlName("RevCostCenterIdNo"), "DataSource", Task2.Result)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End Sub

        Private Shared Function Method1(ByVal Param1 As String)
            Dim cd As New DataCreator()
            Dim data As List(Of Lookup.LookupData) = cd.CreateData(Param1)
            Return data
        End Function

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class

    Public Class DataCreator
        'Public Sub New()
        '    Dim data As List(Of Lookup.LookupData)
        'End Sub

        Public Function CreateData(dataTableName As String) As List(Of Lookup.LookupData)
            Dim lookupObj
            Dim data As List(Of Lookup.LookupData)
            Dim sv = New CommonService("Department")
            lookupObj = SetLookupObject(dataTableName)
            data = sv.GetLookup(lookupObj)
            Return data
        End Function

        Public Function SetLookupObject(dataTableName As String, Optional dataFields As String() = Nothing, Optional sortKey As String = Nothing, Optional filter As String = Nothing) As Lookup
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