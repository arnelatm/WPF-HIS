Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views.Forms

    Public Class SecurityObjectEntryTv
        Implements ISecurityObjectView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ParentFieldName = "ParentIdNo"
            FirstControl = txtSecurityObjectName

        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements ISecurityObjectView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ParentIdNo As Int32? Implements ISecurityObjectView.ParentIdNo
            Get
                Return cacParentIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property SystemViewIdNo As Int16? Implements ISecurityObjectView.SystemViewIdNo
            Get
                Return cboSystemViewIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cboSystemViewIdNo.SetValue(Value)
            End Set
        End Property

        Public Property SecurityObjectCode As String Implements ISecurityObjectView.SecurityObjectCode
            Get
                Return txtSecurityObjectCode.Text
            End Get
            Set
                txtSecurityObjectCode.Text = Value
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

        Public Property ManuallyAdded As Boolean Implements ISecurityObjectView.ManuallyAdded

#End Region

        Protected Overrides Sub CreateDataSources()
            UpdateParentIdData()
            CreateDataSource("SystemView", cboSystemViewIdNo)
        End Sub

        Private Sub UpdateParentIdData()
            CreateDataSource("SecurityObject", cacParentIdNo)
        End Sub

        Protected Overrides Sub RecordSaved(ByRef e As RecordSaved)
            MyBase.RecordSaved(e)
            UpdateParentIdData()
            cacParentIdNo.Refresh()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"SecurityObjectCode", txtSecurityObjectCode},
                {"SecurityObjectName", txtSecurityObjectName},
                {"SecurityObjectNameAra", txtSecurityObjectNameAra},
                {"IdNo", TxtIdNo},
                {"ParentIdNo", cacParentIdNo},
                {"ParentId", TxtIdNo},
                {"ManuallyAdded", chkManuallyAdded},
                {"SystemViewIdNo", cboSystemViewIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace