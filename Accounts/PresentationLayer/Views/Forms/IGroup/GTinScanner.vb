Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class GTinScanner

    Public Event ValidateQrCode(ByRef valid As Boolean)

    Public Property Expiry As String
    Public Property Manufacture As String
    Public Property GTin As String
    Public Property BatchNo As String
    Public Property SerializationNo As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub txtQrCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQrCode.KeyPress

        Dim i As Integer = Me.txtQrCode.SelectionStart 'save for later use

        Select Case Asc(e.KeyChar)

            Case 29 'GS

                Me.txtQrCode.Text = Me.txtQrCode.Text.Insert(Me.txtQrCode.SelectionStart, "<GS>")

                Me.txtQrCode.SelectionStart = i + 5

                e.Handled = True

        End Select

    End Sub

    Private Sub CTextBox1_Validated(sender As Object, e As EventArgs) Handles txtQrCode.Validated
        GlobalFunctions.ProcessQrCode(txtQrCode.Text, GTin, BatchNo, Expiry, SerializationNo, Manufacture)
        Me.Hide()
    End Sub

End Class