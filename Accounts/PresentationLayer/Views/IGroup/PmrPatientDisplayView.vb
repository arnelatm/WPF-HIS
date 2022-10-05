Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces.IGroup

    Public Class PmrPatientDisplayView
        Implements IPmrPatientDisplayView

        Public Property Token As String Implements IPmrPatientDisplayView.Token
        Public Property Status As String Implements IPmrPatientDisplayView.Status
        Public Property File_No As String Implements IPmrPatientDisplayView.File_No
        Public Property Name As String Implements IPmrPatientDisplayView.Name
        Public Property Type As String Implements IPmrPatientDisplayView.Type
        Public Property Inv_Type As String Implements IPmrPatientDisplayView.Inv_Type
        Public Property CreateDate As DateTime Implements IPmrPatientDisplayView.CreateDate
        Public Property Errors As List(Of String) Implements IView.Errors

    End Class

End Namespace