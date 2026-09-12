Imports System.Globalization

Namespace PresentationLayer.Views.Forms
    Public Class GeneralAccountPositionForm
        Inherits CashPositionForm

        Protected Overrides ReadOnly Property ReportTitle As String
            Get
                Return If(CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, "حركة الحسابات العامة", "General Account Position")
            End Get
        End Property

        Protected Overrides ReadOnly Property ShowsCashScopeSetup As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides ReadOnly Property ShowsClosingEntriesOption As Boolean
            Get
                Return True
            End Get
        End Property

        Protected Overrides ReadOnly Property SelectAllAccountsByDefault As Boolean
            Get
                Return False
            End Get
        End Property

        Protected Overrides ReadOnly Property UsesAccountTree As Boolean
            Get
                Return True
            End Get
        End Property

        Public Overrides ReadOnly Property IsGeneralAccountPosition As Boolean
            Get
                Return True
            End Get
        End Property
    End Class
End Namespace
