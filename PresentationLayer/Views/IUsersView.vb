

''' represents view of a list of Users
Public Interface IUsersView
    Inherits IView

    WriteOnly Property Users As IList(Of UserModel)
End Interface