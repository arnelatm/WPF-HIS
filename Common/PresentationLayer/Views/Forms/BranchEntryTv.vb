Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class BranchEntryTv
        Implements IBranchView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FormTitleCaption = "Branches Maintenance Form"
            MainTableName = "Branch"
            TvMainFieldName = "BranchName"
            TvSecondaryFieldName = "BranchCode"
            SortOrderKey = "BranchName"
            FirstControl = txtBranchCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New BranchPresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
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

    End Class

End Namespace