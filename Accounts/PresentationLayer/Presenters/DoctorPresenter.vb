Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters

Namespace PresentationLayer.Presenters

    Public Class DoctorPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDoctorVIew, TM)

        Public Sub New(itemView As IDoctorVIew)
            MyBase.New(itemView)
            Service = New AccountsService("Doctor")
            TableBaseName = "Doctor"
            TableName = "Doctor_View"
            TreeViewMainField = "DoctorName"
            SortOrderKey = "DoctorName"
        End Sub

        Protected Overrides Sub CreateDataSources()
            MakeControlDataSources({New Object() {"Employee", "EmployeeIdNo", Nothing, Nothing}})
            CreateDataSourceGroupCodeThread({"SpecialtyIdNo"})
            'CreateDataSourceGroupCodeThread("SpecialtyIdNo", $"DRSP")
        End Sub

        Protected Overrides Function DependentRecordExist(Optional ByVal warn As Boolean = True) As Boolean
            Dim returnValue As Boolean = False
            'If CheckDependentRecords(Of Int32)(View.IdNo, "DoctorAccount", "DoctorIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Supplier", "DoctorIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Customer", "DoctorIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "Employee", "DoctorIdNo") Then
            '    Return True
            'ElseIf CheckDependentRecords(Of Int32)(View.IdNo, "PensionProvider", "DoctorIdNo") Then
            '    Return True
            'End If
            Return False
        End Function

    End Class

End Namespace