Imports AATM.Libraries.MessagingLibrary

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

        Public Sub OnAfterSave() Handles MyBase.AfterSave
            UpdateParentIdData()
            SecurityGroupView.cacParentIdNo.Refresh()
        End Sub

        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PresenterObj.EditMode And SecurityGroupView.ParentIdNo = SecurityGroupView.TxtIdNo.Text Then
                Messaging.Show(True, "MsgMemberCannotBeAParentToItself", "Sorry a member cannot be a parent to itself.", "Invalid Parent")
                PresenterObj.CancelSave = True
                Exit Sub
            End If
            ' need to do this since last change on the dataGrid will not be saved unless that cell lose focus.
            ' so focusing to this field will force the lost focus on the cell and save that last entry.
            SecurityGroupView.txtNotes.Focus()
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

        Private Sub SecurityGroupView_Load(sender As Object, e As EventArgs) Handles SecurityGroupView.Load

        End Sub

    End Class

End Namespace