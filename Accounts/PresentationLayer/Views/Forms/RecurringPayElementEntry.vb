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

        Public Property LimitAmount As Decimal Implements IRecurringPayElementView.LimitAmount
            Get
                Return NumParser(Of Decimal)(txtLimitAmount.Text)
            End Get
            Set
                txtLimitAmount.Text = Value
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

        Public Property EndDate As Date? Implements IRecurringPayElementView.EndDate
            Get
                Return dtpEndDate.Value
            End Get
            Set
                dtpEndDate.Value = Value
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

        Public Property PeriodicAmount As Decimal Implements IRecurringPayElementView.PeriodicAmount
            Get
                Return NumParser(Of Decimal)(txtPeriodicAmount.Text)
            End Get
            Set
                txtPeriodicAmount.Text = Value
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

        Public Property Active As Boolean Implements IRecurringPayElementView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Public Property RecurType As String Implements IRecurringPayElementView.RecurType
            Get
                Return cboRecurType.GetValue()
            End Get
            Set
                cboRecurType.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Active", chkActive},
                {"Amount", txtLimitAmount},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"IdNo", TxtIdNo},
                {"PayElementIdNo", cboPayElementIdNo},
                {"PeriodicAmount", txtPeriodicAmount},
                {"RecurType", cboRecurType},
                {"StartDate", dtpStartDate}
                }
        End Sub

        Private Sub cboRecurType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboRecurType.SelectedIndexChanged
            Select Case cboRecurType.SelectedValue
                Case EnumToCode(RecurTypeSelection.UpToEndDate)
                    dtpEndDate.Visible = True
                    lblEndDate.Visible = True
                    txtLimitAmount.Visible = False
                    lblLimitAmount.Visible = False
                Case EnumToCode(RecurTypeSelection.UpToLimitAmount)
                    dtpEndDate.Visible = False
                    lblEndDate.Visible = False
                    txtLimitAmount.Visible = True
                    lblLimitAmount.Visible = True
                Case EnumToCode(RecurTypeSelection.WhileActive)
                    dtpEndDate.Visible = False
                    lblEndDate.Visible = False
                    txtLimitAmount.Visible = False
                    lblLimitAmount.Visible = False
            End Select
        End Sub

    End Class

End Namespace