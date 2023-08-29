Imports System.Configuration
Imports System.Globalization
Imports System.Windows.Documents
Imports AATM.Accounts.PresentationLayer.Views.Interfaces
Imports AATM.DataLayer.AdoNet
Imports AATM.Libraries.CBaseControlsLibrary
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Events
Imports AATM.PresentationLayer.Views

Namespace PresentationLayer.Views.Forms

    Public Class GTinMatcherEntry
        Implements IGTinMatcherView

        Private _nfi As NumberFormatInfo
        Private _drugList As Object

        Public Event FinderValueChanged(itemIdNo As Int16) Implements IItemDetailsView.FinderValueChanged
        Public Event UpdateDrugDisplay(gTinIdNo As Int32) Implements IGTinMatcherView.UpdateDrugDisplay
        Public Event UpdateItemDisplay(gTinIdNo As Int32) Implements IGTinMatcherView.UpdateItemDisplay
        Public Event MatchGTinRequested(gTinNumber As String, itemDetailIdNo As Int32) Implements IGTinMatcherView.MatchGTinRequested
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
            HideNavigatorButtons = True
        End Sub

        Private Sub InitializeDataGridView()
            With Me.DataGridViewItems
                .Dock = DockStyle.None
                .VirtualMode = True
                .ReadOnly = True
                .AllowUserToAddRows = False
                .AllowUserToOrderColumns = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
            With Me.DataGridViewDrugs
                .Dock = DockStyle.None
                .VirtualMode = True
                .ReadOnly = True
                .AllowUserToAddRows = False
                .AllowUserToOrderColumns = False
                .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            End With
            ' Create a DataRetriever and use it to create a Cache object
            ' and to initialize the DataGridView columns and rows.

            MakeDataGridViews()
            BnItems.Refresh()
        End Sub

        Private Sub MakeDataGridViews()
            DataGridViewItems.DataFilter = DataFilter
            DataGridViewItems.MakeDataRetrieverCache("ItemDetailsQty_View", "ItemNameEnglish,Primary_Key,Item_Code,GTin,Price_Cash,Pack1,Pack2,Pack3,QtyOnHand", "IGroupClinic")
            DataGridViewDrugs.MakeDataRetrieverCache("DrugList", "[Trade Name],[Strength Value],[Unit Of Strength],[Unit Of Volume],Volume,IdNo,GTin,[Package Size],[Package Type],[Public Price],[Dosage Form],[Generic Name],[RegistrationNo],[Route Of Administration]", "IGroupClinic")
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

        Public WriteOnly Property currentIndex As Integer Implements IGTinMatcherView.CurrentIndex
Set(value As Integer)
                If not _startedByItemGrid Then
                    If DataGridViewItems.Rows.Count > value And value > 0 Then
                        DataGridViewItems.CurrentCell = DataGridViewItems(0, value)
                    End If
                End If
            End Set
        End Property

        Public Property IdNo As Int32 Implements IItemDetailsView.IdNo
            Get
                Return TxtIdNo.GetValue(Of Int32)
            End Get
            Set
                TxtIdNo.SetValue(Value)
            End Set
        End Property

        Public Property ItemDetailsCode As String Implements IItemDetailsView.ItemDetailsCode
            Get
                Return TxtItemDetailsCode.GetValue(Of String)
            End Get
            Set
                TxtItemDetailsCode.SetValue(Value)
            End Set
        End Property

        Public Overloads Property ItemDetailsName As String Implements IItemDetailsView.ItemDetailsName
            Get
                Return TxtItemDetailsName.Text
            End Get
            Set
                TxtItemDetailsName.SetValue(Value)
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
                txtGenericName.SetValue(Value)
            End Set
        End Property

        Private _pack1 As Short

        Public Property Pack1 As Short Implements IItemDetailsView.Pack1
            Get
                Return txtPack1.Text
            End Get
            Set(value As Short)
                txtPack1.SetValue(value)
            End Set
        End Property

        Private _pack2 As Short

        Public Property Pack2 As Short Implements IItemDetailsView.Pack2
            Get
                Return txtpack2.Text
            End Get
            Set(value As Short)
                txtpack2.SetValue(value)
            End Set
        End Property

        Private _pack3 As Short

        Public Property Pack3 As Short Implements IItemDetailsView.Pack3
            Get
                Return txtpack3.Text
            End Get
            Set(value As Short)
                txtpack3.SetValue(value)
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
                txtRegistrationNo.SetValue(Value)
            End Set
        End Property

        Public Property UnitOfStrength As String Implements IItemDetailsView.UnitOfStrength
            Get
                Return cboUnitOfStrength.GetValue(Of String)
            End Get
            Set(value As String)
                cboUnitOfStrength.SetValue(value)
            End Set
        End Property

        Public Property UnitOfVolume As String Implements IItemDetailsView.UnitOfVolume
            Get
                Return cboUnitOfVolume.GetValue(Of String)
            End Get
            Set(value As String)
                cboUnitOfVolume.SetValue(value)
            End Set
        End Property

        Public Property PackageType As String Implements IItemDetailsView.PackageType
            Get
                Return cboPackageType.GetValue(Of String)
            End Get
            Set(value As String)
                cboPackageType.SetValue(value)
            End Set
        End Property

        Public Property DosageForm As String Implements IItemDetailsView.DosageForm
            Get
                Return cboDosageForm.GetValue(Of String)
            End Get
            Set(value As String)
                cboDosageForm.SetValue(value)
            End Set
        End Property

        Public Property RouteOfAdministration As String Implements IItemDetailsView.RouteOfAdministration
            Get
                Return cboRouteOfAdministration.GetValue(Of String)
            End Get
            Set(value As String)
                cboRouteOfAdministration.SetValue(value)
            End Set
        End Property

        Public Property Volume As Double? Implements IItemDetailsView.Volume
            Get
                Return txtVolume.GetValue(Of Double)
            End Get
            Set
                txtVolume.SetValue(Value)
            End Set
        End Property

        Public Property StrengthValue As String Implements IItemDetailsView.StrengthValue
            Get
                Return txtStrengthValue.Text
            End Get
            Set(value As String)
                txtStrengthValue.SetValue(value)
            End Set
        End Property

        Public Property PackageSize As Double? Implements IItemDetailsView.PackageSize
            Get
                Return txtPackageSize.GetValue(Of Double)
            End Get
            Set
                txtPackageSize.SetValue(Value)
            End Set
        End Property

        Public Property GTin As String Implements IItemDetailsView.GTin
            Get
                Return txtGTIN.Text
            End Get
            Set(value As String)
                txtGTIN.SetValue(value)
            End Set
        End Property

        Private Sub SelectRecordOnDrugGrid(gTinValue As String)
            If gTinValue IsNot DBNull.Value OrElse gTinValue IsNot Nothing OrElse gTinValue = "" Then
                RaiseEvent GTinValueChanged(DataGridViewDrugs, gTinValue)
            End If
        End Sub

        Public Property PrescriptionDrug As Boolean Implements IItemDetailsView.PrescriptionDrug

        Public Property DrugIdNo As Int32 Implements IGTinMatcherView.DrugIdNo
            Get
                Return txtDrugIdNo.GetValue(Of Int32)
            End Get
            Set
                txtDrugIdNo.SetValue(Value)
            End Set
        End Property

        Public Property DrugTradeName As String Implements IGTinMatcherView.DrugTradeName
            Get
                Return txtDrugTradeName.GetValue(Of String)
            End Get
            Set(value As String)
                txtDrugTradeName.SetValue(value)
            End Set
        End Property

        Public Overloads Property DrugGenericName As String Implements IGTinMatcherView.DrugGenericName
            Get
                Return txtDrugGenericName.GetValue(Of String)
            End Get
            Set
                txtDrugGenericName.SetValue(Value)
            End Set
        End Property

        Public Property DrugRegistrationNo As String Implements IGTinMatcherView.DrugRegistrationNo
            Get
                Return txtDrugRegistrationNo.GetValue(Of String)
            End Get
            Set
                txtDrugRegistrationNo.SetValue(Value)
            End Set
        End Property

        Public Property DrugUnitOfStrength As String Implements IGTinMatcherView.DrugUnitOfStrength
            Get
                Return txtDrugUnitOfStrength.GetValue(Of String)
            End Get
            Set(value As String)
                txtDrugUnitOfStrength.SetValue(value)
            End Set
        End Property

        Public Property DrugUnitOfVolume As String Implements IGTinMatcherView.DrugUnitOfVolume
            Get
                Return txtDrugUnitOfVolume.GetValue(Of String)
            End Get
            Set(value As String)
                txtDrugUnitOfVolume.SetValue(value)
            End Set
        End Property

        Public Property DrugPackageType As String Implements IGTinMatcherView.DrugPackageType
            Get
                Return txtDrugPackageType.GetValue(Of String)
            End Get
            Set(value As String)
                txtDrugPackageType.SetValue(value)
            End Set
        End Property

        Public Property DrugDosageForm As String Implements IGTinMatcherView.DrugDosageForm
            Get
                Return txtDrugDosageForm.GetValue(Of String)
            End Get
            Set(value As String)
                txtDrugDosageForm.SetValue(value)
            End Set
        End Property

        Public Property DrugRouteOfAdministration As String Implements IGTinMatcherView.DrugRouteOfAdministration
            Get
                Return txtDrugRouteOfAdministration.GetValue(Of String)
            End Get
            Set(value As String)
                txtDrugRouteOfAdministration.SetValue(value)
            End Set
        End Property

        Public Property DrugVolume As Double? Implements IGTinMatcherView.DrugVolume
Get
                txtDrugVolume.GetValue(Of Double)()
            End Get
            Set
                txtDrugVolume.SetValue(Value)
            End Set
        End Property

        Public Property DrugStrengthValue As String Implements IGTinMatcherView.DrugStrengthValue
            Get
                Return txtDrugStrengthValue.Text
            End Get
            Set(value As String)
                txtDrugStrengthValue.SetValue(value)
            End Set
        End Property

        Public Property DrugPackageSize As Double? Implements IGTinMatcherView.DrugPackageSize
            Get
                txtDrugPackageSize.GetValue(Of Double)()
            End Get
            Set
                txtDrugPackageSize.SetValue(Value)
            End Set
        End Property

        Public Property DrugGTin As String Implements IGTinMatcherView.DrugGTin
            Get
                Return txtDrugGTin.GetValue(Of String)
            End Get
            Set(value As String)
                txtDrugGTin.SetValue(value)
            End Set
        End Property

        Public Property DrugPublicPrice As Decimal Implements IGTinMatcherView.DrugPublicPrice
            Get
                Return txtDrugPublicPrice.GetValue(Of Decimal)
            End Get
            Set
                txtDrugPublicPrice.SetValue(Value)
            End Set
        End Property

        Public Property Price_Cash As Decimal? Implements IItemDetailsView.Price_Cash
            Get
                Return txtPrice_Cash.GetValue(Of Decimal)
            End Get
            Set
                txtPrice_Cash.SetValue(Value)
            End Set
        End Property

        Private Property QtyOnHand As Decimal? Implements IItemDetailsView.QtyOnHand
            Get
                Return txtQtyOnHand.GetValue(Of Decimal)
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
                {"GTin", txtGTIN},
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
            DataGridViewDrugs.Cached = True
            DataGridViewItems.Cached = True
            InitializeDataGridView()
            btnDrugBnDeleteItem.Visible = False
            btnDrugBnAddNewItem.Visible = False
            btnItemsBnDeleteItem.Visible = False
            btnItemsBnAddNewItem.Visible = False
            BnRefresh(DataGridViewItems)
            BnRefresh(DataGridViewDrugs)
        End Sub

        Private Sub btnScanQrCode_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnScanQrCode.ClickButtonArea
            Dim gTinScanner As New GTinScanner
            gTinScanner.ShowDialog()
            txtGTIN.Text = gTinScanner.GTin
            gTinScanner.Close()
        End Sub

        Private Sub DataGridViewDrugs_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewDrugs.CellEnter
            Dim dgvIdNo As Int32
            Dim curRow = DataGridViewDrugs.CurrentRow()
            If curRow IsNot Nothing Then
                dgvIdNo = curRow.Cells("IdNo").Value
                RaiseEvent UpdateDrugDisplay(dgvIdNo)
                tsDrugsCurrentRecord.Text = curRow.Index() + 1
            End If
        End Sub

        Private _startedByItemGrid As Boolean = False

        Private Sub DataGridViewItems_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewItems.CellEnter
            Dim dgvIdNo As Int32
            Dim curRow = DataGridViewItems.CurrentRow()
            If curRow IsNot Nothing Then
                dgvIdNo = curRow.Cells("Primary_Key").Value
                _startedByItemGrid = True
                RaiseEvent UpdateItemDisplay(dgvIdNo)
                If GTin IsNot Nothing AndAlso GTin <> "" Then
                    SelectRecordOnDrugGrid(GTin)
                End If
                _startedByItemGrid = False
                tsItemsCurrentRecord.Text = curRow.Index() + 1
            End If
        End Sub

        Private Sub btnOk_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnOk.ClickButtonArea
            If DrugGTin IsNot Nothing Then
                RaiseEvent MatchGTinRequested(DrugGTin, IdNo)
                RaiseEvent UpdateItemDisplay(IdNo)
            End If
        End Sub

        Private Sub AfterSave_Handler() Handles MyBase.AfterSave
            Dim curRow = DataGridViewItems.CurrentRow()
            If curRow IsNot Nothing Then
                Dim dgvIdNo As Int32 = DataGridViewItems.CurrentRow.Cells("Primary_Key").Value
                MakeDataGridViews()
                Dim currentRow = DataGridViewItems.CurrentRow.Index()
                MoveToRow(DataGridViewItems, currentRow)
                tsItemsCount.Text = DataGridViewItems.RowCount
                tsDrugsCount.Text = DataGridViewDrugs.RowCount
            End If
        End Sub

        Private Sub MoveToRow(dataGridView As CDataGridView, rowCount As Integer)
            Dim nRow As Integer = dataGridView.CurrentRow.Index
            With dataGridView
                Dim col = .CurrentCell.ColumnIndex
                Dim row = .CurrentCell.RowIndex
                Dim nRows = .Rows.Count
                Dim nCol = .Columns.Count
                Dim nextRow = row + rowCount
                If nextRow + 1 <= .RowCount() AndAlso nextRow > 0 Then
                    .CurrentCell = dataGridView(col, nextRow)
                    BnRefresh(dataGridView)
                End If
            End With
        End Sub

        Private Sub BindingNavigatorMoveFirstItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveFirstItem.Click
            DataGridViewDrugs.CurrentCell = DataGridViewDrugs(0, 0)
            BnRefresh(DataGridViewDrugs)
        End Sub

        Private Sub BindingNavigatorMovePreviousItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMovePreviousItem.Click
            MoveToRow(DataGridViewDrugs, -1)
        End Sub

        Private Sub BindingNavigatorMoveNextItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveNextItem.Click
            MoveToRow(DataGridViewDrugs, +1)
        End Sub

        Private Sub BindingNavigatorMoveLastItem_Click(sender As Object, e As EventArgs) Handles BindingNavigatorMoveLastItem.Click
            DataGridViewDrugs.CurrentCell = DataGridViewDrugs(0, DataGridViewDrugs.RowCount() - 1)
            BnRefresh(DataGridViewDrugs)
        End Sub

        Private Sub btnFirstItem_Click(sender As Object, e As EventArgs) Handles btnFirstItem.Click
            DataGridViewItems.CurrentCell = DataGridViewItems(0, 0)
            BnRefresh(DataGridViewItems)
        End Sub

        Private Sub btnPrevItem_Click(sender As Object, e As EventArgs) Handles btnPrevItem.Click
            MoveToRow(DataGridViewItems, -1)
        End Sub

        Private Sub btnNextItem_Click(sender As Object, e As EventArgs) Handles btnNextItem.Click
            MoveToRow(DataGridViewItems, +1)
        End Sub

        Private Sub btnLastItem_Click(sender As Object, e As EventArgs) Handles btnLastItem.Click
            DataGridViewItems.CurrentCell = DataGridViewItems(0, DataGridViewItems.RowCount() - 1)
            BnRefresh(DataGridViewItems)
        End Sub

        Private Sub BnRefresh(dataGridView As CDataGridView)
            If dataGridView.CurrentRow() IsNot Nothing Then
                If dataGridView.Name = "DataGridViewItems" Then
                    tsItemsCount.Text = "of " + (dataGridView.RowCount()).ToString()
                    tsItemsCurrentRecord.Text = (dataGridView.CurrentRow.Index + 1).ToString()
                Else
                    tsDrugsCount.Text = "of " + (dataGridView.RowCount()).ToString()
                    tsDrugsCurrentRecord.Text = (dataGridView.CurrentRow.Index + 1).ToString()
                End If
            End If
        End Sub

        Protected Overrides Sub PublishClickedButton(buttonClicked As ButtonClicked)
            MyBase.PublishClickedButton(buttonClicked)
            If buttonClicked = ButtonClicked.Filter Or buttonClicked = ButtonClicked.Save Then
                MakeDataGridViews()
                tsItemsCount.Text = DataGridViewItems.RowCount
            End If
        End Sub

    End Class

End Namespace