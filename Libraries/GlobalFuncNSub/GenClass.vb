Imports System.Linq.Expressions
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

Class Test(Of T As {Structure, IConvertible})
    Private Shared _getInt As Func(Of Integer, T)

    Sub New()
        Dim param = Expression.Parameter(GetType(Integer), "x")
        Dim body As UnaryExpression = Expression.Convert(param, GetType(T))
        _getInt = Expression.Lambda(Of Func(Of Integer, T))(body, param).Compile()
    End Sub

    Public Shared Function TestFunction(ByVal x As T) As T
        Dim n As Integer = Convert.ToInt32(x)
        Dim result As T = _getInt(n)
        Return result
    End Function
End Class

Class Cast(Of T, U)
    Public Shared ReadOnly [Do] As Func(Of T, U)

    Shared Sub New()
        Dim par1 = Expression.Parameter(GetType(T))
        [Do] = Expression.Lambda(Of Func(Of T, U))(Expression.Convert(par1, GetType(U)), par1).Compile()
    End Sub
End Class