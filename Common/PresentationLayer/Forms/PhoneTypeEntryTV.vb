Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Forms

    Public Class PhoneTypeEntryTv
        Implements IPhoneTypeView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()

            MainTableName = "PhoneType"
            IdFieldName = "IdNo"
            TvMainFieldName = "PhoneTypeName"
            TvSecondaryFieldName = "PhoneTypeCode"
            SortOrderKey = "PhoneTypeName"
            FirstControl = txtPhoneTypeCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PhoneTypePresenter(Me)
            '_PhoneTypeesPresenter = New PhoneTypesPresenter(Me)
            'CreateEnumResourceFile()

            'ResourceEnumConverter.MakeResource("PhoneTypeTypeSelection", GetType(PhoneTypeTypeSelection))
        End Sub

        Public Sub CreateEnumResourceFile()
            'ResourceEnumConverter.MakeResource("YesNoSelection", GetType(YesNoSelection))
            'ResourceEnumConverter.MakeResource("PhoneTypeTypeSelection", GetType(PhoneTypeTypeSelection))
            'ResourceEnumConverter.MakeResource("ImageTypeSelection", GetType(ImageTypeSelection))
        End Sub

        Public Property IDNo As Integer Implements IPhoneTypeView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIDNo.Text)
            End Get
            Set
                TxtIDNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PhoneTypeCode As String Implements IPhoneTypeView.PhoneTypeCode
            Get
                Return txtPhoneTypeCode.Text
            End Get
            Set
                txtPhoneTypeCode.Text = Value
            End Set
        End Property

        Public Property PhoneTypeName As String Implements IPhoneTypeView.PhoneTypeName
            Get
                Return txtPhoneTypeName.Text
            End Get
            Set
                txtPhoneTypeName.Text = Value
            End Set
        End Property

        Public Property PhoneTypeNameAra As String Implements IPhoneTypeView.PhoneTypeNameAra
            Get
                Return txtPhoneTypeNameAra.Text
            End Get
            Set
                txtPhoneTypeNameAra.Text = Value
            End Set
        End Property

        Public Property Notes As String Implements IPhoneTypeView.Notes
            Get
                Return txtNotes.Text
            End Get
            Set
                txtNotes.Text = Value
            End Set
        End Property

        Protected Overrides Sub AddMandatoryFieldCheck()
            'Add controls one by one in error provider.
            MyErrorProvider.Controls.AddMandatory(txtPhoneTypeCode, "PhoneType Code")
            MyErrorProvider.Controls.AddMandatory(txtPhoneTypeName, "PhoneType Name in English")
            'Set summary error message
            MyErrorProvider.SummaryMessage = "Following fields are mandatory,"
        End Sub

        
        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"PhoneTypeCode", txtPhoneTypeCode},
                {"PhoneTypeName", txtPhoneTypeName},
                {"PhoneTypeNameAra", txtPhoneTypeNameAra},
                {"IDNo", TxtIDNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace