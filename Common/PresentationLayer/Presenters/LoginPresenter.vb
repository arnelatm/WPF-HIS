Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.DataLayer.AdoNet
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views
Imports AATM.ServicesLayer.Services

Namespace PresentationLayer.Presenters

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
            TableName = "Login"
            OriginalModel = New LoginModel()
            BizObject = New Login
            DataModel = New LoginModel
            DbDataDao = New LoginDao
            Dim myService = New LoginService()
            'Service = myService
            CommonModel.SetService(myService)
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
            Return CommonModel.Login(username, password)

        End Function

    End Class

End Namespace