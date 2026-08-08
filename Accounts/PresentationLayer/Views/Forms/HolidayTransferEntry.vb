Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class HolidayTransferEntry
        Implements IHolidayTransferView

        Private _holidayTransferItems As New List(Of HolidayTransferItemView)

        Public Event HolidayIdChangedEvent() Implements IHolidayTransferView.HolidayIdChangedEvent

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int32 Implements IHolidayTransferView.IdNo
            Get
                Return NumParser(Of Integer)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property EnteredBy As Integer Implements IHolidayTransferView.EnteredBy
            Get
                Return cboenteredBy.GetValue()
            End Get
            Set
                cboenteredBy.SetValue(Value)
            End Set
        End Property

        Public Property DateCreated As DateTime? Implements IHolidayTransferView.DateCreated
            Get
                Return dtpDateCreated.Value
            End Get
            Set
                If Value.HasValue Then
                    dtpDateCreated.Value = Value
                Else
                    dtpDateCreated.Value = Date.Now()
                End If
            End Set
        End Property

        Public Property HolidayIdNo As Int16 Implements IHolidayTransferView.HolidayIdNo
            Get
                Return cboHolidayIdNo.GetValue()
            End Get
            Set(value As Int16)
                cboHolidayIdNo.SetValue(value)
            End Set
        End Property

        Public Property EmployeeList As DataTable Implements IHolidayTransferView.EmployeeList
        Public Property HolidayList As DataTable Implements IHolidayTransferView.HolidayList

        Public Property HolidayTransferItems As List(Of HolidayTransferItemView) Implements IHolidayTransferView.HolidayTransferItems
            Get
                'BindHolidayTransferItems()
                Return _holidayTransferItems
            End Get
            Set(value As List(Of HolidayTransferItemView))
                _holidayTransferItems = value
                RunOrDeferViewDataBinding(AddressOf BindHolidayTransferItems)
            End Set
        End Property

        Public Property DateEnd As Date? Implements IHolidayTransferView.DateEnd
            Get
                Return dtpDateEnd.Value
            End Get
            Set
                If Value.HasValue Then
                    dtpDateEnd.Value = Value
                Else
                    dtpDateEnd.Value = Date.Now()
                End If
            End Set
        End Property

        Public Property DateStart As Date? Implements IHolidayTransferView.DateStart
            Get
                Return dtpDateStart.Value
            End Get
            Set
                If Value.HasValue Then
                    dtpDateStart.Value = Value
                Else
                    dtpDateStart.Value = Date.Now()
                End If
            End Set
        End Property

#End Region

        Private Sub BindHolidayTransferItems()
            SuspendLayout()
            bsHolidayTransferItems.DataSource = Nothing
            DataGridViewHolidayTransferitems.Refresh()
            bsHolidayTransferItems.DataSource = HolidayTransferItems
            bsHolidayTransferItems.AllowNew = True
            With DataGridViewHolidayTransferitems
                .AutoGenerateColumns = False
                .DataSource = bsHolidayTransferItems
            End With
            With DataGridViewHolidayTransferitems.Columns
                dgvEmployeeIdNo.DisplayOnly = True
                dgvEmployeeIdNo.DataSource = EmployeeList
                dgvEmployeeIdNo.DisplayMember = "Name"
                dgvEmployeeIdNo.ValueMember = "IdNo"
                dgvEmployeeIdNo.DisplayStyleForCurrentCellOnly = True
            End With
            ResumeLayout()
        End Sub

        Private Sub OnAfterUpdateView() Handles MyBase.AfterUpdateView
            BindHolidayTransferItems()
        End Sub

        Private Sub HolidayTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridViewHolidayTransferitems.Refresh()
            BindHolidayTransferItems()
        End Sub

        Private Sub HolidayTransfer_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            bsHolidayTransferItems.ResetBindings(True)
            'PublishClickedButton(ButtonClicked.Edit)
            cboenteredBy.DisplayOnly = True
            dtpDateCreated.Value = Now()
        End Sub

        'Private Sub DgvEarning_OnCellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeLeave.CellEndEdit
        '    ProcessCellEndEdit(DataGridViewEmployeeLeave, bsEmployeeLeave)
        '    bsEmployeeLeaveeesf.ResetBindings(False)
        'End Sub

        'Private Sub CheckBoxValueChanged() Handles DataGridViewHolidayTransferitems.CellValueChanged
        '    If TypeOf DataGridViewHolidayTransferitems.CurrentCell Is DataGridViewCheckBoxCell Then
        '        If DataGridViewHolidayTransferitems.CurrentCell.OwningColumn.Name = "dgvApprove" Then
        '            DataGridViewHolidayTransferitems.CurrentRow.Cells("dgvDisapprove").Value = False
        '        ElseIf DataGridViewHolidayTransferitems.CurrentCell.OwningColumn.Name = "dgvDisapprove" Then
        '            DataGridViewHolidayTransferitems.CurrentRow.Cells("dgvApprove").Value = False
        '        End If
        '    End If
        'End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"IdNo", txtIdNo},
                {"DateCreated", dtpDateCreated},
                {"EnteredBy", cboenteredBy},
                {"HolidayIdNo", cboHolidayIdNo}
                }
        End Sub

        Private Sub cboHolidayIdNo_SelectedIndexChanged() Handles cboHolidayIdNo.SelectedIndexChanged
            RaiseEvent HolidayIdChangedEvent()
            bsHolidayTransferItems.ResetBindings(True)
        End Sub

        Private Sub BtnEdit_Click(sender As Object, e As EventArgs)
            'If btnEdit.Enabled Then
            RaiseEvent HolidayIdChangedEvent()
            bsHolidayTransferItems.ResetBindings(True)
            'End If
        End Sub

    End Class

End Namespace
