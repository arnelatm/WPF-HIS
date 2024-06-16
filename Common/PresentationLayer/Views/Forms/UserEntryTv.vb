Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class UserEntryTv
        Implements IUserView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            FirstControl = TxtUserName
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IUserView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property UserName As String Implements IUserView.UserName
            Get
                Return TxtUserName.Text
            End Get
            Set
                TxtUserName.Text = Value
            End Set
        End Property

        Public Property EmployeeIdNo As Int32? Implements IUserView.EmployeeIdNo
            Get
                Return cacEmployeeIdNo.GetValue()
            End Get
            Set
                cacEmployeeIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Password As String Implements IUserView.Password
            Get
                Return TxtPassword.Text
            End Get
            Set
                TxtPassword.Text = Value
            End Set
        End Property

        Public Property SecurityGroupIdNo As Int16 Implements IUserView.SecurityGroupIdNo
            Get
                Return cacSecurityGroupIdNo.GetValue()
            End Get
            Set
                cacSecurityGroupIdNo.SetValue(Value)
            End Set
        End Property

        Public Property SecurityLevel As Int16 Implements IUserView.SecurityLevel
            Get
                Return cacSecurityLevel.GetValue()
            End Get
            Set
                cacSecurityLevel.SetValue(Value)
            End Set
        End Property

        Public Property Active As Boolean Implements IUserView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"IdNo", TxtIdNo},
                {"EmployeeIdNo", cacEmployeeIdNo},
                {"UserName", TxtUserName},
                {"Password", TxtPassword},
                {"SecurityLevel", cacSecurityLevel},
                {"SecurityGroupIdNo", cacSecurityGroupIdNo},
                {"Active", lblActive}
                }
        End Sub

    End Class

End Namespace