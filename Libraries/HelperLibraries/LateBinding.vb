Imports System.Reflection

Public NotInheritable Class LateBinding

    Private Const InvokePublicMethod As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.InvokeMethod

    Private Const GetPublicProperty As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetProperty
    Private Const GetPublicField As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField

    Private Const SetPublicProperty As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetProperty
    Private Const SetPublicField As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetField

    Public Shared Function InvokeFunction(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object

        'Return oObject.InvokeMember(sName, InvokePublicMethod, Nothing, oObject, yArguments)
        Return oObject.GetType().InvokeMember(sName, InvokePublicMethod, Nothing, oObject, yArguments)

    End Function

    Public Shared Function GetProperty(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object

        'Return oObject.InvokeMember(sName, GetPublicProperty, Nothing, oObject, yArguments)
        Return oObject.GetType().InvokeMember(sName, GetPublicProperty, Nothing, oObject, yArguments)

    End Function

    Public Shared Function GetField(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object

        'Return oObject.InvokeMember(sName, GetPublicProperty, Nothing, oObject, yArguments)
        Return oObject.GetType().InvokeMember(sName, GetPublicField, Nothing, oObject, yArguments)

    End Function

    Public Shared Function SetProperty(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object

        'Return oObject.InvokeMember(sName, SetPublicProperty, Nothing, oObject, yArguments)
        Return oObject.GetType().InvokeMember(sName, SetPublicProperty, Nothing, oObject, yArguments)

    End Function

End Class