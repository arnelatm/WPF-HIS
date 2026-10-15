Imports System.Drawing
Imports System.Windows.Forms
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    Public Class ContactViewer
        Inherits CFormEntryTv
        Implements IContactView

        Public ReadOnly Property UseArabicNames As Boolean Implements IContactView.UseArabicNames
            Get
                Return New Global.System.Globalization.CultureInfo(TextDisplayLanguage).TextInfo.IsRightToLeft
            End Get
        End Property

        Private ReadOnly _fieldCaptions As New Dictionary(Of CLabel, String())

        Private ReadOnly txtIdNo As New CTextBox()
        Private ReadOnly txtContactCode As New CTextBox()
        Private ReadOnly txtContactName As New CTextBox()
        Private ReadOnly txtContactNameAra As New CTextBoxArabic()
        Private ReadOnly txtCSECode As New CTextBox()
        Private ReadOnly txtCSEIdNo As New CTextBox()

        Public Sub New()
            Name = "ContactViewer"
            Text = "Contact Viewer"
            DisallowSaves = True
            Dim layout As New TableLayoutPanel With {
                .Name = "ContactDetails", .Dock = DockStyle.Top, .AutoSize = True,
                .ColumnCount = 2, .Padding = New Padding(12)
            }
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 35))
            layout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 65))
            AddField(layout, txtIdNo, "IdNo", "Contact ID", "رقم جهة الاتصال")
            AddField(layout, txtContactCode, "ContactCode", "Contact Code", "رمز جهة الاتصال")
            AddField(layout, txtContactName, "ContactName", "Contact Name", "اسم جهة الاتصال")
            AddField(layout, txtContactNameAra, "ContactNameAra", "Arabic Name", "الاسم بالعربية")
            AddField(layout, txtCSECode, "CSECode", "Source Type (C: Customer, S: Supplier, E: Employee)", "نوع المصدر (C: عميل، S: مورد، E: موظف)")
            AddField(layout, txtCSEIdNo, "CSEIdNo", "Source ID", "رقم المصدر")
            SplitContainer1.Panel2.Controls.Add(layout)
            FirstControl = txtContactName
            For Each button As ToolStripItem In {btnAdd, btnEdit, btnDelete, btnSave, btnUndo}
                button.Enabled = False
                AddHandler button.EnabledChanged, AddressOf KeepWriteButtonDisabled
            Next
        End Sub

        Protected Overrides Sub OnAfterLanguageSwitch(context As LanguageSwitchContext)
            MyBase.OnAfterLanguageSwitch(context)
            Text = If(context.IsRightToLeft, "عارض جهات الاتصال", "Contact Viewer")
            For Each fieldCaption As KeyValuePair(Of CLabel, String()) In _fieldCaptions
                fieldCaption.Key.Text = fieldCaption.Value(If(context.IsRightToLeft, 1, 0))
            Next
            SetFormTitleCaption()
        End Sub

        Private Sub KeepWriteButtonDisabled(sender As Object, e As EventArgs)
            Dim button = DirectCast(sender, ToolStripItem)
            If button.Enabled Then button.Enabled = False
        End Sub

        Private Sub AddField(layout As TableLayoutPanel, field As CTextBox, fieldName As String, caption As String, arabicCaption As String)
            Dim label As New CLabel With {.Name = "lbl" & fieldName, .Text = caption,
                .AutoSize = True, .Anchor = AnchorStyles.Left, .Margin = New Padding(3, 8, 3, 8)}
            _fieldCaptions.Add(label, {caption, arabicCaption})
            field.Name = "txt" & fieldName
            field.FieldName = fieldName
            field.LinkedLabel = label
            field.Dock = DockStyle.Fill
            field.DisplayOnly = True
            field.ReadOnly = True
            field.FindEnabled = True
            field.Margin = New Padding(3, 8, 3, 8)
            Dim row = layout.RowCount
            layout.RowCount += 1
            layout.Controls.Add(label, 0, row)
            layout.Controls.Add(field, 1, row)
        End Sub

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From {
                {"IdNo", txtIdNo},
                {"ContactCode", txtContactCode},
                {"ContactName", txtContactName},
                {"ContactNameAra", txtContactNameAra},
                {"CSECode", txtCSECode},
                {"CSEIdNo", txtCSEIdNo}
            }
        End Sub

        Public Property IdNo As Int32 Implements IContactView.IdNo
            Get
                Return NumParser(Of Int32)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ContactCode As String Implements IContactView.ContactCode
            Get
                Return txtContactCode.Text
            End Get
            Set
                txtContactCode.Text = Value
            End Set
        End Property

        Public Property ContactName As String Implements IContactView.ContactName
            Get
                Return txtContactName.Text
            End Get
            Set
                txtContactName.Text = Value
            End Set
        End Property

        Public Property ContactNameAra As String Implements IContactView.ContactNameAra
            Get
                Return txtContactNameAra.Text
            End Get
            Set
                txtContactNameAra.Text = Value
            End Set
        End Property

        Public Property CSECode As String Implements IContactView.CSECode
            Get
                Return txtCSECode.Text
            End Get
            Set
                txtCSECode.Text = Value
            End Set
        End Property

        Public Property CSEIdNo As Int32 Implements IContactView.CSEIdNo
            Get
                Return NumParser(Of Int32)(txtCSEIdNo.Text)
            End Get
            Set
                txtCSEIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

    End Class
End Namespace
