Imports System.Configuration
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
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

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IItemDetailsView.FinderValueChanged

        Public Event GTinValueChanged(sender As DataGridView, gTinValue As String) Implements IItemDetailsView.GTinValueChanged

        Public Property ItemDetailsByName As List(Of Lookup.LookupData)

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
                Return txtPack1.Text
            End Get
            Set(value As Short)
                txtPack1.Text = value.ToString()
            End Set
        End Property

        Public Property Pack2 As Short Implements IItemDetailsView.Pack2
            Get
                Return txtpack2.Text
            End Get
            Set(value As Short)
                txtpack2.Text = value.ToString()
            End Set
        End Property

        Private _pack3 As Short

        Public Property Pack3 As Short Implements IItemDetailsView.Pack3
            Get
                Return txtpack3.Text
            End Get
            Set(value As Short)
                txtpack3.Text = value.ToString()
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

        Private _category As String

        Public Property RegistrationNo As String Implements IItemDetailsView.RegistrationNo
            Get
                Return txtRegistrationNo.Text
            End Get
            Set
                txtRegistrationNo.Text = Value
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

        Public Property GTIN As String Implements IItemDetailsView.GTIN
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.Text = value
                RaiseEvent GTinValueChanged(Nothing, value)
            End Set
        End Property
        Public Property Price_Cash As Decimal? Implements IItemDetailsView.Price_Cash
            Get
                Return txtPrice_Cash.GetValue(Of Decimal?)
            End Get
            Set
                txtPrice_Cash.SetValue(Value)
            End Set
        End Property

        Private Property QtyOnHand As Decimal? Implements IItemDetailsView.QtyOnHand
            Get
                Return txtQtyOnHand.GetValue(Of Decimal?)
            End Get
            Set
                txtQtyOnHand.SetValue(Value)
            End Set
        End Property

        Private _created_By_Branch As String

        Public Property Created_By_Branch As String Implements IItemDetailsView.Created_By_Branch
            Get
                Return "01"
            End Get
            Set(value As String)
                _created_By_Branch = value
            End Set
        End Property

#End Region

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
            If Strings.Left(RegistrationNo, 1) <> "X" Then
                SetDisplayOnly(True)
            Else
                SetDisplayOnly(False)
            End If
            Refresh()
        End Sub

        Private Sub SetDisplayOnly(value As Boolean)
            cboDosageForm.DisplayOnly = value
            txtGenericName.DisplayOnly = value
            txtPackageSize.DisplayOnly = value
            cboPackageType.DisplayOnly = value
            txtRegistrationNo.DisplayOnly = value
            cboRouteOfAdministration.DisplayOnly = value
            txtStrengthValue.DisplayOnly = value
            cboUnitOfStrength.DisplayOnly = value
            cboUnitOfVolume.DisplayOnly = value
            txtVolume.DisplayOnly = value
        End Sub

        Private Sub chkPrescriptionDrug_CheckedChanged(sender As Object, e As EventArgs) Handles chkPrescriptionDrug.CheckedChanged
            If Not btnEdit.Enabled Then
                If chkPrescriptionDrug.Checked Then
                    SetDisplayOnly(False)
                Else
                    SetDisplayOnly(True)
                End If
            End If
        End Sub

        Private Sub ItemDetailsEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboItemFinder.DataSource = ItemDetailsByName
            cboItemFinder.EditingMode = True
        End Sub

        Private Sub cboItemFinder_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemFinder.SelectedIndexChanged
            RaiseEvent FinderValueChanged(cboItemFinder.SelectedItem.IdNo)
        End Sub

        Private Sub CButton1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnScanQrCode.ClickButtonArea
            Dim gTinScanner As New GTinScanner
            gTinScanner.ShowDialog()
            txtGTIN.Text = gTinScanner.GTin
            gTinScanner.Close()
        End Sub

    End Class

End Namespace