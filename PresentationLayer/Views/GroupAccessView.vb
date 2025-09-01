Imports AATM.Platform.Presentation.Views.Interfaces

Public Class GroupAccessView
    Implements IGroupAccessView

    Private _visible As Boolean = False
    Private _editable As Boolean = False

    Public Property IdNo As Int32 Implements IGroupAccessView.IdNo

    Public Property SecurityGroupIdNo As Int16 Implements IGroupAccessView.SecurityGroupIdNo

    Public Property SecurityObjectIdNo As Int32 Implements IGroupAccessView.SecurityObjectIdNo

    Public Property Visible As Boolean Implements IGroupAccessView.Visible
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

    Public Property Editable As Boolean Implements IGroupAccessView.Editable
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

    Public Property SecurityObjectName As String Implements IGroupAccessView.SecurityObjectName

    Public Property Errors As List(Of String) Implements IGroupAccessView.Errors
End Class