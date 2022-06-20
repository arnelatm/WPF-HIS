Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.DataLayer
Imports AATM.DataLayer.AdoNet

Namespace DataLayer.AdoNet
    ' Data access object for EmployeeIdPrinting
    ' ** DAO Pattern

    Public Class EmployeeIdPrintingDao
        Inherits AccountsDao
        Implements IDaoChild(Of EmployeeIdPrinting)

        Private ReadOnly _db As New Db()
        Protected DboTvpInsertName As String = "InsertEmployeeIdPrintingTvp"

        Public Sub New()
        End Sub

        Public Function InsertTvp(ByRef tvpTable As DataTable) As Integer _
            Implements IDaoChild(Of EmployeeIdPrinting).InsertTvp
            Return _db.InsertTvp(DboTvpInsertName, tvpTable)
        End Function

        Public Function GetRecordsWithGroupIdNo(idNo As Object, Optional sortExpression As Object = Nothing) As List(Of EmployeeIdPrinting) Implements IDaoChild(Of EmployeeIdPrinting).GetRecordsWithGroupIdNo
            Throw New NotImplementedException()
        End Function

        Public Function DelUpdateTvp(ByRef tvpTable As DataTable, groupIdNo As Integer) As Integer Implements IDaoChild(Of EmployeeIdPrinting).DelUpdateTvp
            Throw New NotImplementedException()
        End Function

    End Class

End Namespace