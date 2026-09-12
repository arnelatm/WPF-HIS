Imports System.Globalization
Imports System.Resources

Namespace PresentationLayer.Views.Forms
    Friend Module CashPositionText
        Private ReadOnly Captions As New ResourceManager(
            "AATM.Accounts.PresentationLayer.Views.Forms.CashPositionForm", GetType(CashPositionForm).Assembly)

        Friend Function Caption(key As String) As String
            Return If(Captions.GetString(key, CultureInfo.CurrentCulture),
                      Captions.GetString("CashPositionLoadFailed", CultureInfo.CurrentCulture))
        End Function
    End Module
End Namespace
