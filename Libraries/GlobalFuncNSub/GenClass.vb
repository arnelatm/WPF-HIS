Imports System.Reflection

Public Class GenClass(Of T)
    Private _myCollection As IList(Of T)

    Public Property MyProperty As IList(Of T)
        Get
            Return Me._myCollection
        End Get
        Set
            Me._myCollection = Value
        End Set
    End Property

End Class

Public Class GenericModel(Of T)
    Private _myModel As T

    Public Property MyModel As T
        Get
            Return Me._myModel
        End Get
        Set
            Me._myModel = Value
        End Set
    End Property

End Class

<AttributeUsage(AttributeTargets.Field)>
Public Class EnumCode
    Inherits System.Attribute
    Public Property EnumCode As String

    Public Sub New(value As String)
        EnumCode = value
    End Sub

End Class

Public Class Parser(Of T As Structure)

    Delegate Function ParserFunction(ByVal value As String) As T

    Public Shared ReadOnly Parser As ParserFunction = GetFunction()

    Private Shared Function GetFunction() As ParserFunction
        Dim t As Type = GetType(T)
        Dim m As MethodInfo = t.GetMethod("Parse", New Type() {GetType(String)})
        Dim d As ParserFunction = DirectCast(
                ParserFunction.CreateDelegate(GetType(ParserFunction), m),
                ParserFunction)
        Return d
    End Function

End Class