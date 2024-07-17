' Category business object
' ** Enterprise Design Pattern: Domain Model, Identity Field
Imports System.Globalization
Imports AATM.Libraries.CrystalReportsHelper.CrystalReportPrinter
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public MustInherit Class CommonPresenter(Of TV As IView, TM As New)
        Inherits Presenter(Of TV, TM)

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(itemView As IView)
            MyBase.New(itemView)
        End Sub

        Public Overrides Sub GoAddRecord()
            MyBase.GoAddRecord()
            MakeDefaultValues()
        End Sub

    End Class

    Public MustInherit Class CommonPresenterNew(Of TV As IViewNew, TM As New)
        Inherits PresenterB(Of TV, TM)

        Protected Sub New()
            MyBase.New()
        End Sub

        Protected Sub New(itemView As IViewNew)
            MyBase.New(itemView)
        End Sub

        'Protected Function PrintReport(reportFileName As String, dataBaseConnectionName As String, formCulture As CultureInfo, reportArgs As CrPrintableArgs)
        '    Dim reportPrinter As New AATM.Common.ReportPrinter(reportFileName, dataBaseConnectionName, formCulture, reportArgs)
        '    reportPrinter.ShowReport()
        'End Function

    End Class



End Namespace