Imports System.Drawing.Printing
Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Common.ServiceLayer
Imports AATM.Libraries.CrystalReportsHelper
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Presenters

    Public Class PrintJobPresenter(Of TM As New)
        Inherits CommonPresenter(Of IPrintJobView, TM)

        Public Sub New(view As IPrintJobView)
            MyBase.New(view)

            Service = New CommonService("PrintJob")
            TableName = "PrintJob"
            TreeViewMainField = "PrintJobName"
            SortOrderKey = "PrintJobName"
        End Sub

    End Class

End Namespace