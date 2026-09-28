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
            MakeControlDataSources({New Object() {"Department", "ParentIdNo"},
                                    New Object() {"RevCostCenter", "RevCostCenterIdNo"}})
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim hasDependents =
                Service.CountRecordWithKey(Of Int16)("Employee", "DepartmentIdNo", View.IdNo) > 0 OrElse
                Service.CountRecordWithKey(Of Int16)("Department", "ParentIdNo", View.IdNo) > 0

            If hasDependents AndAlso warn Then
                Messaging.Show(True, "MsgDependentRecordExists", {"additionalMessage", ""})
            End If

            Return hasDependents
        End Function

        Private Sub RefreshParentDataSourceAfterAdd() Handles MyBase.AfterSave
            If AddMode Then
                MakeControlDataSources({New Object() {"Department", "ParentIdNo"}})
            End If
        End Sub

        Public Function GetAccountNameOfChild(idNoToSearch As Integer) As String
            Return Service.GetRecordFieldWithKey(idNoToSearch, "Department", "ParentIdNo", "DepartmentName")
        End Function

    End Class



End Namespace
