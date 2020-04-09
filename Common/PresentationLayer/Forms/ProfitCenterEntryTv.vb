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
            TvMainFieldName = "ProfitCenterName"
            TvSecondaryFieldName = "ProfitCenterCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtProfitCenterCode
            ' Add any initialization after the InitializeComponent() call.
            'Dim model = New ProfitCenterModel
            PresenterObj = New ProfitCenterPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

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

        Public Property LevelNumber As Int16 Implements IProfitCenterView.LevelNumber
            Get
                Return GlobalFunctions.NumParser(Of Int16)(TxtIDNo.Text)
            End Get
            Set(value As Int16)
                txtLevelNumber.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetProfitCenterList()
            cacProfitCenterType.DataSource = PresenterObj.MakeEnumComboList(Of ProfitCenterTypeSelection)
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"IDNo", TxtIDNo},
                {"LevelNumber", txtLevelNumber},
                {"Notes", txtNotes},
                {"ParentIdNo", cacParentIdNo},
                {"ProfitCenterCode", txtProfitCenterCode},
                {"ProfitCenterName", txtProfitCenterName},
                {"ProfitCenterNameAra", txtProfitCenterNameAra},
                {"ProfitCenterType", cacProfitCenterType},
                {"SortKey", txtSortKey}
                }
        End Sub

    End Class

End Namespace