Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ShiftSummaryEntry
        Implements IShiftSummaryView

        Private ReadOnly _nfi As NumberFormatInfo

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = cboUserIdNo
            _nfi = GlobalVariables.DefaultNumberFormatInfo
        End Sub

#Region "Fields"

        Public Property DateCreated As DateTime? Implements IShiftSummaryView.DateCreated
            Get
                Return Convert.ToDateTime(txtDateCreated.Text)
            End Get
            Set
                If Value.HasValue Then
                    txtDateCreated.Text = Value
                Else
                    txtDateCreated.Text = Date.Now().ToString()
                End If
            End Set
        End Property

        Public Property UserIdNo As Int32 Implements IShiftSummaryView.UserIdNo
            Get
                Return cboUserIdNo.GetNullableValue(Of Int32)
            End Get
            Set
                cboUserIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DateEnd As DateTime Implements IShiftSummaryView.DateEnd
            Get
                Return dtpDateEnd.Value
            End Get
            Set
                dtpDateEnd.Value = Value
            End Set
        End Property

        Public Property IdNo As Int32 Implements IShiftSummaryView.IdNo
            Get
                Return NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property DateStart As DateTime Implements IShiftSummaryView.DateStart
            Get
                Return dtpDateStart.Value
            End Get
            Set
                dtpDateStart.Value = Value
            End Set
        End Property

        Public Property Cards As Decimal Implements IShiftSummaryView.Cards
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtCard.Text), _nfi)
            End Get
            Set
                txtCard.Text = FormatMoney(Value)
                txtTotal.Text = FormatMoney(Value + Cash)
            End Set
        End Property

        Public Property Cash As Decimal Implements IShiftSummaryView.Cash
            Get
                Return Convert.ToDecimal(NumParser(Of Decimal)(txtCash.Text), _nfi)
            End Get
            Set
                txtCash.Text = FormatMoney(Value)
                txtTotal.Text = FormatMoney(Value + Cards)
            End Set
        End Property

        Public Property Total As Decimal

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Cash", txtCash},
                {"Cards", txtCard},
                {"UserIdNo", cboUserIdNo},
                {"DateEnd", dtpDateEnd},
                {"IdNo", TxtIdNo},
                {"DateStart", dtpDateStart}
                }
        End Sub


        Private Sub dtpDateStart_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateStart.Validated
            If dtpDateEnd.Value Is Nothing OrElse dtpDateEnd.Value < dtpDateStart.Value Then
                dim time = dtpDateStart.GetTime()
                dtpDateEnd.SetCurrentTime(time)
            End If
        End Sub

        Private Sub dtpDateEnd_ValueChanged(sender As Object, e As EventArgs) Handles dtpDateEnd.Validated
            If dtpDateStart.Value Is Nothing OrElse dtpDateStart.Value > dtpDateEnd.Value Then
                dim time = dtpDateEnd.GetTime()
                dtpDateStart.SetCurrentTime(time)
            End If
        End Sub

        Private Sub txtCash_TextChanged(sender As Object, e As EventArgs) Handles txtCash.TextChanged, txtCard.TextChanged
            txtTotal.Text = FormatMoney(Cash + Cards)
        End Sub


    End Class

End Namespace