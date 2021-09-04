Imports System.Reflection

Public NotInheritable Class Invoker

    Private Const InvokePublicMethodFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.InvokeMethod
    Private Const GetPublicPropertyFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetProperty
    Private Const GetPublicFieldFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField
    Private Const SetPublicPropertyFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetProperty
    Private Const SetPublicNonPublicPropertyFieldFlags As BindingFlags = BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty Or BindingFlags.SetField
    Private Const SetPublicFieldFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetField

    Public Shared Function InvokeFunction(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, InvokePublicMethodFlags, Nothing, oObject, yArguments)
    End Function

    Public Shared Function GetProperty(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, GetPublicPropertyFlags, Nothing, oObject, yArguments)
    End Function

    Public Shared Function GetField(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, GetPublicFieldFlags, Nothing, oObject, yArguments)
    End Function

    Public Shared Function SetPublicProperty(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, SetPublicPropertyFlags, Nothing, oObject, yArguments)
    End Function

    Public Shared Function SetProperty(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, SetPublicNonPublicPropertyFieldFlags, Nothing, oObject, yArguments)
    End Function

    Public Shared Function SetField(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, SetPublicFieldFlags, Nothing, oObject, yArguments)

    End Function

End Class