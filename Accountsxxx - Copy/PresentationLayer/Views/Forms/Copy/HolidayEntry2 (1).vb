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
            FirstControl = cboHolidayIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            'FormTreeView.Visible = False
        End Sub

        Public Event AddedByUserChanged() Implements IHolidayView.AddedByUserChanged

#Region "Fields"

        Public Property HolidayCode As String Implements IHolidayView.HolidayCode
            Get
                Return txtHolidayCode.Text
            End Get
            Set
                txtHolidayCode.Text = Value
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

        Public Property Note As String Implements IHolidayView.Note
            Get
                Return txtNote.Text
            End Get
            Set(value As String)
                txtNote.Text = value
            End Set
        End Property

        Public Property AbsenceType As String Implements IHolidayView.AbsenceType
            Get
                Return cboAbsenceType.GetValue()
            End Get
            Set
                cboAbsenceType.SetValue(Value)
            End Set
        End Property

        Public Property AddedByUser As Short Implements IHolidayView.AddedByUser
            Get
                Return NumParser(Of Int16)(txtAddedByUser.Text)
            End Get
            Set(value As Short)
                txtAddedByUser.Text = value
                RaiseEvent AddedByUserChanged()
            End Set
        End Property

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

        Public Property HolidayIdNo As Integer Implements IHolidayView.HolidayIdNo
            Get
                Return cboHolidayIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboHolidayIdNo.SetValue(Value)
            End Set
        End Property

        Public Property EquivalentHours As Decimal Implements IHolidayView.EquivalentHours
            Get
                Return NumParser(Of Decimal)(txtEquivalentHours.Text)
            End Get
            Set(value As Decimal)
                txtEquivalentHours.Text = Convert.ToString(value)
            End Set
        End Property

        Public Property IdNo As Integer Implements IHolidayView.IdNo
            Get
                Return NumParser(Of Int16)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PayrollIdNo As Short Implements IHolidayView.PayrollIdNo
            Get
                Return NumParser(Of Int32)(txtPayrollIdNo.Text)
            End Get
            Set
                txtPayrollIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PayrollName As String Implements IHolidayView.PayrollName
            Get
                Return txtPayrollName.Text
            End Get
            Set(value As String)
                txtPayrollName.Text = value
            End Set
        End Property

        Public Property PayrollCode As String Implements IHolidayView.PayrollCode
            Get
                Return txtPayrollCode.Text
            End Get
            Set(value As String)
                txtPayrollCode.Text = value
            End Set
        End Property

        Public Property DateEnd As Date Implements IHolidayView.DateEnd
            Get
                Return Convert.ToDateTime(txtEndDate.Text)
            End Get
            Set(value As Date)
                txtEndDate.Text = value.ToShortDateString()
            End Set
        End Property

        Public Property DateStart As Date Implements IHolidayView.DateStart
            Get
                Return Convert.ToDateTime(txtStartDate.Text)
            End Get
            Set(value As Date)
                txtStartDate.Text = value.ToShortDateString()
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Note", txtNote},
                {"AbsenceType", cboAbsenceType},
                {"AddedByUser", txtAddedByUser},
                {"HolidayIdNo", cboHolidayIdNo},
                {"EquivalentHours", txtEquivalentHours},
                {"IdNo", TxtIdNo},
                {"PayrollIdNo", txtPayrollIdNo},
                {"UserName", txtUserName}
                }
        End Sub

        Protected Overrides Sub CreateDataSources()
            CreateEnumDataSource(Of AbsenceTypeSelection)(cboAbsenceType)
            CreateDataSource("Holiday", cboHolidayIdNo)
        End Sub

    End Class

End Namespace