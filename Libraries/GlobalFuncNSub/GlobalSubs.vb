Imports System.Globalization
Imports System.Reflection
Imports System.Runtime.Remoting
Imports System.Windows.Forms

Public Module GlobalSubs

#Region "Old Subs"

    Public Sub SetPropertyValue(obj As Object, propName As String, propValue As Object, Optional ByVal ignoreException As Boolean = False)
        'If propName = "EditingMode" Then
        '    Debugger.Break()
        'End If
        Dim objType As Type = obj.GetType()
        Dim pInfo As PropertyInfo = objType.GetProperty(propName,
                                                        BindingFlags.IgnoreCase Or BindingFlags.IgnoreCase Or
                                                        BindingFlags.Public Or BindingFlags.Instance)
        If pInfo IsNot Nothing Then
            'Dim pInfo As System.Reflection.PropertyInfo = objType.GetProperty(PropName, Reflection.BindingFlags.GetProperty)
            Try
                'If  objType.FullName = "AATM.CCustomControls.CCustomDateTimePicker" Then
                '   Debugger.Break
                'End If
                pInfo.SetValue(obj, propValue) ', BindingFlags.GetProperty, Nothing, Nothing, Nothing)
            Catch ex As Exception
                Debugger.Break()
                If Not ignoreException Then
                    MessageBox.Show("Invalid property " & propName & " in object " & obj.Name)
                    Throw
                    ' not set
                End If
            End Try
        End If
    End Sub

    Public Sub SwapPosition(c1 As Control, c2 As Control)
        Dim tlp As TableLayoutPanel = TryCast(c1.Parent, TableLayoutPanel)
        If tlp Is c2.Parent AndAlso tlp IsNot Nothing Then
            Dim posC1 As TableLayoutPanelCellPosition = tlp.GetCellPosition(c1)
            Dim posC2 As TableLayoutPanelCellPosition = tlp.GetCellPosition(c2)
            tlp.SetCellPosition(c2, posC1)
            tlp.SetCellPosition(c1, posC2)
        End If
    End Sub

    'Public Function InvokeMethod(ByVal obj As Object, ByVal methodName As String, ByVal propValue As Object, ByVal ParamArray arguments() As Object) As Integer
    '    Dim objType As Type = obj.GetType()
    '    Dim pInfo As System.Reflection.PropertyInfo = objType.GetProperty(methodName, Reflection.BindingFlags.IgnoreCase Or Reflection.BindingFlags.IgnoreCase Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance)

    '    Try
    '        'obj.GetType.InvokeMember(methodName, Reflection.BindingFlags.InvokeMethod Or Reflection.BindingFlags.Public Or Reflection.BindingFlags.CreateInstance , nothing, obj, arguments  )
    '        'obj.GetType.InvokeMember(methodName, Reflection.BindingFlags.InvokeMethod or Reflection.BindingFlags.Public Or Reflection.BindingFlags.FlattenHierarchy , nothing, obj, arguments  )
    '        Dim obj2 As Object = Activator.CreateInstance(obj)
    '        obj2.GetType.InvokeMember("UpdateRevCostCenter", Reflection.BindingFlags.InvokeMethod Or Reflection.BindingFlags.IgnoreCase, Nothing, obj2, arguments)

    '    Catch ex As Exception
    '        MessageBox.Show("Invalid property " & methodName & " in object " & obj.Name)
    '        Throw ex
    '        ' not set
    '        Dim i = 0
    '    End Try
    'End Function

    'Private Const InvokePublicMethod As BindingFlags = BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.InvokeMethod

    'Public Function InvokeFunction(ByVal obj As Object, ByVal sName As String, ByVal ParamArray arguments() As Object) As Object

    '    Return obj.GetType().InvokeMember(sName, InvokePublicMethod, Nothing, obj , Arguments)

    'End Function

    Public Sub MapObject(Of TS, TT)(ByRef source As TS, ByRef target As TT, Optional ByVal MainFieldsDictionary As Dictionary(Of String, String) = Nothing)
        Dim tPropertyInfos = target.GetType().GetProperties()
        Dim sPropertyInfos = source.GetType().GetProperties()
        Dim comparer = StringComparer.OrdinalIgnoreCase
        Dim tDictionary = New Dictionary(Of String, Int16)(comparer)
        Dim sDictionary = New Dictionary(Of String, Int16)(comparer)
        Dim i As Int16 = 1
        For Each propertyInfo As PropertyInfo In tPropertyInfos
            Dim pName = propertyInfo.Name
            tDictionary.Add(pName, i)
            i += 1
        Next
        i = 1
        For Each propertyInfo As PropertyInfo In sPropertyInfos
            Dim pName = propertyInfo.Name
            sDictionary.Add(pName, i)
            i += 1
        Next
        Dim sourcePropertyName As String
        Dim targetPropertyName As String = ""
        Dim j As Int16 = 0
        For Each s As PropertyInfo In sPropertyInfos
            sourcePropertyName = s.Name
            If MainFieldsDictionary IsNot Nothing Then
                MainFieldsDictionary.TryGetValue(s.Name, targetPropertyName)
                If targetPropertyName Is Nothing Then
                    targetPropertyName = sourcePropertyName
                End If
            Else
                targetPropertyName = sourcePropertyName
            End If
            Dim iIndex As Int16
            Dim t As PropertyInfo
            tDictionary.TryGetValue(targetPropertyName, iIndex)
            ' the above procedure will give a iIndex of zero if "targetPropertyName" is not found
            ' but 0 is also a valid return value for array
            ' so to avoid this I used 1 as the base value for index and just subtract 1 when gettning the desired value
            If iIndex <> 0 Then
                t = tPropertyInfos(iIndex - 1)  ' subtract 1 since base value started with 1
                'MessageBox.Show(t.GetIndexParameters().ToString())
                If t.Name.ToLower() = "journalitems" Then
                    'Debugger.Break
                Else
                    t.SetValue(target, s.GetValue(source))
                End If

            End If
        Next
    End Sub

    'Public Sub MapObject(ByRef source As Object, ByRef target As Object)
    '    Dim propList = target.GetType().GetProperties()
    '    For Each t As PropertyInfo In propList
    '        For Each s As PropertyInfo In source.GetType().GetProperties()
    '            If t.SetMethod IsNot Nothing AndAlso t.Name.ToLower() = s.Name.ToLower() Then
    '                'If t.Name.ToLower() = "parentidno" Then
    '                '    Dim x As Integer = 0
    '                'End If
    '                t.SetValue(target, s.GetValue(source))
    '                Exit For
    '            End If
    '        Next
    '    Next
    'End Sub

    'Public Sub MapObject(OF TS, TT)(ByRef source As TS, ByRef target As TT)
    '    Dim propertyInfos = target.GetType().GetProperties()
    '    For Each propertyInfo As System.Reflection.PropertyInfo In propertyInfos
    '        For Each s As System.Reflection.PropertyInfo In source.GetType().GetProperties()
    '            If propertyInfo.Name.ToLower() = s.Name.ToLower() Then
    '                propertyInfo.SetValue(target, s.GetValue(Source))
    '                Exit For
    '            End If
    '        Next
    '    Next
    'End Sub

    Public Sub MapObject2(ByRef source As Object, target As Object)
        Dim propList = target.GetType().GetProperties()
        For Each t As PropertyInfo In propList
            For Each s As PropertyInfo In source.GetType().GetProperties()
                If t.Name.ToLower() = s.Name.ToLower() Then
                    t.SetValue(target, s.GetValue(source))
                    Exit For
                End If
            Next
        Next
    End Sub

    Public Sub AdjustForMinimumDate(ByRef dateVar As Date?, Optional dDate As Date? = #0001-01-01#)
        If dateVar Is Nothing OrElse dateVar < dDate Then
            MessageBox.Show("Date can't be less than " + CDate(dDate).ToLongDateString())
            dateVar = CDate(dDate)
            Beep()
        End If
    End Sub

    Public Sub AdjustForMaximumDate(ByRef dateVar As Date?, Optional dDate As Date? = #2999-12-31#)
        If dateVar Is Nothing OrElse dateVar > dDate Then
            MessageBox.Show("Date can't be more than " + CDate(dDate).ToLongDateString())
            dateVar = CDate(dDate)
            Beep()
        End If
    End Sub


    Public Enum CalendarToUse
        Gregorian = 0
        Hijri = 1
        UmAlQura = 2
    End Enum

    Public Sub Caller(classType As Type, classMethod As String, ByRef methodParameter As Object)
        ' Get a type from the string
        'Dim type As Type = Type.GetType(className)
        ' Create an instance of that type
        'Dim obj As Object = Activator.CreateInstance(classType)
        '' Retrieve the method you are looking for
        'Dim methodInfo As MethodInfo = type.GetMethod(classMethod)
        '' Invoke the method on the instance we created above
        'methodInfo.Invoke(obj, methodParameter)
    End Sub

    Public Sub ShowAndEnableMenuItems(ByRef obj As MenuStrip)
        obj.Enabled = True
        obj.Visible = True
        SetVisibleAndEnableOfToolStripMenuItem(True, obj.Items)
    End Sub

    Public Sub HideAndDisableMenuItems(ByRef obj As MenuStrip)
        obj.Enabled = False
        obj.Visible = False
        SetVisibleAndEnableOfToolStripMenuItem(False, obj.Items)
    End Sub

    Private Sub SetVisibleAndEnableOfToolStripMenuItem(ByVal action As Boolean, ByRef toolStripItemCollection As ToolStripItemCollection)
        For Each toolStripItem As Object In toolStripItemCollection
            Dim subMenu As ToolStripMenuItem = TryCast(toolStripItem, ToolStripMenuItem)
            If subMenu IsNot Nothing Then
                subMenu.Enabled = action
                subMenu.Visible = action
                If subMenu.HasDropDown Then
                    Dim childToolStripItemCollection = subMenu.DropDownItems
                    SetVisibleAndEnableOfToolStripMenuItem(action, childToolStripItemCollection)
                End If
            End If
        Next
    End Sub

#End Region

    Public Sub Gobble(dummy As Object)
        ' dummy sub to instantiate an object without assigning to a variable
    End Sub


End Module