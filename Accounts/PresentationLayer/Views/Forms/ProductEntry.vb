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
            FirstControl = cboCategoryIdNo
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

        Public Property BaseUnit As Short Implements IProductView.BaseUnit
            Get
                Return cboBaseUnitIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboBaseUnitIdNo.SetValue(Value)
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

        Public Property CategoryIdNo As Int16 Implements IProductView.CategoryIdNo
            Get
                Return cboCategoryIdNo.GetValue()
            End Get
            Set(value As Int16)
                cboCategoryIdNo.SetValue(value)
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"IdNo", TxtIdNo},
         {"ProductCode", txtProductCode},
         {"ProductName", txtProductName},
         {"ProductNameAra", txtProductNameAra},
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

    End Class

End Namespace