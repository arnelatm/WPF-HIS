Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class ReligionEntryTv
        Implements IReligionView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "Religion"
            IdFieldName = "IdNo"
            TvMainFieldName = "ReligionName"
            TvSecondaryFieldName = "ReligionCode"
            SortOrderKey = "ReligionName"
            FirstControl = txtReligionCode
            ' Add any initialization after the InitializeComponent() call.
            'Dim model = New ReligionModel
            PresenterObj = New ReligionPresenter(Me)
            '_ReligionsPresenter = New ReligionsPresenter(Me)
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("ReligionTypeSelection", GetType(ReligionTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("ReligionTypeSelection", GetType(ReligionTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Public Property IDNo As Integer Implements IReligionView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
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

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtReligionCode, "Religion Code")
            MyErrorProvider.Controls.AddMandatory(txtReligionName, "Religion Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

    End Class

End Namespace