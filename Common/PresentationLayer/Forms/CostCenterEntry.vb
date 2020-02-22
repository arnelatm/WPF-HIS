Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class CostCenterEntryTv
        Implements ICostCenterView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "CostCenter"
            IdFieldName = "IdNo"
            TvMainFieldName = "CostCenterName"
            TvSecondaryFieldName = "CostCenterCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtCostCenterCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New CostCenterPresenter(Me)

            AddHandler TextDisplayLanguageChanged, AddressOf OnTextDisplayLanguageChanged
            CreateDataSources()

            'CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("CostCenterTypeSelection", GetType(CostCenterTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("CostCenterTypeSelection", GetType(CostCenterTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetCostCenterList()
            cacProfitCenterIdNo.DataSource = PresenterObj.GetProfitCenterList()
        End Sub

        Protected Overrides Sub OnTextDisplayLanguageChanged()
            CreateDataSources()
        End Sub

        Public Property IDNo As Integer Implements ICostCenterView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Integer? Implements ICostCenterView.ParentIdNo
            Get
                Return cacParentIdNo.GetValue()
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ProfitCenterIdNo As Integer Implements ICostCenterView.ProfitCenterIdNo
            Get
                Return cacProfitCenterIdNo.GetValue()
            End Get
            Set
                cacProfitCenterIdNo.SetValue(Value)
            End Set
        End Property

        Public Property CostCenterCode As String Implements ICostCenterView.CostCenterCode
            Get
                Return txtCostCenterCode.Text
            End Get
            Set
                txtCostCenterCode.Text = Value
            End Set
        End Property

        Public Property CostCenterName As String Implements ICostCenterView.CostCenterName
            Get
                Return txtCostCenterName.Text
            End Get
            Set
                txtCostCenterName.Text = Value
            End Set
        End Property

        Public Property CostCenterNameAra As String Implements ICostCenterView.CostCenterNameAra
            Get
                Return txtCostCenterNameAra.Text
            End Get
            Set
                txtCostCenterNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements ICostCenterView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property SortKey As String Implements ICostCenterView.SortKey
            Get
                Return txtSortKey.Text
            End Get
            Set
                txtSortKey.Text = Value
            End Set
        End Property

        Public Property LevelNumber As Int16 Implements ICostCenterView.LevelNumber
            Get
                Return NumParser(Of Int16)(txtLevelNumber.Text)
            End Get
            Set(value As Int16)
                txtLevelNumber.Text = value
            End Set
        End Property


        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtCostCenterCode, "CostCenter Code")
            MyErrorProvider.Controls.AddMandatory(txtCostCenterName, "CostCenter Name in English")
            MyErrorProvider.Controls.AddMandatory(cacProfitCenterIdNo, "Profit Center Link")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If EditMode And cacParentIdNo.GetValue() = NumParser(Of Int16)(TxtIDNo.Text) Then
                _MBCostCenterCannotBeParentToItself.Show(Me)
                CancelSave = True
                Exit Sub
            End If
        End Sub

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            cacParentIdNo.DataSource = PresenterObj.GetCostCenterList()
            cacParentIdNo.Refresh()
        End Sub

    End Class

End Namespace