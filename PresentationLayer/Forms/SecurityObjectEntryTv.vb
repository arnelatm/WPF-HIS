Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Public Class SecurityObjectEntryTv
    Implements ISecurityObjectView

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'Dim mapperConfigurationAccounts = New MapperConfiguration(Sub(cfg)
        '    cfg.AddProfile(New MappingProfile)
        'End Sub)
        'mapperConfigurationAccounts.AssertConfigurationIsValid()
        'GlobalVariables.Mapper = mapperConfigurationAccounts.CreateMapper()

        MainTableName = "SecurityObject"
        IdFieldName = "IdNo"
        TvMainFieldName = "SecurityObjectName"
        TvSecondaryFieldName = ""
        SortOrderKey = "SecurityObjectName"
        FirstControl = txtSecurityObjectName
        ' Add any initialization after the InitializeComponent() call.
        Dim model = New SecurityObjectModel
        PresenterObj = New SecurityObjectPresenter(Me)

        '_SecurityObjectsPresenter = New SecurityObjectsPresenter(Me)
        'CreateEnumResourceFile()

        'ResourceEnumConverter.MakeResource("SecurityObjectTypeSelection", GetType(SecurityObjectTypeSelection))
    End Sub

    Public Sub CreateEnumResourceFile()
        'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
        'ResourceEnumConverter.MakeResource("SecurityObjectTypeSelection", GetType(SecurityObjectTypeSelection))
        'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
    End Sub

    Public Property IDNo As Integer Implements ISecurityObjectView.IdNo
        Get
            Return NumParser(Of Int32)(TxtIDNo.Text)
        End Get
        Set
            TxtIDNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property SecurityObjectName As String Implements ISecurityObjectView.SecurityObjectName
        Get
            Return txtSecurityObjectName.Text
        End Get
        Set
            txtSecurityObjectName.Text = Value
        End Set
    End Property

    Public Property SecurityObjectNameAra As String Implements ISecurityObjectView.SecurityObjectNameAra
        Get
            Return txtSecurityObjectNameAra.Text
        End Get
        Set
            txtSecurityObjectNameAra.Text = Value
        End Set
    End Property

    Public Property Notes As String Implements ISecurityObjectView.Notes
        Get
            Return txtNotes.Text
        End Get
        Set
            txtNotes.Text = Value
        End Set
    End Property

    Protected Overrides Sub AddMandatoryFieldCheck()
        'Add controls one by one in error provider.
        MyErrorProvider.Controls.AddMandatory(txtSecurityObjectName, "SecurityObject Name in English")
        'Set summary error message
        MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
    End Sub

End Class