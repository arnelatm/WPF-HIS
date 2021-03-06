Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class BankEntryTv
        Implements IBankView

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Bank"
            TvMainFieldName = "BankName"
            TvSecondaryFieldName = "BankCode"
            SortOrderKey = "BankName"
            FirstControl = txtBankCode
            PresenterObj = New BankPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

#Region "Fields"
        Public Property IdNo As Int32 Implements IBankView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
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
#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"BankCode", txtBankCode},
                {"BankName", txtBankName},
                {"BankNameAra", txtBankNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub



    End Class

End Namespace