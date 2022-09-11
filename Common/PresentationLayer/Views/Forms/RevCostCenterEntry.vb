Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class RevCostCenterEntryTv
        Implements IRevCostCenterView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ParentFieldName = "ParentIdNo"
            FirstControl = txtRevCostCenterCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IRevCostCenterView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements IRevCostCenterView.ParentIdNo
            Get
                Return cacParentIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property RCType As String Implements IRevCostCenterView.RCType
            Get
                Return cacRcType.GetValue()
            End Get
            Set
                cacRcType.SetValue(Value)
            End Set
        End Property

        Public Property RevCostCenterCode As String Implements IRevCostCenterView.RevCostCenterCode
            Get
                Return txtRevCostCenterCode.Text
            End Get
            Set
                txtRevCostCenterCode.Text = Value
            End Set
        End Property

        Public Property RevCostCenterName As String Implements IRevCostCenterView.RevCostCenterName
            Get
                Return txtRevCostCenterName.Text
            End Get
            Set
                txtRevCostCenterName.Text = Value
            End Set
        End Property

        Public Property RevCostCenterNameAra As String Implements IRevCostCenterView.RevCostCenterNameAra
            Get
                Return txtRevCostCenterNameAra.Text
            End Get
            Set
                txtRevCostCenterNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IRevCostCenterView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property SortKey As String Implements IRevCostCenterView.SortKey
            Get
                Return txtSortKey.Text
            End Get
            Set
                txtSortKey.Text = Value
            End Set
        End Property

        Public Property LevelNumber As Int16 Implements IRevCostCenterView.LevelNumber
            Get
                Return NumParser(Of Int16)(txtLevelNumber.Text)
            End Get
            Set(value As Int16)
                txtLevelNumber.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"RevCostCenterCode", txtRevCostCenterCode},
                {"RevCostCenterName", txtRevCostCenterName},
                {"RevCostCenterNameAra", txtRevCostCenterNameAra},
                {"IdNo", TxtIdNo},
                {"ParentIdNo", cacParentIdNo},
                {"RcType", cacRcType},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace