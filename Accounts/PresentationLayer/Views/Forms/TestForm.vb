Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Public Class TestForm
    Implements AATM.Common.PresentationLayer.Views.Interface.IDepartmentView

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ParentFieldName = "ParentIdNo"
        FirstControl = txtDepartmentCode
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Fields"

    Public Property IdNo As Int16 Implements IDepartmentView.IdNo
        Get
            Return NumParser(Of Int16)(TxtIdNo.Text)
        End Get
        Set
            TxtIdNo.Text = Convert.ToString(Value)
        End Set
    End Property

    Public Property ParentIdNo As Int16? Implements IDepartmentView.ParentIdNo
        Get
            Return cacParentIdNo.GetNullableValue(Of Int16)
        End Get
        Set
            cacParentIdNo.SetValue(Value)
        End Set
    End Property

    Public Property DepartmentCode As String Implements IDepartmentView.DepartmentCode
        Get
            Return txtDepartmentCode.Text
        End Get
        Set
            txtDepartmentCode.Text = Value
        End Set
    End Property

    Public Property DepartmentName As String Implements IDepartmentView.DepartmentName
        Get
            Return txtDepartmentName.Text
        End Get
        Set
            txtDepartmentName.Text = Value
        End Set
    End Property

    Public Property DepartmentNameAra As String Implements IDepartmentView.DepartmentNameAra
        Get
            Return txtDepartmentNameAra.Text
        End Get
        Set
            txtDepartmentNameAra.Text = Value
        End Set
    End Property

    Public Property RevCostCenterIdNo As Int16 Implements IDepartmentView.RevCostCenterIdNo
        Get
            Return cacRevCostCenterIdNo.GetValue()
        End Get
        Set
            cacRevCostCenterIdNo.SetValue(Value)
        End Set
    End Property

    Public Property Notes As String Implements IDepartmentView.Notes
        Get
            Return txtNotes.Text
        End Get
        Set
            txtNotes.Text = Value
        End Set
    End Property

    Public Property SortKey As String Implements IDepartmentView.SortKey
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As String)
            Throw New NotImplementedException()
        End Set
    End Property

    'Public Property SortKey As String Implements IDepartmentView.SortKey
    '    Get
    '        Return txtSortKey.Text
    '    End Get
    '    Set
    '        txtSortKey.Text = Value
    '    End Set
    'End Property

#End Region

    Protected Overrides Sub CreateMainFieldsDictionary()
        MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
            {"DepartmentCode", txtDepartmentCode},
            {"DepartmentName", txtDepartmentName},
            {"DepartmentNameAra", txtDepartmentNameAra},
            {"IdNo", TxtIdNo},
            {"ParentIdNo", cacParentIdNo},
            {"RevCostCenterIdNo", cacRevCostCenterIdNo},
            {"ParentId", cacParentIdNo},
            {"Notes", txtNotes}
            }
    End Sub



    Private Sub TestClick() Handles btnEdit.Click
        TurnEditOn()
    End Sub


    Private Sub TurnEditOn()
        CTextBox1.DisplayOnly = False
        'CTextBox2.Editable = True
        CTextBox1.ReadOnly = False
        CTextBox1.EditingMode = True
        CTextBox1.ShortcutsEnabled = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        TurnEditOn()
    End Sub

    Private Sub txtSortKey_TextChanged(sender As Object, e As EventArgs)

    End Sub


End Class