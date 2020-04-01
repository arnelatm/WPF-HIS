Imports System.Windows.Forms

Public Class BaseForm

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal transDac As Dac, ByVal appDac As Dac)
        MyBase.New()
        ' This call is required by the designer.
        InitializeComponent()

        TranslatorDAC = transDac
        AppdataDAC = appDac

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Dim _captionCollection As New Collection
    Dim _originalText As String
    Dim MenuLevel As String = ""
    Public Dv As DataView

    Private Sub BaseForm_Load(
     ByVal sender As Object,
     ByVal e As EventArgs) _
    Handles MyBase.Load

        If Not DesignMode Then
            Dim ds As DataSet
            ds = TranslatorDAC.ReturnDs(
                 "Select lang from languages")
            cmbLanguagePicker.Items.Clear()
            For Each dr As DataRow In ds.Tables(0).Rows
                cmbLanguagePicker.Items.Add(dr("lang"))
            Next
            _captionCollection = StoreCaptions1.StoreCaptions(Me)
        End If

    End Sub

#Region " Events "

    Sub cmbLanguagePicker_SelectedIndexChanged(
      ByVal sender As Object,
      ByVal e As EventArgs) _
     Handles cmbLanguagePicker.SelectedIndexChanged

        If Not DesignMode Then
            Dim cmd As String
            cmd = "Select Caption, translated from TranslatedCaption where lang = '" + cmbLanguagePicker.Text + "'"
            Dim translations As DataSet
            translations = TranslatorDAC.ReturnDs(cmd)
            Dv = translations.Tables(0).DefaultView
            Dv.Sort = "Original"
            Dim r As Integer
            If Tag Is Nothing Then
                r = 0
            Else
                r = Dv.Find(Tag.ToString.TrimEnd)
            End If
            If r >= 0 Then
                Text = Dv(r).Item("translated")
            Else
                Text = Tag
            End If
            For Each ctrl As Control In Controls
                If IsTranslatable(ctrl) Then
                    _originalText = _captionCollection.Item(ctrl.Name)
                    r = Dv.Find(_originalText)
                    If TypeOf ctrl Is DataGrid Then
                        If r >= 0 Then
                            CType(ctrl, DataGrid).CaptionText = Dv(r).Item(1)
                        Else
                            CType(ctrl, DataGrid).CaptionText = ctrl.Tag
                        End If
                    Else
                        If r >= 0 Then
                            ctrl.Text = Dv(r).Item("translated")
                        Else
                            ctrl.Text = ctrl.Tag
                        End If

                    End If
                End If
            Next
            If Not Menu Is Nothing Then
                ProcessMenuItems(Menu.MenuItems, MenuLevel)
            End If
        End If

    End Sub

    Function IsTranslatable(ByVal ctrl As Control) As Boolean
        If TypeOf ctrl Is Label _
            Or TypeOf ctrl Is Button _
            Or TypeOf ctrl Is CheckBox _
            Or TypeOf ctrl Is RadioButton _
            Or TypeOf ctrl Is DataGrid _
            Or TypeOf ctrl Is GroupBox Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub ProcessMenuItems(ByVal menuItems As Menu.MenuItemCollection, ByVal mLevel As String)
        Dim i As Int16
        For i = 0 To menuItems.Count - 1
            Dim mi As MenuItem = menuItems(i)
            Dim localMLevel As String = mLevel + i.ToString
            _originalText = _captionCollection.Item(localMLevel)
            Dim r As Integer = Dv.Find(_originalText)
            If r >= 0 Then mi.Text = Dv(r).Item("translated") _
                   Else mi.Text = _originalText
            If mi.MenuItems.Count > 0 Then _
            ProcessMenuItems(mi.MenuItems, localMLevel)
        Next
    End Sub

#End Region

End Class