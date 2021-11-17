Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class RecurringPayElementEntry
        Implements IRecurringPayElementView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property Amount As Decimal Implements IRecurringPayElementView.Amount
            Get
                Return NumParser(Of Decimal)(txtAmount.Text)
            End Get
            Set
                txtAmount.Text = Value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IRecurringPayElementView.DateCreated
            Get
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set
                If Value.HasValue Then
                    txtDateCreated.Text = Value
                Else
                    txtDateCreated.Text = Date.Now().ToString()
                End If
            End Set
        End Property

        Public Property EmployeeIdNo As Integer Implements IRecurringPayElementView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Integer Implements IRecurringPayElementView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PeriodicPayment As Decimal Implements IRecurringPayElementView.PeriodicPayment
            Get
                Return NumParser(Of Decimal)(txtPeriodicPayment.Text)
            End Get
            Set
                txtPeriodicPayment.Text = Value
            End Set
        End Property

        Public Property StartDate As Date? Implements IRecurringPayElementView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

        Public Property PayElementIdNo As Int16 Implements IRecurringPayElementView.PayElementIdNo
            Get
                Return cboPayElementIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboPayElementIdNo.SetValue(Value)
            End Set
        End Property

        Public Property TotalAmount As Decimal Implements IRecurringPayElementView.TotalAmount
            Get
                Return NumParser(Of Decimal)(txtTotalAmount.Text)
            End Get
            Set
                txtTotalAmount.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Amount", txtAmount},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"IdNo", TxtIdNo},
                {"PayElementIdNo", cboPayElementIdNo},
                {"PeriodicPayment", txtPeriodicPayment},
                {"StartDate", dtpStartDate}
                }
        End Sub

    End Class

End Namespace