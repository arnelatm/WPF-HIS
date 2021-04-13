Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views
Imports AATM.PresentationLayer.Views.Interfaces

Namespace PresentationLayer.Views

    Public Class SecurityGroupView
        Implements ISecurityGroupView

        Public Property MainTableName As String = "SecurityGroup_View"

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            'MainTableName = "SecurityGroup"

            ' Add any initialization after the InitializeComponent() call.

            Ea = New EventAggregator()

        End Sub

#Region "SecurityGroupFields"

        Public Property IdNo As Int16 Implements ISecurityGroupView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property SecurityGroupCode As String Implements ISecurityGroupView.SecurityGroupCode
            Get
                Return txtSecurityGroupCode.Text
            End Get
            Set
                txtSecurityGroupCode.Text = Value
            End Set
        End Property

        Public Property SecurityGroupName As String Implements ISecurityGroupView.SecurityGroupName
            Get
                Return txtSecurityGroupName.Text
            End Get
            Set
                txtSecurityGroupName.Text = Value
            End Set
        End Property

        Public Property SecurityGroupNameAra As String Implements ISecurityGroupView.SecurityGroupNameAra
            Get
                Return txtSecurityGroupNameAra.Text
            End Get
            Set
                txtSecurityGroupNameAra.Text = Value
            End Set
        End Property

        Public Property ParentIdNo As Int16? Implements ISecurityGroupView.ParentIdNo
            Get
                Return cacParentIdNo.GetNullableValue(Of Int16)
            End Get
            Set
                cacParentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements ISecurityGroupView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Private Sub BindGroupAccess()
            SuspendLayout()
            bsGroupAccesses.DataSource = GroupAccesses
            bsGroupAccesses.AllowNew = False
            With DataGridViewGroupAccesses
                .Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsGroupAccesses
                'CallByName(DataGridViewGroupAccesses.Columns("DGVSecurityObjectName").CellTemplate, "DisplayOnly", CallType.Set, True)
                CallByName(DataGridViewGroupAccesses.Columns("DGVSecurityObjectName"), "DisplayOnly", CallType.Set, True)
                .AutoResizeColumns()
                .Refresh()
            End With
            ResumeLayout()
        End Sub

#End Region

        Public Property Errors As List(Of String) Implements IView.Errors

        Private _groupAccesses As List(Of GroupAccessView)

        Public Property GroupAccesses As List(Of GroupAccessView) Implements ISecurityGroupView.GroupAccesses
            Get
                Return _groupAccesses
            End Get
            Set(value As List(Of GroupAccessView))
                _groupAccesses = value
                BindGroupAccess()
            End Set
        End Property

        Public Property Ea As EventAggregator

        Private Sub DataGridViewGroupAccesses_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewGroupAccesses.CellEndEdit
            With DataGridViewGroupAccesses
                If .CurrentRow IsNot Nothing Then
                    Dim nIndex = .CurrentRow.Index
                    Dim columnName As String = .CurrentCell.OwningColumn.Name.ToLower()
                    Select Case columnName
                        Case $"dgvvisible"
                            If Ea IsNot Nothing Then
                                Ea.PublishEvent(New DataGridCellChanged(nIndex, columnName))
                            End If
                        Case $"dgveditable"
                            If Ea IsNot Nothing Then
                                Ea.PublishEvent(New DataGridCellChanged(nIndex, columnName))
                            End If
                    End Select
                End If
            End With
        End Sub

        Private Sub gridCategories_CellMouseUp(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridViewGroupAccesses.CellMouseUp
            ' needs this because after clicking a cell the CellEndEdit doesn't trigger for checkbox unless focus moves to another control
            ' so this sub will trigger the CellEndEdit for checkBoxes DgvVisible and DgvEditable
            If e.ColumnIndex = DataGridViewGroupAccesses.Columns("DgvVisible").Index Or e.ColumnIndex = DataGridViewGroupAccesses.Columns("DgvEditable").Index Then
                DataGridViewGroupAccesses.EndEdit()
            End If
        End Sub

    End Class

End Namespace