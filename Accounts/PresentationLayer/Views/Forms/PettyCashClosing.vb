Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class PettyCashClosing
        Implements IPcJournalsView
        Public TxtTotalCredits As Decimal
        Public TxtTotalDebits As Decimal

        Private Property MyPresenter As ClosePettyCashPresenter
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "PcJournal"
            SortOrderKey = "IdNo"
            MyPresenter = New ClosePettyCashPresenter(Me)
            PresenterObj = MyPresenter
            _nfi.NumberDecimalDigits = 2
            Ea = MyPresenter.Ea
            Ea.SubscribeEvent(Me)
            Me.HideNavigatorButtons = True
        End Sub

        Private Property PcJournals As IList(Of Models.PcJournalModel) Implements IPcJournalsView.PcJournals
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As IList(Of Models.PcJournalModel))
                Throw New NotImplementedException()
            End Set
        End Property

    End Class

End Namespace