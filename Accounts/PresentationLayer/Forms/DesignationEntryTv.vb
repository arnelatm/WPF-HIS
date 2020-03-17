Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class DesignationEntryTv
        Implements IDesignationView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Designation"
            IdFieldName = "IdNo"
            TvMainFieldName = "DesignationName"
            TvSecondaryFieldName = "DesignationCode"
            SortOrderKey = "DesignationName"
            FirstControl = txtDesignationCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New DesignationPresenter(Me)
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("DesignationTypeSelection", GetType(DesignationTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("DesignationTypeSelection", GetType(DesignationTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Public Property IDNo As Integer Implements IDesignationView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DesignationCode As String Implements IDesignationView.DesignationCode
            Get
                Return txtDesignationCode.Text
            End Get
            Set
                txtDesignationCode.Text = Value
            End Set
        End Property

        Public Property DesignationName As String Implements IDesignationView.DesignationName
            Get
                Return txtDesignationName.Text
            End Get
            Set
                txtDesignationName.Text = Value
            End Set
        End Property

        Public Property DesignationNameAra As String Implements IDesignationView.DesignationNameAra
            Get
                Return txtDesignationNameAra.Text
            End Get
            Set
                txtDesignationNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IDesignationView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtDesignationCode, "Designation Code")
            MyErrorProvider.Controls.AddMandatory(txtDesignationName, "Designation Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

    End Class

End Namespace