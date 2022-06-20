Imports AATM.PresentationLayer.Models

Namespace PresentationLayer.Models

    ''' <summary>
    '''     The Model in MVP design pattern.
    '''     Implements IModel and communicates with WCF Service.
    ''' </summary>
    Public Class ReportModel
        'Implements IModelNew

        Public Property Errors As List(Of String)
        Public Property IdNo As Int16
        Public Property QueryForm As String
        Public Property QueryFormParameters As String
        Public Property ReportCode As String
        Public Property ReportFileName As String
        Public Property ReportGroup As String
        Public Property ReportName As String
        Public Property ReportNameAra As String
        Public Property QueryParameters As String
        Public Property ReportTitle As String
        Public Property ReportTitleAra As String
    End Class

End Namespace