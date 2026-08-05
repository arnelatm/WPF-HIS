Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class CDgvCustomCheckBoxColumn
    Inherits DataGridViewColumn


    Public Sub New()
        MyBase.New(New CDgvCustomCheckBoxCell)
    End Sub

    Public Overrides Property CellTemplate() As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(ByVal value As DataGridViewCell)

            If (value IsNot Nothing) AndAlso Not value.GetType().IsAssignableFrom(GetType(CDgvCustomCheckBoxCell)) Then
                Throw New InvalidCastException("Must be a CDgvCustomCheckBoxCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property

End Class