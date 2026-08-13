Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ReportModel
        'Implements IModelNew

        Public Property Active As Boolean
        Public Property BranchIdNo As Int16
        Public Property DatabaseName As String
        Public Property DateCreated As DateTime
        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property PrintJobIdNo As Int16
        Public Property QueryForm As String
        Public Property QueryFormParameters As String
        Public Property QueryParameters As String
        Public Property PromptParameterNames As String
        Public Property RepeatPromptAfterClose As Boolean
        Public Property ReportCode As String
        Public Property ReportFileName As String
        Public Property ReportGroupIdNo As Int16
        Public Property ReportName As String
        Public Property ReportNameAra As String
        Public Property ReportOrder As Int32
        Public Property ReportTitle As String
        Public Property ReportTitleAra As String


    End Class

End Namespace
