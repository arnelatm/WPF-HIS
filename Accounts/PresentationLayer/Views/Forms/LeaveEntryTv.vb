Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class LeaveEntryTv

        Public Sub New()

            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Leave"
            TvMainFieldName = "LeaveName"
            TvSecondaryFieldName = "LeaveCode"
            SortOrderKey = "LeaveName"
            'FirstControl = txtLeaveCode
            PresenterObj = New LeavePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

        Protected Overrides Sub CreateDataSources()
            'cboAccountIdNo.DataSource = PresenterObj.GetChartList()
            'cboDefaultFrequency.DataSource = PresenterObj.MakeEnumComboList(Of PayFrequencySelection)
            'cboLeaveType.DataSource = PresenterObj.MakeEnumComboList(Of LeaveTypeSelection)
        End Sub

        'Protected Overrides Sub CreateFieldsDictionary()
        '    FieldsDictionary = New Dictionary(Of String, Object) From
        '        {
        '        {"LeaveCode", txtLeaveCode},
        '        {"LeaveName", txtLeaveName},
        '        {"LeaveNameAra", txtLeaveNameAra},
        '        {"IdNo", TxtIdNo},
        '        {"Notes", txtNotes}
        '        }
        'End Sub

    End Class

End Namespace