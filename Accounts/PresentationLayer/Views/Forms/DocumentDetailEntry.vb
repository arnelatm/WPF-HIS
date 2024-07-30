Imports System.Globalization
Imports System.IO
Imports System.Windows.Interop
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DocumentDetailEntry
        Implements IDocumentDetailView

        Private ReadOnly _nfi As NumberFormatInfo
        Private _imageFileName As String
        Public Event AddNewDocumentType() Implements IDocumentDetailView.AddNewDocumentType
        Public Event DocumentTypeChanged() Implements IDocumentDetailView.DocumentTypeChanged
        Public Event LookupNeedsUpdate() Implements IDocumentDetailView.LookupNeedsUpdate
        Public Event FilterRecords() Implements IDocumentDetailView.FilterRecords

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboDocumentIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
            ContactIdControl = cboContactIdNo
            ContactIdDataName = "ControlDataSource"
            Changed = False
        End Sub

#Region "Fields"

        Public Property ControlDataSource As Object

        Public Property UserIdNo As Int16 Implements IDocumentDetailView.UserIdNo
            Get
                Return txtUserIdNo.Text
            End Get
            Set
                txtUserIdNo.SetValue(Value)
            End Set
        End Property

        Public Property BranchName As String Implements IDocumentDetailView.BranchName
            Get
                Return cBranchName.Text
            End Get
            Set(value As String)
                cBranchName.Text = value
            End Set
        End Property

        Public Property UserName As String Implements IDocumentDetailView.UserName
            Get
                Return txtUserName.Text
            End Get
            Set
                txtUserName.SetValue(Value)
            End Set
        End Property

        Public Property IssueDate As Date? Implements IDocumentDetailView.IssueDate
            Get
                If dtpIssueDate.Value = Date.MinValue Then
                    dtpIssueDate.Value = Nothing
                End If
                Return dtpIssueDate.Value
            End Get
            Set
                If Value = Date.MinValue Then
                    dtpIssueDate.Value = Nothing
                Else
                    dtpIssueDate.Value = Value
                End If
            End Set
        End Property

        Public Property DocumentIdNo As Int16 Implements IDocumentDetailView.DocumentIdNo
            Get
                Return cboDocumentIdNo.GetValue(Of Int16)
            End Get
            Set
                cboDocumentIdNo.SetValue(Value)
            End Set
        End Property

        Public Property IdNo As Integer Implements IDocumentDetailView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ExpiryDate As Date? Implements IDocumentDetailView.ExpiryDate
            Get
                If dtpExpiryDate.Value = Date.MinValue Then
                    dtpExpiryDate.Value = Nothing
                End If
                Return dtpExpiryDate.Value
            End Get
            Set
                If Value = Date.MinValue Then
                    dtpExpiryDate.Value = Nothing
                Else
                    dtpExpiryDate.Value = Value
                End If
            End Set
        End Property

        Public Property ContactType As String Implements IDocumentDetailView.ContactType
            Get
                Return txtContactType.GetValue(Of String)
            End Get
            Set(value As String)
                txtContactType.SetValue(value)
            End Set
        End Property

        Public Property DataImageIdNo As Integer Implements IDocumentDetailView.DataImageIdNo
            Get
                Return txtDataImageNo.Text
            End Get
            Set(value As Integer)
                txtDataImageNo.SetValue(value)
            End Set
        End Property

        Public Property DocumentNumber As String Implements IDocumentDetailView.DocumentNumber
            Get
                Return txtDocumentNumber.Text
            End Get
            Set
                txtDocumentNumber.SetValue(Value)
            End Set
        End Property

        Public Property ContactIdNo As Integer? Implements IDocumentDetailView.ContactIdNo
            Get
                Return cboContactIdNo.GetValue(Of Integer)
            End Get
            Set(value As Integer?)
                cboContactIdNo.SetValue(value)
            End Set
        End Property

        Public Property DateCreated As Date Implements IDocumentDetailView.DateCreated
            Get
                Return txtDateCreated.Text
            End Get
            Set(value As Date)
                txtDateCreated.SetValue(value)
            End Set
        End Property

        Public Property Active As Boolean Implements IDocumentDetailView.Active
            Get
                Return chkActive.Checked
            End Get
            Set
                chkActive.Checked = Value
            End Set
        End Property

        Private ReadOnly _blankImage As Image = GlobalFuncNSub.CreateTextImage("Click" & Environment.NewLine & "to Change" & Environment.NewLine & "Photo", Nothing, Nothing, Nothing, Nothing, Nothing)

        Public Property Picture As Image Implements IDocumentDetailView.Picture
            Get
                If imgPicture.Image Is Nothing Then
                    Return Nothing
                ElseIf imgPicture.Image.Equals(_blankImage) Then
                    Return Nothing
                End If
                Return imgPicture.Image
            End Get
            Set
                If Value IsNot Nothing Then
                    imgPicture.Image = Value
                Else
                    imgPicture.Image = _blankImage
                End If
            End Set
        End Property


        Public Property ImageFileName As String Implements IDocumentDetailView.ImageFileName
            Get
                Return _imageFileName
            End Get
            Set(value As String)
                If DataImageIdNo <= 0 Then
                    If value IsNot Nothing Then
                        DataImageIdNo = -1
                    ElseIf value = "" Then
                        DataImageIdNo = 0
                    End If
                End If
                _imageFileName = value
            End Set
        End Property


        Public Property ContactIdControl As Control Implements IDocumentDetailView.ContactIdControl

        Public Property ContactIdDataName As String Implements IDocumentDetailView.ContactIdDataName

        Public Property ShowContactIdSelector As Boolean Implements IDocumentDetailView.ShowContactIdSelector

        Public Property ContactDescription As String Implements IDocumentDetailView.ContactDescription

        Public Property Changed As Boolean Implements IDocumentDetailView.Changed

        Public Property BranchIdNo As Short Implements IDocumentDetailView.BranchIdNo


#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
               {
                {"ContactIdNo", cboContactIdNo},
                {"DataImageNo", txtDataImageNo},
                {"DateCreated", txtDateCreated},
                {"DocumentIdNo", cboDocumentIdNo},
                {"DocumentNumber", txtDocumentNumber},
                {"ExpiryDate", dtpExpiryDate},
                {"IdNo", TxtIdNo},
                {"IssueDate", dtpIssueDate},
                {"UserIdNo", txtUserIdNo},
                {"UserName", txtUserName}
               }
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles CButton1.ClickButtonArea
            RaiseEvent AddNewDocumentType()
            RaiseEvent LookupNeedsUpdate()
        End Sub

        Private Sub cboDocumentIdNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDocumentIdNo.SelectedIndexChanged
            RaiseEvent DocumentTypeChanged()
            If ShowContactIdSelector Then
                lblContactName.Visible = True
                cboContactIdNo.Visible = True
                cboContactIdNo.DataSource = ControlDataSource
            Else
                cboContactIdNo.Visible = False
                lblContactName.Visible = False
            End If
            cboContactIdNo.Refresh()
        End Sub

        Private Sub imgPicture_DoubleClick(sender As Object, e As EventArgs) Handles imgPicture.DoubleClick
            Dim tempFileName As String = GetPictureFileName()
            ViewPicture(tempFileName)
        End Sub

        Private Sub CButton2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnPictureViewer.ClickButtonArea
            Dim tempFileName As String = GetPictureFileName()
            ViewPicture(tempFileName)
        End Sub

        Private Function GetPictureFileName() As String
            Dim data As Byte() = {}
            Dim saveImage As New Bitmap(Picture)
            Dim tempFileName As String = Path.GetTempFileName() + ".Jpg"
            saveImage.Save(tempFileName, System.Drawing.Imaging.ImageFormat.Jpeg)
            saveImage.Dispose()
            Dim cPictureBox As New PictureBox
            cPictureBox.Image = Image.FromFile(tempFileName)
            Using ms = New MemoryStream()
                If Picture IsNot Nothing Then
                    cPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                    data = ms.ToArray()
                End If
            End Using
            Return tempFileName
        End Function

        Private Sub ViewPicture(fileName As String)
            Dim p = New Process
            p.StartInfo.FileName = fileName
            p.StartInfo.Verb = "Open"
            p.Start()
        End Sub
    End Class

End Namespace