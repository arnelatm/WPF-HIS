Imports AATM.Common.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ReportGroupEntry
        Implements IReportGroupView

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = txtReportGroupCode
        End Sub

        Public Property IdNo As Int32 Implements IReportGroupView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ReportGroupCode As String Implements IReportGroupView.ReportGroupCode
            Get
                Return txtReportGroupCode.Text
            End Get
            Set
                txtReportGroupCode.Text = Value
            End Set
        End Property

        Public Overloads Property ReportGroupName As String Implements IReportGroupView.ReportGroupName
            Get
                Return txtReportGroupName.Text
            End Get
            Set
                txtReportGroupName.Text = Value
            End Set
        End Property

        Public Property ReportGroupNameAra As String Implements IReportGroupView.ReportGroupNameAra
            Get
                Return txtReportGroupNameAra.Text
            End Get
            Set
                txtReportGroupNameAra.Text = Value
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
             {"IdNo", TxtIdNo},
             {"ReportGroupCode", txtReportGroupCode},
             {"ReportGroupName", txtReportGroupName},
             {"ReportGroupNameAra", txtReportGroupNameAra}
            }
        End Sub

        Private Sub ReportGroupEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace