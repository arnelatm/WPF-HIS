Imports System.Drawing.Printing
Imports System.Runtime.InteropServices.ComTypes
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class PrinterEntryTv
        Implements IPrinterView

        Public Event CheckPrinterClicked(sender As Object) Implements IPrinterView.CheckPrinterClicked

        Public Event PrinterChanged(sender As Object) Implements IPrinterView.PrinterChanged

        Public Sub New()
            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = txtPrinterName
            ' Add any initialization after the InitializeComponent() call.
        End Sub

#Region "Fields"

        Public Property IdNo As Int16 Implements IPrinterView.IdNo
            Get
                Return GlobalFunctions.NumParser(Of Int32)(TxtIdNo.Text)
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property PrinterName As String Implements IPrinterView.PrinterName
            Get
                Return txtPrinterName.Text
            End Get
            Set
                txtPrinterName.Text = Value
                RaiseEvent PrinterChanged(Me)
            End Set
        End Property

        Public Property PrinterCode As String Implements IPrinterView.PrinterCode
            Get
                Return txtPrinterCode.Text
            End Get
            Set
                txtPrinterCode.Text = Value
            End Set
        End Property

        Public Property DefaultPaperSize As Int32? Implements IPrinterView.DefaultPaperSize
            Get
                Return cboDefaultPaperSize.GetValue()
            End Get
            Set
                cboDefaultPaperSize.SetValue(Value)
                cboDefaultPaperSize.Refresh()
            End Set
        End Property

        Public Property DefaultPaperSource As Int32? Implements IPrinterView.DefaultPaperSource
            Get
                Return cboDefaultPaperSource.GetValue()
            End Get
            Set
                cboDefaultPaperSource.SetValue(Value)
            End Set
        End Property

        Public Property DefaultPaperOrientation As Int32? Implements IPrinterView.DefaultPaperOrientation
            Get
                Return cboDefaultPaperOrientation.GetValue()
            End Get
            Set
                cboDefaultPaperOrientation.SetValue(Value)
            End Set
        End Property

        Public Property HostOrIpName As String Implements IPrinterView.HostOrIpName
            Get
                Return txtHostOrIpName.Text
            End Get
            Set(value As String)
                txtHostOrIpName.Text = value
            End Set
        End Property

#End Region

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {
                {"HostOrIpName", txtHostOrIpName},
                {"IdNo", TxtIdNo},
                {"DefaultPaperOrientation", cboDefaultPaperOrientation},
                {"DefaultPaperSize", cboDefaultPaperSize},
                {"DefaultPaperSource", cboDefaultPaperSource},
                {"PrinterCode", txtPrinterCode},
                {"PrinterName", txtPrinterName}
                }
        End Sub

        Private Sub BtnCheckPrinter_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnCheckPrinter.ClickButtonArea
            RaiseEvent CheckPrinterClicked(Me)
        End Sub

        Private Sub txtPrinterName_Validated(sender As Object, e As EventArgs) Handles txtPrinterName.Validated
            RaiseEvent PrinterChanged(Me)
        End Sub

        'Private Sub SetPrinterPropertiesLookup(pPrinterName As String)
        '    Dim data = GetPrinterPageInfo(pPrinterName)
        '    Dim paperSizeLookup As New List(Of Lookup.LookupData)
        '    Dim index As Int16 = 0
        '    For Each item As PaperSize In data.PrinterSettings.PaperSizes
        '        Dim dbLookup = New Lookup.LookupData()
        '        dbLookup.IdNo = item.RawKind
        '        dbLookup.Name = item.PaperName
        '        dbLookup.Code = item.Kind
        '        dbLookup.Index = index
        '        paperSizeLookup.Add(dbLookup)
        '        index += 1
        '    Next
        '    cboPaperSize.DataSource = paperSizeLookup

        '    Dim paperSourceLookup As New List(Of Lookup.LookupData)
        '    index = 0
        '    For Each item As PaperSource In data.PrinterSettings.PaperSources
        '        Dim dbLookup = New Lookup.LookupData()
        '        dbLookup.IdNo = item.RawKind
        '        dbLookup.Name = item.SourceName
        '        dbLookup.Code = item.Kind
        '        dbLookup.Index = index
        '        paperSourceLookup.Add(dbLookup)
        '        index += 1
        '    Next
        '    cboPaperSource.DataSource = paperSourceLookup

        'End Sub

    End Class

End Namespace