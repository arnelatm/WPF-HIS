Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class CountryEntryTv
        Implements ICountryView

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtCountryCode
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements ICountryView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property CountryCode As String Implements ICountryView.CountryCode
            Get
                Return txtCountryCode.Text
            End Get
            Set
                txtCountryCode.Text = Value
            End Set
        End Property

        Public Property CountryName As String Implements ICountryView.CountryName
            Get
                Return txtCountryName.Text
            End Get
            Set
                txtCountryName.Text = Value
            End Set
        End Property

        Public Property CountryNameAra As String Implements ICountryView.CountryNameAra
            Get
                Return txtCountryNameAra.Text
            End Get
            Set
                txtCountryNameAra.Text = Value
            End Set
        End Property

        Public Property Nationality As String Implements ICountryView.Nationality
            Get
                Return txtNationality.Text
            End Get
            Set
                txtNationality.Text = Value
            End Set
        End Property

        Public Property NationalityAra As String Implements ICountryView.NationalityAra
            Get
                Return txtNationalityAra.Text
            End Get
            Set
                txtNationalityAra.Text = Value
            End Set
        End Property

        Public Property Isoa3 As String Implements ICountryView.Isoa3
            Get
                Return TxtISOA3.Text
            End Get
            Set
                TxtISOA3.Text = Value
            End Set
        End Property

        Public Property Ison As String Implements ICountryView.Ison
            Get
                Return TxtISON.Text
            End Get
            Set
                TxtISON.Text = Value
            End Set
        End Property

        Public Property Flag32 As String Implements ICountryView.Flag32
        Public Property Flag128 As String Implements ICountryView.Flag128

        Public Property CountryTelCode As String Implements ICountryView.CountryTelCode
            Get
                Return TxtCountryTelCode.Text
            End Get
            Set
                TxtCountryTelCode.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"CountryCode", txtCountryCode},
                {"CountryName", txtCountryName},
                {"CountryNameAra", txtCountryNameAra},
                {"IdNo", TxtIdNo},
                {"Nationality", txtNationality},
                {"NationalityAra", txtNationalityAra},
                {"Isoa3", TxtISOA3},
                {"CountryTelCode", TxtCountryTelCode},
                {"Flag32", TxtFlag32},
                {"Flag128", TxtFlag128},
                {"IsoN", TxtISON}
                }
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs)
            txtCountryName.DisplayOnly = False
            txtCountryName.ReadOnly = False
            txtCountryName.EditingMode = True
            txtCountryName.ShortcutsEnabled = True
        End Sub

    End Class

End Namespace