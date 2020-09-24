Imports AATM.Accounts.PresentationLayer.Presenters

Public Class LeaveEntry

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        MainTableName = "Leave"
        TvMainFieldName = "LeaveName"
        TvSecondaryFieldName = "LeaveCode"
        SortOrderKey = "DeductionName"
        FirstControl = LeaveView.txtLeaveCode
        PresenterObj = New LeavePresenter(LeaveView)
        Ea = PresenterObj.Ea
        Ea.SubscribeEvent(Me)

    End Sub

End Class