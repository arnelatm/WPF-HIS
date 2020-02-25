Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Forms

    Public Class BankEntryTv
        Implements IBankView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Bank"
            IdFieldName = "IdNo"
            TvMainFieldName = "BankName"
            TvSecondaryFieldName = "BankCode"
            SortOrderKey = "BankName"
            FirstControl = txtBankCode
            'PairFieldsToControls()

            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New BankPresenter(Me)
            'CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("BankTypeSelection", GetType(BankTypeSelection))
        End Sub

        'Public Sub PairFieldsToControls()
        '    Dim fieldsDictionary = New Dictionary(Of String, Object)
        '    fieldsDictionary.Add("IdNo", TxtIDNo)
        '    fieldsDictionary.Add("BankCode", txtBankCode)
        '    fieldsDictionary.Add("BankName", txtBankName)
        '    fieldsDictionary.Add("BankNameAra", txtBankNameAra)
        '    fieldsDictionary.Add("Notes", txtNotes)
        'End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("BankTypeSelection", GetType(BankTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Private _fieldObject As List(Of Object)

        Public Property FieldObject As List(Of Object)
            Get
                Return _fieldObject
            End Get
            Set(value As List(Of Object))
                _fieldObject = value
            End Set
        End Property

        Public Property IDNo As Integer Implements IBankView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
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

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtBankCode, "Bank Code")
            MyErrorProvider.Controls.AddMandatory(txtBankName, "Bank Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

    End Class

End Namespace