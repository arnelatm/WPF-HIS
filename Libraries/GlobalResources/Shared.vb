Imports System.Drawing

Public Class Icons

    Public Shared ReadOnly Property TreeNodeIcon() As Icon
        Get
            Return My.Resources.TreeNode
        End Get
    End Property

End Class

Public Class Images

    Public Shared ReadOnly Property GreenGradientBackgroundLarge() As Image
        Get
            Return My.Resources.GreenGradientBackgroundLarge
        End Get
    End Property

    Public Shared ReadOnly Property GreenPlainBackgroundLarge() As Image
        Get
            Return My.Resources.GreenPlainBackGroundLarge
        End Get
    End Property

    Public Shared ReadOnly Property YellowGradientBackgroundLarge() As Image
        Get
            Return My.Resources.YellowGradientBackgroundLarge
        End Get
    End Property

    Public Shared ReadOnly Property YellowPlainBackgroundLarge() As Image
        Get
            Return My.Resources.YellowPlainBackgroundLarge
        End Get
    End Property

    Public Shared ReadOnly Property GreenPlainBackgroundSmall() As Image
        Get
            Return My.Resources.GreenPlainBackGroundSmall
        End Get
    End Property

    Public Shared ReadOnly Property YellowPlainBackgroundSmall() As Image
        Get
            Return My.Resources.YellowPlainBackgroundSmall
        End Get
    End Property

    Public Shared ReadOnly Property FirstImage() As Image
        Get
            Return My.Resources.btnfirst
        End Get
    End Property

    Public Shared ReadOnly Property NextImage() As Image
        Get
            Return My.Resources.btnnext
        End Get
    End Property

    Public Shared ReadOnly Property PreviousImage() As Image
        Get
            Return My.Resources.btnprev
        End Get
    End Property

    Public Shared ReadOnly Property LastImage() As Image
        Get
            Return My.Resources.btnlast
        End Get
    End Property

    Public Shared ReadOnly Property AddImage() As Image
        Get
            Return My.Resources.btnadd
        End Get
    End Property

    Public Shared ReadOnly Property DeleteImage() As Image
        Get
            Return My.Resources.btndelete
        End Get
    End Property

    Public Shared ReadOnly Property QuitImage() As Image
        Get
            Return My.Resources.btnquit
        End Get
    End Property

    Public Shared ReadOnly Property UndoImage() As Image
        Get
            Return My.Resources.btnundo
        End Get
    End Property

    Public Shared ReadOnly Property SaveImage() As Image
        Get
            Return My.Resources.btnsave
        End Get
    End Property

    Public Shared ReadOnly Property FindImage() As Image
        Get
            Return My.Resources.btnfind
        End Get
    End Property

    Public Shared ReadOnly Property InsertRowImage() As Image
        Get
            Return My.Resources.insertrow
        End Get
    End Property

    'Public Shared ReadOnly Property YellowGradientButtonBackGround() As Image
    '    Get
    '        Return My.Resources.YellowGradientButtonBackGround
    '    End Get
    'End Property

    Public Shared ReadOnly Property CurrentSelectionImage() As Image
        Get
            Return My.Resources.openbriefcase
        End Get
    End Property

End Class

Public Class Strings

    Public Shared ReadOnly Property HijriCalendarMarker() As String
        Get
            Return My.Resources.HijriCalendarMarker
        End Get
    End Property

    Public Shared ReadOnly Property UmAlQuraCalendarMarker() As String
        Get
            Return My.Resources.UmAlQuraCalendarMarker
        End Get
    End Property

    Public Shared ReadOnly Property GregorianCalendarMarker() As String
        Get
            Return My.Resources.GregorianCalendarMarker
        End Get
    End Property

End Class
