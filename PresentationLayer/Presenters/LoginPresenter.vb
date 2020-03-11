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
    Inherits Presenter(Of ILoginView, LoginModel)

    ''' <summary>
    '''     Constructor.
    ''' </summary>
    ''' <param name="view">The view</param>
    Public Sub New(ByVal view As ILoginView)
        MyBase.New(view)
        'Model = New ModelLogin
        ''ModelPresenter = New ModelLogin()
        'TableName = "User"
        'OriginalModel = New LoginModel()
        'DataBizObject = New Login
        DataModel = New LoginModel()
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
        Return Model.Login(username, password)
    End Function

End Class