Imports System.ComponentModel
Imports System.Windows.Forms
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Forms
    Partial Public Class Main
        Inherits BfMain
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Dim SecurityPresenter1 As AATM.PresentationLayer.Presenters.SecurityPresenter = New AATM.PresentationLayer.Presenters.SecurityPresenter()
        Me.imageListMember = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonLogin = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonLogout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonExit = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonCut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCopy = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonPaste = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDelete = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonHelp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonArabic = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEnglish = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonTranslate = New System.Windows.Forms.ToolStripButton()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItemFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCut = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPaste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMasters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemGeneral = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemBranches = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemChartOfAccounts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDepartments = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCostCenters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemProfitCenters = New System.Windows.Forms.ToolStripMenuItem()
        Me.RevenueGroupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DistributionSchemesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemCountries = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPhoneTypes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemReligions = New System.Windows.Forms.ToolStripMenuItem()
        Me.BanksToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSecurity = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSecurityGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSecurityObjects = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEmployees = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesignationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTranslations = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMessages = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCaptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.TranslationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateAllMessagesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPayroll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSuppliersVendors = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCustomersClients = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTransactions = New System.Windows.Forms.ToolStripMenuItem()
        Me.PettyCashToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCashDisbursementEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsPayableEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountsReceivableEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem8 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCashReceiptEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemGeneralJournalEntry = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesJournalEntryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountReconciliationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemReports = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSummaryOfAccountsPayable = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemStatementOfAccountsPayable = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSummaryOfAccountsReceivable = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemStatementOfAccountsReceivable = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTrialBalance = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTrialBalanceForAGivenYear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemIncomeStatementForAGivenMonth = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemIncomeStatementForAGivenYear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemBalanceSheet = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemBalanceSheetForAGivenYear = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemindex = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemAbout = New System.Windows.Forms.ToolStripMenuItem()
        Me.contextMenuStripMember = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.addNewMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.editMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.deleteMemberToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.contextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.toolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem7 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem9 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem10 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem18 = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolStripMenuItem19 = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).BeginInit
        Me.ToolStrip.SuspendLayout
        Me.MainMenu.SuspendLayout
        Me.contextMenuStripMember.SuspendLayout
        Me.contextMenuStrip1.SuspendLayout
        Me.SuspendLayout
        '
        'imageListMember
        '
        Me.imageListMember.ImageStream = CType(resources.GetObject("imageListMember.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imageListMember.TransparentColor = System.Drawing.Color.Transparent
        Me.imageListMember.Images.SetKeyName(0, "")
        Me.imageListMember.Images.SetKeyName(1, "")
        '
        'ToolStrip
        '
        resources.ApplyResources(Me.ToolStrip, "ToolStrip")
        Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonLogin, Me.ToolStripButtonLogout, Me.ToolStripButtonExit, Me.toolStripSeparator1, Me.ToolStripButtonCut, Me.ToolStripButtonCopy, Me.ToolStripButtonPaste, Me.toolStripSeparator3, Me.ToolStripButtonAdd, Me.ToolStripButtonEdit, Me.ToolStripButtonDelete, Me.toolStripSeparator2, Me.ToolStripButtonHelp, Me.ToolStripButtonArabic, Me.ToolStripButtonEnglish, Me.ToolStripButtonTranslate})
        Me.ToolStrip.Name = "ToolStrip"
        '
        'ToolStripButtonLogin
        '
        resources.ApplyResources(Me.ToolStripButtonLogin, "ToolStripButtonLogin")
        Me.ToolStripButtonLogin.Name = "ToolStripButtonLogin"
        Me.ToolStripButtonLogin.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        'ToolStripButtonLogout
        '
        resources.ApplyResources(Me.ToolStripButtonLogout, "ToolStripButtonLogout")
        Me.ToolStripButtonLogout.Name = "ToolStripButtonLogout"
        Me.ToolStripButtonLogout.Padding = New System.Windows.Forms.Padding(1, 0, 1, 0)
        '
        'ToolStripButtonExit
        '
        resources.ApplyResources(Me.ToolStripButtonExit, "ToolStripButtonExit")
        Me.ToolStripButtonExit.Name = "ToolStripButtonExit"
        Me.ToolStripButtonExit.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        resources.ApplyResources(Me.toolStripSeparator1, "toolStripSeparator1")
        '
        'ToolStripButtonCut
        '
        resources.ApplyResources(Me.ToolStripButtonCut, "ToolStripButtonCut")
        Me.ToolStripButtonCut.Name = "ToolStripButtonCut"
        Me.ToolStripButtonCut.Padding = New System.Windows.Forms.Padding(6, 0, 6, 0)
        '
        'ToolStripButtonCopy
        '
        resources.ApplyResources(Me.ToolStripButtonCopy, "ToolStripButtonCopy")
        Me.ToolStripButtonCopy.Name = "ToolStripButtonCopy"
        Me.ToolStripButtonCopy.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'ToolStripButtonPaste
        '
        resources.ApplyResources(Me.ToolStripButtonPaste, "ToolStripButtonPaste")
        Me.ToolStripButtonPaste.Name = "ToolStripButtonPaste"
        Me.ToolStripButtonPaste.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        resources.ApplyResources(Me.toolStripSeparator3, "toolStripSeparator3")
        '
        'ToolStripButtonAdd
        '
        resources.ApplyResources(Me.ToolStripButtonAdd, "ToolStripButtonAdd")
        Me.ToolStripButtonAdd.Name = "ToolStripButtonAdd"
        Me.ToolStripButtonAdd.Padding = New System.Windows.Forms.Padding(7, 0, 7, 0)
        '
        'ToolStripButtonEdit
        '
        resources.ApplyResources(Me.ToolStripButtonEdit, "ToolStripButtonEdit")
        Me.ToolStripButtonEdit.Name = "ToolStripButtonEdit"
        Me.ToolStripButtonEdit.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'ToolStripButtonDelete
        '
        resources.ApplyResources(Me.ToolStripButtonDelete, "ToolStripButtonDelete")
        Me.ToolStripButtonDelete.Name = "ToolStripButtonDelete"
        Me.ToolStripButtonDelete.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        resources.ApplyResources(Me.toolStripSeparator2, "toolStripSeparator2")
        '
        'ToolStripButtonHelp
        '
        resources.ApplyResources(Me.ToolStripButtonHelp, "ToolStripButtonHelp")
        Me.ToolStripButtonHelp.Name = "ToolStripButtonHelp"
        Me.ToolStripButtonHelp.Padding = New System.Windows.Forms.Padding(5, 0, 5, 0)
        '
        'ToolStripButtonArabic
        '
        resources.ApplyResources(Me.ToolStripButtonArabic, "ToolStripButtonArabic")
        Me.ToolStripButtonArabic.Name = "ToolStripButtonArabic"
        Me.ToolStripButtonArabic.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        'ToolStripButtonEnglish
        '
        resources.ApplyResources(Me.ToolStripButtonEnglish, "ToolStripButtonEnglish")
        Me.ToolStripButtonEnglish.Name = "ToolStripButtonEnglish"
        Me.ToolStripButtonEnglish.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        'ToolStripButtonTranslate
        '
        resources.ApplyResources(Me.ToolStripButtonTranslate, "ToolStripButtonTranslate")
        Me.ToolStripButtonTranslate.Name = "ToolStripButtonTranslate"
        Me.ToolStripButtonTranslate.Padding = New System.Windows.Forms.Padding(2, 0, 2, 0)
        '
        'MainMenu
        '
        Me.MainMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.MainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemFile, Me.ToolStripMenuItemEdit, Me.ToolStripMenuItemMasters, Me.ToolStripMenuItemTransactions, Me.ToolStripMenuItemReports, Me.ToolStripMenuItemHelp})
        resources.ApplyResources(Me.MainMenu, "MainMenu")
        Me.MainMenu.Name = "MainMenu"
        '
        'ToolStripMenuItemFile
        '
        Me.ToolStripMenuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemLogin, Me.ToolStripMenuItemLogout, Me.toolStripMenuItem1, Me.ToolStripMenuItemExit})
        Me.ToolStripMenuItemFile.Name = "ToolStripMenuItemFile"
        resources.ApplyResources(Me.ToolStripMenuItemFile, "ToolStripMenuItemFile")
        '
        'ToolStripMenuItemLogin
        '
        resources.ApplyResources(Me.ToolStripMenuItemLogin, "ToolStripMenuItemLogin")
        Me.ToolStripMenuItemLogin.Name = "ToolStripMenuItemLogin"
        '
        'ToolStripMenuItemLogout
        '
        resources.ApplyResources(Me.ToolStripMenuItemLogout, "ToolStripMenuItemLogout")
        Me.ToolStripMenuItemLogout.Name = "ToolStripMenuItemLogout"
        '
        'toolStripMenuItem1
        '
        Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
        resources.ApplyResources(Me.toolStripMenuItem1, "toolStripMenuItem1")
        '
        'ToolStripMenuItemExit
        '
        Me.ToolStripMenuItemExit.Name = "ToolStripMenuItemExit"
        resources.ApplyResources(Me.ToolStripMenuItemExit, "ToolStripMenuItemExit")
        '
        'ToolStripMenuItemEdit
        '
        Me.ToolStripMenuItemEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCut, Me.ToolStripMenuItemCopy, Me.ToolStripMenuItemPaste})
        Me.ToolStripMenuItemEdit.Name = "ToolStripMenuItemEdit"
        resources.ApplyResources(Me.ToolStripMenuItemEdit, "ToolStripMenuItemEdit")
        '
        'ToolStripMenuItemCut
        '
        resources.ApplyResources(Me.ToolStripMenuItemCut, "ToolStripMenuItemCut")
        Me.ToolStripMenuItemCut.Name = "ToolStripMenuItemCut"
        '
        'ToolStripMenuItemCopy
        '
        resources.ApplyResources(Me.ToolStripMenuItemCopy, "ToolStripMenuItemCopy")
        Me.ToolStripMenuItemCopy.Name = "ToolStripMenuItemCopy"
        '
        'ToolStripMenuItemPaste
        '
        resources.ApplyResources(Me.ToolStripMenuItemPaste, "ToolStripMenuItemPaste")
        Me.ToolStripMenuItemPaste.Name = "ToolStripMenuItemPaste"
        '
        'ToolStripMenuItemMasters
        '
        Me.ToolStripMenuItemMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemGeneral, Me.ToolStripMenuItemSecurity, Me.ToolStripMenuItemEmployee, Me.ToolStripMenuItemTranslations, Me.ToolStripMenuItemPayroll, Me.ToolStripMenuItemSuppliersVendors, Me.ToolStripMenuItemCustomersClients})
        Me.ToolStripMenuItemMasters.Name = "ToolStripMenuItemMasters"
        resources.ApplyResources(Me.ToolStripMenuItemMasters, "ToolStripMenuItemMasters")
        '
        'ToolStripMenuItemGeneral
        '
        Me.ToolStripMenuItemGeneral.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemBranches, Me.ToolStripMenuItemChartOfAccounts, Me.ToolStripMenuItemDepartments, Me.ToolStripMenuItemCostCenters, Me.ToolStripMenuItemProfitCenters, Me.RevenueGroupsToolStripMenuItem, Me.DistributionSchemesToolStripMenuItem, Me.ToolStripSeparator4, Me.ToolStripMenuItemCountries, Me.ToolStripMenuItemPhoneTypes, Me.ToolStripMenuItemReligions, Me.BanksToolStripMenuItem, Me.CategoriesToolStripMenuItem, Me.ItemsToolStripMenuItem})
        Me.ToolStripMenuItemGeneral.Name = "ToolStripMenuItemGeneral"
        resources.ApplyResources(Me.ToolStripMenuItemGeneral, "ToolStripMenuItemGeneral")
        '
        'ToolStripMenuItemBranches
        '
        Me.ToolStripMenuItemBranches.Name = "ToolStripMenuItemBranches"
        resources.ApplyResources(Me.ToolStripMenuItemBranches, "ToolStripMenuItemBranches")
        '
        'ToolStripMenuItemChartOfAccounts
        '
        Me.ToolStripMenuItemChartOfAccounts.Name = "ToolStripMenuItemChartOfAccounts"
        resources.ApplyResources(Me.ToolStripMenuItemChartOfAccounts, "ToolStripMenuItemChartOfAccounts")
        '
        'ToolStripMenuItemDepartments
        '
        Me.ToolStripMenuItemDepartments.Name = "ToolStripMenuItemDepartments"
        resources.ApplyResources(Me.ToolStripMenuItemDepartments, "ToolStripMenuItemDepartments")
        '
        'ToolStripMenuItemCostCenters
        '
        Me.ToolStripMenuItemCostCenters.Name = "ToolStripMenuItemCostCenters"
        resources.ApplyResources(Me.ToolStripMenuItemCostCenters, "ToolStripMenuItemCostCenters")
        '
        'ToolStripMenuItemProfitCenters
        '
        Me.ToolStripMenuItemProfitCenters.Name = "ToolStripMenuItemProfitCenters"
        resources.ApplyResources(Me.ToolStripMenuItemProfitCenters, "ToolStripMenuItemProfitCenters")
        '
        'RevenueGroupsToolStripMenuItem
        '
        Me.RevenueGroupsToolStripMenuItem.Name = "RevenueGroupsToolStripMenuItem"
        resources.ApplyResources(Me.RevenueGroupsToolStripMenuItem, "RevenueGroupsToolStripMenuItem")
        '
        'DistributionSchemesToolStripMenuItem
        '
        Me.DistributionSchemesToolStripMenuItem.Name = "DistributionSchemesToolStripMenuItem"
        resources.ApplyResources(Me.DistributionSchemesToolStripMenuItem, "DistributionSchemesToolStripMenuItem")
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        resources.ApplyResources(Me.ToolStripSeparator4, "ToolStripSeparator4")
        '
        'ToolStripMenuItemCountries
        '
        Me.ToolStripMenuItemCountries.Name = "ToolStripMenuItemCountries"
        resources.ApplyResources(Me.ToolStripMenuItemCountries, "ToolStripMenuItemCountries")
        '
        'ToolStripMenuItemPhoneTypes
        '
        Me.ToolStripMenuItemPhoneTypes.Name = "ToolStripMenuItemPhoneTypes"
        resources.ApplyResources(Me.ToolStripMenuItemPhoneTypes, "ToolStripMenuItemPhoneTypes")
        '
        'ToolStripMenuItemReligions
        '
        Me.ToolStripMenuItemReligions.Name = "ToolStripMenuItemReligions"
        resources.ApplyResources(Me.ToolStripMenuItemReligions, "ToolStripMenuItemReligions")
        '
        'BanksToolStripMenuItem
        '
        Me.BanksToolStripMenuItem.Name = "BanksToolStripMenuItem"
        resources.ApplyResources(Me.BanksToolStripMenuItem, "BanksToolStripMenuItem")
        '
        'CategoriesToolStripMenuItem
        '
        Me.CategoriesToolStripMenuItem.Name = "CategoriesToolStripMenuItem"
        resources.ApplyResources(Me.CategoriesToolStripMenuItem, "CategoriesToolStripMenuItem")
        '
        'ItemsToolStripMenuItem
        '
        Me.ItemsToolStripMenuItem.Name = "ItemsToolStripMenuItem"
        resources.ApplyResources(Me.ItemsToolStripMenuItem, "ItemsToolStripMenuItem")
        '
        'ToolStripMenuItemSecurity
        '
        Me.ToolStripMenuItemSecurity.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemSecurityGroups, Me.ToolStripMenuItemSecurityObjects, Me.ToolStripMenuItemUsers})
        Me.ToolStripMenuItemSecurity.Name = "ToolStripMenuItemSecurity"
        resources.ApplyResources(Me.ToolStripMenuItemSecurity, "ToolStripMenuItemSecurity")
        '
        'ToolStripMenuItemSecurityGroups
        '
        Me.ToolStripMenuItemSecurityGroups.Name = "ToolStripMenuItemSecurityGroups"
        resources.ApplyResources(Me.ToolStripMenuItemSecurityGroups, "ToolStripMenuItemSecurityGroups")
        '
        'ToolStripMenuItemSecurityObjects
        '
        Me.ToolStripMenuItemSecurityObjects.Name = "ToolStripMenuItemSecurityObjects"
        resources.ApplyResources(Me.ToolStripMenuItemSecurityObjects, "ToolStripMenuItemSecurityObjects")
        '
        'ToolStripMenuItemUsers
        '
        Me.ToolStripMenuItemUsers.Name = "ToolStripMenuItemUsers"
        resources.ApplyResources(Me.ToolStripMenuItemUsers, "ToolStripMenuItemUsers")
        '
        'ToolStripMenuItemEmployee
        '
        Me.ToolStripMenuItemEmployee.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEmployees, Me.DesignationsToolStripMenuItem})
        Me.ToolStripMenuItemEmployee.Name = "ToolStripMenuItemEmployee"
        resources.ApplyResources(Me.ToolStripMenuItemEmployee, "ToolStripMenuItemEmployee")
        '
        'ToolStripMenuItemEmployees
        '
        Me.ToolStripMenuItemEmployees.Name = "ToolStripMenuItemEmployees"
        resources.ApplyResources(Me.ToolStripMenuItemEmployees, "ToolStripMenuItemEmployees")
        '
        'DesignationsToolStripMenuItem
        '
        Me.DesignationsToolStripMenuItem.Name = "DesignationsToolStripMenuItem"
        resources.ApplyResources(Me.DesignationsToolStripMenuItem, "DesignationsToolStripMenuItem")
        '
        'ToolStripMenuItemTranslations
        '
        Me.ToolStripMenuItemTranslations.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemMessages, Me.ToolStripMenuItemCaptions, Me.TranslationsToolStripMenuItem, Me.CreateAllMessagesToolStripMenuItem})
        Me.ToolStripMenuItemTranslations.Name = "ToolStripMenuItemTranslations"
        resources.ApplyResources(Me.ToolStripMenuItemTranslations, "ToolStripMenuItemTranslations")
        '
        'ToolStripMenuItemMessages
        '
        Me.ToolStripMenuItemMessages.Name = "ToolStripMenuItemMessages"
        resources.ApplyResources(Me.ToolStripMenuItemMessages, "ToolStripMenuItemMessages")
        '
        'ToolStripMenuItemCaptions
        '
        Me.ToolStripMenuItemCaptions.Name = "ToolStripMenuItemCaptions"
        resources.ApplyResources(Me.ToolStripMenuItemCaptions, "ToolStripMenuItemCaptions")
        '
        'TranslationsToolStripMenuItem
        '
        Me.TranslationsToolStripMenuItem.Name = "TranslationsToolStripMenuItem"
        resources.ApplyResources(Me.TranslationsToolStripMenuItem, "TranslationsToolStripMenuItem")
        '
        'CreateAllMessagesToolStripMenuItem
        '
        Me.CreateAllMessagesToolStripMenuItem.Name = "CreateAllMessagesToolStripMenuItem"
        resources.ApplyResources(Me.CreateAllMessagesToolStripMenuItem, "CreateAllMessagesToolStripMenuItem")
        '
        'ToolStripMenuItemPayroll
        '
        Me.ToolStripMenuItemPayroll.Name = "ToolStripMenuItemPayroll"
        resources.ApplyResources(Me.ToolStripMenuItemPayroll, "ToolStripMenuItemPayroll")
        '
        'ToolStripMenuItemSuppliersVendors
        '
        Me.ToolStripMenuItemSuppliersVendors.Name = "ToolStripMenuItemSuppliersVendors"
        resources.ApplyResources(Me.ToolStripMenuItemSuppliersVendors, "ToolStripMenuItemSuppliersVendors")
        '
        'ToolStripMenuItemCustomersClients
        '
        Me.ToolStripMenuItemCustomersClients.Name = "ToolStripMenuItemCustomersClients"
        resources.ApplyResources(Me.ToolStripMenuItemCustomersClients, "ToolStripMenuItemCustomersClients")
        '
        'ToolStripMenuItemTransactions
        '
        Me.ToolStripMenuItemTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PettyCashToolStripMenuItem, Me.ToolStripMenuItemCashDisbursementEntry, Me.AccountsPayableEntryToolStripMenuItem, Me.AccountsReceivableEntryToolStripMenuItem, Me.ToolStripMenuItem8, Me.ToolStripMenuItemCashReceiptEntry, Me.ToolStripMenuItemGeneralJournalEntry, Me.SalesJournalEntryToolStripMenuItem, Me.AccountReconciliationToolStripMenuItem})
        Me.ToolStripMenuItemTransactions.Name = "ToolStripMenuItemTransactions"
        resources.ApplyResources(Me.ToolStripMenuItemTransactions, "ToolStripMenuItemTransactions")
        '
        'PettyCashToolStripMenuItem
        '
        Me.PettyCashToolStripMenuItem.Name = "PettyCashToolStripMenuItem"
        resources.ApplyResources(Me.PettyCashToolStripMenuItem, "PettyCashToolStripMenuItem")
        '
        'ToolStripMenuItemCashDisbursementEntry
        '
        Me.ToolStripMenuItemCashDisbursementEntry.Name = "ToolStripMenuItemCashDisbursementEntry"
        resources.ApplyResources(Me.ToolStripMenuItemCashDisbursementEntry, "ToolStripMenuItemCashDisbursementEntry")
        '
        'AccountsPayableEntryToolStripMenuItem
        '
        Me.AccountsPayableEntryToolStripMenuItem.Name = "AccountsPayableEntryToolStripMenuItem"
        resources.ApplyResources(Me.AccountsPayableEntryToolStripMenuItem, "AccountsPayableEntryToolStripMenuItem")
        '
        'AccountsReceivableEntryToolStripMenuItem
        '
        Me.AccountsReceivableEntryToolStripMenuItem.Name = "AccountsReceivableEntryToolStripMenuItem"
        resources.ApplyResources(Me.AccountsReceivableEntryToolStripMenuItem, "AccountsReceivableEntryToolStripMenuItem")
        '
        'ToolStripMenuItem8
        '
        Me.ToolStripMenuItem8.Name = "ToolStripMenuItem8"
        resources.ApplyResources(Me.ToolStripMenuItem8, "ToolStripMenuItem8")
        '
        'ToolStripMenuItemCashReceiptEntry
        '
        Me.ToolStripMenuItemCashReceiptEntry.Name = "ToolStripMenuItemCashReceiptEntry"
        resources.ApplyResources(Me.ToolStripMenuItemCashReceiptEntry, "ToolStripMenuItemCashReceiptEntry")
        '
        'ToolStripMenuItemGeneralJournalEntry
        '
        Me.ToolStripMenuItemGeneralJournalEntry.Name = "ToolStripMenuItemGeneralJournalEntry"
        resources.ApplyResources(Me.ToolStripMenuItemGeneralJournalEntry, "ToolStripMenuItemGeneralJournalEntry")
        '
        'SalesJournalEntryToolStripMenuItem
        '
        Me.SalesJournalEntryToolStripMenuItem.Name = "SalesJournalEntryToolStripMenuItem"
        resources.ApplyResources(Me.SalesJournalEntryToolStripMenuItem, "SalesJournalEntryToolStripMenuItem")
        '
        'AccountReconciliationToolStripMenuItem
        '
        Me.AccountReconciliationToolStripMenuItem.Name = "AccountReconciliationToolStripMenuItem"
        resources.ApplyResources(Me.AccountReconciliationToolStripMenuItem, "AccountReconciliationToolStripMenuItem")
        '
        'ToolStripMenuItemReports
        '
        Me.ToolStripMenuItemReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemSummaryOfAccountsPayable, Me.ToolStripMenuItemStatementOfAccountsPayable, Me.ToolStripMenuItemSummaryOfAccountsReceivable, Me.ToolStripMenuItemStatementOfAccountsReceivable, Me.ToolStripMenuItemTrialBalance, Me.ToolStripMenuItemTrialBalanceForAGivenYear, Me.ToolStripMenuItemIncomeStatementForAGivenMonth, Me.ToolStripMenuItemIncomeStatementForAGivenYear, Me.ToolStripMenuItemBalanceSheet, Me.ToolStripMenuItemBalanceSheetForAGivenYear})
        Me.ToolStripMenuItemReports.Name = "ToolStripMenuItemReports"
        resources.ApplyResources(Me.ToolStripMenuItemReports, "ToolStripMenuItemReports")
        '
        'ToolStripMenuItemSummaryOfAccountsPayable
        '
        Me.ToolStripMenuItemSummaryOfAccountsPayable.Name = "ToolStripMenuItemSummaryOfAccountsPayable"
        resources.ApplyResources(Me.ToolStripMenuItemSummaryOfAccountsPayable, "ToolStripMenuItemSummaryOfAccountsPayable")
        '
        'ToolStripMenuItemStatementOfAccountsPayable
        '
        Me.ToolStripMenuItemStatementOfAccountsPayable.Name = "ToolStripMenuItemStatementOfAccountsPayable"
        resources.ApplyResources(Me.ToolStripMenuItemStatementOfAccountsPayable, "ToolStripMenuItemStatementOfAccountsPayable")
        '
        'ToolStripMenuItemSummaryOfAccountsReceivable
        '
        Me.ToolStripMenuItemSummaryOfAccountsReceivable.Name = "ToolStripMenuItemSummaryOfAccountsReceivable"
        resources.ApplyResources(Me.ToolStripMenuItemSummaryOfAccountsReceivable, "ToolStripMenuItemSummaryOfAccountsReceivable")
        '
        'ToolStripMenuItemStatementOfAccountsReceivable
        '
        Me.ToolStripMenuItemStatementOfAccountsReceivable.Name = "ToolStripMenuItemStatementOfAccountsReceivable"
        resources.ApplyResources(Me.ToolStripMenuItemStatementOfAccountsReceivable, "ToolStripMenuItemStatementOfAccountsReceivable")
        '
        'ToolStripMenuItemTrialBalance
        '
        Me.ToolStripMenuItemTrialBalance.Name = "ToolStripMenuItemTrialBalance"
        resources.ApplyResources(Me.ToolStripMenuItemTrialBalance, "ToolStripMenuItemTrialBalance")
        '
        'ToolStripMenuItemTrialBalanceForAGivenYear
        '
        Me.ToolStripMenuItemTrialBalanceForAGivenYear.Name = "ToolStripMenuItemTrialBalanceForAGivenYear"
        resources.ApplyResources(Me.ToolStripMenuItemTrialBalanceForAGivenYear, "ToolStripMenuItemTrialBalanceForAGivenYear")
        '
        'ToolStripMenuItemIncomeStatementForAGivenMonth
        '
        Me.ToolStripMenuItemIncomeStatementForAGivenMonth.Name = "ToolStripMenuItemIncomeStatementForAGivenMonth"
        resources.ApplyResources(Me.ToolStripMenuItemIncomeStatementForAGivenMonth, "ToolStripMenuItemIncomeStatementForAGivenMonth")
        '
        'ToolStripMenuItemIncomeStatementForAGivenYear
        '
        Me.ToolStripMenuItemIncomeStatementForAGivenYear.Name = "ToolStripMenuItemIncomeStatementForAGivenYear"
        resources.ApplyResources(Me.ToolStripMenuItemIncomeStatementForAGivenYear, "ToolStripMenuItemIncomeStatementForAGivenYear")
        '
        'ToolStripMenuItemBalanceSheet
        '
        Me.ToolStripMenuItemBalanceSheet.Name = "ToolStripMenuItemBalanceSheet"
        resources.ApplyResources(Me.ToolStripMenuItemBalanceSheet, "ToolStripMenuItemBalanceSheet")
        '
        'ToolStripMenuItemBalanceSheetForAGivenYear
        '
        Me.ToolStripMenuItemBalanceSheetForAGivenYear.Name = "ToolStripMenuItemBalanceSheetForAGivenYear"
        resources.ApplyResources(Me.ToolStripMenuItemBalanceSheetForAGivenYear, "ToolStripMenuItemBalanceSheetForAGivenYear")
        '
        'ToolStripMenuItemHelp
        '
        Me.ToolStripMenuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemindex, Me.toolStripMenuItem2, Me.ToolStripMenuItemAbout})
        Me.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp"
        resources.ApplyResources(Me.ToolStripMenuItemHelp, "ToolStripMenuItemHelp")
        '
        'ToolStripMenuItemindex
        '
        resources.ApplyResources(Me.ToolStripMenuItemindex, "ToolStripMenuItemindex")
        Me.ToolStripMenuItemindex.Name = "ToolStripMenuItemindex"
        '
        'toolStripMenuItem2
        '
        Me.toolStripMenuItem2.Name = "toolStripMenuItem2"
        resources.ApplyResources(Me.toolStripMenuItem2, "toolStripMenuItem2")
        '
        'ToolStripMenuItemAbout
        '
        Me.ToolStripMenuItemAbout.Name = "ToolStripMenuItemAbout"
        resources.ApplyResources(Me.ToolStripMenuItemAbout, "ToolStripMenuItemAbout")
        '
        'contextMenuStripMember
        '
        Me.contextMenuStripMember.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.contextMenuStripMember.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.addNewMemberToolStripMenuItem, Me.editMemberToolStripMenuItem, Me.deleteMemberToolStripMenuItem})
        Me.contextMenuStripMember.Name = "contextMenuStripMember"
        resources.ApplyResources(Me.contextMenuStripMember, "contextMenuStripMember")
        '
        'addNewMemberToolStripMenuItem
        '
        resources.ApplyResources(Me.addNewMemberToolStripMenuItem, "addNewMemberToolStripMenuItem")
        Me.addNewMemberToolStripMenuItem.Name = "addNewMemberToolStripMenuItem"
        '
        'editMemberToolStripMenuItem
        '
        resources.ApplyResources(Me.editMemberToolStripMenuItem, "editMemberToolStripMenuItem")
        Me.editMemberToolStripMenuItem.Name = "editMemberToolStripMenuItem"
        '
        'deleteMemberToolStripMenuItem
        '
        resources.ApplyResources(Me.deleteMemberToolStripMenuItem, "deleteMemberToolStripMenuItem")
        Me.deleteMemberToolStripMenuItem.Name = "deleteMemberToolStripMenuItem"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "")
        Me.imageList1.Images.SetKeyName(1, "")
        '
        'contextMenuStrip1
        '
        Me.contextMenuStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.contextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolStripMenuItem3, Me.toolStripMenuItem4, Me.toolStripMenuItem5})
        Me.contextMenuStrip1.Name = "contextMenuStripMember"
        resources.ApplyResources(Me.contextMenuStrip1, "contextMenuStrip1")
        '
        'toolStripMenuItem3
        '
        resources.ApplyResources(Me.toolStripMenuItem3, "toolStripMenuItem3")
        Me.toolStripMenuItem3.Name = "toolStripMenuItem3"
        '
        'toolStripMenuItem4
        '
        resources.ApplyResources(Me.toolStripMenuItem4, "toolStripMenuItem4")
        Me.toolStripMenuItem4.Name = "toolStripMenuItem4"
        '
        'toolStripMenuItem5
        '
        resources.ApplyResources(Me.toolStripMenuItem5, "toolStripMenuItem5")
        Me.toolStripMenuItem5.Name = "toolStripMenuItem5"
        '
        'toolStripMenuItem6
        '
        resources.ApplyResources(Me.toolStripMenuItem6, "toolStripMenuItem6")
        Me.toolStripMenuItem6.Name = "toolStripMenuItem6"
        '
        'toolStripMenuItem7
        '
        resources.ApplyResources(Me.toolStripMenuItem7, "toolStripMenuItem7")
        Me.toolStripMenuItem7.Name = "toolStripMenuItem7"
        '
        'toolStripMenuItem9
        '
        resources.ApplyResources(Me.toolStripMenuItem9, "toolStripMenuItem9")
        Me.toolStripMenuItem9.Name = "toolStripMenuItem9"
        '
        'toolStripMenuItem10
        '
        Me.toolStripMenuItem10.Name = "toolStripMenuItem10"
        resources.ApplyResources(Me.toolStripMenuItem10, "toolStripMenuItem10")
        '
        'toolStripMenuItem12
        '
        resources.ApplyResources(Me.toolStripMenuItem12, "toolStripMenuItem12")
        Me.toolStripMenuItem12.Name = "toolStripMenuItem12"
        '
        'toolStripMenuItem13
        '
        resources.ApplyResources(Me.toolStripMenuItem13, "toolStripMenuItem13")
        Me.toolStripMenuItem13.Name = "toolStripMenuItem13"
        '
        'toolStripSeparator6
        '
        Me.toolStripSeparator6.Name = "toolStripSeparator6"
        resources.ApplyResources(Me.toolStripSeparator6, "toolStripSeparator6")
        '
        'toolStripMenuItem15
        '
        resources.ApplyResources(Me.toolStripMenuItem15, "toolStripMenuItem15")
        Me.toolStripMenuItem15.Name = "toolStripMenuItem15"
        '
        'toolStripMenuItem16
        '
        resources.ApplyResources(Me.toolStripMenuItem16, "toolStripMenuItem16")
        Me.toolStripMenuItem16.Name = "toolStripMenuItem16"
        '
        'toolStripMenuItem17
        '
        resources.ApplyResources(Me.toolStripMenuItem17, "toolStripMenuItem17")
        Me.toolStripMenuItem17.Name = "toolStripMenuItem17"
        '
        'toolStripMenuItem18
        '
        Me.toolStripMenuItem18.Name = "toolStripMenuItem18"
        resources.ApplyResources(Me.toolStripMenuItem18, "toolStripMenuItem18")
        '
        'toolStripSeparator8
        '
        Me.toolStripSeparator8.Name = "toolStripSeparator8"
        resources.ApplyResources(Me.toolStripSeparator8, "toolStripSeparator8")
        '
        'toolStripMenuItem19
        '
        resources.ApplyResources(Me.toolStripMenuItem19, "toolStripMenuItem19")
        Me.toolStripMenuItem19.Name = "toolStripMenuItem19"
        '
        'Main
        '
        Me.AllowDrop = true
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.MainMenu)
        Me.IsMdiContainer = true
        Me.Name = "Main"
        Me.SecurityPresenterObj = SecurityPresenter1
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip.ResumeLayout(false)
        Me.ToolStrip.PerformLayout
        Me.MainMenu.ResumeLayout(false)
        Me.MainMenu.PerformLayout
        Me.contextMenuStripMember.ResumeLayout(false)
        Me.contextMenuStrip1.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

#End Region

        Private imageListMember As ImageList
        Private ToolStrip As ToolStrip
        Private WithEvents ToolStripButtonLogin As ToolStripButton
        Private WithEvents ToolStripButtonLogout As ToolStripButton
        Private toolStripSeparator1 As ToolStripSeparator
        Private ToolStripButtonCut As ToolStripButton
        Private ToolStripButtonCopy As ToolStripButton
        Private ToolStripButtonPaste As ToolStripButton
        Private toolStripSeparator3 As ToolStripSeparator
        Private WithEvents ToolStripButtonAdd As ToolStripButton
        Private WithEvents ToolStripButtonEdit As ToolStripButton
        Private WithEvents ToolStripButtonDelete As ToolStripButton
        Private toolStripSeparator2 As ToolStripSeparator
        Private WithEvents ToolStripButtonHelp As ToolStripButton
        Private MainMenu As MenuStrip
        Private ToolStripMenuItemFile As ToolStripMenuItem
        Private WithEvents ToolStripMenuItemLogin As ToolStripMenuItem
        Private WithEvents ToolStripMenuItemLogout As ToolStripMenuItem
        Private toolStripMenuItem1 As ToolStripSeparator
        Private WithEvents ToolStripMenuItemExit As ToolStripMenuItem
        Private ToolStripMenuItemEdit As ToolStripMenuItem
        Private ToolStripMenuItemCut As ToolStripMenuItem
        Private ToolStripMenuItemCopy As ToolStripMenuItem
        Private ToolStripMenuItemPaste As ToolStripMenuItem
        Private ToolStripMenuItemMasters As ToolStripMenuItem
        Private ToolStripMenuItemHelp As ToolStripMenuItem
        Private WithEvents ToolStripMenuItemindex As ToolStripMenuItem
        Private toolStripMenuItem2 As ToolStripSeparator
        Private WithEvents ToolStripMenuItemAbout As ToolStripMenuItem
        Private contextMenuStripMember As ContextMenuStrip
        Private WithEvents addNewMemberToolStripMenuItem As ToolStripMenuItem
        Private WithEvents editMemberToolStripMenuItem As ToolStripMenuItem
        Private WithEvents deleteMemberToolStripMenuItem As ToolStripMenuItem
        Private imageList1 As ImageList
        Private contextMenuStrip1 As ContextMenuStrip
        Private toolStripMenuItem3 As ToolStripMenuItem
        Private toolStripMenuItem4 As ToolStripMenuItem
        Private toolStripMenuItem5 As ToolStripMenuItem
        Private toolStripMenuItem6 As ToolStripMenuItem
        Private toolStripMenuItem7 As ToolStripMenuItem
        Private toolStripMenuItem9 As ToolStripMenuItem
        Private toolStripMenuItem10 As ToolStripMenuItem
        Private toolStripMenuItem12 As ToolStripMenuItem
        Private toolStripMenuItem13 As ToolStripMenuItem
        Private toolStripSeparator6 As ToolStripSeparator
        Private toolStripMenuItem15 As ToolStripMenuItem
        Private toolStripMenuItem16 As ToolStripMenuItem
        Private toolStripMenuItem17 As ToolStripMenuItem
        Private toolStripMenuItem18 As ToolStripMenuItem
        Private toolStripSeparator8 As ToolStripSeparator
        Private toolStripMenuItem19 As ToolStripMenuItem
        Private WithEvents ToolStripButtonArabic As ToolStripButton
        Private WithEvents ToolStripButtonEnglish As ToolStripButton
        Friend WithEvents ToolStripMenuItemSecurity As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemGeneral As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPhoneTypes As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemUsers As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSecurityGroups As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSecurityObjects As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCountries As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemReligions As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployee As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayroll As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTransactions As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployees As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBranches As ToolStripMenuItem
        Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
        Friend WithEvents ToolStripMenuItemDepartments As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCostCenters As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemProfitCenters As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemChartOfAccounts As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSuppliersVendors As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCustomersClients As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemGeneralJournalEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCashDisbursementEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCashReceiptEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTrialBalance As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBalanceSheet As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemIncomeStatementForAGivenMonth As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemIncomeStatementForAGivenYear As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemStatementOfAccountsPayable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemStatementOfAccountsReceivable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBalanceSheetForAGivenYear As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTrialBalanceForAGivenYear As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSummaryOfAccountsPayable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSummaryOfAccountsReceivable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTranslations As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemMessages As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCaptions As ToolStripMenuItem
        Private WithEvents ToolStripButtonTranslate As ToolStripButton
        Private WithEvents ToolStripButtonExit As ToolStripButton
        Friend WithEvents RevenueGroupsToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents DistributionSchemesToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents DesignationsToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents BanksToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents AccountsPayableEntryToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents AccountsReceivableEntryToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItem8 As ToolStripMenuItem
        Friend WithEvents ItemsToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents CategoriesToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents TranslationsToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents SalesJournalEntryToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents AccountReconciliationToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents PettyCashToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents CreateAllMessagesToolStripMenuItem As ToolStripMenuItem
    End Class
End NameSpace