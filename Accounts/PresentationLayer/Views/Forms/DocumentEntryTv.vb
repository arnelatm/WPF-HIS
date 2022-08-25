Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class DocumentEntryTv
        Implements IDocumentView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtDocumentCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IDocumentView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DocumentCode As String Implements IDocumentView.DocumentCode
            Get
                Return txtDocumentCode.Text
            End Get
            Set
                txtDocumentCode.Text = Value
            End Set
        End Property

        Public Property DocumentName As String Implements IDocumentView.DocumentName
            Get
                Return txtDocumentName.Text
            End Get
            Set
                txtDocumentName.Text = Value
            End Set
        End Property

        Public Property DocumentNameAra As String Implements IDocumentView.DocumentNameAra
            Get
                Return txtDocumentNameAra.Text
            End Get
            Set
                txtDocumentNameAra.Text = Value
            End Set
        End Property

        Public Property DocumentType As String Implements IDocumentView.DocumentType
            Get
                Return cboDocumentType.GetValue()
            End Get
            Set
                cboDocumentType.SetValue(Value)
            End Set
        End Property

        Public Property ImageType As String Implements IDocumentView.ImageType
            Get
                Return cboImageType.GetValue()
            End Get
            Set
                cboImageType.SetValue(Value)
            End Set
        End Property

        Public Property Notes As String Implements IDocumentView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Public Property NeedsExpiryDate As Boolean Implements IDocumentView.NeedsExpiryDate
            Get
                Return chkNeedsNumber.Checked
            End Get
            Set
                chkNeedsNumber.Checked = Value
            End Set
        End Property

        Public Property NeedsIssueDate As Boolean Implements IDocumentView.NeedsIssueDate
            Get
                Return chkNeedsNumber.Checked
            End Get
            Set
                chkNeedsNumber.Checked = Value
            End Set
        End Property

        Public Property NeedsNumber As Boolean Implements IDocumentView.NeedsNumber
            Get
                Return chkNeedsNumber.Checked
            End Get
            Set
                chkNeedsNumber.Checked = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"DocumentCode", txtDocumentCode},
                {"ImageType", cboImageType},
                {"DocumentName", txtDocumentName},
                {"DocumentNameAra", txtDocumentNameAra},
                {"DocumentType", cboDocumentType},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace