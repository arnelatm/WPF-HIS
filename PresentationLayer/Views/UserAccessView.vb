Imports AATM.PresentationLayer.Views.Interfaces

Public Class UserAccessView
    Implements IUserAccessView

    Private _visible As Boolean = False
    Private _editable As Boolean = False

    Public Property IdNo As Int32 Implements IUserAccessView.IdNo

    Public Property UserIdNo As Int16 Implements IUserAccessView.UserIdNo

    Public Property SecurityObjectIdNo As Int32 Implements IUserAccessView.SecurityObjectIdNo

    Public Property Visible As Boolean Implements IUserAccessView.Visible
        Get
            Return _visible
        End Get
        Set(value As Boolean)
            If Not value Then
                _editable = False
            End If
            _visible = value
        End Set
    End Property

    Public Property Editable As Boolean Implements IUserAccessView.Editable
        Get
            Return _editable
        End Get
        Set(value As Boolean)
            If value Then
                _visible = True
            End If
            _editable = value
        End Set
    End Property

    Public Property SecurityObjectName As String Implements IUserAccessView.SecurityObjectName

    Public Property Errors As List(Of String) Implements IUserAccessView.Errors
End Class