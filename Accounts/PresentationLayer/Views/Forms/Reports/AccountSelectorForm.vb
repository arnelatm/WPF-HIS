Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms.Reports

    Public Class AccountSelectorForm
        Implements IAccountSelector

        Private _idNoData As DataTable
        Public Event PostButtonClicked(IdNo As Int16) Implements IAccountSelector.PostButtonClicked
        Protected SortOrderKey As String

        Public Sub New(title As String)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            Text = AATM.Libraries.MessagingLibrary.Messaging.TranslateCaption(title)
            MainTableName = "Account"
            SortOrderKey = "IdNo"
            Dim today = Now()
            AccountSelectorControl = cboIdNo
        End Sub

        Public Property MainTableName As String


        Public Property IdNo As Integer Implements IAccountSelector.IdNo
            Get
                Return cboIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer)
                cboIdNo.SetValue(value)
            End Set
        End Property

        Public Property IdNoData As DataTable Implements IAccountSelector.IdNoData
            Get
                Return _idNoData
            End Get
            Set(value As DataTable)
                _idNoData = value
                cboIdNo.DataSource = value
            End Set
        End Property

        Public ReadOnly Property ReportCode As String Implements IAccountSelector.ReportCode

        Public Property UserHasAccess As Boolean Implements IAccountSelector.UserHasAccess

        Public Property Title As String Implements IAccountSelector.Title

        Private ReadOnly Property Language As String Implements IAccountSelector.Language

        Public Property AccountSelectorControl As Control Implements IAccountSelector.AccountSelectorControl
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Control)
                Throw New NotImplementedException()
            End Set
        End Property

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCancel.ClickButtonArea
            Close()
        End Sub

        Private Sub btnOk_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            RaiseEvent PostButtonClicked(IdNo)
        End Sub


        'Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    cboIdNo.EditingMode = False
        '    RaiseEvent ReportLoaded()

        '    cboIdNo.EditingMode = True
        '    Text = Title
        '    lblTitle.Text = Title
        '    btnCancel.Left = floButtons.Size.Width - btnCancel.Width - btnOk.Width - floButtons.Margin.Left - floButtons.Margin.Right
        'End Sub

    End Class

End Namespace