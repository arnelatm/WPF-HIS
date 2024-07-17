Imports System.Globalization
Imports AATM.Libraries.GlobalFuncNSub

Public Class View
    Implements IViewForm

    Private _formCulture As CultureInfo

    Public Property Errors As List(Of String) Implements IViewForm.Errors
    Public Property DataFilter As String Implements IViewForm.DataFilter

    Public Property FormCulture As CultureInfo Implements IViewForm.FormCulture
        Get
            If _formCulture Is Nothing Then
                _formCulture = GlobalVariables.AppCurrentCultureInfo
            End If
            Return _formCulture
        End Get
        Set(value As CultureInfo)
            _formCulture = value
        End Set
    End Property
End Class
