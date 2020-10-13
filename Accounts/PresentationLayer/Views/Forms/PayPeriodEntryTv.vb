Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PayPeriodEntryTv
        Implements IPayPeriodView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PayPeriod"
            TvMainFieldName = "PayPeriodName"
            TvSecondaryFieldName = "PayPeriodCode"
            SortOrderKey = "SortKey"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtPayPeriodCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PayPeriodPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

        Protected Overrides Sub CreateDataSources()
            cacParentIdNo.DataSource = PresenterObj.GetPayPeriodList()
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPayPeriodView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements IPayPeriodView.ParentIdNo
            Get
                Return CType(cacParentIdNo.GetValue(), Integer?)
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property PayPeriodCode As String Implements IPayPeriodView.PayPeriodCode
            Get
                Return txtPayPeriodCode.Text
            End Get
            Set
                txtPayPeriodCode.Text = Value
            End Set
        End Property

        Public Property PayPeriodName As String Implements IPayPeriodView.PayPeriodName
            Get
                Return txtPayPeriodName.Text
            End Get
            Set
                txtPayPeriodName.Text = Value
            End Set
        End Property

        Public Property PayPeriodNameAra As String Implements IPayPeriodView.PayPeriodNameAra
            Get
                Return txtPayPeriodNameAra.Text
            End Get
            Set
                txtPayPeriodNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IPayPeriodView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        'Public Property SortKey As String Implements IPayPeriodView.SortKey
        '    Get
        '        Return txtSortKey.Text
        '    End Get
        '    Set
        '        txtSortKey.Text = Value
        '    End Set
        'End Property

        'Public Property LevelNumber As Int16 Implements IPayPeriodView.LevelNumber
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
                {"PayPeriodCode", txtPayPeriodCode},
                {"PayPeriodName", txtPayPeriodName},
                {"PayPeriodNameAra", txtPayPeriodNameAra},
                {"IdNo", TxtIdNo},
                {"ParentIdNo", cacParentIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace