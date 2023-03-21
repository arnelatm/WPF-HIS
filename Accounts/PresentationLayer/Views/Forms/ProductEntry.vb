Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ProductEntry
        Implements IProductView

        'Private _glAccounts
        'Private _inputVatAccounts

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = cboProductCategoryIdNo
        End Sub

        Public Property DateCreated As DateTime? Implements IProductView.DateCreated
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

        Public Property IdNo As Int32 Implements IProductView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ProductCode As String Implements IProductView.ProductCode
            Get
                Return txtProductCode.Text
            End Get
            Set
                txtProductCode.Text = Value
            End Set
        End Property

        Public Property ProductName As String Implements IProductView.ProductName
            Get
                Return txtProductName.Text
            End Get
            Set
                txtProductName.Text = Value
            End Set
        End Property

        Public Property ProductNameAra As String Implements IProductView.ProductNameAra
            Get
                Return txtProductNameAra.Text
            End Get
            Set
                txtProductNameAra.Text = Value
            End Set
        End Property

        Public Property Unit1 As String Implements IProductView.Unit1
            Get
                Return txtUnit1.Text
            End Get
            Set
                txtUnit1.Text = Value
            End Set
        End Property

        Public Property Unit2 As String Implements IProductView.Unit2
            Get
                Return txtUnit2.Text
            End Get
            Set
                txtUnit2.Text = Value
            End Set
        End Property

        Public Property Unit3 As String Implements IProductView.Unit3
            Get
                Return txtUnit3.Text
            End Get
            Set
                txtUnit3.Text = Value
            End Set
        End Property

        Public Property Unit1Ara As String Implements IProductView.Unit1Ara
            Get
                Return txtUnit1Ara.Text
            End Get
            Set
                txtUnit1Ara.Text = Value
            End Set
        End Property

        Public Property Unit2Ara As String Implements IProductView.Unit2Ara
            Get
                Return txtUnit2Ara.Text
            End Get
            Set
                txtUnit2Ara.Text = Value
            End Set
        End Property

        Public Property Unit3Ara As String Implements IProductView.Unit3Ara
            Get
                Return txtUnit3Ara.Text
            End Get
            Set
                txtUnit3Ara.Text = Value
            End Set
        End Property

        Public Property StdPrice1 As Decimal Implements IProductView.StdPrice1
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

        Public Property StdPrice2 As Decimal Implements IProductView.StdPrice2
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

        Public Property StdPrice3 As Decimal Implements IProductView.StdPrice3
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

        Public Property Active As Boolean Implements IProductView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property GlAccountIdNo As Int16? Implements IProductView.GlAccountIdNo
            Get
                Return cboGlAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboGlAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property VatAccountIdNo As Int16? Implements IProductView.VatAccountIdNo
            Get
                Return cboVatAccountIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboVatAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ProductCategoryIdNo As Int16 Implements IProductView.ProductCategoryIdNo
            Get
                Return cboProductCategoryIdNo.GetValue()
            End Get
            Set(value As Int16)
                cboProductCategoryIdNo.SetValue(value)
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"IdNo", TxtIdNo},
         {"ProductCode", txtProductCode},
         {"ProductName", txtProductName},
         {"ProductNameAra", txtProductNameAra},
         {"ProductCategoryIdNo", cboProductCategoryIdNo},
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

    End Class

End Namespace