Imports System.Drawing
Imports System.Threading
Imports System.Windows.Forms

Public Class LoadingForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Button1 = New Button()
        With Button1
            .Location = New Point(15, 55)
            .Size = New Size(240, 20)
            .Text = "Set text safely"
        End With
        _picBox1 = New PictureBox()
        With _picBox1
            .Location = New Point(15, 15)
            .Size = New Size(200, 200)
        End With
        WritePicSafe(My.Resources.loading)
        'Controls.Add(Button1)
        Controls.Add(_picBox1)
    End Sub

    Public Shared Sub Main()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.EnableVisualStyles()
        Dim frm As New LoadingForm()
        Application.Run(frm)
    End Sub

    Dim WithEvents Button1 As Button
    ReadOnly _picBox1 As PictureBox
    Dim _thread2 As Thread = Nothing

    Delegate Sub SafeCallDelegate(pic As Image)

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        _thread2 = New Thread(New ThreadStart(AddressOf SetPic))
        _thread2.Start()
        Thread.Sleep(1000)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        _thread2 = New Thread(New ThreadStart(AddressOf SetText))
        _thread2.Start()
        Thread.Sleep(1000)
    End Sub

    Private Sub WriteTextSafe(text As String)
        If _picBox1.InvokeRequired Then
            Dim d As New SafeCallDelegate(AddressOf SetText)
            Invoke(d, New Object() {text})
        Else
            _picBox1.Text = text
        End If
    End Sub

    Private Sub SetText()
        WriteTextSafe("This text was set safely.")
    End Sub

    Private Sub WritePicSafe(pic As Image)
        If _picBox1.InvokeRequired Then
            Dim d As New SafeCallDelegate(AddressOf SetPic)
            Invoke(d, New Object() {pic})
        Else
            _picBox1.Image = pic
        End If
    End Sub

    Private Sub SetPic()
        WritePicSafe(My.Resources.loading)
    End Sub

End Class