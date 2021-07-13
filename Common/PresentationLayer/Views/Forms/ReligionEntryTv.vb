Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ReligionEntryTv
        Implements IReligionView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtReligionCode
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IReligionView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ReligionCode As String Implements IReligionView.ReligionCode
            Get
                Return txtReligionCode.Text
            End Get
            Set
                txtReligionCode.Text = Value
            End Set
        End Property

        Public Property ReligionName As String Implements IReligionView.ReligionName
            Get
                Return txtReligionName.Text
            End Get
            Set
                txtReligionName.Text = Value
            End Set
        End Property

        Public Property ReligionNameAra As String Implements IReligionView.ReligionNameAra
            Get
                Return txtReligionNameAra.Text
            End Get
            Set
                txtReligionNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IReligionView.Notes
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
                {"ReligionCode", txtReligionCode},
                {"ReligionName", txtReligionName},
                {"ReligionNameAra", txtReligionNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace