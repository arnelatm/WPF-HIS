Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class PurchaseEntry
        Implements IPurchaseView

        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
        Private _footer As DgvFooter

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            _nfi.NumberDecimalDigits = 2
        End Sub

        Public Property Amount As Decimal Implements IPurchaseView.Amount

        Public Property Cancelled As Boolean Implements IPurchaseView.Cancelled

        Public Property DueDate As Date? Implements IPurchaseView.DueDate

        Public Property IdNo As Integer Implements IPurchaseView.IdNo

        Public Property InvoiceDate As Date? Implements IPurchaseView.InvoiceDate

        Public Property InvoiceNo As String Implements IPurchaseView.InvoiceNo

        Public Property SupplierIdNo As Integer? Implements IPurchaseView.SupplierIdNo

        Public Property TransactionDate As Date? Implements IPurchaseView.TransactionDate

        Public Property VatAmount As Decimal Implements IPurchaseView.VatAmount

        Public Property VatNumber As String Implements IPurchaseView.VatNumber

        Public Property Posted As Boolean Implements IPurchaseView.Posted

        Public Property PurchaseDetails As List(Of PurchaseDetailView) Implements IPurchaseView.PurchaseDetails

        Public Property ProductsByCode As Object Implements IPurchaseView.ProductsByCode

        Public Property UnitsByCode As Object Implements IPurchaseView.UnitsByCode

        Public Property DateCreated As Date? Implements IPurchaseView.DateCreated


        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
        {
         {"Amount", txtAmount},
         {"DueDate", dtpDueDate},
         {"IdNo", TxtIdNo},
         {"InvoiceNo", txtInvoiceNo},
         {"SupplierIdNo", cboSupplierIdNo},
         {"TransactionDate", dtpTransactionDate},
         {"TransactionType", cboTransactionType},
         {"VatNumber", txtVatNumber}
        }
        End Sub
    End Class

End Namespace