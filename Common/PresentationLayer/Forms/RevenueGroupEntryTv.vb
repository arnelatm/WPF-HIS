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
            TvMainFieldName = "RevenueGroupName"
            TvSecondaryFieldName = "RevenueGroupCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtRevenueGroupCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New RevenueGroupPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IRevenueGroupView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int32? Implements IRevenueGroupView.ParentIdNo
            Get
                Return CType(cacParentIdNo.GetValue(), Integer?)
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

        Public Property LevelNumber As Int16 Implements IRevenueGroupView.LevelNumber
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
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"IDNo", TxtIDNo},
                {"LevelNumber", txtLevelNumber},
                {"Notes", txtNotes},
                {"ParentIdNo", cacParentIdNo},
                {"RevenueGroupCode", txtRevenueGroupCode},
                {"RevenueGroupName", txtRevenueGroupName},
                {"RevenueGroupNameAra", txtRevenueGroupNameAra},
                {"SortKey", txtSortKey}
                }
        End Sub

    End Class

End Namespace