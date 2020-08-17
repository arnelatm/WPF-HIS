Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Forms

    Public Class SecurityGroupEntryTv

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            MainTableName = "SecurityGroup"
            TvMainFieldName = "SecurityGroupName"
            TvSecondaryFieldName = "SecurityGroupCode"
            SortOrderKey = "SecurityGroupName"
            ParentFieldName = "ParentIdNo"
            FirstControl = SecurityGroupView.txtSecurityGroupCode

            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New SecurityGroupPresenter(SecurityGroupView)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub

        Protected Overrides Sub CreateDataSources()
            UpdateParentIdData()
        End Sub

        Private Sub UpdateParentIdData()
            SecurityGroupView.cacParentIdNo.DataSource = PresenterObj.GetSecurityGroupList()
        End Sub

        Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
            MyBase.RecordSaved(e)
            UpdateParentIdData()
            SecurityGroupView.cacParentIdNo.Refresh()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            With SecurityGroupView
                FieldsDictionary = New Dictionary(Of String, Object) From
                    {
                    {"IdNo", .TxtIdNo},
                    {"Notes", .txtNotes},
                    {"ParentId", .TxtIdNo},
                    {"ParentIdNo", .cacParentIdNo},
                    {"SecurityGroupCode", .txtSecurityGroupCode},
                    {"SecurityGroupName", .txtSecurityGroupName},
                    {"SecurityGroupNameAra", .txtSecurityGroupNameAra}
                    }
            End With
        End Sub

    End Class

End Namespace