Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Forms

    Public Class UserEntryTv
        Implements IUserView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "User"
            IdFieldName = "IdNo"
            TvMainFieldName = "FullName"
            TvSecondaryFieldName = "UserName"
            SortOrderKey = "FullName"
            FirstControl = TxtUserName
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New UserPresenter(Me)

            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            CreateDataSources()
            'Assign comboboxes datasources
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("BranchTypeSelection", GetType(BranchTypeSelection))
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacSecurityGroupIdNo.DataSource = PresenterObj.GetSecurityGroupList()
            cacSecurityLevel.DataSource = PresenterObj.MakeEnumComboList(Of SecurityLevelSelection)
        End Sub

        Private Shadows Sub OnTextDisplayLanguageChanged()
            CreateDataSources()
        End Sub

        Public Property IDNo As Integer Implements IUserView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
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

        Public Property Password As String Implements IUserView.Password
            Get
                Return TxtPassword.Text
            End Get
            Set
                TxtPassword.Text = Value
            End Set
        End Property

        Public Property FullName As String Implements IUserView.FullName
            Get
                Return TxtFullName.Text
            End Get
            Set
                TxtFullName.Text = Value
            End Set
        End Property

        Public Property FullNameAra As String Implements IUserView.FullNameAra
            Get
                Return txtFullNameAra.Text
            End Get
            Set
                txtFullNameAra.Text = Value
            End Set
        End Property

        Public Property SecurityGroupIdNo As Integer Implements IUserView.SecurityGroupIdNo
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

        Private Sub CFlowLayout1_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles CFlowLayout1.Paint

        End Sub
    End Class

End Namespace