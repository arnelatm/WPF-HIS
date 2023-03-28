Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views.Forms
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
            TableBaseName = "Dosage"
            TreeViewMainField = "DosageName"
            SortOrderKey = "DosageName"
            WithTreeView = True
            AddHandler View.AddNewDosage, AddressOf OnAddNewDosage
            AddHandler View.UpdateTree, AddressOf OnUpdateTree
        End Sub

        Protected Overrides Sub CreateDataSources()
            Dim data As New ArrayList
            data.Add({"ItemCode", "DurationTiming", Nothing, "CodeGroupIdNo=12"})
            data.Add({"ItemCode", "DosageUnit", Nothing, "CodeGroupIdNo=7"})
            CreateDataSourceThread(data)
            Dim viewIdNo As Int32 = GetRecordFieldWithKey("DosagePrinting","SystemView","SystemViewName","IdNo")
            View.DosageUnit = GetRecordFieldWithKey(viewIdNo,"DefaultFieldValue","SystemViewIdNo","DefaultValue").ToInt32Number()
        End Sub

        Public Overrides Sub GoPrintRecord()
            Dim qtyDescription As String = IIf(View.Dose <> 0, GlobalFunctions.NumberToWordEnglish(View.Dose, False).ToLower() + Trim(GetRecordFieldWithKeyG(Of String)(View.DosageUnit, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")
            Dim duration As String = IIf(View.Duration <> 0, " for " + GlobalFunctions.NumberToWordEnglish(View.Duration).ToLower() + " " + Trim(GetRecordFieldWithKeyG(Of String)(View.DurationTiming, "ItemCode", "IdNo", "ItemCodeName")) + IIf(View.Dose > 1, "s", ""), "")

            Dim prPresenter As New PrintReportPresenter()
            Dim args As Array =  { View.IdNo, "IdNo", qtyDescription, "QtyDescription", duration, "Duration" }
            prPresenter.PrintReport("DosageLabel.Rpt", Nothing , args)




            'Dim cForm As New ReportForm("DosageLabel.Rpt", View.IdNo, "IdNo", qtyDescription, "QtyDescription", duration, "Duration")
            'cForm.Show()
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
            Dim nIdNo As Int32 =  GetFieldOnMaxField("IdNo","Dosage", "IdNo") 
            DisplayTree(nIdNo)
        End Sub

    End Class

End Namespace