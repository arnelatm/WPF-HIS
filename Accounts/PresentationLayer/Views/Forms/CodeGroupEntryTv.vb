Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class CodeGroupEntryTv
        Implements ICodeGroupView

        Public Sub New()
            'MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtCodeGroupName
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements ICodeGroupView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property CodeGroupCode As String Implements ICodeGroupView.CodeGroupCode
            Get
                Return txtCodeGroupCode.Text
            End Get
            Set
                txtCodeGroupCode.Text = Value
            End Set
        End Property

        Public Property CodeGroupName As String Implements ICodeGroupView.CodeGroupName
            Get
                Return txtCodeGroupName.Text
            End Get
            Set
                txtCodeGroupName.Text = Value
            End Set
        End Property

        Public Property CodeGroupNameAra As String Implements ICodeGroupView.CodeGroupNameAra
            Get
                Return txtCodeGroupNameAra.Text
            End Get
            Set
                txtCodeGroupNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements ICodeGroupView.Notes
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
                {"CodeGroupCode", txtCodeGroupCode},
                {"CodeGroupName", txtCodeGroupName},
                {"CodeGroupNameAra", txtCodeGroupNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace