Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DrugSaleEntry
        Implements IDrugSaleView

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

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IDrugSaleView.FinderValueChanged

        Public Event GenerateCsvFile(salesDate As Date) Implements IDrugSaleView.GenerateCsvFile

        Public Property DrugSaleByName As List(Of Lookup.LookupData)

#Region "Field Items"

        Public Property IdNo As Int32 Implements IDrugSaleView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property GTIN As String Implements IDrugSaleView.GTin
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.Text = value
            End Set
        End Property

        Public Property BatchNo As String Implements IDrugSaleView.BatchNo
            Get
                Return txtBatchNo.Text
            End Get
            Set(value As String)
                txtBatchNo.Text = value
            End Set
        End Property

        Public Property Expiry As Date Implements IDrugSaleView.Expiry
            Get
                Return dtpExpiry.Value
            End Get
            Set
                dtpExpiry.Value = Value
            End Set
        End Property

        Public Property Item_Code As String Implements IDrugSaleView.Item_Code
            Get
                Return TxtItem_Code.Text
            End Get
            Set(value As String)
                TxtItem_Code.Text = value
            End Set
        End Property

        Public Property ItemNameEnglish As String Implements IDrugSaleView.ItemNameEnglish
            Get
                Return txtItemNameEnglish.Text
            End Get
            Set(value As String)
                txtItemNameEnglish.Text = value
            End Set
        End Property

        Public Property SerializationNo As String Implements IDrugSaleView.SerializationNo
            Get
                Return txtSerializationNo.Text
            End Get
            Set(value As String)
                txtSerializationNo.Text = value
            End Set
        End Property

        Public Property SaleDate As Date Implements IDrugSaleView.SaleDate
            Get
                Return dtpSaleDate.Value
            End Get
            Set(value As DateTime)
                dtpSaleDate.Value = value
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {{"BatchNo", txtBatchNo},
                {"Expiry", dtpExpiry},
                {"GTin", txtGTIN},
                {"IdNo", TxtIdNo},
                {"Item_Code", TxtItem_Code},
                {"ItemNameEnglish", txtItemNameEnglish},
                {"SaleDate", dtpSaleDate},
                {"SerializationNo", txtSerializationNo}
                }
        End Sub

        Protected Overrides Sub BeforeEdit()
            SetDisplayOnly(True)
            Refresh()
        End Sub

        Private Sub SetDisplayOnly(value As Boolean)
            txtItemNameEnglish.DisplayOnly = value
            TxtItem_Code.DisplayOnly = value
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea

        End Sub

        'Private Sub cboItemFinder_SelectedIndexChanged(sender As Object, e As EventArgs)
        '    RaiseEvent FinderValueChanged(cboItemFinder.SelectedItem.IdNo)
        'End Sub

#End Region

    End Class

End Namespace