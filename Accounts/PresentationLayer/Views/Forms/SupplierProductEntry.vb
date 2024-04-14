Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class SupplierProductEntry
        Implements ISupplierProductView

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            FirstControl = cboProductIdNo
        End Sub

        Public Property IdNo As Int32 Implements ISupplierProductView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property SupplierProductCode As String Implements ISupplierProductView.SupplierProductCode
            Get
                Return txtSupplierProductCode.Text
            End Get
            Set
                txtSupplierProductCode.Text = Value
            End Set
        End Property

        Public Overloads Property SupplierProductName As String Implements ISupplierProductView.SupplierProductName
            Get
                Return txtSupplierProductName.Text
            End Get
            Set
                txtSupplierProductName.Text = Value
            End Set
        End Property

        Public Property SupplierProductNameAra As String Implements ISupplierProductView.SupplierProductNameAra
            Get
                Return txtSupplierProductNameAra.Text
            End Get
            Set
                txtSupplierProductNameAra.Text = Value
            End Set
        End Property

        Public Property ProductIdNo As Int32 Implements ISupplierProductView.ProductIdNo
            Get
                Return cboProductIdNo.GetValue(Of Int32)
            End Get
            Set(value As Int32)
                cboProductIdNo.SetValue(value)
            End Set
        End Property

        Public Property SupplierIdNo As Int32 Implements ISupplierProductView.SupplierIdNo
            Get
                Return cboSupplierIdNo.GetValue(Of Int32)
            End Get
            Set
                cboSupplierIdNo.SetValue(Value)
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
             {"IdNo", TxtIdNo},
             {"ProductIdNo", cboProductIdNo},
             {"SupplierIdNo", cboSupplierIdNo},
             {"SupplierProductCode", txtSupplierProductCode},
             {"SupplierProductName", txtSupplierProductName},
             {"SupplierProductNameAra", txtSupplierProductNameAra}
            }
        End Sub

        Private Sub SupplierProductEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub
    End Class

End Namespace