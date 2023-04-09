Imports System.Globalization
Imports AATM.Accounts.BusinessLayer
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

        Public Overloads Property ProductName As String Implements IProductView.ProductName
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

        Public Property BaseUnitIdNo As Short Implements IProductView.BaseUnitIdNo
            Get
                Return cboBaseUnitIdNo.GetValue(Of Int16)
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

        Public Property CategoryIdNo As Int16 Implements IProductView.CategoryIdNo
            Get
                Return cboCategoryIdNo.GetValue(Of Int16)
            End Get
            Set(value As Int16)
                cboCategoryIdNo.SetValue(value)
            End Set
        End Property

        Public Property BarCode As String Implements IProductView.Barcode
            Get
                Return txtBarcode.Text
            End Get
            Set
                txtBarcode.Text = Value
            End Set
        End Property

        Public Property GTIN As String Implements IProductView.GTIN
            Get
                Return txtGTIN.Text
            End Get
            Set
                txtGTIN.Text = Value
            End Set
        End Property

        Public Property Drug As Boolean Implements IProductView.Drug
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As Boolean)
                Throw New NotImplementedException()
            End Set
        End Property


        Private Property IProductView_ProductUnits As List(Of ProductUnit) Implements IProductView.ProductUnits
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As List(Of ProductUnit))
                Throw New NotImplementedException()
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
             {"Active", chkActive},
             {"Barcode", txtBarcode},
             {"BaseUnitIdNo", cboBaseUnitIdNo},
             {"CategoryIdNo", cboCategoryIdNo},
             {"DateCreated", txtDateCreated},
             {"GTIN", txtGTIN},
             {"IdNo", TxtIdNo},
             {"ProductCode", txtProductCode},
             {"ProductName", txtProductName},
             {"ProductNameAra", txtProductNameAra}
            }
        End Sub

    End Class

End Namespace