Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class RevenueGroupEntryTv
        Implements IRevenueGroupView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "RevenueGroup_View"
            IdFieldName = "IdNo"
            TvMainFieldName = "RevenueGroupName"
            TvSecondaryFieldName = "RevenueGroupCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtRevenueGroupCode
            ' Add any initialization after the InitializeComponent() call.
            'Dim model = New RevenueGroupModel
            PresenterObj = New RevenueGroupPresenter(Me)

            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            CreateDataSources()

            'CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("RevenueGroupTypeSelection", GetType(RevenueGroupTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("RevenueGroupTypeSelection", GetType(RevenueGroupTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetRevenueGroupList()
        End Sub

        Private Shadows Sub OnTextDisplayLanguageChanged()
            CreateDataSources()
        End Sub

        Public Property IDNo As Integer Implements IRevenueGroupView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Integer? Implements IRevenueGroupView.ParentIdNo
            Get
                Return cacParentIdNo.GetValue()
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property RevenueGroupCode As String Implements IRevenueGroupView.RevenueGroupCode
            Get
                Return txtRevenueGroupCode.Text
            End Get
            Set
                txtRevenueGroupCode.Text = Value
            End Set
        End Property

        Public Property RevenueGroupName As String Implements IRevenueGroupView.RevenueGroupName
            Get
                Return txtRevenueGroupName.Text
            End Get
            Set
                txtRevenueGroupName.Text = Value
            End Set
        End Property

        Public Property RevenueGroupNameAra As String Implements IRevenueGroupView.RevenueGroupNameAra
            Get
                Return txtRevenueGroupNameAra.Text
            End Get
            Set
                txtRevenueGroupNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IRevenueGroupView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property SortKey As String Implements IRevenueGroupView.SortKey
            Get
                Return txtSortKey.Text
            End Get
            Set
                txtSortKey.Text = Value
            End Set
        End Property

        'Public WriteOnly Property RevenueGroupsParent As IList(Of RevenueGroupModel)
        '    Set(value As IList(Of RevenueGroupModel))
        '        _RevenueGroupsList = value
        '    End Set
        'End Property

        Public Property LevelNumber As Int16 Implements IRevenueGroupView.LevelNumber
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIDNo.Text)
            End Get
            Set(value As Int16)
                txtLevelNumber.Text = value
            End Set
        End Property

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtRevenueGroupCode, "RevenueGroup Code")
            MyErrorProvider.Controls.AddMandatory(txtRevenueGroupName, "RevenueGroup Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If EditMode And cacParentIdNo.GetValue() = NumParser(Of Int16)(TxtIDNo.Text) Then
                _MBRevenueGroupCannotBeParentToItself.Show(Me)
                CancelSave = True
                Exit Sub
            End If
        End Sub

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            cacParentIdNo.DataSource = PresenterObj.GetRevenueGroupList()
            cacParentIdNo.Refresh()
        End Sub

        Private Sub RevenueGroupEntryTv_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        End Sub

    End Class

End Namespace