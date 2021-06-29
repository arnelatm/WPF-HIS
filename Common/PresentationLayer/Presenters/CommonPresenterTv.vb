Imports System.ComponentModel
Imports System.Globalization
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Presenters

    Public Class CommonPresenterTv(Of T As IView, TM As New)
        Inherits CommonPresenter(Of T, TM)

        Public Sub New(itemView As T)
            MyBase.New(itemView)
        End Sub

        Public Overridable Sub InitializerWithTv(baseClassName As String, Optional bizParams As Object = Nothing, Optional daoParams As Object = Nothing)
            TreeViewMainField = baseClassName + "Name"
            TreeViewSecondaryField = baseClassName + "Code"
            TreeViewList = New List(Of TM)
            Initializer(baseClassName, bizParams, daoParams)
        End Sub

    End Class

End Namespace