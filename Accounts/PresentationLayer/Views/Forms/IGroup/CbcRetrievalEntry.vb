Imports System.Configuration
Imports System.Globalization
Imports System.IO
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class CbcRetrievalEntry
        Implements ILab_InvoiceGroupView


        Private _nfi As NumberFormatInfo
        Private _labInvoiceDetails As List(Of Lab_InvoiceDetailsView)

        Public Event RetrieveLabResultRequested() Implements ILab_InvoiceGroupView.RetrieveLabResultRequested

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            'FirstControl = txtInvoiceNo
            Presenter = New Lab_InvoiceGroupPresenter(Of Lab_InvoiceGroupModel)(Me)
            Dim numberDecimalDigits = 4
            Dim numberDecimalSeparator = ConfigurationManager.AppSettings("DefaultNumberDecimalSeparator")
            Dim numberGroupSeparator = ConfigurationManager.AppSettings("DefaultNumberGroupSeparator")
            _nfi = New CultureInfo(CultureInfo.CurrentCulture.ToString, False).NumberFormat
            _nfi.NumberDecimalDigits = 4
            If numberDecimalSeparator Is Nothing Then
                _nfi.NumberDecimalSeparator = "."
            Else
                _nfi.NumberDecimalSeparator = numberDecimalSeparator
            End If
            If numberGroupSeparator Is Nothing Then
                _nfi.NumberGroupSeparator = ","
            Else
                _nfi.NumberGroupSeparator = numberGroupSeparator
            End If

        End Sub

#Region "Field Items"
        Public Property InvoiceNo As Decimal Implements ILab_InvoiceGroupView.InvoiceNo
            Get
                Return txtInvoiceNo.Text
            End Get
            Set(value As Decimal)
                txtInvoiceNo.Text = value
            End Set
        End Property

        Public Property InvoiceType As String Implements ILab_InvoiceGroupView.InvoiceType
            Get
                Return txtInvoiceTypeDisplay.Text
            End Get
            Set(value As String)
                txtInvoiceTypeDisplay.Text = value
                If value = "CA" Then
                    txtInvoiceTypeDisplay.Text = "Cash"
                Else
                    txtInvoiceTypeDisplay.Text = "Credit"
                End If
            End Set
        End Property

        Public Property InvoiceDate As Date Implements ILab_InvoiceGroupView.InvoiceDate
            Get
                Return txtInvoiceDate.Text
            End Get
            Set(value As Date)
                txtInvoiceDate.Text = value
            End Set
        End Property

        Public Property PatientNameEnglish As String Implements ILab_InvoiceGroupView.PatientNameEnglish
            Get
                Return txtPatientNameEnglish.Text
            End Get
            Set(value As String)
                txtPatientNameEnglish.Text = value
            End Set
        End Property

        Public Property PatientName As String Implements ILab_InvoiceGroupView.PatientName
            Get
                Return txtPatientName.Text
            End Get
            Set(value As String)
                txtPatientName.Text = value
            End Set
        End Property

        Public Property Age As Decimal Implements ILab_InvoiceGroupView.Age
            Get
                Return txtAge.Text
            End Get
            Set(value As Decimal)
                txtAge.Text = value
                If AgeYMD = "Y" Then
                    txtAgeDisplay.Text = value.ToString() + "Year(s)"
                ElseIf AgeYMD = "M" Then
                    txtAgeDisplay.Text = value.ToString() + "Month(s)"
                ElseIf AgeYMD = "W" Then
                    txtAgeDisplay.Text = value.ToString() + "Week(s)"
                ElseIf AgeYMD = "D" Then
                    txtAgeDisplay.Text = value.ToString() + "Day(s)"
                Else
                    txtAgeDisplay.Text = value.ToString() + "Year(s)"
                End If

            End Set
        End Property

        Public Property AgeYMD As String Implements ILab_InvoiceGroupView.AgeYMD
            Get
                Return txtAgeYmd.Text
            End Get
            Set(value As String)
                txtAgeYmd.Text = value
            End Set
        End Property

        Public Property Sex As String Implements ILab_InvoiceGroupView.Sex
            Get
                Return txtSex.Text
            End Get
            Set(value As String)
                txtSex.Text = value
                If value = "M" Then
                    txtSexDisplay.Text = "Male"
                Else
                    txtSexDisplay.Text = "Female"
                End If
            End Set
        End Property

        Public Property RegistrationNo As Decimal Implements ILab_InvoiceGroupView.RegistrationNo
            Get
                Return txtRegistrationNo.Text
            End Get
            Set(value As Decimal)
                txtRegistrationNo.Text = value
            End Set
        End Property


        Public Property SampleNo As String Implements ILab_InvoiceGroupView.SampleNo
            Get
                Return txtSampleNo.Text
            End Get
            Set(value As String)
                txtSampleNo.Text = value
            End Set
        End Property

        Public Property Wbc As String Implements ILab_InvoiceGroupView.Wbc
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property NE As String Implements ILab_InvoiceGroupView.NE
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Ly As String Implements ILab_InvoiceGroupView.Ly
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Mo As String Implements ILab_InvoiceGroupView.Mo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Eo As String Implements ILab_InvoiceGroupView.Eo
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Ba As String Implements ILab_InvoiceGroupView.Ba
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Rbc As String Implements ILab_InvoiceGroupView.Rbc
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Hgb As String Implements ILab_InvoiceGroupView.Hgb
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Hct As String Implements ILab_InvoiceGroupView.Hct
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Mcv As String Implements ILab_InvoiceGroupView.Mcv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Mch As String Implements ILab_InvoiceGroupView.Mch
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Mchc As String Implements ILab_InvoiceGroupView.Mchc
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Rdwcv As String Implements ILab_InvoiceGroupView.Rdwcv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Rdwcd As String Implements ILab_InvoiceGroupView.Rdwcd
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Plt As String Implements ILab_InvoiceGroupView.Plt
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Pct As String Implements ILab_InvoiceGroupView.Pct
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Mpv As String Implements ILab_InvoiceGroupView.Mpv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Pdw As String Implements ILab_InvoiceGroupView.Pdw
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property WbcNv As String Implements ILab_InvoiceGroupView.WbcNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property NENv As String Implements ILab_InvoiceGroupView.NENv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property LyNv As String Implements ILab_InvoiceGroupView.LyNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MoNv As String Implements ILab_InvoiceGroupView.MoNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property EoNv As String Implements ILab_InvoiceGroupView.EoNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property BaNv As String Implements ILab_InvoiceGroupView.BaNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RbcNv As String Implements ILab_InvoiceGroupView.RbcNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property HgbNv As String Implements ILab_InvoiceGroupView.HgbNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property HctNv As String Implements ILab_InvoiceGroupView.HctNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property McvNv As String Implements ILab_InvoiceGroupView.McvNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MchNv As String Implements ILab_InvoiceGroupView.MchNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MchcNv As String Implements ILab_InvoiceGroupView.MchcNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RdwcvNv As String Implements ILab_InvoiceGroupView.RdwcvNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RdwcdNv As String Implements ILab_InvoiceGroupView.RdwcdNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PltNv As String Implements ILab_InvoiceGroupView.PltNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PctNv As String Implements ILab_InvoiceGroupView.PctNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MpvNv As String Implements ILab_InvoiceGroupView.MpvNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PdwNv As String Implements ILab_InvoiceGroupView.PdwNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property WbcR As String Implements ILab_InvoiceGroupView.WbcR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property NeR As String Implements ILab_InvoiceGroupView.NeR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property LyR As String Implements ILab_InvoiceGroupView.LyR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MoR As String Implements ILab_InvoiceGroupView.MoR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property EoR As String Implements ILab_InvoiceGroupView.EoR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property BaR As String Implements ILab_InvoiceGroupView.BaR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RbcR As String Implements ILab_InvoiceGroupView.RbcR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property HgbR As String Implements ILab_InvoiceGroupView.HgbR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property HctR As String Implements ILab_InvoiceGroupView.HctR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property McvR As String Implements ILab_InvoiceGroupView.McvR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MchR As String Implements ILab_InvoiceGroupView.MchR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MchcR As String Implements ILab_InvoiceGroupView.MchcR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RdwcvR As String Implements ILab_InvoiceGroupView.RdwcvR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RdwcdR As String Implements ILab_InvoiceGroupView.RdwcdR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PltR As String Implements ILab_InvoiceGroupView.PltR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PctR As String Implements ILab_InvoiceGroupView.PctR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MpvR As String Implements ILab_InvoiceGroupView.MpvR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PdwR As String Implements ILab_InvoiceGroupView.PdwR
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property WbcRNv As String Implements ILab_InvoiceGroupView.WbcRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property NeRNv As String Implements ILab_InvoiceGroupView.NeRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property LyRNv As String Implements ILab_InvoiceGroupView.LyRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MoRNv As String Implements ILab_InvoiceGroupView.MoRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property EoRNv As String Implements ILab_InvoiceGroupView.EoRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property BaRNv As String Implements ILab_InvoiceGroupView.BaRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RbcRNv As String Implements ILab_InvoiceGroupView.RbcRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property HgbRNv As String Implements ILab_InvoiceGroupView.HgbRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property HctRNv As String Implements ILab_InvoiceGroupView.HctRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property McvRNv As String Implements ILab_InvoiceGroupView.McvRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MchRNv As String Implements ILab_InvoiceGroupView.MchRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MchcRNv As String Implements ILab_InvoiceGroupView.MchcRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RdwcvRNv As String Implements ILab_InvoiceGroupView.RdwcvRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property RdwcdRNv As String Implements ILab_InvoiceGroupView.RdwcdRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PltRNv As String Implements ILab_InvoiceGroupView.PltRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PctRNv As String Implements ILab_InvoiceGroupView.PctRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property MpvRNv As String Implements ILab_InvoiceGroupView.MpvRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property PdwRNv As String Implements ILab_InvoiceGroupView.PdwRNv
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property Remarks As String Implements ILab_InvoiceGroupView.Remarks
            Get
                Throw New NotImplementedException()
            End Get
            Set(value As String)
                Throw New NotImplementedException()
            End Set
        End Property

        Public Property LabInvoiceDetails As List(Of Lab_InvoiceDetailsView) Implements ILab_InvoiceGroupView.LabInvoiceDetails
            Get
                Return _labInvoiceDetails
            End Get
            Set(value As List(Of Lab_InvoiceDetailsView))
                _labInvoiceDetails = value
            End Set
        End Property

        Public Property Status As Integer Implements ILab_InvoiceGroupView.Status
            Get
                Return txtStatus.Text
            End Get
            Set(value As Integer)
                txtStatus.Text = value
                If value = 1 Then
                    txtStatusDisplay.Text = "Incomplete"
                ElseIf value = 2 Then
                    txtStatusDisplay.Text = "Partially Incomplete"
                ElseIf value = 3 Then
                    txtStatusDisplay.Text = "Complete"
                Else
                    txtStatusDisplay.Text = "Unknown"
                End If
            End Set
        End Property

        Private Sub btnRetrieve_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRetrieve.ClickButtonArea
            'Dim dInvDate As Date = DateAdd(DateInterval.Day, -2, Today)
            Dim filePath As String = "\\laboratory5\drivec\NihonKohden"
            Dim sFiles As String()
            ' Dim pattern As String = GlobalFunctions.DtoS(dInvDate) + "*_" + txtInvoiceNo.Text.ToString() + "*.csv"
            Dim pattern As String = "*_" + txtInvoiceNo.Text.ToString() + ".csv"
            'Dim Folder As New IO.DirectoryInfo("C:\NihonKohden")
            sFiles = Directory.GetFileSystemEntries(filePath, pattern)
            If Not CopyFileResultsToView(sFiles, filePath) Then
                Messaging.Show("No result with that invoice number was found on [" + filePath + "]")
            End If
            RaiseEvent RetrieveLabResultRequested()
            AssigValuesToDisplay()
        End Sub

        Private Sub AssigValuesToDisplay()
            For Each item In LabInvoiceDetails
                Select Case item.SlNo
                    Case 1
                        txtWbcR.Text = item.Result1
                        txtWbcRNv.Text = item.Suffix1
                    Case 2
                        txtNER.Text = item.Result1
                        txtNERNv.Text = item.Suffix1
                    Case 3
                        txtLYR.Text = item.Result1
                        txtLYRNv.Text = item.Suffix1
                    Case 4
                        txtMOR.Text = item.Result1
                        txtMORNv.Text = item.Suffix1
                    Case 5
                        txtEOR.Text = item.Result1
                        txtEORNv.Text = item.Suffix1
                    Case 6
                        txtBAR.Text = item.Result1
                        txtBARNv.Text = item.Suffix1
                    Case 8
                        txtRbcR.Text = item.Result1
                        txtRbcRNv.Text = item.Suffix1
                    Case 9
                        txtHgbR.Text = item.Result1
                        txtHgbRNv.Text = item.Suffix1
                    Case 10
                        txtHctR.Text = item.Result1
                        txtHctRNv.Text = item.Suffix1
                    Case 11
                        txtMcvR.Text = item.Result1
                        txtMcvRNv.Text = item.Suffix1
                    Case 12
                        txtMchR.Text = item.Result1
                        txtMchRNv.Text = item.Suffix1
                    Case 13
                        txtMchcR.Text = item.Result1
                        txtMchcRNv.Text = item.Suffix1
                    Case 14
                        txtRdwcvR.Text = item.Result1
                        txtRdwcvRNv.Text = item.Suffix1
                    Case 15
                        txtRdwsdR.Text = item.Result1
                        txtRdwsdRNv.Text = item.Suffix1
                    Case 17
                        txtPltR.Text = item.Result1
                        txtPltRNv.Text = item.Suffix1
                    Case 18
                        txtPctR.Text = item.Result1
                        txtPctRNv.Text = item.Suffix1
                    Case 19
                        txtMpvR.Text = item.Result1
                        txtMpvRNv.Text = item.Suffix1
                    Case 20
                        txtPdwR.Text = item.Result1
                        txtPdwRNv.Text = item.Suffix1
                End Select
            Next
            SetNormalValues()
        End Sub

        Private Sub SetNormalValues()
            Dim nAge As Decimal
            Select Case AgeYMD
                Case "Y"
                    nAge = txtAge.Text
                Case "M"
                    nAge = txtAge.Text / 12
                Case = "W"
                    nAge = txtAge.Text / 365.25
                Case = "D"
                    nAge = txtAge.Text * 7 / 365.25
                Case Else
                    nAge = 12
            End Select
            Select Case nAge
                Case <= 1
                    txtWbcNv.Text = "4.5 - 20.0 (10^3/µL)"
                    txtNENv.Text = "37 - 70 %"
                    txtLYNv.Text = "40 - 65 %"
                    txtMONv.Text = "0 - 12 %"
                    txtEONv.Text = "0 - 8 %"
                    txtBANv.Text = "0 - 3 %"

                    txtRbcNv.Text = "3.9 - 5.9 (10^6 /µL)"
                    txtHgbNv.Text = "14 - 18 g/dL"
                    txtHctNv.Text = "32 - 55 %"
                    txtMcvNv.Text = "80 - 100 fL"
                    txtMchNv.Text = "31 - 37 pg"
                    txtMchcNv.Text = "31 - 35 g/dL"
                    txtRdwcvNv.Text = "11.5 - 18.7 %"
                    txtRdwsdNv.Text = "39 - 46 fL"

                    txtPltNv.Text = "150 - 450 (10^3/µL)"
                    txtPctNv.Text = "0.16 - 0.33 %"
                    txtMpvNv.Text = "6.2 - 12.4 fL"
                    txtPdwNv.Text = "12.5 - 17 %"
                Case <= 11
                    txtWbcNv.Text = "4.5 - 13.0 (10^3/µL)"
                    txtNENv.Text = "30 - 65 %"
                    txtLYNv.Text = "20 - 65 %"
                    txtMONv.Text = "0 - 12 %"
                    txtEONv.Text = "0 - 8 %"
                    txtBANv.Text = "0 - 3 %"

                    txtRbcNv.Text = "3.8 - 5.4 (10^6/µL)"
                    txtHgbNv.Text = "11 - 16 g/dL"
                    txtHctNv.Text = "32 - 42 %"
                    txtMcvNv.Text = "72 - 86.6 fL"
                    txtMchNv.Text = "25 - 32 pg"
                    txtMchcNv.Text = "32 - 36 g/dL"
                    txtRdwcvNv.Text = "11.5 - 15.0 %"
                    txtRdwsdNv.Text = "39 - 46 fL"

                    txtPltNv.Text = "150 - 400 (10^3/µL)"
                    txtPctNv.Text = "0.16 - 0.33"
                    txtMpvNv.Text = "7 - 11 fL"
                    txtPdwNv.Text = "15 - 17"

                Case >= 12
                    If txtSex.Text = "F" Then
                        txtWbcNv.Text = "4 - 10 (10^3/µL)"
                        txtNENv.Text = "37 - 65 %"
                        txtLYNv.Text = "16 - 51 %"
                        txtMONv.Text = "0 - 12 %"
                        txtEONv.Text = "0 - 8 %"
                        txtBANv.Text = "0 - 3 %"

                        txtRbcNv.Text = "3.85 - 5.2 (10^6/µL)"
                        txtHgbNv.Text = "11.5 - 16 g/dL"
                        txtHctNv.Text = "34.7 - 46 %"
                        txtMcvNv.Text = "80 - 97 fL"
                        txtMchNv.Text = "26 - 34 pg"
                        txtMchcNv.Text = "31 - 36 g/dL"
                        txtRdwcvNv.Text = "11.5 - 15.0 %"
                        txtRdwsdNv.Text = "39 - 46 fL"

                        txtPltNv.Text = "150 - 350 (10^3/µL)"
                        txtPctNv.Text = "0.16 - 0.33 %"
                        txtMpvNv.Text = "6.5 - 12.4 fL"
                        txtPdwNv.Text = "15 - 17 %"

                    Else
                        txtWbcNv.Text = "4 - 10 (10^3/µL)"
                        txtNENv.Text = "37 - 65 %"
                        txtLYNv.Text = "16 - 51 %"
                        txtMONv.Text = "0 - 12 %"
                        txtEONv.Text = "0 - 8 %"
                        txtBANv.Text = "0 - 3 %"

                        txtRbcNv.Text = "4.31 - 6.4 (10^6/µL)"
                        txtHgbNv.Text = "13.6 - 18.0 g/dL"
                        txtHctNv.Text = "39.8 - 52.0 %"
                        txtMcvNv.Text = "80 - 97 fL"
                        txtMchNv.Text = "26 - 34 pg"
                        txtMchcNv.Text = "31 - 36 g/dL"
                        txtRdwcvNv.Text = "11.5 - 15.0 %"
                        txtRdwsdNv.Text = "39 - 46 fL"

                        txtPltNv.Text = "150 - 350 (10^3/µL)"
                        txtPctNv.Text = "0.16 - 0.33 %"
                        txtMpvNv.Text = "6.5 - 12.4 fL"
                        txtPdwNv.Text = "15 - 17 %"
                    End If
            End Select
        End Sub

        Private Function CopyFileResultsToView(sFiles() As String, filePath As String) As Boolean
            Dim success As Boolean
            Dim aFileResults(146) As String
            Dim aCBCResults(19) As String

            'sFiles = Folder.GetFiles(cFilePath + "*.csv",IO.SearchOption.AllDirectories)
            If sFiles.Count() = 1 Then
                GetResultOnFile(sFiles, aFileResults, aCBCResults)
                success = True
            ElseIf sFiles.Count() > 1 Then
                Messaging.Show("Multiple results found on file, please manually select the record you want to transfer")
                Dim cbcReportSelector As New CbcReportSelector(sFiles, filePath, txtInvoiceNo.Text)
                Dim result = cbcReportSelector.ShowDialog()
                If result = DialogResult.OK Then
                    Dim cPatern = sFiles(cbcReportSelector.SelectedIndex).Substring(filePath.Length + 1)
                    Dim cFile = Directory.GetFileSystemEntries(filePath, cPatern)
                    GetResultOnFile(cFile, aFileResults, aCBCResults)
                    success = True
                Else
                    success = False
                End If
            Else
                success = False
            End If
            Return success
        End Function

        Private Sub GetResultOnFile(sFiles() As String, aFileResults() As String, aCBCResults() As String)
            Dim lineCount = File.ReadAllLines(sFiles(0)).Length
            Using file As New IO.StreamReader(sFiles(0))
                For i As Integer = 1 To 146
                    aFileResults(i) = file.ReadLine()
                Next
            End Using
            FileResultsToCbcResults(aFileResults, aCBCResults)
            txtPatientName.Text = aFileResults(143)
            txtSexF.Text = aFileResults(144)
            txtAgeF.Text = aFileResults(146)
        End Sub

        Private Sub GetResultOnServer(invoiceNumber As Int32)
            Dim serverResult As ILab_InvoiceGroupView
            serverResult = Presenter.GetResult(invoiceNumber)

        End Sub

        Private Sub FileResultsToCbcResults(aFileResults() As String, aCBCResults() As String)
            aCBCResults(CBCEnum.Wbc) = aFileResults(15)
            aCBCResults(CBCEnum.NE) = aFileResults(16) 
            aCBCResults(CBCEnum.LY) = aFileResults(17) 
            aCBCResults(CBCEnum.MO) = aFileResults(18) 
            aCBCResults(CBCEnum.EO) = aFileResults(19) 
            aCBCResults(CBCEnum.BA) = aFileResults(20) 
            aCBCResults(CBCEnum.Rbc) = aFileResults(26)
            aCBCResults(CBCEnum.Hgb) = aFileResults(27)
            aCBCResults(CBCEnum.Hct) = aFileResults(28)
            aCBCResults(CBCEnum.Mcv) = aFileResults(29)
            aCBCResults(CBCEnum.Mch) = aFileResults(30)
            aCBCResults(CBCEnum.Mchc) = aFileResults(31)
            aCBCResults(CBCEnum.Rdwcv) = aFileResults(32)
            aCBCResults(CBCEnum.Rdwsd) = aFileResults(49)
            aCBCResults(CBCEnum.Plt) = aFileResults(33)
            aCBCResults(CBCEnum.Pct) = aFileResults(34)
            aCBCResults(CBCEnum.Mpv) = aFileResults(35)
            aCBCResults(CBCEnum.Pdw) = aFileResults(36)
            CbcResultsToView(aCBCResults)
        End Sub

        Private Sub CbcResultsToView(aCBCResults() As String)
            txtWbc.Text = aCBCResults(CBCEnum.Wbc) + " 10^3/µL"
            txtNE.Text = aCBCResults(CBCEnum.NE) + "%"
            txtLY.Text = aCBCResults(CBCEnum.LY) + "%"
            txtMO.Text = aCBCResults(CBCEnum.MO) + "%"
            txtEO.Text = aCBCResults(CBCEnum.EO) + "%"
            txtBA.Text = aCBCResults(CBCEnum.BA) + "%"
            txtRbc.Text = aCBCResults(CBCEnum.Rbc) + " 10^6/µL"
            txtHgb.Text = aCBCResults(CBCEnum.Hgb) + " g/dL"
            txtHct.Text = aCBCResults(CBCEnum.Hct) + "%"
            txtMcv.Text = aCBCResults(CBCEnum.Mcv) + " fL"
            txtMch.Text = aCBCResults(CBCEnum.Mch) + " pg"
            txtMchc.Text = aCBCResults(CBCEnum.Mchc) + " g/dL"
            txtRdwcv.Text = aCBCResults(CBCEnum.Rdwcv) + "%"
            txtRdwsd.Text = aCBCResults(CBCEnum.Rdwsd) + " fL"
            txtPlt.Text = aCBCResults(CBCEnum.Plt) + " 10^3/µL"
            txtPct.Text = aCBCResults(CBCEnum.Pct) + "%"
            txtMpv.Text = aCBCResults(CBCEnum.Mpv) + " fL"
            txtPdw.Text = aCBCResults(CBCEnum.Pdw) + "%"
        End Sub

        'Protected Overrides Sub CreateMainFieldsDictionary()
        '    MainFieldsDictionary = New Dictionary(Of String, Object) From
        '        {{"DosageForm", cboDosageForm},
        '        {"GenericName", txtGenericName},
        '        {"IdNo", txtInvoiceNo},
        '        {"ItemDetailsCode", txtInvoiceType},
        '        {"ItemDetailsName", TxtItemDetailsName},
        '        {"PackageSize", txtRbc},
        '        {"PackageType", cboPackageType},
        '        {"PrescriptionDrug", chkPrescriptionDrug},
        '        {"RegistrationNo", txtHgb},
        '        {"RouteOfAdministration", cboRouteOfAdministration},
        '        {"StrengthValue", txtWbc},
        '        {"UnitOfStrength", cboUnitOfStrength},
        '        {"UnitOfVolume", cboUnitOfVolume},
        '        {"Volume", txtMO}
        '        }
        'End Sub

        'Protected Overrides Sub BeforeEdit()
        '    If Strings.Left(RegistrationNo, 1) <> "X" Then
        '        SetDisplayOnly(True)
        '    Else
        '        SetDisplayOnly(False)
        '    End If
        '    Refresh()
        'End Sub

        'Private Sub SetDisplayOnly(value As Boolean)
        '    cboDosageForm.DisplayOnly = value
        '    txtGenericName.DisplayOnly = value
        '    txtRbc.DisplayOnly = value
        '    cboPackageType.DisplayOnly = value
        '    txtHgb.DisplayOnly = value
        '    cboRouteOfAdministration.DisplayOnly = value
        '    txtWbc.DisplayOnly = value
        '    cboUnitOfStrength.DisplayOnly = value
        '    cboUnitOfVolume.DisplayOnly = value
        '    txtMO.DisplayOnly = value
        'End Sub

        'Private Sub chkPrescriptionDrug_CheckedChanged(sender As Object, e As EventArgs) 
        '    If chkPrescriptionDrug.Checked Then
        '        SetDisplayOnly(False)
        '    Else
        '        SetDisplayOnly(True)
        '    End If
        'End Sub


        Public Enum CBCEnum
            Wbc
            LY
            NE
            MO
            EO
            BA
            Rbc
            Hgb
            Hct
            Mcv
            Mch
            Mchc
            Rdwcv
            Rdwsd
            Plt
            Pct
            Mpv
            Pdw
        End Enum

#End Region

    End Class




End Namespace