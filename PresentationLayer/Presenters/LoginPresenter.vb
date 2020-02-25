
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer.AdoNet
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Views

''' <summary>
'''     Login Presenter class.
''' </summary>
''' <remarks>
'''     MV Patterns: MVP design pattern.
''' </remarks>
Public Class LoginPresenter
    Inherits Presenter(Of ILoginView, Login, LoginModel)

    ''' <summary>
    '''     Constructor.
    ''' </summary>
    ''' <param name="view">The view</param>
    Public Sub New(view As IView)
        MyBase.New(view)
        CurrentModel = New ModelLogin()
        TableName = "Login"
        OriginalModel = New LoginModel()
        BizObject = New Login
        DataModel = New LoginModel
        DbDataDao = New LoginDao
        Model = New ModelLogin
    End Sub

    'Shared Sub New()
    '    ModelTblColProp = New ModelTblColProp
    '    ModelDefaultFieldValue = New ModelDefaultFieldValue
    'End Sub

    ''' <summary>
    '''     Perform login. Gets data from view and calls model.
    ''' </summary>
    Function Login()
        Dim username As String = View.UserName
        Dim password As String = View.Password
        Return CurrentModel.Login(username, password)
    End Function

End Class