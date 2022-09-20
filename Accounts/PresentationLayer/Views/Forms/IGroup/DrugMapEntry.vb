Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DrugMapEntry
        Implements IDrugMapView

        Private _nfi As NumberFormatInfo

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtGTIN

            Dim numberDecimalDigits = 4
            Dim numberDecimalSeparator = ConfigurationManager.AppSettings("DefaultNumberDecimalSeparator")
            Dim numberGroupSeparator = ConfigurationManager.AppSettings("DefaultNumberGroupSeparator")
            _nfi = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
            _nfi.NumberDecimalDigits = 4
            If numberDecimalSeparator Is Nothing Then
                _nfi.NumberDecimalSeparator = "."
            Else
                _nfi.NumberDecimalSeparator = numberDecimalSeparator
            End If
            If numberGroupSeparator Is Nothing Then
                _nfi.NumberGroupSeparator = ","
            Else
                _nfi.NumberGroupSeparator = numberGroupSeparator
            End If

        End Sub

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IDrugMapView.FinderValueChanged

        Public Property DrugMapByName As List(Of Lookup.LookupData)

#Region "Field Items"

        Public Property IdNo As Int32 Implements IDrugMapView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt32(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Private _branchID As String

        Public Property BranchID As String Implements IDrugMapView.BranchId
            Get
                Return "01"
            End Get
            Set(value As String)
                _branchID = value
            End Set
        End Property

        Public Property GTIN As String Implements IDrugMapView.GTIN
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.Text = value
            End Set
        End Property

        Public Property Batch As String Implements IDrugMapView.Batch
            Get
                Return txtBatch.Text
            End Get
            Set(value As String)
                txtBatch.Text = value
            End Set
        End Property

        Public Property CashPrice As Decimal Implements IDrugMapView.CashPrice
            Get
                Return txtCashPrice.Text
            End Get
            Set(value As Decimal)
                txtCashPrice.Text = value
            End Set
        End Property

        Public Property Expiry As Date Implements IDrugMapView.Expiry
            Get
                Return dtpExpiry.Value
            End Get
            Set
                dtpExpiry.Value = Value
            End Set
        End Property

        Public Property Item_Code As String Implements IDrugMapView.Item_Code
            Get
                Return TxtItem_Code.Text
            End Get
            Set(value As String)
                TxtItem_Code.Text = value
            End Set
        End Property

        Public Property ItemNameEnglish As String Implements IDrugMapView.ItemNameEnglish
            Get
                Return txtItemNameEnglish.Text
            End Get
            Set(value As String)
                txtItemNameEnglish.Text = value
            End Set
        End Property

        Public Property PurchaseNo As Decimal Implements IDrugMapView.PurchaseNo
            Get
                Return txtPurchaseNo.Text
            End Get
            Set(value As Decimal)
                txtPurchaseNo.Text = value
            End Set
        End Property

        Public Property Quantity As Decimal Implements IDrugMapView.Quantity
            Get
                Return txtQuantity.Text
            End Get
            Set(value As Decimal)
                txtQuantity.Text = value
            End Set
        End Property

        Public Property SerialNo As String Implements IDrugMapView.SerialNo
            Get
                Return txtSerialNo.Text
            End Get
            Set(value As String)
                txtSerialNo.Text = value
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {{"Batch", txtBatch},
                {"BranchId", txtBranchId},
                {"CashPrice", txtCashPrice},
                {"Expiry", dtpExpiry},
                {"GTIN", txtGTIN},
                {"IdNo", TxtIdNo},
                {"Item_Code", TxtItem_Code},
                {"ItemNameEnglish", txtItemNameEnglish},
                {"PurchaseNo", txtPurchaseNo},
                {"Quantity", txtQuantity},
                {"SerialNo", txtSerialNo}
                }
        End Sub

        Protected Overrides Sub BeforeEdit()
            SetDisplayOnly(True)
            Refresh()
        End Sub

        Private Sub SetDisplayOnly(value As Boolean)
            txtItemNameEnglish.DisplayOnly = value
            txtQuantity.DisplayOnly = value
            txtPurchaseNo.DisplayOnly = value
            txtCashPrice.DisplayOnly = value
            TxtItem_Code.DisplayOnly = value
        End Sub

        Private Sub DrugMapEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboItemFinder.DataSource = DrugMapByName
            cboItemFinder.EditingMode = True
        End Sub

        Private Sub cboItemFinder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemFinder.SelectedIndexChanged
            RaiseEvent FinderValueChanged(cboItemFinder.SelectedItem.IdNo)
        End Sub

#End Region

    End Class

End Namespace