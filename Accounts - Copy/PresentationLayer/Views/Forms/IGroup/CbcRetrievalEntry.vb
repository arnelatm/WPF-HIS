Imports System.Configuration
Imports System.Globalization
Imports System.IO
Imports System.Text.RegularExpressions
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary

Namespace PresentationLayer.Views.Forms

    Public Class CbcRetrievalEntry
        Implements ILab_InvoiceGroupView

        Private _nfi As NumberFormatInfo
        Private Event RetrieveLabResultRequested() Implements ILab_InvoiceGroupView.RetrieveLabResultRequested
        Private Event SaveResultRequested() Implements ILab_InvoiceGroupView.SaveResultRequested

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

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
            txtRemarks.Enabled = True
        End Sub

#Region "Field Items"
        Public Property InvoiceNo As Decimal Implements ILab_InvoiceGroupView.InvoiceNo
            Get
                If txtInvoiceNo.Text Is Nothing Or txtInvoiceNo.Text = "" Then
                    Return 0
                Else
                    Return txtInvoiceNo.Text
                End If
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
                If txtAge.Text Is Nothing Or txtAge.Text = "" Then
                    Return 0
                Else
                    Return txtAge.Text
                End If
            End Get
            Set(value As Decimal)
                txtAge.Text = value
                If AgeYMD = "Y" Then
                    txtAgeDisplay.Text = value.ToString() + IIf(value <= 1, " year", " years")
                ElseIf AgeYMD = "M" Then
                    txtAgeDisplay.Text = value.ToString() + IIf(value <= 1, " month", " months")
                ElseIf AgeYMD = "W" Then
                    txtAgeDisplay.Text = value.ToString() + IIf(value <= 1, " week", " weeks")
                ElseIf AgeYMD = "D" Then
                    txtAgeDisplay.Text = value.ToString() + IIf(value <= 1, " day", " days")
                Else
                    txtAgeDisplay.Text = value.ToString() + IIf(value <= 1, " year", " years")
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
                If txtRegistrationNo.Text Is Nothing Or txtRegistrationNo.Text = "" Then
                    Return 0
                End If
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
                Return txtWbc.Text
            End Get
            Set(value As String)
                txtWbc.Text = value
            End Set
        End Property

        Public Property NE As String Implements ILab_InvoiceGroupView.NE
            Get
                Return txtNE.Text
            End Get
            Set(value As String)
                txtNE.Text = value
            End Set
        End Property

        Public Property Ly As String Implements ILab_InvoiceGroupView.Ly
            Get
                Return txtLY.Text
            End Get
            Set(value As String)
                txtLY.Text = value
            End Set
        End Property

        Public Property Mo As String Implements ILab_InvoiceGroupView.Mo
            Get
                Return txtMO.Text
            End Get
            Set(value As String)
                txtMO.Text = value
            End Set
        End Property

        Public Property Eo As String Implements ILab_InvoiceGroupView.Eo
            Get
                Return txtEO.Text
            End Get
            Set(value As String)
                txtEO.Text = value
            End Set
        End Property

        Public Property Ba As String Implements ILab_InvoiceGroupView.Ba
            Get
                Return txtBA.Text
            End Get
            Set(value As String)
                txtBA.Text = value
            End Set
        End Property

        Public Property Rbc As String Implements ILab_InvoiceGroupView.Rbc
            Get
                Return txtRbc.Text
            End Get
            Set(value As String)
                txtRbc.Text = value
            End Set
        End Property

        Public Property Hgb As String Implements ILab_InvoiceGroupView.Hgb
            Get
                Return txtHgb.Text
            End Get
            Set(value As String)
                txtHgb.Text = value
            End Set
        End Property

        Public Property Hct As String Implements ILab_InvoiceGroupView.Hct
            Get
                Return txtHct.Text
            End Get
            Set(value As String)
                txtHct.Text = value
            End Set
        End Property

        Public Property Mcv As String Implements ILab_InvoiceGroupView.Mcv
            Get
                Return txtMcv.Text
            End Get
            Set(value As String)
                txtMcv.Text = value
            End Set
        End Property

        Public Property Mch As String Implements ILab_InvoiceGroupView.Mch
            Get
                Return txtMch.Text
            End Get
            Set(value As String)
                txtMch.Text = value
            End Set
        End Property

        Public Property Mchc As String Implements ILab_InvoiceGroupView.Mchc
            Get
                Return txtMchc.Text
            End Get
            Set(value As String)
                txtMchc.Text = value
            End Set
        End Property

        Public Property Rdwcv As String Implements ILab_InvoiceGroupView.Rdwcv
            Get
                Return txtRdwcv.Text
            End Get
            Set(value As String)
                txtRdwcv.Text = value
            End Set
        End Property

        Public Property Rdwsd As String Implements ILab_InvoiceGroupView.Rdwsd
            Get
                Return txtRdwsd.Text
            End Get
            Set(value As String)
                txtRdwsd.Text = value
            End Set
        End Property

        Public Property Plt As String Implements ILab_InvoiceGroupView.Plt
            Get
                Return txtPlt.Text
            End Get
            Set(value As String)
                txtPlt.Text = value
            End Set
        End Property

        Public Property Pct As String Implements ILab_InvoiceGroupView.Pct
            Get
                Return txtPct.Text
            End Get
            Set(value As String)
                txtPct.Text = value
            End Set
        End Property

        Public Property Mpv As String Implements ILab_InvoiceGroupView.Mpv
            Get
                Return txtMpv.Text
            End Get
            Set(value As String)
                txtMpv.Text = value
            End Set
        End Property

        Public Property Pdw As String Implements ILab_InvoiceGroupView.Pdw
            Get
                Return txtPdw.Text
            End Get
            Set(value As String)
                txtPdw.Text = value
            End Set
        End Property

        Public Property WbcNv As String Implements ILab_InvoiceGroupView.WbcNv
            Get
                Return txtWbcNv.Text
            End Get
            Set(value As String)
                txtWbcNv.Text = value
            End Set
        End Property

        Public Property NENv As String Implements ILab_InvoiceGroupView.NENv
            Get
                Return txtNENv.Text
            End Get
            Set(value As String)
                txtNENv.Text = value
            End Set
        End Property

        Public Property LyNv As String Implements ILab_InvoiceGroupView.LyNv
            Get
                Return txtLYNv.Text
            End Get
            Set(value As String)
                txtLYNv.Text = value
            End Set
        End Property

        Public Property MoNv As String Implements ILab_InvoiceGroupView.MoNv
            Get
                Return txtMONv.Text
            End Get
            Set(value As String)
                txtMONv.Text = value
            End Set
        End Property

        Public Property EoNv As String Implements ILab_InvoiceGroupView.EoNv
            Get
                Return txtEONv.Text
            End Get
            Set(value As String)
                txtEONv.Text = value
            End Set
        End Property

        Public Property BaNv As String Implements ILab_InvoiceGroupView.BaNv
            Get
                Return txtBANv.Text
            End Get
            Set(value As String)
                txtBANv.Text = value
            End Set
        End Property

        Public Property RbcNv As String Implements ILab_InvoiceGroupView.RbcNv
            Get
                Return txtRbcNv.Text
            End Get
            Set(value As String)
                txtRbcNv.Text = value
            End Set
        End Property

        Public Property HgbNv As String Implements ILab_InvoiceGroupView.HgbNv
            Get
                Return txtHgbNv.Text
            End Get
            Set(value As String)
                txtHgbNv.Text = value
            End Set
        End Property

        Public Property HctNv As String Implements ILab_InvoiceGroupView.HctNv
            Get
                Return txtHctNv.Text
            End Get
            Set(value As String)
                txtHctNv.Text = value
            End Set
        End Property

        Public Property McvNv As String Implements ILab_InvoiceGroupView.McvNv
            Get
                Return txtMcvNv.Text
            End Get
            Set(value As String)
                txtMcvNv.Text = value
            End Set
        End Property

        Public Property MchNv As String Implements ILab_InvoiceGroupView.MchNv
            Get
                Return txtMchNv.Text
            End Get
            Set(value As String)
                txtMchNv.Text = value
            End Set
        End Property

        Public Property MchcNv As String Implements ILab_InvoiceGroupView.MchcNv
            Get
                Return txtMchcNv.Text
            End Get
            Set(value As String)
                txtMchcNv.Text = value
            End Set
        End Property

        Public Property RdwcvNv As String Implements ILab_InvoiceGroupView.RdwcvNv
            Get
                Return txtRdwcvNv.Text
            End Get
            Set(value As String)
                txtRdwcvNv.Text = value
            End Set
        End Property

        Public Property RdwsdNv As String Implements ILab_InvoiceGroupView.RdwsdNv
            Get
                Return txtRdwsdNv.Text
            End Get
            Set(value As String)
                txtRdwsdNv.Text = value
            End Set
        End Property

        Public Property PltNv As String Implements ILab_InvoiceGroupView.PltNv
            Get
                Return txtPltNv.Text
            End Get
            Set(value As String)
                txtPltNv.Text = value
            End Set
        End Property

        Public Property PctNv As String Implements ILab_InvoiceGroupView.PctNv
            Get
                Return txtPctNv.Text
            End Get
            Set(value As String)
                txtPctNv.Text = value
            End Set
        End Property

        Public Property MpvNv As String Implements ILab_InvoiceGroupView.MpvNv
            Get
                Return txtMpvNv.Text
            End Get
            Set(value As String)
                txtMpvNv.Text = value
            End Set
        End Property

        Public Property PdwNv As String Implements ILab_InvoiceGroupView.PdwNv
            Get
                Return txtPdwNv.Text
            End Get
            Set(value As String)
                txtPdwNv.Text = value
            End Set
        End Property

        Public Property WbcR As String Implements ILab_InvoiceGroupView.WbcR
        Public Property NeR As String Implements ILab_InvoiceGroupView.NeR
        Public Property LyR As String Implements ILab_InvoiceGroupView.LyR
        Public Property MoR As String Implements ILab_InvoiceGroupView.MoR
        Public Property EoR As String Implements ILab_InvoiceGroupView.EoR
        Public Property BaR As String Implements ILab_InvoiceGroupView.BaR
        Public Property RbcR As String Implements ILab_InvoiceGroupView.RbcR
        Public Property HgbR As String Implements ILab_InvoiceGroupView.HgbR
        Public Property HctR As String Implements ILab_InvoiceGroupView.HctR
        Public Property McvR As String Implements ILab_InvoiceGroupView.McvR
        Public Property MchR As String Implements ILab_InvoiceGroupView.MchR
        Public Property MchcR As String Implements ILab_InvoiceGroupView.MchcR
        Public Property RdwcvR As String Implements ILab_InvoiceGroupView.RdwcvR
        Public Property RdwcdR As String Implements ILab_InvoiceGroupView.RdwsdR
        Public Property PltR As String Implements ILab_InvoiceGroupView.PltR
        Public Property PctR As String Implements ILab_InvoiceGroupView.PctR
        Public Property MpvR As String Implements ILab_InvoiceGroupView.MpvR
        Public Property PdwR As String Implements ILab_InvoiceGroupView.PdwR
        Public Property WbcRNv As String Implements ILab_InvoiceGroupView.WbcRNv
        Public Property NeRNv As String Implements ILab_InvoiceGroupView.NeRNv
        Public Property LyRNv As String Implements ILab_InvoiceGroupView.LyRNv
        Public Property MoRNv As String Implements ILab_InvoiceGroupView.MoRNv
        Public Property EoRNv As String Implements ILab_InvoiceGroupView.EoRNv
        Public Property BaRNv As String Implements ILab_InvoiceGroupView.BaRNv
        Public Property RbcRNv As String Implements ILab_InvoiceGroupView.RbcRNv
        Public Property HgbRNv As String Implements ILab_InvoiceGroupView.HgbRNv
        Public Property HctRNv As String Implements ILab_InvoiceGroupView.HctRNv
        Public Property McvRNv As String Implements ILab_InvoiceGroupView.McvRNv
        Public Property MchRNv As String Implements ILab_InvoiceGroupView.MchRNv
        Public Property MchcRNv As String Implements ILab_InvoiceGroupView.MchcRNv
        Public Property RdwcvRNv As String Implements ILab_InvoiceGroupView.RdwcvRNv
        Public Property RdwcdRNv As String Implements ILab_InvoiceGroupView.RdwsdRNv
        Public Property PltRNv As String Implements ILab_InvoiceGroupView.PltRNv
        Public Property PctRNv As String Implements ILab_InvoiceGroupView.PctRNv
        Public Property MpvRNv As String Implements ILab_InvoiceGroupView.MpvRNv
        Public Property PdwRNv As String Implements ILab_InvoiceGroupView.PdwRNv
        Public Property Remarks As String Implements ILab_InvoiceGroupView.Remarks
            Get
                Return txtRemarks.Text
            End Get
            Set(value As String)
                txtRemarks.Text = value
            End Set
        End Property
        Public Property LabInvoiceDetails As List(Of Lab_InvoiceDetailsView) Implements ILab_InvoiceGroupView.LabInvoiceDetails

        Public Property Status As Integer Implements ILab_InvoiceGroupView.Status
            Get
                Return txtStatus.Text
            End Get
            Set(value As Integer)
                txtStatus.Text = value
                btnTransferResults.Enabled = True
                If value = 0 Then
                    txtStatusDisplay.Text = "Incomplete"
                ElseIf value = 1 Then
                    txtStatusDisplay.Text = "Partially Incomplete"
                ElseIf value = 2 Then
                    txtStatusDisplay.Text = "Complete"
                    btnTransferResults.Enabled = False
                Else
                    txtStatusDisplay.Text = "Unknown"
                End If
            End Set
        End Property


#End Region

        'Private Sub btnRetrieve_ClickButtonArea_1(Sender As Object, e As MouseEventArgs) Handles btnRetrieve.ClickButtonArea
        '    RaiseEvent RetrieveLabResultRequested()
        '    AssigValuesToDisplay()
        'End Sub

        Private Sub btnRetrieve_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnRetrieve.ClickButtonArea
            RetrieveResult()
        End Sub

        Private Sub RetrieveResult()
            If InvoiceNo = 0 Then
                Messaging.Show("Sorry you must enter the invoice number to be retrieved.")
            Else
                Dim filePath As String = "\\laboratory5\drivec\NihonKohden"
                Dim sFiles As String()
                Dim pattern As String = "*_" + txtInvoiceNo.Text.ToString() + ".csv"
                sFiles = Directory.GetFileSystemEntries(filePath, pattern)
                If Not CopyFileResultsToView(sFiles, filePath) Then
                    Messaging.Show("No result with that invoice number was found on [" + filePath + "]")
                    Dim allControls As New List(Of Control)
                    allControls = FindControlRecursive(allControls, Me)
                    For Each cCtrl As Control In allControls
                        If TypeOf cCtrl Is CTextBox Then
                            cCtrl.Text = ""
                        End If
                    Next
                Else
                    RaiseEvent RetrieveLabResultRequested()
                    AssigValuesToDisplay()
                End If
            End If
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

        Private Function StripNonNumbers(value As String)
            Dim num As String
            num = Regex.Replace(value, "[^0-9.]", "")
            Return num
        End Function

        Private Function StripAsterisk(value As String)
            Dim num As String
            num = value.Replace("*", String.Empty)
            Return num
        End Function


        Private Function RemoveDigits(ByVal S As String) As String
            Dim txt As String
            txt = Regex.Replace(S, "\d", "")
            txt = txt.Replace(".", String.Empty)
            Return txt
        End Function

        Private Function Transform(ByVal value As String, suffix As String) As String
            Dim retVal As String
            retVal = StripNonNumbers(value)
            retVal = (retVal + suffix).PadRight(25, " ")
            retVal = retVal + RemoveDigits(value)
            retVal = Trim(StripAsterisk(retVal))
            Return retVal
        End Function

        Private Sub CbcResultsToView(aCBCResults() As String)
            txtWbc.Text = Transform(aCBCResults(CBCEnum.Wbc), " 10^3/µL")
            txtNE.Text = Transform(aCBCResults(CBCEnum.NE), "%")
            txtLY.Text = Transform(aCBCResults(CBCEnum.LY), "%")
            txtMO.Text = Transform(aCBCResults(CBCEnum.MO), "%")
            txtEO.Text = Transform(aCBCResults(CBCEnum.EO), "%")
            txtBA.Text = Transform(aCBCResults(CBCEnum.BA), "%")
            txtRbc.Text = Transform(aCBCResults(CBCEnum.Rbc), " 10^6/µL")
            txtHgb.Text = Transform(aCBCResults(CBCEnum.Hgb), " g/dL")
            txtHct.Text = Transform(aCBCResults(CBCEnum.Hct), "%")
            txtMcv.Text = Transform(aCBCResults(CBCEnum.Mcv), " fL")
            txtMch.Text = Transform(aCBCResults(CBCEnum.Mch), " pg")
            txtMchc.Text = Transform(aCBCResults(CBCEnum.Mchc), " g/dL")
            txtRdwcv.Text = Transform(aCBCResults(CBCEnum.Rdwcv), "%")
            txtRdwsd.Text = Transform(aCBCResults(CBCEnum.Rdwsd), " fL")
            txtPlt.Text = Transform(aCBCResults(CBCEnum.Plt), " 10^3/µL")
            txtPct.Text = Transform(aCBCResults(CBCEnum.Pct), "%")
            txtMpv.Text = Transform(aCBCResults(CBCEnum.Mpv), " fL")
            txtPdw.Text = Transform(aCBCResults(CBCEnum.Pdw), "%")
        End Sub

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


        Private Sub btnTransferResults_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnTransferResults.ClickButtonArea
            RaiseEvent SaveResultRequested()
        End Sub

        Private Sub txtInvoiceNo_Leave(sender As Object, e As EventArgs) Handles txtInvoiceNo.Leave
            RetrieveResult()
        End Sub

        Private Sub txtRemarks_TextChanged(sender As Object, e As EventArgs) Handles txtRemarks.TextChanged

        End Sub
    End Class




End Namespace