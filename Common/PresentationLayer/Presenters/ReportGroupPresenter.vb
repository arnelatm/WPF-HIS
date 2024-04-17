Imports System.Globalization
Imports AATM.Common.BusinessLayer
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class ReportGroupPresenter(Of TM As New)
        Inherits CommonPresenter(Of IReportGroupView, TM)

        Public Sub New(view As IReportGroupView)
            MyBase.New(view)
            Service = New CommonService("ReportGroup")
            TableName = "ReportGroup"
            WithTreeView = False
            SortOrderKey = "ReportGroupName"
        End Sub

        'Protected Overrides Sub CreateDataSources()
        '    MakeControlDataSources({New Object() {"Supplier", "SupplierIdNo", Nothing, Nothing},
        '                            New Object() {"Product", "ProductIdNo", Nothing, "BranchIdNo=" & GlobalVariables.BranchIdNo.ToString()}})
        'End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            If CheckDependentRecords(Of Int32)(View.IdNo, "SecurityReportAccess", "ReportGroupIdNo") Then
                Return True
            End If
            Return False
        End Function

    End Class

End Namespace