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
            TvMainFieldName = "PhoneTypeName"
            TvSecondaryFieldName = "PhoneTypeCode"
            SortOrderKey = "PhoneTypeName"
            FirstControl = txtPhoneTypeCode
            ' Add any initialization after the InitializeComponent() call.
            PresenterObj = New PhoneTypePresenter(Me)
            Ea = PresenterObj.Ea
            Ea.SubscribeEvent(Me)
        End Sub

#Region "Fields"

        Public Property IdNo As Byte Implements IPhoneTypeView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Byte)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
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

#End Region

        Protected Overrides Sub CreateFieldsDictionary()
            FieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"PhoneTypeCode", txtPhoneTypeCode},
                {"PhoneTypeName", txtPhoneTypeName},
                {"PhoneTypeNameAra", txtPhoneTypeNameAra},
                {"IdNo", TxtIdNo},
                {"Notes", txtNotes}
                }
        End Sub

    End Class

End Namespace