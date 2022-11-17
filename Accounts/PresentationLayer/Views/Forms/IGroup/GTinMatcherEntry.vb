Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.Libraries
Imports AATM.Libraries.GlobalFuncNSub

Namespace PresentationLayer.Views.Forms

    Public Class GTinMatcherEntry
        Implements IGTinMatcherView

        Private _nfi As NumberFormatInfo
        Private _drugList As Object

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IItemDetailsView.FinderValueChanged

        'Public Event GTinMatcherValueChanged(sender As Object, gTinIdNo As Int32) Implements IGTinMatcherView.GTinMatcherValueChanged

        Public Event GetDataTable(ByRef drugListDataTable As DataTable) Implements IGTinMatcherView.GetDataTable

        Public Event DgvDoubleClick(gTinIdNo As Int32) Implements IGTinMatcherView.DgvDoubleClicked

        Public Event GTinValueChanged(sender As DataGridView, gTinValue As String) Implements IItemDetailsView.GTinValueChanged

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

        Public Property ItemDetailsByName As List(Of Lookup.LookupData)

        Private Sub InitializeDataGridView()
            ' Set up the DataGridView.
            With Me.DataGridViewDrugs
                ' Automatically generate the DataGridView columns.
                .AutoGenerateColumns = True
                Dim drugListDataTable As New DataTable
                RaiseEvent GetDataTable(drugListDataTable)
                ' Set up the data source.
                bsDrugList.DataSource = drugListDataTable
                .DataSource = bsDrugList
                ' Automatically resize the visible rows.
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
                ' Set the DataGridView control's border.
                .BorderStyle = BorderStyle.Fixed3D
                ' Put the cells in edit mode when user enters them.
                DataGridViewDrugs.ReadOnly = True
            End With

        End Sub

#Region "Field Items"

        Public Property DrugList As Object Implements IGTinMatcherView.DrugList
            Get
                Return _drugList
            End Get
            Set
                _drugList = Value
            End Set
        End Property

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
                txtPack1.Text = value
            End Set
        End Property

        Private _pack2 As Short

        Public Property Pack2 As Short Implements IItemDetailsView.Pack2
            Get
                Return txtpack2.Text
            End Get
            Set(value As Short)
                txtpack2.Text = value
            End Set
        End Property

        Private _pack3 As Short

        Public Property Pack3 As Short Implements IItemDetailsView.Pack3
            Get
                Return txtpack3.Text
            End Get
            Set(value As Short)
                txtpack3.Text = value
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

        Public Property GTin As String Implements IItemDetailsView.GTIN
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.Text = value
                RaiseEvent GTinValueChanged(DataGridViewDrugs, value)
            End Set
        End Property

        Public Property PrescriptionDrug As Boolean Implements IItemDetailsView.PrescriptionDrug

        Public Property DrugIdNo As Int32 Implements IGTinMatcherView.DrugIdNo
            Get
                If txtDrugIdNo.Text Is Nothing Then
                    Return 0
                Else
                    Return Convert.ToInt32(txtDrugIdNo.Text)
                End If
            End Get
            Set
                txtDrugIdNo.Text = Convert.ToInt32(Value)
            End Set
        End Property

        Public Property DrugTradeName As String Implements IGTinMatcherView.DrugTradeName
            Get
                Return txtDrugTradeName.Text
            End Get
            Set(value As String)
                txtDrugTradeName.Text = value
            End Set
        End Property

        Public Overloads Property DrugGenericName As String Implements IGTinMatcherView.DrugGenericName
            Get
                Return txtDrugGenericName.Text
            End Get
            Set
                txtDrugGenericName.Text = Value
            End Set
        End Property

        Public Property DrugRegistrationNo As String Implements IGTinMatcherView.DrugRegistrationNo
            Get
                Return txtDrugRegistrationNo.Text
            End Get
            Set
                txtDrugRegistrationNo.Text = Value
            End Set
        End Property

        Public Property DrugUnitOfStrength As String Implements IGTinMatcherView.DrugUnitOfStrength
            Get
                Return txtDrugUnitOfStrength.Text
            End Get
            Set(value As String)
                txtDrugUnitOfStrength.Text = value
            End Set
        End Property

        Public Property DrugUnitOfVolume As String Implements IGTinMatcherView.DrugUnitOfVolume
            Get
                Return txtDrugUnitOfVolume.Text
            End Get
            Set(value As String)
                txtDrugUnitOfVolume.Text = value
            End Set
        End Property

        Public Property DrugPackageType As String Implements IGTinMatcherView.DrugPackageType
            Get
                Return txtDrugPackageType.Text
            End Get
            Set(value As String)
                txtDrugPackageType.Text = value
            End Set
        End Property

        Public Property DrugDosageForm As String Implements IGTinMatcherView.DrugDosageForm
            Get
                Return txtDrugDosageForm.Text
            End Get
            Set(value As String)
                txtDrugDosageForm.Text = value
            End Set
        End Property

        Public Property DrugRouteOfAdministration As String Implements IGTinMatcherView.DrugRouteOfAdministration
            Get
                Return txtDrugRouteOfAdministration.Text
            End Get
            Set(value As String)
                txtDrugRouteOfAdministration.Text = value
            End Set
        End Property

        Public Property DrugVolume As Double? Implements IGTinMatcherView.DrugVolume
            Get
                If txtDrugVolume.Text Is Nothing Then
                    Return Nothing
                Else
                    Return txtDrugVolume.Text.ToDoubleNumber(_nfi)
                End If
            End Get
            Set
                If Value Is Nothing Then
                    txtDrugVolume.Text = ""
                Else
                    txtDrugVolume.Text = Value
                End If
            End Set
        End Property

        Public Property DrugStrengthValue As String Implements IGTinMatcherView.DrugStrengthValue
            Get
                Return txtDrugStrengthValue.Text
            End Get
            Set(value As String)
                txtDrugStrengthValue.Text = value
            End Set
        End Property

        Public Property DrugPackageSize As Double? Implements IGTinMatcherView.DrugPackageSize
            Get
                If txtDrugPackageSize.Text Is Nothing Then
                    Return Nothing
                Else
                    Return txtDrugPackageSize.Text.ToDoubleNumber(_nfi)
                End If
            End Get
            Set
                If Value Is Nothing Then
                    txtDrugPackageSize.Text = ""
                Else
                    txtDrugPackageSize.Text = Value
                End If
            End Set
        End Property

        Public Property DrugGTin As String Implements IGTinMatcherView.DrugGTin
            Get
                Return txtDrugGTin.Text
            End Get
            Set(value As String)
                txtDrugGTin.Text = value
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
                {"Pack1", txtPack1},
                {"Pack2", txtpack2},
                {"Pack3", txtpack3},
                {"PackageSize", txtPackageSize},
                {"PackageType", cboPackageType},
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

        Private Sub GTinMatcher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            cboItemFinder.DataSource = ItemDetailsByName
            cboItemFinder.EditingMode = True
            InitializeDataGridView()
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

        Private Sub DataGridView1_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDrugs.CellContentDoubleClick
            Dim dgvIdNo As Int32
            Dim curRow = DataGridViewDrugs.CurrentRow()
            dgvIdNo = curRow.Cells("IdNo").Value
            RaiseEvent DgvDoubleClick(dgvIdNo)
        End Sub

        Private Sub DataGridViewDrugs_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDrugs.CellEnter
            Dim dgvIdNo As Int32
            Dim curRow = DataGridViewDrugs.CurrentRow()
            If curRow IsNot Nothing Then
                dgvIdNo = curRow.Cells("IdNo").Value
                RaiseEvent DgvDoubleClick(dgvIdNo)
            End If
        End Sub

    End Class

End Namespace