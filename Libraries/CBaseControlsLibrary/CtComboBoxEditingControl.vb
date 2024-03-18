Imports System.Drawing
Imports System.Globalization
Imports System.Windows.Forms

Public Class CtComboBoxEditingControl
    Inherits CtComboBox
    Implements IDataGridViewEditingControl

    Private _dataGridView As DataGridView
    Private _valueChanged As Boolean
    Private _rowIndex As Integer

    Public Property EditingControlDataGridView As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return _dataGridView
        End Get
        Set(value As DataGridView)
            _dataGridView = value
        End Set
    End Property

    Public Property EditingControlFormattedValue As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return GetEditingControlFormattedValue(DataGridViewDataErrorContexts.Formatting)
        End Get
        Set(value As Object)
            Dim text As String = TryCast(value, String)
            If text IsNot Nothing Then
                text = text
                If String.Compare(text, text, ignoreCase:=True, CultureInfo.CurrentCulture) <> 0 Then
                    SelectedIndex = -1
                End If
            End If
        End Set
    End Property

    Public Property EditingControlRowIndex As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return _rowIndex
        End Get
        Set(ByVal value As Integer)
            _rowIndex = value
        End Set
    End Property

    Public Property EditingControlValueChanged As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return _valueChanged
        End Get
        Set(ByVal value As Boolean)
            _valueChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingPanelCursor As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return Cursors.[Default]
        End Get
    End Property

    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Sub ApplyCellStyleToEditingControl(dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

        Font = dataGridViewCellStyle.Font
        If dataGridViewCellStyle.BackColor.A < Byte.MaxValue Then
            Dim backColor As Color = dataGridViewCellStyle.BackColor
            _dataGridView.EditingPanel.BackColor = backColor
        Else
            BackColor = dataGridViewCellStyle.BackColor
        End If
        ForeColor = dataGridViewCellStyle.ForeColor
    End Sub

    Public Sub PrepareEditingControlForEdit(selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        If selectAll Then
            Me.SelectAll()
        End If
    End Sub

    Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        If (keyData And Keys.KeyCode) = Keys.Down OrElse (keyData And Keys.KeyCode) = Keys.Up OrElse (MyBase.DroppedDown AndAlso (keyData And Keys.KeyCode) = Keys.Escape) OrElse (keyData And Keys.KeyCode) = Keys.[Return] Then
            Return True
        End If
        Return Not dataGridViewWantsInputKey
    End Function

    Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Text
    End Function
End Class
