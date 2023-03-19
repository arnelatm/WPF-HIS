Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Accounts.ServiceLayer.ActionService
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Presenters

    Public Class DosagePrintingPresenter(Of TM As New)
        Inherits CommonPresenter(Of IDosagePrintingView, TM)

        Public Sub New(itemView As IDosagePrintingView)
            MyBase.New(itemView)
            Service = New AccountsService("DosagePrinting")
            TableName = "Dosage_View"
            TreeViewMainField = "DosageName"
            SortOrderKey = "DosageName"
            WithTreeView = True
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"ItemCode", "DurationTiming", Nothing, "CodeGroupIdNo=12"})
            data.Add({"ItemCode", "DosageUnit", Nothing, "CodeGroupIdNo=7"})
            CreateDataSourceThread(data)
        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim qtyDescription As String = IIf(View.Dose <> 0, GlobalFunctions.NumberToWordEnglish(View.Dose, False).ToLower() + Trim(GetRecordFieldWithKeyG(Of String)(View.DosageUnit, "ItemCode", "IdNo", "ItemCodeName"))+IIf(View.Dose>1,"s",""), "")
            Dim duration As String = IIf(View.Duration <> 0, " for " + GlobalFunctions.NumberToWordEnglish(View.Duration).ToLower() + " " + Trim(GetRecordFieldWithKeyG(Of String)(View.DurationTiming, "ItemCode", "IdNo", "ItemCodeName"))+IIf(View.Dose>1,"s",""), "")
            Dim cForm As New ReportForm("DosageLabel.Rpt", View.IdNo, "IdNo", qtyDescription, "QtyDescription", duration, "Duration")
            cForm.Show()

        End Sub

    End Class

End Namespace