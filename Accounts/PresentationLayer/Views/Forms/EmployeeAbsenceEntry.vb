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

        Public Property AddedBy As Short Implements IEmployeeAbsenceView.AddedBy
            Get
                Return txtAddedBy.Text
            End Get
            Set(value As Short)
                txtAddedBy.Text = value
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IEmployeeAbsenceView.DateCreated
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
                txtEquivalentHours.Text = value
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
                Return NumParser(Of Int16)(txtPayrollIdNo.Text)
            End Get
            Set
                txtPayrollIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"AbsenceReason", txtAbsenceReason},
                {"AbsenceType", cboAbsenceType},
                {"AddedByUser", txtAddedBy},
                {"Amount", txtEquivalentHours},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"EquivalentHours", txtEquivalentHours},
                {"IdNo", TxtIdNo}
                }
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateDataSource("Employee", cboEmployeeIdNo)
        End Sub

    End Class

End Namespace