Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class BankEntryTv
        Implements IBankView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Bank"
            TvMainFieldName = "BankName"
            TvSecondaryFieldName = "BankCode"
            SortOrderKey = "BankName"
            FirstControl = txtBankCode
            'PairFieldsToControls()

            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New BankPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
            'CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("BankTypeSelection", GetType(BankTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
        End Sub
        Public Property IDNo As Integer Implements IBankView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property BankCode As String Implements IBankView.BankCode
            Get
                Return txtBankCode.Text
            End Get
            Set
                txtBankCode.Text = Value
            End Set
        End Property

        Public Property BankName As String Implements IBankView.BankName
            Get
                Return txtBankName.Text
            End Get
            Set
                txtBankName.Text = Value
            End Set
        End Property

        Public Property BankNameAra As String Implements IBankView.BankNameAra
            Get
                Return txtBankNameAra.Text
            End Get
            Set
                txtBankNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IBankView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

    End Class

End Namespace