Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeAbsenceEntry
        Implements IAbsenceView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property AbsenceReason As String Implements IAbsenceView.AbsenceReason
            Get
                Return txtAbsenceReason.Text
            End Get
            Set(value As String)
                txtAbsenceReason.Text = value
            End Set
        End Property

        Public Property AbsenceType As Char Implements IAbsenceView.AbsenceType
            Get
                Return cboAbsenceType.GetValue()
            End Get
            Set
                cboAbsenceType.SetValue(Value)
            End Set
        End Property

        Public Property AddedBy As Short Implements IAbsenceView.AddedBy

        Public Property DateCreated As DateTime? Implements IAbsenceView.DateCreated
            Get
                Return Convert.ToDateTime(txtAddedBy.Text)
            End Get
            Set
                If Value.HasValue Then
                    txtAddedBy.Text = Value
                Else
                    txtAddedBy.Text = Date.Now().ToString()
                End If
            End Set
        End Property

        Public Property EmployeeIdNo As Integer Implements IAbsenceView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property EquivalentHours As Decimal Implements IAbsenceView.EquivalentHours

        Public Property IdNo As Integer Implements IAbsenceView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PayrollIdNo As Short Implements IAbsenceView.PayrollIdNo
            Get
                Return cboPayrollIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboPayrollIdNo.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Amount", txtAmount},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"IdNo", TxtIdNo},
                {"PayElementIdNo", cboAbsenceType},
                {"PeriodicPayment", txtPeriodicPayment},
                {"StartDate", dtpStartDate}
                }
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Employee", cboEmployeeIdNo)
            CreateDataSource("PayElement", cboAbsenceType)
        End Sub

    End Class

End Namespace