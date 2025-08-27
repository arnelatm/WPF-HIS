Imports System.Windows.Forms
Imports AATM.Libraries.GlobalFuncNSub

Namespace Services.Security
    ' Applies visibility / enabled logic using provided lambdas so we decouple from Presenter and GlobalVariables direct use in the view.
    Public Class SecurityApplier
        Private ReadOnly _isSuperAdminFunc As Func(Of Boolean)
        Private ReadOnly _isUserLoggedInFunc As Func(Of Boolean)
        Private ReadOnly _securityGroupIdFunc As Func(Of Integer)
        Private ReadOnly _getSecurityIdFunc As Func(Of String, Boolean, Long)
        Private ReadOnly _getUserSecurityFunc As Func(Of Long, Integer, ArrayList)

        Public Sub New(isSuperAdmin As Func(Of Boolean),
                       isLoggedIn As Func(Of Boolean),
                       securityGroupId As Func(Of Integer),
                       getSecurityId As Func(Of String, Boolean, Long),
                       getUserSecurity As Func(Of Long, Integer, ArrayList))
            _isSuperAdminFunc = isSuperAdmin
            _isUserLoggedInFunc = isLoggedIn
            _securityGroupIdFunc = securityGroupId
            _getSecurityIdFunc = getSecurityId
            _getUserSecurityFunc = getUserSecurity
        End Sub

        Public Sub ApplyMenuStrip(menu As MenuStrip, menuRootPath As String)
            If menu Is Nothing Then Return
            ApplyToolStripSecurity(menu.Items, menuRootPath & " > " & menu.Name.Trim())
        End Sub

        Public Sub ApplyToolStrip(tool As ToolStrip, menuRootPath As String)
            If tool Is Nothing Then Return
            ApplyToolStripSecurity(tool.Items, menuRootPath & " > " & tool.Name.Trim())
        End Sub

        Public Sub ApplyControl(ctrl As Control, securityKey As String)
            If String.IsNullOrWhiteSpace(securityKey) Then Return
            Dim visible As Boolean, selectable As Boolean
            Evaluate(securityKey, False, visible, selectable)
            ctrl.Visible = visible OrElse _isSuperAdminFunc()
            If Not selectable Then
                SetPropertyValue(ctrl, "DisplayOnly", True)
            End If
        End Sub

        Private Sub ApplyToolStripSecurity(items As ToolStripItemCollection, basePath As String)
            For Each itm As ToolStripItem In items
                Dim submenu = TryCast(itm, ToolStripMenuItem)
                If submenu IsNot Nothing Then
                    Dim key = basePath & " > " & TrimMenuPrefix(submenu.Name)
                    Dim visible As Boolean, selectable As Boolean
                    Evaluate(key, True, visible, selectable)
                    submenu.Visible = visible OrElse _isSuperAdminFunc()
                    submenu.Enabled = selectable OrElse _isSuperAdminFunc()
                    If submenu.HasDropDown Then
                        ApplyToolStripSecurity(submenu.DropDownItems, basePath & " > " & TrimMenuPrefix(submenu.Name))
                    End If
                    Continue For
                End If

                Dim btn = TryCast(itm, ToolStripButton)
                If btn IsNot Nothing Then
                    Dim key = basePath & " > " & TrimToolButtonPrefix(btn.Name)
                    Dim visible As Boolean, selectable As Boolean
                    Evaluate(key, True, visible, selectable)
                    btn.Visible = visible OrElse _isSuperAdminFunc()
                    btn.Enabled = selectable OrElse _isSuperAdminFunc()
                End If
            Next
        End Sub

        Private Sub Evaluate(key As String, objIsMenu As Boolean, ByRef isVisible As Boolean, ByRef isSelectable As Boolean)
            If _isSuperAdminFunc() Then
                isVisible = True : isSelectable = True : Return
            End If
            If Not _isUserLoggedInFunc() Then
                isVisible = True : isSelectable = False : Return
            End If
            Dim secId = _getSecurityIdFunc(key, objIsMenu)
            If secId = 0 Then
                isVisible = True : isSelectable = True
                Return
            End If
            Dim grp = _securityGroupIdFunc()
            If grp = 0 Then
                isVisible = True : isSelectable = False
                Return
            End If
            Dim vals = _getUserSecurityFunc(secId, grp)
            If vals IsNot Nothing AndAlso vals.Count >= 2 Then
                isVisible = CBool(vals(0))
                isSelectable = CBool(vals(1))
            Else
                isVisible = False
                isSelectable = False
            End If
        End Sub

        Private Shared Function TrimMenuPrefix(name As String) As String
            Const prefix = "ToolStripMenuItem"
            If name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) Then
                Return name.Substring(prefix.Length)
            End If
            Return name
        End Function

        Private Shared Function TrimToolButtonPrefix(name As String) As String
            Const prefix = "ToolStripButton"
            If name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase) Then
                Return name.Substring(prefix.Length)
            End If
            Return name
        End Function
    End Class
End Namespace