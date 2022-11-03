Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class BranchEntryTv
        Implements IBranchView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtBranchCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IBranchView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property BranchCode As String Implements IBranchView.BranchCode
            Get
                Return txtBranchCode.Text
            End Get
            Set
                txtBranchCode.Text = Value
            End Set
        End Property

        Public Property BranchName As String Implements IBranchView.BranchName
            Get
                Return txtBranchName.Text
            End Get
            Set
                txtBranchName.Text = Value
            End Set
        End Property

        Public Property BranchNameAra As String Implements IBranchView.BranchNameAra
            Get
                Return txtBranchNameAra.Text
            End Get
            Set
                txtBranchNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IBranchView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"BranchCode", txtBranchCode},
                {"BranchName", txtBranchName},
                {"BranchNameAra", txtBranchNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

        Private Sub CButton1_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea

            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText("C:\temp\DrugQrCode.txt")

            Dim data As Byte()
            data = convertQPToByteArray(fileReader)
            Dim message As String = "Text Length = " + data.Count().ToString() + vbLf
            Dim myByte() As Byte = data
            Dim i As Int16 = 1
            For Each x In myByte
                i += 1
                message += i.ToString("####") + " - " + x.ToString() + vbLf
            Next
            MessageBox.Show(message)
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton2.ClickButtonArea
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText("C:\temp\DrugQrCode.txt")

            Dim message As String = "Text Length = " + Len(txtNotes.Text).ToString() + vbLf
            For i = 1 To Len(txtNotes.Text)
                Dim x = Mid(txtNotes.Text, i, 1)
                message += i.ToString("####") + " - " + Mid(txtNotes.Text, i, 1) + vbLf
            Next
            MessageBox.Show(message)
        End Sub

        Private Function convertQPToByteArray(ByVal qpString As String) As Byte()
            Dim c As Integer = 0
            Dim i As Integer = 0

            While i < qpString.Length
                If qpString(i) = "="c Then i += 2
                i += 1
                c += 1
            End While

            Dim binaryData As Byte() = New Byte(c - 1) {}
            Dim zero As Integer = Convert.ToInt16("0"c)
            c = 0
            i = 0

            While i < qpString.Length

                If qpString(i) = "="c Then
                    binaryData(c) = CByte(Integer.Parse(qpString.Substring(i + 1, 2), System.Globalization.NumberStyles.HexNumber))
                    i += 2
                Else
                    binaryData(c) = Convert.ToByte(qpString(i))
                End If

                i += 1
                c += 1
            End While

            Return binaryData

        End Function

    End Class

End Namespace