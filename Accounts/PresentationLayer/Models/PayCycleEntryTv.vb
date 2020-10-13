Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PayCycleEntryTv
        Implements IPayCycleView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PayCycle"
            TvMainFieldName = "PayCycleName"
            TvSecondaryFieldName = "PayCycleCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtPayCycleCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PayCyclePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetPayCycleList()
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPayCycleView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements IPayCycleView.ParentIdNo
            Get
                Return CType(cacParentIdNo.GetValue(), Integer?)
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayCycleCode As String Implements IPayCycleView.PayCycleCode
            Get
                Return txtPayCycleCode.Text
            End Get
            Set
                txtPayCycleCode.Text = Value
            End Set
        End Property

        Public Property PayCycleName As String Implements IPayCycleView.PayCycleName
            Get
                Return txtPayCycleName.Text
            End Get
            Set
                txtPayCycleName.Text = Value
            End Set
        End Property

        Public Property PayCycleNameAra As String Implements IPayCycleView.PayCycleNameAra
            Get
                Return txtPayCycleNameAra.Text
            End Get
            Set
                txtPayCycleNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IPayCycleView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        'Public Property SortKey As String Implements IPayCycleView.SortKey
        '    Get
        '        Return txtSortKey.Text
        '    End Get
        '    Set
        '        txtSortKey.Text = Value
        '    End Set
        'End Property

        'Public Property LevelNumber As Int16 Implements IPayCycleView.LevelNumber
        '    Get
        '        Return NumParser(Of Int16)(txtLevelNumber.Text)
        '    End Get
        '    Set(value As Int16)
        '        txtLevelNumber.Text = value
        '    End Set
        'End Property

#End Region

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"PayCycleCode", txtPayCycleCode},
                {"PayCycleName", txtPayCycleName},
                {"PayCycleNameAra", txtPayCycleNameAra},
                {"IdNo", TxtIdNo},
                {"ParentIdNo", cacParentIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace