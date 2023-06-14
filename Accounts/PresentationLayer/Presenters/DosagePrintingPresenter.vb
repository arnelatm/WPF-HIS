Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Forms
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class DosagePrintingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosagePrintingView, TM)
        Implements ISubscriber(Of PrintCrEventArgs)

        'Implements IPrintReport


        'Public Event PrintReport As IPrintReport.PrintReportEventHandler Implements IPrintReport.PrintReport

        Public Sub New(itemView As IDosagePrintingView)
            MyBase.New(itemView)
            Service = New AccountsService("DosagePrinting")
            TableName = "Dosage_View"
            TableBaseName = "Dosage"
            TreeViewMainField = "DosageName"
            SortOrderKey = "DosageName"
            WithTreeView = True
            AddHandler View.AddNewDosage, AddressOf OnAddNewDosage
            AddHandler View.UpdateTree, AddressOf OnUpdateTree
            'AddHandler PrintReport, AddressOf OnPrintReport
            Ea = New EventAggregator()
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"ItemCode", "DurationTiming", Nothing, "CodeGroupIdNo=12"})
            data.Add({"ItemCode", "DosageUnit", Nothing, "CodeGroupIdNo=7"})
            CreateDataSourceThread(data)
            Dim viewIdNo As Int32 = GetRecordFieldWithKey("DosagePrinting", "SystemView", "SystemViewName", "IdNo")
            View.DosageUnit = GetRecordFieldWithKey(viewIdNo, "DefaultFieldValue", "SystemViewIdNo", "DefaultValue").ToInt32Number()
        End Sub

        Public Overrides Sub GoPrintRecord()

            Dim qtyDescription As String = IIf(View.Dose <> 0, GlobalFunctions.NumberToWordEnglish(View.Dose, False).ToLower() + Trim(GetRecordFieldWithKeyG(Of String)(View.DosageUnit, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")
            Dim duration As String = IIf(View.Duration <> 0, " for " + GlobalFunctions.NumberToWordEnglish(View.Duration).ToLower() + " " + Trim(GetRecordFieldWithKeyG(Of String)(View.DurationTiming, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")
            Dim args As Object = {View.IdNo, "IdNo", qtyDescription, "QtyDescription", duration, "Duration"}
            Ea.PublishEvent(New PrintCrEventArgs("DosageLabel.Rpt", "ISPDATA", args, 1))

        End Sub


        Private Sub OnAddNewDosage()
            Dim formToRun = Activator.CreateInstance(GetType(DosageEntryTv))
            Dim pType As Type = GetType(DosagePresenter(Of DosageModel))
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun})
            formToRun.AddOnOpen = True
            formToRun.QuitOnSave = True
            formToRun.ShowDialog()
        End Sub

        Private Sub OnUpdateTree()
            Dim nIdNo As Int32 = GetFieldOnMaxField("IdNo", "Dosage", "IdNo")
            DisplayTree(nIdNo)
        End Sub

        Public Sub OnPrintReportEventHandler(ByRef eventType As PrintCrEventArgs) Implements ISubscriber(Of PrintCrEventArgs).OnEventHandler
            Dim printModel As New ReportModel
            Dim reportPrinter As New PrintReportPresenter(Of ReportModel)
            reportPrinter.OnPrintReport(eventType.FileName, eventType.DataBaseConnectionName, eventType.Args, eventType.Copies)
        End Sub

        'Public Sub OnEventHandler(ByRef eventType As PrintCrEventArgs) Implements ISubscriber(Of PrintCrEventArgs).OnEventHandler
        '    Throw New NotImplementedException()
        'End Sub

    End Class

End Namespace