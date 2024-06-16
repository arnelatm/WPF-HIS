Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.ServicesLayer.Services

Public Class UserModel
    'Inherits Model

    Public Property Active As Boolean
    Public Property IdNo As Int16
    Public Property UserName As String
    Public Property EmployeeIdNo As Int32?
    Public Property Password As String
    Public Property SecurityLevel As Int16
    Public Property SecurityGroupIdNo As Int16

End Class

Public Class UserSecurityModel
    Inherits UserModel

    Public UserAccesses As List(Of UserAccessModel)

End Class
