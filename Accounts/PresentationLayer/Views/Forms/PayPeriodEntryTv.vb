Imports AATM.Accounts.DataLayer.AdoNet
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
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
            FirstControl = txtPayPeriodName
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PayPeriodPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

        Protected Overrides Sub CreateDataSources()
            CacPayCycleIdNo.DataSource = PresenterObj.GetLookup("PayCycle")
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IPayPeriodView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PayCycleIdNo As Int16 Implements IPayPeriodView.PayCycleIdNo
            Get
                Return CacPayCycleIdNo.GetValue()
            End Get
            Set
                CacPayCycleIdNo.SetValue(Value)
            End Set
        End Property

        Public Property StartDate As Date Implements IPayPeriodView.StartDate
            Get
                Return dtpStartDate.Value
            End Get
            Set
                dtpStartDate.Value = Value
            End Set
        End Property

        Public Property EndDate As Date Implements IPayPeriodView.EndDate
            Get
                Return dtpEndDate.Value
            End Get
            Set
                dtpEndDate.Value = Value
            End Set
        End Property

        Public Property PayPeriodName As String Implements IPayPeriodView.PayPeriodName
            Get
                Return txtPayPeriodName.Text
            End Get
            Set(value As String)
                txtPayPeriodName.Text = value
            End Set
        End Property

        Public Property PayPeriodNameAra As String Implements IPayPeriodView.PayPeriodNameAra
            Get
                Return txtPayPeriodNameAra.Text
            End Get
            Set(value As String)
                txtPayPeriodNameAra.Text = value
            End Set
        End Property

        Public Property PayPeriodCode As String Implements IPayPeriodView.PayPeriodCode
            Get
                Return txtPayPeriodCode.Text
            End Get
            Set(value As String)
                txtPayPeriodCode.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"StartDate", dtpStartDate},
                {"EndDate", dtpEndDate},
                {"Description", txtPayPeriodName},
                {"IdNo", TxtIdNo},
                {"PayCycleIdNo", CacPayCycleIdNo}
                }
        End Sub

        Private Sub CacPayCycleIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CacPayCycleIdNo.SelectedIndexChanged
            If PresenterObj.AddMode Then
                Dim payFrequency As PayFrequencySelection
                Dim payCycleDaoObject As New PayCycleDao
                Dim payCycleRecord = payCycleDaoObject.GetRecordById(PayCycleIdNo)
                payFrequency = GetEnumCodeValue(Of PayFrequencySelection)(payCycleRecord.PayFrequency)
                Select Case payFrequency
                    Case PayFrequencySelection.Monthly
                        PresenterObj.InitializeMonthlyPayroll(payCycleRecord)
                End Select
            End If
        End Sub

        Private Sub btnInitialize_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnInitialize.ClickButtonArea

        End Sub

    End Class

End Namespace