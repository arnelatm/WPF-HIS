Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Forms

    Public Class SecurityObjectEntryTv
        Implements ISecurityObjectView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            MainTableName = "SecurityObject_View"
            TvMainFieldName = "SecurityObjectName"
            TvSecondaryFieldName = ""
            SortOrderKey = "SecurityObjectName"
            ParentFieldName = "ParentIdNo"
            FirstControl = txtSecurityObjectName
            PresenterObj = New SecurityObjectPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)

        End Sub
#Region "Fields"
        Public Property IdNo As Int32 Implements ISecurityObjectView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int32? Implements ISecurityObjectView.ParentIdNo
            Get
                Return CType(cacParentIdNo.GetValue(), Integer?)
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property SecurityObjectName As String Implements ISecurityObjectView.SecurityObjectName
            Get
                Return txtSecurityObjectName.Text
            End Get
            Set
                txtSecurityObjectName.Text = Value
            End Set
        End Property

        Public Property SecurityObjectNameAra As String Implements ISecurityObjectView.SecurityObjectNameAra
            Get
                Return txtSecurityObjectNameAra.Text
            End Get
            Set
                txtSecurityObjectNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements ISecurityObjectView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property
#End Region

        Protected Overrides Sub CreateDataSources()
            UpdateParentIdData()
        End Sub

        Private Sub UpdateParentIdData()
            cacParentIdNo.DataSource = PresenterObj.GetSecurityObjectList()
        End Sub
        Public Sub OnBeforeSave() Handles MyBase.BeforeSave
            If PresenterObj.EditMode And cacParentIdNo.Text = TxtIdNo.Text Then
                Messaging.Show(True, "MsgMemberCannotBeAParentToItself", "Sorry a member cannot be a parent to itself.", "Invalid Parent")
                PresenterObj.CancelSave = True
                Exit Sub
            End If
        End Sub
        Public Sub OnAfterSave() Handles MyBase.AfterSave
            UpdateParentIdData()
            cacParentIdNo.Refresh()
        End Sub

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"SecurityObjectName", txtSecurityObjectName},
                {"SecurityObjectNameAra", txtSecurityObjectNameAra},
                {"IdNo", TxtIdNo},
                {"ParentIdNo", cacParentIdNo},
                {"ParentId", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub
    End Class
End NameSpace