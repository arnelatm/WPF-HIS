Imports System.Windows.Forms
Imports System.Windows.Forms.TabControl

Public Class CTabPageCollection
    Inherits TabPageCollection
    
    Public Sub New()
        MyBase.New(Me)


    End Sub

    Default Public Overrides Property Item(index As Integer) As TabPage
        Get
            Return MyBase.Item(index)
        End Get
        Set(value As TabPage)
            MyBase.Item(index) = value
        End Set
    End Property

    Default Public Overrides ReadOnly Property Item(key As String) As TabPage
        Get
            Return MyBase.Item(key)
        End Get
    End Property

    Public Overrides Sub Clear()
        MyBase.Clear()
    End Sub

    Public Overrides Sub RemoveByKey(key As String)
        MyBase.RemoveByKey(key)
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Overrides Function ToString() As String
        Return MyBase.ToString()
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return MyBase.GetHashCode()
    End Function

    Public Overrides Function ContainsKey(key As String) As Boolean
        Return MyBase.ContainsKey(key)
    End Function

    Public Overrides Function IndexOfKey(key As String) As Integer
        Return MyBase.IndexOfKey(key)
    End Function
End Class
