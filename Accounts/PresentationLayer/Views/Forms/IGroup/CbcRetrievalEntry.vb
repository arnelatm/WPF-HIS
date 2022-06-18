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

            'TurnOnInputs()

        End Sub

#Region "Field Items Old"

        'Public Property IdNo As Int32 Implements IItemDetailsView.IdNo
        '    Get
        '        If txtInvoiceNo.Text <> "" Then
        '            Return Convert.ToInt32(txtInvoiceNo.Text)
        '        Else
        '            Return 0
        '        End If
        '    End Get
        '    Set
        '        txtInvoiceNo.Text = Convert.ToString(Value)
        '    End Set
        'End Property

        'Public Property ItemDetailsCode As String Implements IItemDetailsView.ItemDetailsCode
        '    Get
        '        Return txtInvoiceType.Text
        '    End Get
        '    Set
        '        txtInvoiceType.Text = If(Value, "")
        '    End Set
        'End Property

        'Public Overloads Property ItemDetailsName As String Implements IItemDetailsView.ItemDetailsName
        '    Get
        '        Return TxtItemDetailsName.Text
        '    End Get
        '    Set
        '        TxtItemDetailsName.Text = Value
        '    End Set
        'End Property

        'Private _itemGroup = "MD"
        'Public Property ItemGroup As String Implements IItemDetailsView.ItemGroup
        '    Get
        '        Return "MD"
        '    End Get
        '    Set(value As String)
        '        _itemGroup = value
        '    End Set
        'End Property

        'Public Overloads Property GenericName As String Implements IItemDetailsView.GenericName
        '    Get
        '        Return txtGenericName.Text
        '    End Get
        '    Set
        '        txtGenericName.Text = Value
        '    End Set
        'End Property

        'Private _pack1 As Short
        'Public Property Pack1 As Short Implements IItemDetailsView.Pack1
        '    Get
        '        Return 1
        '    End Get
        '    Set(value As Short)
        '        _pack1 = value
        '    End Set
        'End Property

        'Private _pack2 As Short
        'Public Property Pack2 As Short Implements IItemDetailsView.Pack2
        '    Get
        '        Return 1
        '    End Get
        '    Set(value As Short)
        '        _pack2 = value
        '    End Set
        'End Property

        'Private _pack3 As Short
        'Public Property Pack3 As Short Implements IItemDetailsView.Pack3
        '    Get
        '        Return 1
        '    End Get
        '    Set(value As Short)
        '        _pack3 = value
        '    End Set
        'End Property

        'Private _branchID As String
        'Public Property BranchID As String Implements IItemDetailsView.BranchID
        '    Get
        '        Return "01"
        '    End Get
        '    Set(value As String)
        '        _branchID = value
        '    End Set
        'End Property

        'Private _created_By_Branch As String
        'Public Property Created_By_Branch As String Implements IItemDetailsView.Created_By_Branch
        '    Get
        '        Return "01"
        '    End Get
        '    Set(value As String)
        '        _category = value
        '    End Set
        'End Property

        'Private _category As String
        'Public Property Category As String Implements IItemDetailsView.Category
        '    Get
        '        Return "XX"
        '    End Get
        '    Set(value As String)
        '        _category = value
        '    End Set
        'End Property

        'Public Property RegistrationNo As String Implements IItemDetailsView.RegistrationNo
        '    Get
        '        Return txtHgb.Text
        '    End Get
        '    Set
        '        txtHgb.Text = Value
        '    End Set
        'End Property

        'Private _saleStrip As String
        'Public Property SaleStrip As String Implements IItemDetailsView.SaleStrip
        '    Get
        '        Return "N"
        '    End Get
        '    Set(value As String)
        '        _category = value
        '    End Set
        'End Property

        'Private _Item_Status As String
        'Public Property Item_Status As String Implements IItemDetailsView.Item_Status
        '    Get
        '        Return "S"
        '    End Get
        '    Set(value As String)
        '        _category = value
        '    End Set
        'End Property

        'Private _userID As String
        'Public Property UserID As String Implements IItemDetailsView.UserId
        '    Get
        '        Return GlobalVariables.UserName
        '    End Get
        '    Set(value As String)
        '        _category = value
        '    End Set
        'End Property

        'Public Property UnitOfStrength As String Implements IItemDetailsView.UnitOfStrength
        '    Get
        '        Return cboUnitOfStrength.GetNullableValue(Of String)
        '    End Get
        '    Set(value As String)
        '        cboUnitOfStrength.SetValue(value)
        '    End Set
        'End Property

        'Public Property UnitOfVolume As String Implements IItemDetailsView.UnitOfVolume
        '    Get
        '        Return cboUnitOfVolume.GetNullableValue(Of String)
        '    End Get
        '    Set(value As String)
        '        cboUnitOfVolume.SetValue(value)
        '    End Set
        'End Property

        'Public Property PackageType As String Implements IItemDetailsView.PackageType
        '    Get
        '        Return cboPackageType.GetNullableValue(Of String)
        '    End Get
        '    Set(value As String)
        '        cboPackageType.SetValue(value)
        '    End Set
        'End Property

        'Public Property DosageForm As String Implements IItemDetailsView.DosageForm
        '    Get
        '        Return cboDosageForm.GetNullableValue(Of String)
        '    End Get
        '    Set(value As String)
        '        cboDosageForm.SetValue(value)
        '    End Set
        'End Property

        'Public Property RouteOfAdministration As String Implements IItemDetailsView.RouteOfAdministration
        '    Get
        '        Return cboRouteOfAdministration.GetNullableValue(Of String)
        '    End Get
        '    Set(value As String)
        '        cboRouteOfAdministration.SetValue(value)
        '    End Set
        'End Property

        'Public Property Volume As Double? Implements IItemDetailsView.Volume
        '    Get
        '        If txtMO.Text Is Nothing Then
        '            Return Nothing
        '        Else
        '            Return txtMO.Text.ToDoubleNumber(_nfi)
        '        End If
        '    End Get
        '    Set
        '        If Value Is Nothing Then
        '            txtMO.Text = ""
        '        Else
        '            txtMO.Text = Value
        '        End If
        '    End Set
        'End Property

        'Public Property StrengthValue As String Implements IItemDetailsView.StrengthValue
        '    Get
        '        Return txtWbc.Text
        '    End Get
        '    Set(value As String)
        '        txtWbc.Text = value
        '    End Set
        'End Property

        'Public Property PackageSize As Double? Implements IItemDetailsView.PackageSize
        '    Get
        '        If txtRbc.Text Is Nothing Then
        '            Return Nothing
        '        Else
        '            Return txtRbc.Text.ToDoubleNumber(_nfi)
        '        End If
        '    End Get
        '    Set
        '        If Value Is Nothing Then
        '            txtRbc.Text = ""
        '        Else
        '            txtRbc.Text = Value
        '        End If
        '    End Set
        'End Property

        'Public Property PrescriptionDrug As Boolean Implements IItemDetailsView.PrescriptionDrug
        '    Get
        '        Return chkPrescriptionDrug.Checked
        '    End Get
        '    Set
        '        chkPrescriptionDrug.Checked = Value                
        '    End Set
        'End Property
#End Region

#Region "Field Items"
        Public Property InvoiceNo As String Implements ILab_InvoiceGroupView.InvoiceNo
            Get
                Return txtInvoiceNo.Text
            End Get
            Set(value As String)
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
                txtSexDisplay.Text = value
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
                Return txtStatusDisplay.Text
            End Get
            Set(value As Integer)
                txtStatusDisplay.Text = value
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
        End Sub

        Private Function CopyFileResultsToView(sFiles() As String, filePath As String) As Boolean
            Dim success As Boolean
            Dim aFileResults(144) As String
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
                For i As Integer = 1 To 144
                    aFileResults(i) = file.ReadLine()
                Next
            End Using
            FileResultsToCbcResults(aFileResults, aCBCResults)
            txtPatientName.Text = aFileResults(143)
            txtSexDisplay.Text = aFileResults(144)
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
            txtWbc.Text = aCBCResults(CBCEnum.Wbc)
            txtNE.Text = aCBCResults(CBCEnum.NE)
            txtLY.Text = aCBCResults(CBCEnum.Wbc)
            txtMO.Text = aCBCResults(CBCEnum.MO)
            txtEO.Text = aCBCResults(CBCEnum.EO)
            txtBA.Text = aCBCResults(CBCEnum.BA)
            txtRbc.Text = aCBCResults(CBCEnum.Rbc)
            txtHgb.Text = aCBCResults(CBCEnum.Hgb)
            txtHct.Text = aCBCResults(CBCEnum.Hct)
            txtMcv.Text = aCBCResults(CBCEnum.Mcv)
            txtMch.Text = aCBCResults(CBCEnum.Mch)
            txtMchc.Text = aCBCResults(CBCEnum.Mchc)
            txtRdwcv.Text = aCBCResults(CBCEnum.Rdwcv)
            txtRdwsd.Text = aCBCResults(CBCEnum.Rdwsd)
            txtPlt.Text = aCBCResults(CBCEnum.Plt)
            txtPct.Text = aCBCResults(CBCEnum.Pct)
            txtMpv.Text = aCBCResults(CBCEnum.Mpv)
            txtPdw.Text = aCBCResults(CBCEnum.Pdw)
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