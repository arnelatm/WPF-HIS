Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views

Namespace PresentationLayer.Forms

    Public Class PurchaseItemEntry
        Implements IPurchaseItemView

        'Private _glAccounts
        'Private _inputVatAccounts

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "PurchaseItem"
            SortOrderKey = "IdNo"
            FirstControl = cboCategoryIdNo
            PresenterObj = New PurchaseItemPresenter(Me)

        End Sub

        Public Property DateCreated As DateTime? Implements IPurchaseItemView.DateCreated
            Get
                If String.IsNullOrEmpty(txtDateCreated.Text) Then
                    Return Now()
                End If
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    txtDateCreated.Text = Nothing
                Else
                    txtDateCreated.Text = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If

            End Set
        End Property

        Public Property IdNo As Integer Implements IPurchaseItemView.IdNo
            Get
                If TxtIDNo.Text <> "" Then
                    Return Convert.ToInt16(TxtIDNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PurchaseItemCode As String Implements IPurchaseItemView.PurchaseItemCode
            Get
                Return txtPurchaseItemCode.Text
            End Get
            Set
                txtPurchaseItemCode.Text = Value
            End Set
        End Property

        Public Property PurchaseItemName As String Implements IPurchaseItemView.PurchaseItemName
            Get
                Return txtPurchaseItemName.Text
            End Get
            Set
                txtPurchaseItemName.Text = Value
            End Set
        End Property

        Public Property PurchaseItemNameAra As String Implements IPurchaseItemView.PurchaseItemNameAra
            Get
                Return txtPurchaseItemNameAra.Text
            End Get
            Set
                txtPurchaseItemNameAra.Text = Value
            End Set
        End Property

        Public Property Unit1 As String Implements IPurchaseItemView.Unit1
            Get
                Return txtUnit1.Text
            End Get
            Set
                txtUnit1.Text = Value
            End Set
        End Property

        Public Property Unit2 As String Implements IPurchaseItemView.Unit2
            Get
                Return txtUnit2.Text
            End Get
            Set
                txtUnit2.Text = Value
            End Set
        End Property

        Public Property Unit3 As String Implements IPurchaseItemView.Unit3
            Get
                Return txtUnit3.Text
            End Get
            Set
                txtUnit3.Text = Value
            End Set
        End Property

        Public Property Unit1Ara As String Implements IPurchaseItemView.Unit1Ara
            Get
                Return txtUnit1Ara.Text
            End Get
            Set
                txtUnit1Ara.Text = Value
            End Set
        End Property

        Public Property Unit2Ara As String Implements IPurchaseItemView.Unit2Ara
            Get
                Return txtUnit2Ara.Text
            End Get
            Set
                txtUnit2Ara.Text = Value
            End Set
        End Property

        Public Property Unit3Ara As String Implements IPurchaseItemView.Unit3Ara
            Get
                Return txtUnit3Ara.Text
            End Get
            Set
                txtUnit3Ara.Text = Value
            End Set
        End Property

        Public Property StdPrice1 As Decimal Implements IPurchaseItemView.StdPrice1
            Get
                If txtStdPrice1.Text <> "" Then
                    Return Convert.ToSingle(txtStdPrice1.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtStdPrice1.Text = Value
            End Set
        End Property

        Public Property StdPrice2 As Decimal Implements IPurchaseItemView.StdPrice2
            Get
                If txtStdPrice2.Text <> "" Then
                    Return Convert.ToSingle(txtStdPrice2.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtStdPrice2.Text = Value
            End Set
        End Property

        Private Property StdPrice3 As Decimal Implements IPurchaseItemView.StdPrice3
            Get
                If txtStdPrice3.Text <> "" Then
                    Return Convert.ToSingle(txtStdPrice3.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                txtStdPrice3.Text = Value
            End Set
        End Property

        Public Property Active As Boolean Implements IPurchaseItemView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property GlAccountIdNo As Integer Implements IPurchaseItemView.GlAccountIdNo
            Get
                Return cboGlAccountIdNo.GetValue()
            End Get
            Set
                cboGlAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property VatAccountIdNo As Integer Implements IPurchaseItemView.VatAccountIdNo
            Get
                Return cboVatAccountIdNo.GetValue()
            End Get
            Set
                cboVatAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CategoryIdNo As Integer Implements IPurchaseItemView.CategoryIdNo
            Get
                Return cboCategoryIdNo.GetValue()
            End Get
            Set(value As Integer)
                cboCategoryIdNo.SetValue(value)
            End Set
        End Property

        Protected Overrides Sub CreateDataSources()

            cboCategoryIdNo.BeginUpdate()
            cboCategoryIdNo.DataSource = PresenterObj.GetCategoryList()
            cboCategoryIdNo.EndUpdate()
            cboGlAccountIdNo.BeginUpdate()
            cboGlAccountIdNo.DataSource = PresenterObj.GetDetailAccountListByCode()
            cboGlAccountIdNo.EndUpdate()
            cboVatAccountIdNo.BeginUpdate()
            cboVatAccountIdNo.DataSource = PresenterObj.GetAccountTypesList("VI")
            cboVatAccountIdNo.EndUpdate()
            'ResourceEnumConverter.MakeResource("MaritalStatusSelection", GetType(MaritalStatusSelection))
            'ResourceEnumConverter.MakeResource("MaleFemaleSelection", GetType(MaleFemaleSelection))
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"IdNo", TxtIDNo},
         {"PurchaseItemCode", txtPurchaseItemCode},
         {"PurchaseItemName", txtPurchaseItemName},
         {"PurchaseItemNameAra", txtPurchaseItemNameAra},
         {"CategoryIdNo", cboCategoryIdNo},
         {"GlAccountIdNo", cboGlAccountIdNo},
         {"VatAccountIdNo", cboVatAccountIdNo},
         {"Unit1", txtUnit1},
         {"Unit2", txtUnit2},
         {"Unit3", txtUnit3},
         {"Unit1Ara", txtUnit1Ara},
         {"Unit2Ara", txtUnit2},
         {"Unit3Ara", txtUnit3},
         {"StdPrice1", txtStdPrice1},
         {"StdPrice2", txtStdPrice2},
         {"StdPrice3", txtStdPrice3},
         {"Active", chkActive},
         {"DateCreated", txtDateCreated}
        }
        End Sub

        Private Sub PurchaseItemEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            KeyPreview = True
        End Sub

    End Class

End Namespace