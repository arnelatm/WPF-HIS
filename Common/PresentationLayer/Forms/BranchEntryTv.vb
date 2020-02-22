Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class BranchEntryTv
        Implements IBranchView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Branch"
            IdFieldName = "IdNo"
            TvMainFieldName = "BranchName"
            TvSecondaryFieldName = "BranchCode"
            SortOrderKey = "BranchName"
            FirstControl = txtBranchCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New BranchPresenter(Me)
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("BranchTypeSelection", GetType(BranchTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("BranchTypeSelection", GetType(BranchTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Public Property IDNo As Integer Implements IBranchView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
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

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtBranchCode, "Branch Code")
            MyErrorProvider.Controls.AddMandatory(txtBranchName, "Branch Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

    End Class

End Namespace