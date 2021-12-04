Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class HolidayEntry
        Implements IHolidayView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtHolidayName
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

#Region "Fields"

        Public Property DateCreated As DateTime? Implements IHolidayView.DateCreated
            Get
                If String.IsNullOrEmpty(txtDateCreated.Text) Then
                    Return Now()
                End If
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set(value As DateTime?)
                If value Is Nothing Then
                    txtDateCreated.Text = Nothing
                Else
                    txtDateCreated.Text = String.Format(CultureInfo.CurrentCulture, "{0:g}", value)
                End If
            End Set
        End Property

        Public Property IdNo As Integer Implements IHolidayView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property HolidayDate As Date Implements IHolidayView.HolidayDate
            Get
                Return Convert.ToDateTime(dtpHolidayDate.Text)
            End Get
            Set
                dtpHolidayDate.Text = Value.ToShortDateString()
            End Set
        End Property

        Public Property HolidayName As String Implements IHolidayView.HolidayName
            Get
                Return txtHolidayName.Text
            End Get
            Set
                txtHolidayName.Text = Value
            End Set
        End Property

        Public Property HolidayNameAra As String Implements IHolidayView.HolidayNameAra
            Get
                Return txtHolidayNameAra.Text
            End Get
            Set
                txtHolidayNameAra.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"HolidayName", txtHolidayName},
                {"HolidayNameAra", txtHolidayNameAra},
                {"HolidayDate", dtpHolidayDate},
                {"IdNo", TxtIdNo}
                }
        End Sub

        Private Sub HolidayEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            If Not Presenter.UserHasAccess("HumanResources") Then
                btnEdit.Enabled = False
                btnAdd.Enabled = False
            End If
        End Sub

    End Class

End Namespace