Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.ServicesLayer.Services

Public Class UserModel
    'Inherits Model

    Public Property IdNo As Int32
    Public Property UserName As String
    Public Property FullName As String
    Public Property FullNameAra As String
    Public Property Password As String
    Public Property SecurityLevel As Int16
    Public Property SecurityGroupIdNo As Int16

End Class