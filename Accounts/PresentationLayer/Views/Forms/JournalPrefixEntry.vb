Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class JournalPrefixEntry
        Implements IJournalPrefixView

        Private ReadOnly _nfi As NumberFormatInfo
        Private _presenter As JournalPrefixPresenter

        Public Sub New()
            MyBase.New()
            ' This call is required by the designer.
            InitializeComponent()
            TvMainFieldName = "JournalName"
            TvSecondaryFieldName = "JournalCode"
            MainTableName = "JournalPrefix"
            SortOrderKey = "JournalName"
            _nfi = GlobalVariables.DefaultNumberFormatInfo
            Ea = New EventAggregator()
            _presenter = New JournalPrefixPresenter(Me)
        End Sub

#Region "Fields"

        Public Property JournalCode As String Implements IJournalPrefixView.JournalCode
            Get
                Return txtJournalCode.Text
            End Get
            Set
                txtJournalCode.Text = Value
            End Set
        End Property

        Public Property JournalNameAra As String Implements IJournalPrefixView.JournalNameAra
            Get
                Return txtJournalNameAra.Text
            End Get
            Set
                txtJournalNameAra.Text = Value
            End Set
        End Property

        Public Property IdNo As Int16 Implements IJournalPrefixView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int16)(txtIdNo.Text)
            End Get
            Set
                txtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property JournalCodeAra As String Implements IJournalPrefixView.JournalCodeAra
            Get
                Return txtJournalCodeAra.Text
            End Get
            Set
                txtJournalCodeAra.Text = Value
            End Set
        End Property

        Public Property JournalName As String Implements IJournalPrefixView.JournalName
            Get
                Return txtJournalName.Text
            End Get
            Set
                txtJournalName.Text = Value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"IdNo", txtIdNo},
                {"JournalCode", txtJournalCode},
                {"JournalCodeAra", txtJournalCodeAra},
                {"JournalName", txtJournalNameAra},
                {"JournalNameAra", txtJournalNameAra}
                }
        End Sub

    End Class

End Namespace