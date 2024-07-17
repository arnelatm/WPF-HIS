Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class DosageEntryTv
        Implements IDosageView

        Public Property AddMode As Boolean = False
        Private ReadOnly _nfi As NumberFormatInfo = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Public Sub New(ByVal tableName As String)
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            ' Add any initialization after the InitializeComponent() call.
            Text = Messaging.TranslateCaption("Dosage Entry")
            _nfi.NumberDecimalDigits = 2

        End Sub


        Public Property IdNo As Int32 Implements IDosageView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property Route As Int32 Implements IDosageView.Route
            Get
                Return cboRoute.GetValue(Of Int32)
            End Get
            Set
                cboRoute.SetValue(Value)
            End Set
        End Property

        Public Property Direction As Int32 Implements IDosageView.Direction
            Get
                Return cboDirection.GetValue(Of Int32)
            End Get
            Set
                cboDirection.SetValue(Value)
            End Set
        End Property

        Public Property Frequency As Int32 Implements IDosageView.Frequency
            Get
                Return cboFrequency.GetValue(Of Int32)
            End Get
            Set
                cboFrequency.SetValue(Value)
            End Set
        End Property

        Public Property FrequencyTiming As Int32 Implements IDosageView.FrequencyTiming
            Get
                Return cboFrequencyTiming.GetValue(Of Int32)
            End Get
            Set
                cboFrequencyTiming.SetValue(Value)
            End Set
        End Property

        Public Property DosageCode As String Implements IDosageView.DosageCode
            Get
                Return txtDosageCode.Text
            End Get
            Set(value As String)
                txtDosageCode.Text = value
            End Set
        End Property

        Public Property DosageNameAra As String Implements IDosageView.DosageNameAra
            Get
                Return txtDosageNameAra.Text
            End Get
            Set(value As String)
                txtDosageNameAra.Text = value
            End Set
        End Property

        Public Property DosageName As String Implements IDosageView.DosageName
            Get
                Return txtDosageName.Text
            End Get
            Set(value As String)
                txtDosageName.Text = value
            End Set
        End Property

#Region "Field Items"

#End Region

        Public Overloads Sub Dispose()
            Close()
        End Sub


        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"Direction", cboDirection},
                {"DosageCode", txtDosageCode},
                {"DosageName", txtDosageName},
                {"DosageNameAra", txtDosageNameAra},
                {"Frequency", cboFrequency},
                {"FrequencyTiming", cboFrequencyTiming},
                {"IdNo", txtIdNo},
                {"Route", cboRoute}
                }
        End Sub


    End Class

End Namespace