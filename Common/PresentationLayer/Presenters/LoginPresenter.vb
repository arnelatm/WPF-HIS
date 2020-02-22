Imports AATM.Common.BusinessLayer
Imports AATM.Common.DataLayer.AdoNet
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Views
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    ''' <summary>
    '''     Login Presenter class.
    ''' </summary>
    ''' <remarks>
    '''     MV Patterns: MVP design pattern.
    ''' </remarks>
    Public Class LoginPresenter
        Inherits CommonPresenterOld(Of ILoginView, Login, LoginModel)

        ''' <summary>
        '''     Constructor.
        ''' </summary>
        ''' <param name="view">The view</param>
        Public Sub New(view As IView)
            MyBase.New(view)
            TableName = "Login"
            OriginalModel = New LoginModel()
            BizObject = New Login
            DataModel = New LoginModel
            DbDataDao = New LoginDao
            Model.SetService(New ServiceLayer.ActionServices.LoginService)
        End Sub

        'Public Sub Display()
        '    View.UserName = ""
        '    View.Password = ""
        'End Sub

        ''' <summary>
        '''     Perform login. Gets data from view and calls model.
        ''' </summary>
        Function Login()
            Dim username As String = View.UserName
            Dim password As String = View.Password

            'Return OriginalModel.Login(username,password)
            Return Model.Login(username, password)

        End Function

    End Class

End Namespace