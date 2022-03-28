Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class ItemDetailsEntry
        Implements IItemDetailsView


        Private _nfi As NumberFormatInfo

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()
            FirstControl = TxtItemDetailsName

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

        Public Property IdNo As Int32 Implements IItemDetailsView.IdNo
            Get
                If TxtIdNo.Text <> "" Then
                    Return Convert.ToInt32(TxtIdNo.Text)
                Else
                    Return 0
                End If
            End Get
            Set
                TxtIdNo.Text = Convert.ToString(Value)
            End Set
        End Property

        Public Property ItemDetailsCode As String Implements IItemDetailsView.ItemDetailsCode
            Get
                Return TxtItemDetailsCode.Text
            End Get
            Set
                TxtItemDetailsCode.Text = If(Value, "")
            End Set
        End Property

        Public Overloads Property ItemDetailsName As String Implements IItemDetailsView.ItemDetailsName
            Get
                Return TxtItemDetailsName.Text
            End Get
            Set
                TxtItemDetailsName.Text = Value
            End Set
        End Property

        Private _itemGroup = "MD"
        Public Property ItemGroup As String Implements IItemDetailsView.ItemGroup
            Get
                Return "MD"
            End Get
            Set(value As String)
                _itemGroup = value
            End Set
        End Property

        Public Overloads Property GenericName As String Implements IItemDetailsView.GenericName
            Get
                Return txtGenericName.Text
            End Get
            Set
                txtGenericName.Text = Value
            End Set
        End Property

        Private _pack1 As Short
        Public Property Pack1 As Short Implements IItemDetailsView.Pack1
            Get
                Return 1
            End Get
            Set(value As Short)
                _pack1 = value
            End Set
        End Property

        Private _pack2 As Short
        Public Property Pack2 As Short Implements IItemDetailsView.Pack2
            Get
                Return 1
            End Get
            Set(value As Short)
                _pack2 = value
            End Set
        End Property

        Private _pack3 As Short
        Public Property Pack3 As Short Implements IItemDetailsView.Pack3
            Get
                Return 1
            End Get
            Set(value As Short)
                _pack3 = value
            End Set
        End Property

        Private _branchID As String
        Public Property BranchID As String Implements IItemDetailsView.BranchID
            Get
                Return "01"
            End Get
            Set(value As String)
                _branchID = value
            End Set
        End Property

        Private _created_By_Branch As String
        Public Property Created_By_Branch As String Implements IItemDetailsView.Created_By_Branch
            Get
                Return "01"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Private _category As String
        Public Property Category As String Implements IItemDetailsView.Category
            Get
                Return "XX"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Public Property RegistrationNo As String Implements IItemDetailsView.RegistrationNo
            Get
                Return txtRegistrationNo.Text
            End Get
            Set
                txtRegistrationNo.Text = Value
            End Set
        End Property

        Private _saleStrip As String
        Public Property SaleStrip As String Implements IItemDetailsView.SaleStrip
            Get
                Return "N"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Private _Item_Status As String
        Public Property Item_Status As String Implements IItemDetailsView.Item_Status
            Get
                Return "S"
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Private _userID As String
        Public Property UserID As String Implements IItemDetailsView.UserId
            Get
                Return GlobalVariables.UserName
            End Get
            Set(value As String)
                _category = value
            End Set
        End Property

        Public Property UnitOfStrength As String Implements IItemDetailsView.UnitOfStrength
            Get
                Return cboUnitOfStrength.GetNullableValue(Of String)
            End Get
            Set(value As String)
                cboUnitOfStrength.SetValue(value)
            End Set
        End Property

        Public Property UnitOfVolume As String Implements IItemDetailsView.UnitOfVolume
            Get
                Return cboUnitOfVolume.GetNullableValue(Of String)
            End Get
            Set(value As String)
                cboUnitOfVolume.SetValue(value)
            End Set
        End Property

        Public Property PackageType As String Implements IItemDetailsView.PackageType
            Get
                Return cboPackageType.GetNullableValue(Of String)
            End Get
            Set(value As String)
                cboPackageType.SetValue(value)
            End Set
        End Property

        Public Property DosageForm As String Implements IItemDetailsView.DosageForm
            Get
                Return cboDosageForm.GetNullableValue(Of String)
            End Get
            Set(value As String)
                cboDosageForm.SetValue(value)
            End Set
        End Property

        Public Property RouteOfAdministration As String Implements IItemDetailsView.RouteOfAdministration
            Get
                Return cboRouteOfAdministration.GetNullableValue(Of String)
            End Get
            Set(value As String)
                cboRouteOfAdministration.SetValue(value)
            End Set
        End Property

        Public Property Volume As Double? Implements IItemDetailsView.Volume
            Get
                If txtVolume.Text Is Nothing Then
                    Return Nothing
                Else
                    Return txtVolume.Text.ToDoubleNumber(_nfi)
                End If
            End Get
            Set
                If Value Is Nothing Then
                    txtVolume.Text = ""
                Else
                    txtVolume.Text = Value
                End If
            End Set
        End Property

        Public Property StrengthValue As String Implements IItemDetailsView.StrengthValue
            Get
                Return txtStrengthValue.Text
            End Get
            Set(value As String)
                txtStrengthValue.Text = value
            End Set
        End Property

        Public Property PackageSize As Double? Implements IItemDetailsView.PackageSize
            Get
                If txtPackageSize.Text Is Nothing Then
                    Return Nothing
                Else
                    Return txtPackageSize.Text.ToDoubleNumber(_nfi)
                End If
            End Get
            Set
                If Value Is Nothing Then
                    txtPackageSize.Text = ""
                Else
                    txtPackageSize.Text = Value
                End If
            End Set
        End Property

        Public Property PrescriptionDrug As Boolean Implements IItemDetailsView.PrescriptionDrug
            Get
                Return chkPrescriptionDrug.Checked
            End Get
            Set
                chkPrescriptionDrug.Checked = Value
            End Set
        End Property

        Protected Overrides Sub CreateMainFieldsDictionary()
            MainFieldsDictionary = New Dictionary(Of String, Object) From
                {{"DosageForm", cboDosageForm},
                {"GenericName", txtGenericName},
                {"IdNo", TxtIdNo},
                {"ItemDetailsCode", TxtItemDetailsCode},
                {"ItemDetailsName", TxtItemDetailsName},
                {"PackageSize", txtPackageSize},
                {"PackageType", cboPackageType},
                {"PrescriptionDrug", chkPrescriptionDrug},
                {"RegistrationNo", txtRegistrationNo},
                {"RouteOfAdministration", cboRouteOfAdministration},
                {"StrengthValue", txtStrengthValue},
                {"UnitOfStrength", cboUnitOfStrength},
                {"UnitOfVolume", cboUnitOfVolume},
                {"Volume", txtVolume}
                }
        End Sub

        Protected Overrides Sub BeforeEdit()
            If Strings.Left(RegistrationNo,1) <> "X" Then
                cboDosageForm.DisplayOnly = True
                txtGenericName.DisplayOnly = True
                txtPackageSize.DisplayOnly = True
                cboPackageType.DisplayOnly = True
                txtRegistrationNo.DisplayOnly = True
                cboRouteOfAdministration.DisplayOnly = True
                txtStrengthValue.DisplayOnly = True
                cboUnitOfStrength.DisplayOnly = True
                cboUnitOfVolume.DisplayOnly = True
                txtVolume.DisplayOnly = True
            Else
                cboDosageForm.DisplayOnly = False
                txtGenericName.DisplayOnly = False
                txtPackageSize.DisplayOnly = False
                cboPackageType.DisplayOnly = False
                txtRegistrationNo.DisplayOnly = False
                cboRouteOfAdministration.DisplayOnly = False
                txtStrengthValue.DisplayOnly = False
                cboUnitOfStrength.DisplayOnly = False
                cboUnitOfVolume.DisplayOnly = False
                txtVolume.DisplayOnly = False
            End If
            Refresh()
        End Sub

#End Region

    End Class

End Namespace