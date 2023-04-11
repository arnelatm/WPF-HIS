Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class BasicEntry
        Implements IBasicView

        Public Sub New(ByVal tableOrViewName As String, ByVal formCaption As String, ByVal withNotes As Boolean)
            MyBase.New()

            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = TxtCode
            Me.Text = Messaging.TranslateCaption(formCaption)
            If withNotes Then
                TxtNote.Visible = True
                lblNote.Visible = True
            Else
                TxtNote.Visible = False
                lblNote.Visible = False
            End If

        End Sub

#Region "Field Items"

        Public Property IdNo As Int32 Implements IBasicView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt32(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Code As String Implements IBasicView.Code
            Get
                Return TxtCode.Text
            End Get
            Set
                TxtCode.Text = If(Value, "")
            End Set
        End Property

        Public Property Notes As String Implements IBasicView.Notes
            Get
                Return TxtNote.Text
            End Get
            Set
                TxtNote.Text = If(Value, "")
            End Set
        End Property

        Public Overloads Property Name As String Implements IBasicView.Name
            Get
                Return TxtName.Text
            End Get
            Set
                TxtName.Text = Value
            End Set
        End Property

        Public Property NameAra As String Implements IBasicView.NameAra
            Get
                Return txtNameAra.Text
            End Get
            Set
                txtNameAra.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
            {
             {"IdNo", TxtIdNo},
             {"Code", TxtCode},
             {"Name", TxtName},
             {"NameAra", txtNameAra},
             {"Note", TxtNote}
            }
        End Sub

    End Class

End Namespace