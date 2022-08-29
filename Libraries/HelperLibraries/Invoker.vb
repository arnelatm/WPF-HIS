Imports System.Reflection

Public NotInheritable Class Invoker

    Private Const InvokePublicMethodFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.InvokeMethod
    Private Const GetPublicPropertyFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetProperty
    Private Const GetPublicFieldFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.GetField
    Private Const SetPublicPropertyFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetProperty
    Private Const SetPublicNonPublicPropertyFieldFlags As BindingFlags = BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.SetProperty Or BindingFlags.SetField
    Private Const SetPublicFieldFlags As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.SetField
    Private Const SetPublicPropertyOnlyFlags As BindingFlags = BindingFlags.Public Or BindingFlags.SetProperty Or BindingFlags.Instance Or BindingFlags.SetField Or BindingFlags.Static Or BindingFlags.IgnoreCase

    Public Shared Function InvokeFunction(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, InvokePublicMethodFlags, Nothing, oObject, yArguments)
    End Function

    Public Shared Function InvokeProperty(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Return oObject.GetType().InvokeMember(sName, GetPublicPropertyFlags, Nothing, oObject, yArguments)
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
        Try
            Return oObject.GetType().InvokeMember(sName, SetPublicNonPublicPropertyFieldFlags, Nothing, oObject, yArguments)
        Catch ex As Exception
            Debugger.Break()
            Return Nothing
        End Try
    End Function

    'Public Shared Function SetPublicPropertyOnly(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
    '    ' ReSharper disable once VBPossibleMistakenCallToGetType.2
    '    dim retValue As Object 
    '    Try
    '        'retValue = oObject.GetType().InvokeMember(sName, GetPublicPropertyFlags, Nothing, oObject, yArguments, Nothing , Nothing, Nothing)
    '        'retValue = oObject.GetType().InvokeMember(sName, GetPublicPropertyFlags, Nothing, oObject, yArguments)
    '         retValue = oObject.GetType().InvokeMember(sName,  SetPublicNonPublicPropertyFieldFlags , Nothing, oObject, yArguments )
    '        'Return oObject.GetType().InvokeMember(sName, GetPublicPropertyFlags, Nothing, oObject, yArguments)
    '    Catch ex As Exception
    '        Return Nothing
    '    End Try
    '    Return retValue
    'End Function

    Public Shared Function SetField(ByVal oObject As Object, ByVal sName As String, ByVal ParamArray yArguments() As Object) As Object
        ' ReSharper disable once VBPossibleMistakenCallToGetType.2
        Try
            Return oObject.GetType().InvokeMember(sName, SetPublicFieldFlags, Nothing, oObject, yArguments)
        Catch ex As Exception
            Debugger.Break()
            Return nothing
        End Try
        Return nothing

    End Function

End Class