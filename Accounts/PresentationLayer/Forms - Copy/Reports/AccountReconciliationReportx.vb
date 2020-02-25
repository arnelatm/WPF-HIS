Imports AATM.Libraries.BaseFormsLibrary

Namespace AATM.HIS.Accounts.PresentationLayer.Forms.Reports

    Public Class AccountReconciliationReport
        Inherits CrReportViewerForm

        Public Sub New(ByVal idNo As Integer)
            Report.Load("\\Ibn-server\isp\Accounts\Reports\Account Reconciliation Report.rpt")
            Report.SetParameterValue("ReconciliationNumber", idNo)
            Report.DataSourceConnections.Clear()
            Report.SetDatabaseLogon("iGroupAdmin", "igss@123", "IBN-SERVER", "ISPDATA")
            ProcessReport()
        End Sub

    End Class

End Namespace