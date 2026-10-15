Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Interfaces
    Public Interface IContactView
        Inherits IView
        ReadOnly Property UseArabicNames As Boolean
        Property IdNo As Int32
        Property ContactCode As String
        Property ContactName As String
        Property ContactNameAra As String
        Property CSECode As String
        Property CSEIdNo As Int32
    End Interface
End Namespace
