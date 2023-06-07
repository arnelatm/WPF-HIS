Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class CategoryEntryTv
        Implements ICategoryView

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtCategoryCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements ICategoryView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property CategoryCode As String Implements ICategoryView.CategoryCode
            Get
                Return txtCategoryCode.Text
            End Get
            Set
                txtCategoryCode.Text = Value
            End Set
        End Property

        Public Property CategoryName As String Implements ICategoryView.CategoryName
            Get
                Return txtCategoryName.Text
            End Get
            Set
                txtCategoryName.Text = Value
            End Set
        End Property

        Public Property CategoryNameAra As String Implements ICategoryView.CategoryNameAra
            Get
                Return txtCategoryNameAra.Text
            End Get
            Set
                txtCategoryNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements ICategoryView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = If(Value, "")
            End Set
        End Property

        Public Property PurchaseAccountIdNo As Short Implements ICategoryView.PurchaseAccountIdNo
            Get
                Return cboPurchaseAccountIdNo.GetValue(Of Short)
            End Get
            Set
                cboPurchaseAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property SaleAccountIdNo As Short Implements ICategoryView.SaleAccountIdNo
            Get
                Return cboSaleAccountIdNo.GetValue(Of Short)
            End Get
            Set
                cboSaleAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property VatPurchaseAccountIdNo As Short Implements ICategoryView.VatPurchaseAccountIdNo
            Get
                Return cboVatPurchaseAccountIdNo.GetValue(Of Short)
            End Get
            Set
                cboVatPurchaseAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public Property VatPercentage As Decimal Implements ICategoryView.VatPercentage
            Get
                Return GlobalFunctions.NumParser(Of Decimal)(txtVatPercentage.Text)
            End Get
            Set
                txtVatPercentage.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property VatSaleAccountIdNo As Short Implements ICategoryView.VatSaleAccountIdNo
            Get
                Return cboVatSaleAccountIdNo.GetValue(Of Short)
            End Get
            Set
                cboVatSaleAccountIdNo.SetValue(Value)
            End Set
        End Property

        Public ReadOnly Property BranchIdNo As Short Implements ICategoryView.BranchIdNo
            Get
                Return GlobalVariables.BranchIdNo
            End Get
        End Property

        Public Property NeedsExpiryDate As Boolean Implements ICategoryView.NeedsExpiryDate
            Get
                Return chkNeedsExpiryDate.Checked
            End Get
            Set
                chkNeedsExpiryDate.Checked = Value
            End Set
        End Property

#End Region


        Private Sub OnFormLoad() Handles MyBase.Load
            RaiseEvent FilterRecords()
        End Sub

        Public Event FilterRecords() Implements ICategoryView.FilterRecords


        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                    {
                    {"CategoryCode", txtCategoryCode},
                    {"CategoryName", txtCategoryName},
                    {"CategoryNameAra", txtCategoryNameAra},
                    {"NeedsExpiryDate", chkNeedsExpiryDate},
                    {"IdNo", TxtIdNo},
                    {"Notes", txtNotes},
                    {"PurchaseAccountIdNo", cboPurchaseAccountIdNo},
                    {"SaleAccountIdNo", cboSaleAccountIdNo},
                    {"VatPurchaseAccountIdNo", cboVatPurchaseAccountIdNo},
                    {"VatSaleAccountIdNo", cboVatSaleAccountIdNo}
                    }
        End Sub



    End Class

End Namespace