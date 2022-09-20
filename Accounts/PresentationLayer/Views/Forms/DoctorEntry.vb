Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DoctorEntryTv
        Implements IDoctorView

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtDoctorName
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IDoctorView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DoctorCode As String Implements IDoctorView.DoctorCode
            Get
                Return txtDoctorCode.Text
            End Get
            Set
                txtDoctorCode.Text = Value
            End Set
        End Property

        Public Property DoctorName As String Implements IDoctorView.DoctorName
            Get
                Return txtDoctorName.Text
            End Get
            Set
                txtDoctorName.Text = Value
            End Set
        End Property

        Public Property DoctorNameAra As String Implements IDoctorView.DoctorNameAra
            Get
                Return txtDoctorNameAra.Text
            End Get
            Set
                txtDoctorNameAra.Text = Value
            End Set
        End Property

        Public Property EmployeeIdNo As Int32 Implements IDoctorView.EmployeeIdNo
            Get
                Return cboEmployeeIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As Date? Implements IDoctorView.DateCreated

        Public Property SpecialtyIdNo As Integer Implements IDoctorView.SpecialtyIdNo
            Get
                Return cboSpecialtyIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboSpecialtyIdNo.SetValue(Value)
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"DoctorCode", txtDoctorCode},
                {"DoctorName", txtDoctorName},
                {"DoctorNameAra", txtDoctorNameAra},
                {"IdNo", TxtIdNo},
                {"EmployeeIdNo", cboEmployeeIdNo},
                {"SpecialtyIdNo", cboSpecialtyIdNo}
                }
        End Sub

    End Class

End Namespace