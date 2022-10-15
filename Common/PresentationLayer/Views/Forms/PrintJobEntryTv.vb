Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PrintJobEntryTv
        Implements IPrintJobView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtPrintJobCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPrintJobView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrintJobCode As String Implements IPrintJobView.PrintJobCode
            Get
                Return txtPrintJobCode.Text
            End Get
            Set
                txtPrintJobCode.Text = Value
            End Set
        End Property

        Public Property PrintJobName As String Implements IPrintJobView.PrintJobName
            Get
                Return txtPrintJobName.Text
            End Get
            Set
                txtPrintJobName.Text = Value
            End Set
        End Property

        Public Property PrintJobNameAra As String Implements IPrintJobView.PrintJobNameAra
            Get
                Return txtPrintJobNameAra.Text
            End Get
            Set
                txtPrintJobNameAra.Text = Value
            End Set
        End Property

        Public Property ComputerName As String Implements IPrintJobView.ComputerName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PaperSize As Integer Implements IPrintJobView.PaperSize
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Integer)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PaperSource As Short Implements IPrintJobView.PaperSource
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Short)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PrinterName As String Implements IPrintJobView.PrinterName
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PaperOrientation As String Implements IPrintJobView.PaperOrientation
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property


#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"PrintJobCode", txtPrintJobCode},
                {"PrintJobName", txtPrintJobName},
                {"PrintJobNameAra", txtPrintJobNameAra},
                {"IdNo", TxtIdNo}
                }
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs)
            txtPrintJobName.DisplayOnly = False
            txtPrintJobName.ReadOnly = False
            txtPrintJobName.EditingMode = True
            txtPrintJobName.ShortcutsEnabled = True
        End Sub

        Private Sub CLabel1_Click(sender As Object, e As EventArgs) Handles LblPaperSource.Click

        End Sub

        Private Sub CTextBoxArabic2_TextChanged(sender As Object, e As EventArgs) Handles CTextBoxArabic2.TextChanged

        End Sub
    End Class

End Namespace