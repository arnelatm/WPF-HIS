Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles
Imports AATM.Libraries.AatmInterfaces
Imports AATM.Libraries.GlobalFuncNSub

Public Class UcCheckBox
    Implements IEntryControl, IFindableControl, ILinkedLabel

    Private _displayOnly As Boolean
    Private _textToSearch As String
    Private clicked As Boolean = False
    Private _state As CheckBoxState = CheckBoxState.UncheckedNormal
    Private _text As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Translatable = True
        'If GlobalVariables.RightToLeftLayout Then
        RightToLeft = RightToLeft.No
        checkBox.BoxSize = New Size(12, 12)
        'RtlTranslateAlignment(align:=Drawing.ContentAlignment.MiddleRight)
        'Else
        '    RightToLeft = RightToLeft.No
        '    RtlTranslateAlignment(align:=Drawing.ContentAlignment.MiddleLeft)
        'End If
    End Sub

    <Category("Custom Properties")>
    <DefaultValue(CType(Nothing, String))>
    <Description("Security Key to use for this control.")>
    <Browsable(True)>
    Public Property SecurityKey As String

    '<Category("Custom Properties")>
    '<DefaultValue("UcCheckBox")>
    '<Description("Text to display for the control.")>
    '<Browsable(True)>
    'Public Property Caption As String

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    Public Overrides Property Text As String
        Get
            Return CLabel1.Text
        End Get
        Set(value As String)
            CLabel1.Text = value
        End Set
    End Property

    <EditorBrowsable(EditorBrowsableState.Always)>
    <Browsable(True)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    <Bindable(True)>
    Public Overrides Property Font As Font
        Get
            Return CLabel1.Font
        End Get
        Set(value As Font)
            CLabel1.Font = value
            MyBase.Font = value
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue("UcCheckBox")>
    <Description("Text to display for the control.")>
    <Browsable(True)>
    Public Property Checked As Boolean
        Get
            Return checkBox.Checked
        End Get
        Set(value As Boolean)
            checkBox.Checked = value
        End Set
    End Property

    <Category("Custom Properties")>
    <DefaultValue(False)>
    <Description("Set to True to specify that this control is Read Only .")>
    <Browsable(True)>
    Public Property DisplayOnly As Boolean
        Get
            Return _displayOnly
        End Get
        Set(value As Boolean)
            If _displayOnly = value Then Exit Property
            _displayOnly = value
            checkBox.DisplayOnly = value
        End Set
    End Property

    Public Property LinkedLabel As CLabel Implements ILinkedLabel.LinkedLabel

    'Private Sub UcCheckBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '    CLabel1.Text = Text
    'End Sub

    'Private Sub OnRefresh()
    '    CLabel1.Text = Text
    'End Sub

    Public Function GetControlDescription(Optional defaultDescription As String = Nothing) Implements ILinkedLabel.GetControlDescription
        Dim description As String
        If LinkedLabel Is Nothing OrElse LinkedLabel.Text Is Nothing OrElse LinkedLabel.Text = "" Then
            description = If(defaultDescription Is Nothing OrElse defaultDescription = "", Name, defaultDescription)
        Else
            description = LinkedLabel.Text
        End If
        Return description
    End Function

    Public Property EditingMode As Boolean Implements IEntryControl.EditingMode

    Public Property Translatable As Boolean Implements IEntryControl.Translatable

    Public Property FindDataType As IFindableControl.DataTypeEnum Implements IFindableControl.FindDataType
    Public Property FindEnabled As Boolean Implements IFindableControl.FindEnabled
    Public Property BegFindValue As Object Implements IFindableControl.BegFindValue
    Public Property EndFindValue As Object Implements IFindableControl.EndFindValue
    Public Property SearchPlace As IFindableControl.SearchPlaceEnum Implements IFindableControl.SearchPlace
    Public Property FieldName As String Implements IFindableControl.FieldName
    Public Property FieldDescription As String Implements IFindableControl.FieldDescription
    Public Property IgnoreCase As Boolean Implements IFindableControl.IgnoreCase
    Public ReadOnly Property FindDataSource As Object Implements IFindableControl.FindDataSource
    Public ReadOnly Property FindDisplayMember As String Implements IFindableControl.FindDisplayMember

    Public ReadOnly Property SearchMode As IFindableControl.SearchModeEnum Implements IFindableControl.SearchMode
        Get
            Return IFindableControl.SearchModeEnum.CheckBox
        End Get
    End Property

    Public ReadOnly Property FindValueMember As String Implements IFindableControl.FindValueMember

    Private Sub MenuItemFind_Click()
        If FindEnabled Then
            Dim myForm = FindForm()
            Dim pnt As Point
            Dim searchForm = New CFindForm(Me)
            Dim screenRectangle As Rectangle
            Dim formLocation As Point
            FieldName = Name.Substring(3)
            If LinkedLabel IsNot Nothing AndAlso LinkedLabel.Text <> "" Then
                searchForm.SetFieldDescription(LinkedLabel.Text)
            Else
                searchForm.SetFieldDescription(FieldName)
            End If
            screenRectangle = Screen.PrimaryScreen.WorkingArea
            searchForm.StartPosition = FormStartPosition.Manual
            pnt = myForm.PointToScreen(Location)
            If formLocation.Y + searchForm.Height > screenRectangle.Height Then
                formLocation.Y = pnt.Y - searchForm.Height + Height
            End If
            FindDataType = IFindableControl.DataTypeEnum.Boolean
            searchForm.Location = formLocation
            If LinkedLabel IsNot Nothing AndAlso LinkedLabel.Text <> "" Then
                searchForm.SetFieldDescription(LinkedLabel.Text)
            Else
                searchForm.SetFieldDescription(FieldName)
            End If
            searchForm.ShowDialog()
            searchForm.Dispose()

            CallByName(myForm, "FindFieldNew", CallType.Method, Me)
        Else
            AATM.Libraries.MessagingLibrary.Messaging.Show(True, "MsgNothingToFind")
        End If
        'Dim x = Me.GetType()
        'MessageBox.Show(x.ToString())
    End Sub

    Public Function GetTextToSearch() As String
        Return _textToSearch
    End Function

    Private Sub CLabel1_Click(sender As Object, e As EventArgs) Handles CLabel1.Click
        If checkBox.Checked Then
            checkBox.Checked = False
        Else
            checkBox.Checked = True
        End If
    End Sub

    'Protected Overrides Sub OnPaint(ByVal pEvent As PaintEventArgs)
    '    MyBase.OnPaint(pEvent)
    '    If GlobalVariables.RightToLeftLayout Then
    '        RightToLeft = RightToLeft.Yes
    '        RtlTranslateAlignment(align:=Drawing.ContentAlignment.MiddleRight)
    '    Else
    '        RightToLeft = RightToLeft.No
    '        RtlTranslateAlignment(align:=Drawing.ContentAlignment.MiddleLeft)
    '    End If
    'End Sub

End Class