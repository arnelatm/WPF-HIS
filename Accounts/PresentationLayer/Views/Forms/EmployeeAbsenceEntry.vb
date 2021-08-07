Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeAbsenceEntry
        Implements IEmployeeAbsenceView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboEmployeeIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo

            'FormTreeView.Visible = False
        End Sub

        Public Event AddedByUserChanged()

        Private Event IEmployeeAbsenceView_AddedByUserChanged() Implements IEmployeeAbsenceView.AddedByUserChanged

#Region "Fields"

        Public Property AbsenceReason As String Implements IEmployeeAbsenceView.AbsenceReason
            Get
                Return txtAbsenceReason.Text
            End Get
            Set(value As String)
                txtAbsenceReason.Text = value
            End Set
        End Property

        Public Property AbsenceType As Char Implements IEmployeeAbsenceView.AbsenceType
            Get
                Return cboAbsenceType.GetValue()
            End Get
            Set
                cboAbsenceType.SetValue(Value)
            End Set
        End Property

        Public Property AddedByUser As Short Implements IEmployeeAbsenceView.AddedByUser
            Get
                Return txtAddedByUser.Text
            End Get
            Set(value As Short)
                txtAddedByUser.Text = value
                RaiseEvent AddedByUserChanged()
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IEmployeeAbsenceView.DateCreated
            Get
                Return Convert.ToDateTime(txtUserName.Text)
            End Get
            Set
                If Value.HasValue Then
                    txtUserName.Text = Value
                Else
                    txtUserName.Text = Date.Now().ToString()
                End If
            End Set
        End Property

        Public Property EmployeeIdNo As Integer Implements IEmployeeAbsenceView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property EquivalentHours As Decimal Implements IEmployeeAbsenceView.EquivalentHours
            Get
                Return NumParser(Of Decimal)(txtEquivalentHours.Text)
            End Get
            Set(value As Decimal)
                txtEquivalentHours.Text = Convert.ToString(value)
            End Set
        End Property

        Public Property IdNo As Integer Implements IEmployeeAbsenceView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PayrollIdNo As Short Implements IEmployeeAbsenceView.PayrollIdNo
            Get
                Return NumParser(Of Int32)(txtPayrollIdNo.Text)
            End Get
            Set
                txtPayrollIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property UserName As String Implements IEmployeeAbsenceView.UserName
            Get
                Return txtUserName.Text
            End Get
            Set(value As String)
                txtUserName.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AbsenceReason", txtAbsenceReason},
                {"AbsenceType", cboAbsenceType},
                {"AddedByUser", txtUserName},
                {"DateCreated", txtDateCreated},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"IdNo", TxtIdNo},
                {"PayElementIdNo", cboAbsenceType},
                {"PeriodicPayment", txtPeriodicPayment},
                {"StartDate", dtpStartDate}
                {"PeriodicPayment", txtPeriodicPayment},
                {"StartDate", dtpStartDate}
                }
        End Sub

            CreateEnumDataSource(Of AbsenceTypeSelection)(cboAbsenceType)
            CreateDataSource("Employee", cboEmployeeIdNo)
            CreateDataSource("PayElement", cboAbsenceType)
        End Sub

    End Class

End Namespace