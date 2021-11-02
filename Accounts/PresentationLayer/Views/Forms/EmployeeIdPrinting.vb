Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Events

Namespace PresentationLayer.Views.Forms

    Public Class EmployeeIdPrinting
        Implements IEmployeeIdListView

        Private _employeeIdList As New List(Of EmployeeIdView)

        Public Event EmployeeCheckedEvent(sender As Object) 'Implements IEmployeeIdPrintingView.EmployeeCheckedEvent

        Public Event ClearAllEmployeeID(sender As Object, clear As Boolean) 'Implements IEmployeeIdPrintingView.ClearAllEmployee

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Me.Text = Messaging.TranslateCaption("Employee I.D. Printing")
        End Sub

#Region "Field Items"

        Private Property EmployeeIdList As List(Of EmployeeIdView) Implements IEmployeeIdListView.EmployeeIdList
            Get
                Return _employeeIdList
            End Get
            Set
                _employeeIdList = Value
                BindEmployeeIdList()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateDataSources()
            EmployeeIdList = Presenter.GetEmployeeIdList()
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {}
        End Sub

        Private Sub BindEmployeeIdList()
            SuspendLayout()
            bsEmployeeIdList.DataSource = Nothing
            DataGridViewEmployeeIdList.Refresh()
            bsEmployeeIdList.DataSource = EmployeeIdList
            bsEmployeeIdList.AllowNew = True
            With DataGridViewEmployeeIdList
                '.Refresh()
                .AutoGenerateColumns = False
                .DataSource = bsEmployeeIdList
                '.Refresh()
            End With
            With DataGridViewEmployeeIdList.Columns
                dgvIdNo.DisplayOnly = True
                dgvEmployeeName.DisplayOnly = True
                dgvNationalIdNo.DisplayOnly = True
                dgvPicture.ImageLayout = DataGridViewImageCellLayout.Stretch
            End With
            ResumeLayout()
        End Sub

        Private Sub EmployeeIdPrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            DataGridViewEmployeeIdList.Refresh()
            BindEmployeeIdList()
        End Sub

        Private Sub EmployeeIdPrinting_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
            bsEmployeeIdList.ResetBindings(True)
        End Sub

        Private Sub SelectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnSelectAll.ClickButtonArea
            RaiseEvent ClearAllEmployeeID(bsEmployeeIdList, True)
            bsEmployeeIdList.ResetBindings(False)
        End Sub

        Private Sub UnselectAll_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnUnSelectAll.ClickButtonArea
            RaiseEvent ClearAllEmployeeID(bsEmployeeIdList, False)
            bsEmployeeIdList.ResetBindings(False)
        End Sub

        Private Sub DataGridViewEmployeeIdListCellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewEmployeeIdList.CellContentClick
            If DataGridViewEmployeeIdList.CurrentCell IsNot Nothing AndAlso (Presenter.EditMode Or Presenter.AddMode) Then
                With DataGridViewEmployeeIdList.CurrentCell
                    Select Case .OwningColumn.Name.ToLower()
                        'Case $"dgvpcclosed"
                        '    If Not DataGridViewEmployeeIdList.DisplayOnly Then
                        '        Dim selectedRow = DataGridViewEmployeeIdList.Rows(.RowIndex).DataBoundItem
                        '        RaiseEvent PcJournalCheckedEvent(selectedRow)
                        '    End If
                    End Select
                End With
            End If
        End Sub

    End Class

End Namespace