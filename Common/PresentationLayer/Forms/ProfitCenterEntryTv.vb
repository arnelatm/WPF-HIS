Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class ProfitCenterEntryTv
        Implements IProfitCenterView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "ProfitCenter_View"
            IdFieldName = "IdNo"
            TvMainFieldName = "ProfitCenterName"
            TvSecondaryFieldName = "ProfitCenterCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtProfitCenterCode
            ' Add any initialization after the InitializeComponent() call.
            'Dim model = New ProfitCenterModel
            PresenterObj = New ProfitCenterPresenter(Me)

            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            CreateDataSources()

            'CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("ProfitCenterTypeSelection", GetType(ProfitCenterTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("ProfitCenterTypeSelection", GetType(ProfitCenterTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetProfitCenterList()
            cacProfitCenterType.DataSource = PresenterObj.MakeEnumComboList(Of ProfitCenterTypeSelection)
        End Sub

        Private Shadows Sub OnTextDisplayLanguageChanged()
            CreateDataSources()
        End Sub

        Public Property IDNo As Integer Implements IProfitCenterView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Integer? Implements IProfitCenterView.ParentIdNo
            Get
                Return cacParentIdNo.GetValue()
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ProfitCenterCode As String Implements IProfitCenterView.ProfitCenterCode
            Get
                Return txtProfitCenterCode.Text
            End Get
            Set
                txtProfitCenterCode.Text = Value
            End Set
        End Property

        Public Property ProfitCenterName As String Implements IProfitCenterView.ProfitCenterName
            Get
                Return txtProfitCenterName.Text
            End Get
            Set
                txtProfitCenterName.Text = Value
            End Set
        End Property

        Public Property ProfitCenterNameAra As String Implements IProfitCenterView.ProfitCenterNameAra
            Get
                Return txtProfitCenterNameAra.Text
            End Get
            Set
                txtProfitCenterNameAra.Text = Value
            End Set
        End Property

        Public Property ProfitCenterType As String Implements IProfitCenterView.ProfitCenterType
            Get
                Return cacProfitCenterType.GetValue()
            End Get
            Set
                cacProfitCenterType.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IProfitCenterView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property SortKey As String Implements IProfitCenterView.SortKey
            Get
                Return txtSortKey.Text
            End Get
            Set
                txtSortKey.Text = Value
            End Set
        End Property

        'Public WriteOnly Property ProfitCentersParent As IList(Of ProfitCenterModel)
        '    Set(value As IList(Of ProfitCenterModel))
        '        _profitCentersList = value
        '    End Set
        'End Property

        Public Property LevelNumber As Int16 Implements IProfitCenterView.LevelNumber
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIDNo.Text)
            End Get
            Set(value As Int16)
                txtLevelNumber.Text = value
            End Set
        End Property

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtProfitCenterCode, "ProfitCenter Code")
            MyErrorProvider.Controls.AddMandatory(txtProfitCenterName, "ProfitCenter Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If EditMode And cacParentIdNo.GetValue() = NumParser(Of Int16)(TxtIDNo.Text) Then
                _MBProfitCenterCannotBeParentToItself.Show(Me)
                CancelSave = True
                Exit Sub
            End If
        End Sub

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            cacParentIdNo.DataSource = PresenterObj.GetProfitCenterList()
            cacParentIdNo.Refresh()
        End Sub

    End Class

End Namespace