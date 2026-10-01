Imports System.Configuration
Imports System.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportAppServer.DataDefModel

Public Class ReportPrinter

    Public Report As New ReportDocument

    Public Property ReportFileName As String

    Protected Sub New(ConnectionStringName As String)
        Dim reportPaths As String
        Dim server As String
        Dim database As String

        Select Case ConnectionStringName
            Case $"ISPDATA"
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPaths")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator")
                database = ConfigurationManager.AppSettings.Get($"DATABASE")
                Report.Load(reportPaths & ReportFileName)
                If Report.DataSourceConnections.Count > 0 Then
                    Report.DataSourceConnections(0).SetConnection(server, database, True)
                End If
            Case $"IGROUP"
                reportPaths = ConfigurationManager.AppSettings.Get("ReportPathsIGroup")
                server = ConfigurationManager.AppSettings.Get("ServerTranslator")
                database = ConfigurationManager.AppSettings.Get($"DATABASEIGroup")
                Report.Load(reportPaths & ReportFileName)
                If Report.DataSourceConnections.Count > 0 Then
                    Report.DataSourceConnections(0).SetConnection(server, database, True)
                End If

        End Select

    End Sub

End Class
