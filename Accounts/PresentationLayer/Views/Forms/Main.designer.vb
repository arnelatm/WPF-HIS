Imports System.ComponentModel
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    Partial Public Class Main
        Inherits BFMain
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
        Me.imageListMember = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonLogin = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonLogout = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonExit = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButtonArabic = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEnglish = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonTranslate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonDebug = New System.Windows.Forms.ToolStripButton()
        Me.AccountsMenu = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItemFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLogout = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSettings = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ToolStripMenuItemRevCostCenters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemRevenueGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDistributionSchemes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemCountries = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDocuments = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPhoneTypes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemReligions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemBanks = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCategories = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemItems = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDefaultFieldValues = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSalesDepositTypes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPrinters = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSecurity = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSecurityGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSecurityObjects = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEmployee = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemEmployees = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDesignations = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTranslations = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemMessages = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCaptions = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCaptionsBatchEdit = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCreateAllMessages = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemTransactionJournalCodes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPayroll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPayElement = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemLeaves = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPayGroups = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPayCycles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPensionProviders = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPensionSchemes = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemDoctor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemSupplierVendors = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCustomerClients = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemItemCode = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCodeGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemIGroup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPharmacyItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemStockInventory = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTransactions = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPettyCash = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCashDisbursementEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAccountsPayableEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAccountsReceivableEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCashReceiptEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeReceivable = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemGeneralJournalEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSalesJournalEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAccountReconciliation = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPostPettyCashAccount = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemClosing = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemHR = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeLeaveNonHoliday = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeLeaveHoliday = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeAbsenceLate = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemHolidayEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeLeaveApproval = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeHolidayTransfer = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPayrollTransaction = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPayrollEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemRecurringPayrollEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemShiftSummaryEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripMenuItemClosePettyCashFund = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemLaboratory = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCbcResultRetrieval = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPharmacy = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemDrugSale = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemStatementOfAccountsPayable = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemStatementOfAccountsReceivable = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemStatementOfEmployeeLoans = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSummaryOfEmployeeLoans = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSummaryOfAccountsPayable = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSummaryOfAccountsReceivable = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTrialBalance = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTBMonthly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTBQuarterly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTBSemestral = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTBYearly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTBCustom = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBalanceSheet = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBSYearly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBSMonthly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBSQuarterly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBSSemestral = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemIncomeStatement = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemISYearly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemISMonthly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemISQuarterly = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemISSemiAnnually = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemISCustomRange = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAccountingtLists = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAccountActivity = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemJournalTransactionSummary = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemARAging = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAPAging = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCheckPrinting = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemVATReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPayrollReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPeriodicPayroll = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBankTransferReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemHRReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeIDPrinting = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeLeaveReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeInformation = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeMedicalReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemReceptionReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemShiftDailySummary = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAccountingReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemLaboratoryReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSalesReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPMRReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPharmacyBarcodePrinting = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemGenerateDailyDrugTransfer = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemUtilities = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemUpdateMenuSecurityObjects = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemRecreateSecurityObjectMenu = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTransactionNotesTranslator = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSimplePasswordGenerator = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTestForm = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemHelp = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemIndex = New System.Windows.Forms.ToolStripMenuItem()
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
            Me.ToolStripMenuItemDrugAcceptance = New System.Windows.Forms.ToolStripMenuItem()
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ToolStrip.SuspendLayout()
            Me.AccountsMenu.SuspendLayout()
            Me.contextMenuStripMember.SuspendLayout()
            Me.contextMenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'imageListMember
            '
            Me.imageListMember.ImageStream = CType(resources.GetObject("imageListMember.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me.imageListMember.TransparentColor = System.Drawing.Color.Transparent
            Me.imageListMember.Images.SetKeyName(0, "")
            Me.imageListMember.Images.SetKeyName(1, "")
            '
            'ToolStrip
            '
            resources.ApplyResources(Me.ToolStrip, "ToolStrip")
            Me.ToolStrip.ImageScalingSize = New System.Drawing.Size(24, 24)
            Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonLogin, Me.ToolStripButtonLogout, Me.ToolStripButtonExit, Me.toolStripSeparator1, Me.ToolStripButtonArabic, Me.ToolStripButtonEnglish, Me.ToolStripButtonTranslate, Me.ToolStripButtonDebug})
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
            'ToolStripButtonDebug
            '
            resources.ApplyResources(Me.ToolStripButtonDebug, "ToolStripButtonDebug")
            Me.ToolStripButtonDebug.Name = "ToolStripButtonDebug"
            '
            'AccountsMenu
            '
            Me.AccountsMenu.ImageScalingSize = New System.Drawing.Size(24, 24)
            Me.AccountsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemFile, Me.ToolStripMenuItemEdit, Me.ToolStripMenuItemMasters, Me.ToolStripMenuItemTransactions, Me.ToolStripMenuItemReports, Me.ToolStripMenuItemUtilities, Me.ToolStripMenuItemHelp})
            resources.ApplyResources(Me.AccountsMenu, "AccountsMenu")
            Me.AccountsMenu.Name = "AccountsMenu"
            '
            'ToolStripMenuItemFile
            '
            Me.ToolStripMenuItemFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemLogin, Me.ToolStripMenuItemLogout, Me.toolStripMenuItem1, Me.ToolStripMenuItemChangePassword, Me.ToolStripMenuItemSettings, Me.ToolStripMenuItemExit})
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
            'ToolStripMenuItemChangePassword
            '
            Me.ToolStripMenuItemChangePassword.Name = "ToolStripMenuItemChangePassword"
            resources.ApplyResources(Me.ToolStripMenuItemChangePassword, "ToolStripMenuItemChangePassword")
            '
            'ToolStripMenuItemSettings
            '
            Me.ToolStripMenuItemSettings.Name = "ToolStripMenuItemSettings"
            resources.ApplyResources(Me.ToolStripMenuItemSettings, "ToolStripMenuItemSettings")
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
            Me.ToolStripMenuItemMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemGeneral, Me.ToolStripMenuItemSecurity, Me.ToolStripMenuItemEmployee, Me.ToolStripMenuItemTranslations, Me.ToolStripMenuItemPayroll, Me.ToolStripMenuItemDoctor, Me.ToolStripMenuItemSupplierVendors, Me.ToolStripMenuItemCustomerClients, Me.ToolStripMenuItemItemCode, Me.ToolStripMenuItemCodeGroup, Me.ToolStripMenuItemIGroup})
            Me.ToolStripMenuItemMasters.Name = "ToolStripMenuItemMasters"
            resources.ApplyResources(Me.ToolStripMenuItemMasters, "ToolStripMenuItemMasters")
            '
            'ToolStripMenuItemGeneral
            '
            Me.ToolStripMenuItemGeneral.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemBranches, Me.ToolStripMenuItemChartOfAccounts, Me.ToolStripMenuItemDepartments, Me.ToolStripMenuItemRevCostCenters, Me.ToolStripMenuItemRevenueGroups, Me.ToolStripMenuItemDistributionSchemes, Me.ToolStripSeparator4, Me.ToolStripMenuItemCountries, Me.ToolStripMenuItemDocuments, Me.ToolStripMenuItemPhoneTypes, Me.ToolStripMenuItemReligions, Me.ToolStripMenuItemBanks, Me.ToolStripMenuItemCategories, Me.ToolStripMenuItemItems, Me.ToolStripMenuItemDefaultFieldValues, Me.ToolStripMenuItemSalesDepositTypes, Me.ToolStripMenuItemPrinters})
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
            'ToolStripMenuItemRevCostCenters
            '
            Me.ToolStripMenuItemRevCostCenters.Name = "ToolStripMenuItemRevCostCenters"
            resources.ApplyResources(Me.ToolStripMenuItemRevCostCenters, "ToolStripMenuItemRevCostCenters")
            '
            'ToolStripMenuItemRevenueGroups
            '
            Me.ToolStripMenuItemRevenueGroups.Name = "ToolStripMenuItemRevenueGroups"
            resources.ApplyResources(Me.ToolStripMenuItemRevenueGroups, "ToolStripMenuItemRevenueGroups")
            '
            'ToolStripMenuItemDistributionSchemes
            '
            Me.ToolStripMenuItemDistributionSchemes.Name = "ToolStripMenuItemDistributionSchemes"
            resources.ApplyResources(Me.ToolStripMenuItemDistributionSchemes, "ToolStripMenuItemDistributionSchemes")
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
            'ToolStripMenuItemDocuments
            '
            Me.ToolStripMenuItemDocuments.Name = "ToolStripMenuItemDocuments"
            resources.ApplyResources(Me.ToolStripMenuItemDocuments, "ToolStripMenuItemDocuments")
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
            'ToolStripMenuItemBanks
            '
            Me.ToolStripMenuItemBanks.Name = "ToolStripMenuItemBanks"
            resources.ApplyResources(Me.ToolStripMenuItemBanks, "ToolStripMenuItemBanks")
            '
            'ToolStripMenuItemCategories
            '
            Me.ToolStripMenuItemCategories.Name = "ToolStripMenuItemCategories"
            resources.ApplyResources(Me.ToolStripMenuItemCategories, "ToolStripMenuItemCategories")
            '
            'ToolStripMenuItemItems
            '
            Me.ToolStripMenuItemItems.Name = "ToolStripMenuItemItems"
            resources.ApplyResources(Me.ToolStripMenuItemItems, "ToolStripMenuItemItems")
            '
            'ToolStripMenuItemDefaultFieldValues
            '
            Me.ToolStripMenuItemDefaultFieldValues.Name = "ToolStripMenuItemDefaultFieldValues"
            resources.ApplyResources(Me.ToolStripMenuItemDefaultFieldValues, "ToolStripMenuItemDefaultFieldValues")
            '
            'ToolStripMenuItemSalesDepositTypes
            '
            Me.ToolStripMenuItemSalesDepositTypes.Name = "ToolStripMenuItemSalesDepositTypes"
            resources.ApplyResources(Me.ToolStripMenuItemSalesDepositTypes, "ToolStripMenuItemSalesDepositTypes")
            '
            'ToolStripMenuItemPrinters
            '
            Me.ToolStripMenuItemPrinters.Name = "ToolStripMenuItemPrinters"
            resources.ApplyResources(Me.ToolStripMenuItemPrinters, "ToolStripMenuItemPrinters")
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
            Me.ToolStripMenuItemEmployee.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEmployees, Me.ToolStripMenuItemDesignations})
            Me.ToolStripMenuItemEmployee.Name = "ToolStripMenuItemEmployee"
            resources.ApplyResources(Me.ToolStripMenuItemEmployee, "ToolStripMenuItemEmployee")
            '
            'ToolStripMenuItemEmployees
            '
            Me.ToolStripMenuItemEmployees.Name = "ToolStripMenuItemEmployees"
            resources.ApplyResources(Me.ToolStripMenuItemEmployees, "ToolStripMenuItemEmployees")
            '
            'ToolStripMenuItemDesignations
            '
            Me.ToolStripMenuItemDesignations.Name = "ToolStripMenuItemDesignations"
            resources.ApplyResources(Me.ToolStripMenuItemDesignations, "ToolStripMenuItemDesignations")
            '
            'ToolStripMenuItemTranslations
            '
            Me.ToolStripMenuItemTranslations.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemMessages, Me.ToolStripMenuItemCaptions, Me.ToolStripMenuItemCaptionsBatchEdit, Me.ToolStripMenuItemCreateAllMessages, Me.ToolStripMenuItemTransactionJournalCodes})
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
            'ToolStripMenuItemCaptionsBatchEdit
            '
            Me.ToolStripMenuItemCaptionsBatchEdit.Name = "ToolStripMenuItemCaptionsBatchEdit"
            resources.ApplyResources(Me.ToolStripMenuItemCaptionsBatchEdit, "ToolStripMenuItemCaptionsBatchEdit")
            '
            'ToolStripMenuItemCreateAllMessages
            '
            Me.ToolStripMenuItemCreateAllMessages.Name = "ToolStripMenuItemCreateAllMessages"
            resources.ApplyResources(Me.ToolStripMenuItemCreateAllMessages, "ToolStripMenuItemCreateAllMessages")
            '
            'ToolStripMenuItemTransactionJournalCodes
            '
            Me.ToolStripMenuItemTransactionJournalCodes.Name = "ToolStripMenuItemTransactionJournalCodes"
            resources.ApplyResources(Me.ToolStripMenuItemTransactionJournalCodes, "ToolStripMenuItemTransactionJournalCodes")
            '
            'ToolStripMenuItemPayroll
            '
            Me.ToolStripMenuItemPayroll.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPayElement, Me.ToolStripMenuItemLeaves, Me.ToolStripMenuItemPayGroups, Me.ToolStripMenuItemPayCycles, Me.ToolStripMenuItemPensionProviders, Me.ToolStripMenuItemPensionSchemes})
            Me.ToolStripMenuItemPayroll.Name = "ToolStripMenuItemPayroll"
            resources.ApplyResources(Me.ToolStripMenuItemPayroll, "ToolStripMenuItemPayroll")
            '
            'ToolStripMenuItemPayElement
            '
            Me.ToolStripMenuItemPayElement.Name = "ToolStripMenuItemPayElement"
            resources.ApplyResources(Me.ToolStripMenuItemPayElement, "ToolStripMenuItemPayElement")
            '
            'ToolStripMenuItemLeaves
            '
            Me.ToolStripMenuItemLeaves.Name = "ToolStripMenuItemLeaves"
            resources.ApplyResources(Me.ToolStripMenuItemLeaves, "ToolStripMenuItemLeaves")
            '
            'ToolStripMenuItemPayGroups
            '
            Me.ToolStripMenuItemPayGroups.Name = "ToolStripMenuItemPayGroups"
            resources.ApplyResources(Me.ToolStripMenuItemPayGroups, "ToolStripMenuItemPayGroups")
            '
            'ToolStripMenuItemPayCycles
            '
            Me.ToolStripMenuItemPayCycles.Name = "ToolStripMenuItemPayCycles"
            resources.ApplyResources(Me.ToolStripMenuItemPayCycles, "ToolStripMenuItemPayCycles")
            '
            'ToolStripMenuItemPensionProviders
            '
            Me.ToolStripMenuItemPensionProviders.Name = "ToolStripMenuItemPensionProviders"
            resources.ApplyResources(Me.ToolStripMenuItemPensionProviders, "ToolStripMenuItemPensionProviders")
            '
            'ToolStripMenuItemPensionSchemes
            '
            Me.ToolStripMenuItemPensionSchemes.Name = "ToolStripMenuItemPensionSchemes"
            resources.ApplyResources(Me.ToolStripMenuItemPensionSchemes, "ToolStripMenuItemPensionSchemes")
            '
            'ToolStripMenuItemDoctor
            '
            Me.ToolStripMenuItemDoctor.Name = "ToolStripMenuItemDoctor"
            resources.ApplyResources(Me.ToolStripMenuItemDoctor, "ToolStripMenuItemDoctor")
            '
            'ToolStripMenuItemSupplierVendors
            '
            Me.ToolStripMenuItemSupplierVendors.Name = "ToolStripMenuItemSupplierVendors"
            resources.ApplyResources(Me.ToolStripMenuItemSupplierVendors, "ToolStripMenuItemSupplierVendors")
            '
            'ToolStripMenuItemCustomerClients
            '
            Me.ToolStripMenuItemCustomerClients.Name = "ToolStripMenuItemCustomerClients"
            resources.ApplyResources(Me.ToolStripMenuItemCustomerClients, "ToolStripMenuItemCustomerClients")
            '
            'ToolStripMenuItemItemCode
            '
            Me.ToolStripMenuItemItemCode.Name = "ToolStripMenuItemItemCode"
            resources.ApplyResources(Me.ToolStripMenuItemItemCode, "ToolStripMenuItemItemCode")
            '
            'ToolStripMenuItemCodeGroup
            '
            Me.ToolStripMenuItemCodeGroup.Name = "ToolStripMenuItemCodeGroup"
            resources.ApplyResources(Me.ToolStripMenuItemCodeGroup, "ToolStripMenuItemCodeGroup")
            '
            'ToolStripMenuItemIGroup
            '
            Me.ToolStripMenuItemIGroup.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPharmacyItem, Me.ToolStripMenuItemStockInventory})
            Me.ToolStripMenuItemIGroup.Name = "ToolStripMenuItemIGroup"
            resources.ApplyResources(Me.ToolStripMenuItemIGroup, "ToolStripMenuItemIGroup")
            '
            'ToolStripMenuItemPharmacyItem
            '
            Me.ToolStripMenuItemPharmacyItem.Name = "ToolStripMenuItemPharmacyItem"
            resources.ApplyResources(Me.ToolStripMenuItemPharmacyItem, "ToolStripMenuItemPharmacyItem")
            '
            'ToolStripMenuItemStockInventory
            '
            Me.ToolStripMenuItemStockInventory.Name = "ToolStripMenuItemStockInventory"
            resources.ApplyResources(Me.ToolStripMenuItemStockInventory, "ToolStripMenuItemStockInventory")
            '
            'ToolStripMenuItemTransactions
            '
            Me.ToolStripMenuItemTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPettyCash, Me.ToolStripMenuItemCashDisbursementEntry, Me.ToolStripMenuItemAccountsPayableEntry, Me.ToolStripMenuItemAccountsReceivableEntry, Me.ToolStripMenuItemCashReceiptEntry, Me.ToolStripMenuItemEmployeeReceivable, Me.ToolStripMenuItemGeneralJournalEntry, Me.ToolStripMenuItemSalesJournalEntry, Me.ToolStripMenuItemAccountReconciliation, Me.ToolStripMenuItemPostPettyCashAccount, Me.ToolStripMenuItemClosing, Me.ToolStripMenuItemHR, Me.ToolStripMenuItemPayrollTransaction, Me.ToolStripMenuItemShiftSummaryEntry, Me.ToolStripSeparator2, Me.ToolStripMenuItemClosePettyCashFund, Me.ToolStripMenuItemLaboratory, Me.ToolStripMenuItemPharmacy})
            Me.ToolStripMenuItemTransactions.Name = "ToolStripMenuItemTransactions"
            resources.ApplyResources(Me.ToolStripMenuItemTransactions, "ToolStripMenuItemTransactions")
            '
            'ToolStripMenuItemPettyCash
            '
            Me.ToolStripMenuItemPettyCash.Name = "ToolStripMenuItemPettyCash"
            resources.ApplyResources(Me.ToolStripMenuItemPettyCash, "ToolStripMenuItemPettyCash")
            '
            'ToolStripMenuItemCashDisbursementEntry
            '
            Me.ToolStripMenuItemCashDisbursementEntry.Name = "ToolStripMenuItemCashDisbursementEntry"
            resources.ApplyResources(Me.ToolStripMenuItemCashDisbursementEntry, "ToolStripMenuItemCashDisbursementEntry")
            '
            'ToolStripMenuItemAccountsPayableEntry
            '
            Me.ToolStripMenuItemAccountsPayableEntry.Name = "ToolStripMenuItemAccountsPayableEntry"
            resources.ApplyResources(Me.ToolStripMenuItemAccountsPayableEntry, "ToolStripMenuItemAccountsPayableEntry")
            '
            'ToolStripMenuItemAccountsReceivableEntry
            '
            Me.ToolStripMenuItemAccountsReceivableEntry.Name = "ToolStripMenuItemAccountsReceivableEntry"
            resources.ApplyResources(Me.ToolStripMenuItemAccountsReceivableEntry, "ToolStripMenuItemAccountsReceivableEntry")
            '
            'ToolStripMenuItemCashReceiptEntry
            '
            Me.ToolStripMenuItemCashReceiptEntry.Name = "ToolStripMenuItemCashReceiptEntry"
            resources.ApplyResources(Me.ToolStripMenuItemCashReceiptEntry, "ToolStripMenuItemCashReceiptEntry")
            '
            'ToolStripMenuItemEmployeeReceivable
            '
            Me.ToolStripMenuItemEmployeeReceivable.Name = "ToolStripMenuItemEmployeeReceivable"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeReceivable, "ToolStripMenuItemEmployeeReceivable")
            '
            'ToolStripMenuItemGeneralJournalEntry
            '
            Me.ToolStripMenuItemGeneralJournalEntry.Name = "ToolStripMenuItemGeneralJournalEntry"
            resources.ApplyResources(Me.ToolStripMenuItemGeneralJournalEntry, "ToolStripMenuItemGeneralJournalEntry")
            '
            'ToolStripMenuItemSalesJournalEntry
            '
            Me.ToolStripMenuItemSalesJournalEntry.Name = "ToolStripMenuItemSalesJournalEntry"
            resources.ApplyResources(Me.ToolStripMenuItemSalesJournalEntry, "ToolStripMenuItemSalesJournalEntry")
            '
            'ToolStripMenuItemAccountReconciliation
            '
            Me.ToolStripMenuItemAccountReconciliation.Name = "ToolStripMenuItemAccountReconciliation"
            resources.ApplyResources(Me.ToolStripMenuItemAccountReconciliation, "ToolStripMenuItemAccountReconciliation")
            '
            'ToolStripMenuItemPostPettyCashAccount
            '
            Me.ToolStripMenuItemPostPettyCashAccount.Name = "ToolStripMenuItemPostPettyCashAccount"
            resources.ApplyResources(Me.ToolStripMenuItemPostPettyCashAccount, "ToolStripMenuItemPostPettyCashAccount")
            '
            'ToolStripMenuItemClosing
            '
            Me.ToolStripMenuItemClosing.Name = "ToolStripMenuItemClosing"
            resources.ApplyResources(Me.ToolStripMenuItemClosing, "ToolStripMenuItemClosing")
            '
            'ToolStripMenuItemHR
            '
            Me.ToolStripMenuItemHR.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEmployeeLeaveNonHoliday, Me.ToolStripMenuItemEmployeeLeaveHoliday, Me.ToolStripMenuItemEmployeeAbsenceLate, Me.ToolStripMenuItemHolidayEntry, Me.ToolStripMenuItemEmployeeLeaveApproval, Me.ToolStripMenuItemEmployeeHolidayTransfer})
            Me.ToolStripMenuItemHR.Name = "ToolStripMenuItemHR"
            resources.ApplyResources(Me.ToolStripMenuItemHR, "ToolStripMenuItemHR")
            '
            'ToolStripMenuItemEmployeeLeaveNonHoliday
            '
            Me.ToolStripMenuItemEmployeeLeaveNonHoliday.Name = "ToolStripMenuItemEmployeeLeaveNonHoliday"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeLeaveNonHoliday, "ToolStripMenuItemEmployeeLeaveNonHoliday")
            '
            'ToolStripMenuItemEmployeeLeaveHoliday
            '
            Me.ToolStripMenuItemEmployeeLeaveHoliday.Name = "ToolStripMenuItemEmployeeLeaveHoliday"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeLeaveHoliday, "ToolStripMenuItemEmployeeLeaveHoliday")
            '
            'ToolStripMenuItemEmployeeAbsenceLate
            '
            Me.ToolStripMenuItemEmployeeAbsenceLate.Name = "ToolStripMenuItemEmployeeAbsenceLate"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeAbsenceLate, "ToolStripMenuItemEmployeeAbsenceLate")
            '
            'ToolStripMenuItemHolidayEntry
            '
            Me.ToolStripMenuItemHolidayEntry.Name = "ToolStripMenuItemHolidayEntry"
            resources.ApplyResources(Me.ToolStripMenuItemHolidayEntry, "ToolStripMenuItemHolidayEntry")
            '
            'ToolStripMenuItemEmployeeLeaveApproval
            '
            Me.ToolStripMenuItemEmployeeLeaveApproval.Name = "ToolStripMenuItemEmployeeLeaveApproval"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeLeaveApproval, "ToolStripMenuItemEmployeeLeaveApproval")
            '
            'ToolStripMenuItemEmployeeHolidayTransfer
            '
            Me.ToolStripMenuItemEmployeeHolidayTransfer.Name = "ToolStripMenuItemEmployeeHolidayTransfer"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeHolidayTransfer, "ToolStripMenuItemEmployeeHolidayTransfer")
            '
            'ToolStripMenuItemPayrollTransaction
            '
            Me.ToolStripMenuItemPayrollTransaction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPayrollEntry, Me.ToolStripMenuItemRecurringPayrollEntry})
            Me.ToolStripMenuItemPayrollTransaction.Name = "ToolStripMenuItemPayrollTransaction"
            resources.ApplyResources(Me.ToolStripMenuItemPayrollTransaction, "ToolStripMenuItemPayrollTransaction")
            '
            'ToolStripMenuItemPayrollEntry
            '
            Me.ToolStripMenuItemPayrollEntry.Name = "ToolStripMenuItemPayrollEntry"
            resources.ApplyResources(Me.ToolStripMenuItemPayrollEntry, "ToolStripMenuItemPayrollEntry")
            '
            'ToolStripMenuItemRecurringPayrollEntry
            '
            Me.ToolStripMenuItemRecurringPayrollEntry.Name = "ToolStripMenuItemRecurringPayrollEntry"
            resources.ApplyResources(Me.ToolStripMenuItemRecurringPayrollEntry, "ToolStripMenuItemRecurringPayrollEntry")
            '
            'ToolStripMenuItemShiftSummaryEntry
            '
            Me.ToolStripMenuItemShiftSummaryEntry.Name = "ToolStripMenuItemShiftSummaryEntry"
            resources.ApplyResources(Me.ToolStripMenuItemShiftSummaryEntry, "ToolStripMenuItemShiftSummaryEntry")
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
            '
            'ToolStripMenuItemClosePettyCashFund
            '
            Me.ToolStripMenuItemClosePettyCashFund.Name = "ToolStripMenuItemClosePettyCashFund"
            resources.ApplyResources(Me.ToolStripMenuItemClosePettyCashFund, "ToolStripMenuItemClosePettyCashFund")
            '
            'ToolStripMenuItemLaboratory
            '
            Me.ToolStripMenuItemLaboratory.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCbcResultRetrieval})
            Me.ToolStripMenuItemLaboratory.Name = "ToolStripMenuItemLaboratory"
            resources.ApplyResources(Me.ToolStripMenuItemLaboratory, "ToolStripMenuItemLaboratory")
            '
            'ToolStripMenuItemCbcResultRetrieval
            '
            Me.ToolStripMenuItemCbcResultRetrieval.Name = "ToolStripMenuItemCbcResultRetrieval"
            resources.ApplyResources(Me.ToolStripMenuItemCbcResultRetrieval, "ToolStripMenuItemCbcResultRetrieval")
            '
            'ToolStripMenuItemPharmacy
            '
            Me.ToolStripMenuItemPharmacy.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemDrugSale, Me.ToolStripMenuItemDrugAcceptance})
            Me.ToolStripMenuItemPharmacy.Name = "ToolStripMenuItemPharmacy"
            resources.ApplyResources(Me.ToolStripMenuItemPharmacy, "ToolStripMenuItemPharmacy")
            '
            'ToolStripMenuItemDrugSale
            '
            Me.ToolStripMenuItemDrugSale.Name = "ToolStripMenuItemDrugSale"
            resources.ApplyResources(Me.ToolStripMenuItemDrugSale, "ToolStripMenuItemDrugSale")
            '
            'ToolStripMenuItemReports
            '
            Me.ToolStripMenuItemReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemStatementOfAccountsPayable, Me.ToolStripMenuItemStatementOfAccountsReceivable, Me.ToolStripMenuItemStatementOfEmployeeLoans, Me.ToolStripMenuItemSummaryOfEmployeeLoans, Me.ToolStripMenuItemSummaryOfAccountsPayable, Me.ToolStripMenuItemSummaryOfAccountsReceivable, Me.ToolStripMenuItemTrialBalance, Me.ToolStripMenuItemBalanceSheet, Me.ToolStripMenuItemIncomeStatement, Me.ToolStripMenuItemAccountingtLists, Me.ToolStripMenuItemARAging, Me.ToolStripMenuItemAPAging, Me.ToolStripMenuItemCheckPrinting, Me.ToolStripMenuItemVATReport, Me.ToolStripMenuItemPayrollReport, Me.ToolStripMenuItemHRReports, Me.ToolStripMenuItemReceptionReports, Me.ToolStripMenuItemAccountingReports, Me.ToolStripMenuItemLaboratoryReports, Me.ToolStripMenuItemSalesReports, Me.ToolStripMenuItemPMRReports, Me.ToolStripMenuItemPharmacyBarcodePrinting, Me.ToolStripMenuItemGenerateDailyDrugTransfer})
            Me.ToolStripMenuItemReports.Name = "ToolStripMenuItemReports"
            resources.ApplyResources(Me.ToolStripMenuItemReports, "ToolStripMenuItemReports")
            '
            'ToolStripMenuItemStatementOfAccountsPayable
            '
            Me.ToolStripMenuItemStatementOfAccountsPayable.Name = "ToolStripMenuItemStatementOfAccountsPayable"
            resources.ApplyResources(Me.ToolStripMenuItemStatementOfAccountsPayable, "ToolStripMenuItemStatementOfAccountsPayable")
            '
            'ToolStripMenuItemStatementOfAccountsReceivable
            '
            Me.ToolStripMenuItemStatementOfAccountsReceivable.Name = "ToolStripMenuItemStatementOfAccountsReceivable"
            resources.ApplyResources(Me.ToolStripMenuItemStatementOfAccountsReceivable, "ToolStripMenuItemStatementOfAccountsReceivable")
            '
            'ToolStripMenuItemStatementOfEmployeeLoans
            '
            Me.ToolStripMenuItemStatementOfEmployeeLoans.Name = "ToolStripMenuItemStatementOfEmployeeLoans"
            resources.ApplyResources(Me.ToolStripMenuItemStatementOfEmployeeLoans, "ToolStripMenuItemStatementOfEmployeeLoans")
            '
            'ToolStripMenuItemSummaryOfEmployeeLoans
            '
            Me.ToolStripMenuItemSummaryOfEmployeeLoans.Name = "ToolStripMenuItemSummaryOfEmployeeLoans"
            resources.ApplyResources(Me.ToolStripMenuItemSummaryOfEmployeeLoans, "ToolStripMenuItemSummaryOfEmployeeLoans")
            '
            'ToolStripMenuItemSummaryOfAccountsPayable
            '
            Me.ToolStripMenuItemSummaryOfAccountsPayable.Name = "ToolStripMenuItemSummaryOfAccountsPayable"
            resources.ApplyResources(Me.ToolStripMenuItemSummaryOfAccountsPayable, "ToolStripMenuItemSummaryOfAccountsPayable")
            '
            'ToolStripMenuItemSummaryOfAccountsReceivable
            '
            Me.ToolStripMenuItemSummaryOfAccountsReceivable.Name = "ToolStripMenuItemSummaryOfAccountsReceivable"
            resources.ApplyResources(Me.ToolStripMenuItemSummaryOfAccountsReceivable, "ToolStripMenuItemSummaryOfAccountsReceivable")
            '
            'ToolStripMenuItemTrialBalance
            '
            Me.ToolStripMenuItemTrialBalance.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemTBMonthly, Me.ToolStripMenuItemTBQuarterly, Me.ToolStripMenuItemTBSemestral, Me.ToolStripMenuItemTBYearly, Me.ToolStripMenuItemTBCustom})
            Me.ToolStripMenuItemTrialBalance.Name = "ToolStripMenuItemTrialBalance"
            resources.ApplyResources(Me.ToolStripMenuItemTrialBalance, "ToolStripMenuItemTrialBalance")
            '
            'ToolStripMenuItemTBMonthly
            '
            Me.ToolStripMenuItemTBMonthly.Name = "ToolStripMenuItemTBMonthly"
            resources.ApplyResources(Me.ToolStripMenuItemTBMonthly, "ToolStripMenuItemTBMonthly")
            '
            'ToolStripMenuItemTBQuarterly
            '
            Me.ToolStripMenuItemTBQuarterly.Name = "ToolStripMenuItemTBQuarterly"
            resources.ApplyResources(Me.ToolStripMenuItemTBQuarterly, "ToolStripMenuItemTBQuarterly")
            '
            'ToolStripMenuItemTBSemestral
            '
            Me.ToolStripMenuItemTBSemestral.Name = "ToolStripMenuItemTBSemestral"
            resources.ApplyResources(Me.ToolStripMenuItemTBSemestral, "ToolStripMenuItemTBSemestral")
            '
            'ToolStripMenuItemTBYearly
            '
            Me.ToolStripMenuItemTBYearly.Name = "ToolStripMenuItemTBYearly"
            resources.ApplyResources(Me.ToolStripMenuItemTBYearly, "ToolStripMenuItemTBYearly")
            '
            'ToolStripMenuItemTBCustom
            '
            Me.ToolStripMenuItemTBCustom.Name = "ToolStripMenuItemTBCustom"
            resources.ApplyResources(Me.ToolStripMenuItemTBCustom, "ToolStripMenuItemTBCustom")
            '
            'ToolStripMenuItemBalanceSheet
            '
            Me.ToolStripMenuItemBalanceSheet.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemBSYearly, Me.ToolStripMenuItemBSMonthly, Me.ToolStripMenuItemBSQuarterly, Me.ToolStripMenuItemBSSemestral})
            Me.ToolStripMenuItemBalanceSheet.Name = "ToolStripMenuItemBalanceSheet"
            resources.ApplyResources(Me.ToolStripMenuItemBalanceSheet, "ToolStripMenuItemBalanceSheet")
            '
            'ToolStripMenuItemBSYearly
            '
            Me.ToolStripMenuItemBSYearly.Name = "ToolStripMenuItemBSYearly"
            resources.ApplyResources(Me.ToolStripMenuItemBSYearly, "ToolStripMenuItemBSYearly")
            '
            'ToolStripMenuItemBSMonthly
            '
            Me.ToolStripMenuItemBSMonthly.Name = "ToolStripMenuItemBSMonthly"
            resources.ApplyResources(Me.ToolStripMenuItemBSMonthly, "ToolStripMenuItemBSMonthly")
            '
            'ToolStripMenuItemBSQuarterly
            '
            Me.ToolStripMenuItemBSQuarterly.Name = "ToolStripMenuItemBSQuarterly"
            resources.ApplyResources(Me.ToolStripMenuItemBSQuarterly, "ToolStripMenuItemBSQuarterly")
            '
            'ToolStripMenuItemBSSemestral
            '
            Me.ToolStripMenuItemBSSemestral.Name = "ToolStripMenuItemBSSemestral"
            resources.ApplyResources(Me.ToolStripMenuItemBSSemestral, "ToolStripMenuItemBSSemestral")
            '
            'ToolStripMenuItemIncomeStatement
            '
            Me.ToolStripMenuItemIncomeStatement.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemISYearly, Me.ToolStripMenuItemISMonthly, Me.ToolStripMenuItemISQuarterly, Me.ToolStripMenuItemISSemiAnnually, Me.ToolStripMenuItemISCustomRange})
            Me.ToolStripMenuItemIncomeStatement.Name = "ToolStripMenuItemIncomeStatement"
            resources.ApplyResources(Me.ToolStripMenuItemIncomeStatement, "ToolStripMenuItemIncomeStatement")
            '
            'ToolStripMenuItemISYearly
            '
            Me.ToolStripMenuItemISYearly.Name = "ToolStripMenuItemISYearly"
            resources.ApplyResources(Me.ToolStripMenuItemISYearly, "ToolStripMenuItemISYearly")
            '
            'ToolStripMenuItemISMonthly
            '
            Me.ToolStripMenuItemISMonthly.Name = "ToolStripMenuItemISMonthly"
            resources.ApplyResources(Me.ToolStripMenuItemISMonthly, "ToolStripMenuItemISMonthly")
            '
            'ToolStripMenuItemISQuarterly
            '
            Me.ToolStripMenuItemISQuarterly.Name = "ToolStripMenuItemISQuarterly"
            resources.ApplyResources(Me.ToolStripMenuItemISQuarterly, "ToolStripMenuItemISQuarterly")
            '
            'ToolStripMenuItemISSemiAnnually
            '
            Me.ToolStripMenuItemISSemiAnnually.Name = "ToolStripMenuItemISSemiAnnually"
            resources.ApplyResources(Me.ToolStripMenuItemISSemiAnnually, "ToolStripMenuItemISSemiAnnually")
            '
            'ToolStripMenuItemISCustomRange
            '
            Me.ToolStripMenuItemISCustomRange.Name = "ToolStripMenuItemISCustomRange"
            resources.ApplyResources(Me.ToolStripMenuItemISCustomRange, "ToolStripMenuItemISCustomRange")
            '
            'ToolStripMenuItemAccountingtLists
            '
            Me.ToolStripMenuItemAccountingtLists.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAccountActivity, Me.ToolStripMenuItemJournalTransactionSummary})
            Me.ToolStripMenuItemAccountingtLists.Name = "ToolStripMenuItemAccountingtLists"
            resources.ApplyResources(Me.ToolStripMenuItemAccountingtLists, "ToolStripMenuItemAccountingtLists")
            '
            'ToolStripMenuItemAccountActivity
            '
            Me.ToolStripMenuItemAccountActivity.Name = "ToolStripMenuItemAccountActivity"
            resources.ApplyResources(Me.ToolStripMenuItemAccountActivity, "ToolStripMenuItemAccountActivity")
            '
            'ToolStripMenuItemJournalTransactionSummary
            '
            Me.ToolStripMenuItemJournalTransactionSummary.Name = "ToolStripMenuItemJournalTransactionSummary"
            resources.ApplyResources(Me.ToolStripMenuItemJournalTransactionSummary, "ToolStripMenuItemJournalTransactionSummary")
            '
            'ToolStripMenuItemARAging
            '
            Me.ToolStripMenuItemARAging.Name = "ToolStripMenuItemARAging"
            resources.ApplyResources(Me.ToolStripMenuItemARAging, "ToolStripMenuItemARAging")
            '
            'ToolStripMenuItemAPAging
            '
            Me.ToolStripMenuItemAPAging.Name = "ToolStripMenuItemAPAging"
            resources.ApplyResources(Me.ToolStripMenuItemAPAging, "ToolStripMenuItemAPAging")
            '
            'ToolStripMenuItemCheckPrinting
            '
            Me.ToolStripMenuItemCheckPrinting.Name = "ToolStripMenuItemCheckPrinting"
            resources.ApplyResources(Me.ToolStripMenuItemCheckPrinting, "ToolStripMenuItemCheckPrinting")
            '
            'ToolStripMenuItemVATReport
            '
            Me.ToolStripMenuItemVATReport.Name = "ToolStripMenuItemVATReport"
            resources.ApplyResources(Me.ToolStripMenuItemVATReport, "ToolStripMenuItemVATReport")
            '
            'ToolStripMenuItemPayrollReport
            '
            Me.ToolStripMenuItemPayrollReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPeriodicPayroll, Me.ToolStripMenuItemBankTransferReport})
            Me.ToolStripMenuItemPayrollReport.Name = "ToolStripMenuItemPayrollReport"
            resources.ApplyResources(Me.ToolStripMenuItemPayrollReport, "ToolStripMenuItemPayrollReport")
            '
            'ToolStripMenuItemPeriodicPayroll
            '
            Me.ToolStripMenuItemPeriodicPayroll.Name = "ToolStripMenuItemPeriodicPayroll"
            resources.ApplyResources(Me.ToolStripMenuItemPeriodicPayroll, "ToolStripMenuItemPeriodicPayroll")
            '
            'ToolStripMenuItemBankTransferReport
            '
            Me.ToolStripMenuItemBankTransferReport.Name = "ToolStripMenuItemBankTransferReport"
            resources.ApplyResources(Me.ToolStripMenuItemBankTransferReport, "ToolStripMenuItemBankTransferReport")
            '
            'ToolStripMenuItemHRReports
            '
            Me.ToolStripMenuItemHRReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemEmployeeIDPrinting, Me.ToolStripMenuItemEmployeeLeaveReport, Me.ToolStripMenuItemEmployeeInformation, Me.ToolStripMenuItemEmployeeMedicalReport})
            Me.ToolStripMenuItemHRReports.Name = "ToolStripMenuItemHRReports"
            resources.ApplyResources(Me.ToolStripMenuItemHRReports, "ToolStripMenuItemHRReports")
            '
            'ToolStripMenuItemEmployeeIDPrinting
            '
            Me.ToolStripMenuItemEmployeeIDPrinting.Name = "ToolStripMenuItemEmployeeIDPrinting"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeIDPrinting, "ToolStripMenuItemEmployeeIDPrinting")
            '
            'ToolStripMenuItemEmployeeLeaveReport
            '
            Me.ToolStripMenuItemEmployeeLeaveReport.Name = "ToolStripMenuItemEmployeeLeaveReport"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeLeaveReport, "ToolStripMenuItemEmployeeLeaveReport")
            '
            'ToolStripMenuItemEmployeeInformation
            '
            Me.ToolStripMenuItemEmployeeInformation.Name = "ToolStripMenuItemEmployeeInformation"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeInformation, "ToolStripMenuItemEmployeeInformation")
            '
            'ToolStripMenuItemEmployeeMedicalReport
            '
            Me.ToolStripMenuItemEmployeeMedicalReport.Name = "ToolStripMenuItemEmployeeMedicalReport"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeMedicalReport, "ToolStripMenuItemEmployeeMedicalReport")
            '
            'ToolStripMenuItemReceptionReports
            '
            Me.ToolStripMenuItemReceptionReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemShiftDailySummary})
            Me.ToolStripMenuItemReceptionReports.Name = "ToolStripMenuItemReceptionReports"
            resources.ApplyResources(Me.ToolStripMenuItemReceptionReports, "ToolStripMenuItemReceptionReports")
            '
            'ToolStripMenuItemShiftDailySummary
            '
            Me.ToolStripMenuItemShiftDailySummary.Name = "ToolStripMenuItemShiftDailySummary"
            resources.ApplyResources(Me.ToolStripMenuItemShiftDailySummary, "ToolStripMenuItemShiftDailySummary")
            '
            'ToolStripMenuItemAccountingReports
            '
            Me.ToolStripMenuItemAccountingReports.Name = "ToolStripMenuItemAccountingReports"
            resources.ApplyResources(Me.ToolStripMenuItemAccountingReports, "ToolStripMenuItemAccountingReports")
            '
            'ToolStripMenuItemLaboratoryReports
            '
            Me.ToolStripMenuItemLaboratoryReports.Name = "ToolStripMenuItemLaboratoryReports"
            resources.ApplyResources(Me.ToolStripMenuItemLaboratoryReports, "ToolStripMenuItemLaboratoryReports")
            '
            'ToolStripMenuItemSalesReports
            '
            Me.ToolStripMenuItemSalesReports.Name = "ToolStripMenuItemSalesReports"
            resources.ApplyResources(Me.ToolStripMenuItemSalesReports, "ToolStripMenuItemSalesReports")
            '
            'ToolStripMenuItemPMRReports
            '
            Me.ToolStripMenuItemPMRReports.Name = "ToolStripMenuItemPMRReports"
            resources.ApplyResources(Me.ToolStripMenuItemPMRReports, "ToolStripMenuItemPMRReports")
            '
            'ToolStripMenuItemPharmacyBarcodePrinting
            '
            Me.ToolStripMenuItemPharmacyBarcodePrinting.Name = "ToolStripMenuItemPharmacyBarcodePrinting"
            resources.ApplyResources(Me.ToolStripMenuItemPharmacyBarcodePrinting, "ToolStripMenuItemPharmacyBarcodePrinting")
            '
            'ToolStripMenuItemGenerateDailyDrugTransfer
            '
            Me.ToolStripMenuItemGenerateDailyDrugTransfer.Name = "ToolStripMenuItemGenerateDailyDrugTransfer"
            resources.ApplyResources(Me.ToolStripMenuItemGenerateDailyDrugTransfer, "ToolStripMenuItemGenerateDailyDrugTransfer")
            '
            'ToolStripMenuItemUtilities
            '
            Me.ToolStripMenuItemUtilities.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemUpdateMenuSecurityObjects, Me.ToolStripMenuItemRecreateSecurityObjectMenu, Me.ToolStripMenuItemTransactionNotesTranslator, Me.ToolStripMenuItemSimplePasswordGenerator, Me.ToolStripMenuItemTestForm})
            Me.ToolStripMenuItemUtilities.Name = "ToolStripMenuItemUtilities"
            resources.ApplyResources(Me.ToolStripMenuItemUtilities, "ToolStripMenuItemUtilities")
            '
            'ToolStripMenuItemUpdateMenuSecurityObjects
            '
            Me.ToolStripMenuItemUpdateMenuSecurityObjects.Name = "ToolStripMenuItemUpdateMenuSecurityObjects"
            resources.ApplyResources(Me.ToolStripMenuItemUpdateMenuSecurityObjects, "ToolStripMenuItemUpdateMenuSecurityObjects")
            '
            'ToolStripMenuItemRecreateSecurityObjectMenu
            '
            Me.ToolStripMenuItemRecreateSecurityObjectMenu.Name = "ToolStripMenuItemRecreateSecurityObjectMenu"
            resources.ApplyResources(Me.ToolStripMenuItemRecreateSecurityObjectMenu, "ToolStripMenuItemRecreateSecurityObjectMenu")
            '
            'ToolStripMenuItemTransactionNotesTranslator
            '
            Me.ToolStripMenuItemTransactionNotesTranslator.Name = "ToolStripMenuItemTransactionNotesTranslator"
            resources.ApplyResources(Me.ToolStripMenuItemTransactionNotesTranslator, "ToolStripMenuItemTransactionNotesTranslator")
            '
            'ToolStripMenuItemSimplePasswordGenerator
            '
            Me.ToolStripMenuItemSimplePasswordGenerator.Name = "ToolStripMenuItemSimplePasswordGenerator"
            resources.ApplyResources(Me.ToolStripMenuItemSimplePasswordGenerator, "ToolStripMenuItemSimplePasswordGenerator")
            '
            'ToolStripMenuItemTestForm
            '
            Me.ToolStripMenuItemTestForm.Name = "ToolStripMenuItemTestForm"
            resources.ApplyResources(Me.ToolStripMenuItemTestForm, "ToolStripMenuItemTestForm")
            '
            'ToolStripMenuItemHelp
            '
            Me.ToolStripMenuItemHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemIndex, Me.toolStripMenuItem2, Me.ToolStripMenuItemAbout})
            Me.ToolStripMenuItemHelp.Name = "ToolStripMenuItemHelp"
            resources.ApplyResources(Me.ToolStripMenuItemHelp, "ToolStripMenuItemHelp")
            '
            'ToolStripMenuItemIndex
            '
            resources.ApplyResources(Me.ToolStripMenuItemIndex, "ToolStripMenuItemIndex")
            Me.ToolStripMenuItemIndex.Name = "ToolStripMenuItemIndex"
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
            Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
            'ToolStripMenuItemDrugAcceptance
            '
            Me.ToolStripMenuItemDrugAcceptance.Name = "ToolStripMenuItemDrugAcceptance"
            resources.ApplyResources(Me.ToolStripMenuItemDrugAcceptance, "ToolStripMenuItemDrugAcceptance")
            '
            'Main
            '
            Me.AllowDrop = True
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.ToolStrip)
            Me.Controls.Add(Me.AccountsMenu)
        Me.IsMdiContainer = true
        Me.MenuFormName = "Menu"
        Me.Name = "Main"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.MyErrorProvider,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip.ResumeLayout(false)
        Me.ToolStrip.PerformLayout
        Me.AccountsMenu.ResumeLayout(false)
        Me.AccountsMenu.PerformLayout
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
        Private AccountsMenu As MenuStrip
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
        Private WithEvents ToolStripMenuItemIndex As ToolStripMenuItem
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
        Friend WithEvents ToolStripMenuItemRevCostCenters As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemChartOfAccounts As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSupplierVendors As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCustomerClients As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemGeneralJournalEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCashDisbursementEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCashReceiptEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTrialBalance As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBalanceSheet As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemIncomeStatement As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemStatementOfAccountsPayable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemStatementOfAccountsReceivable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSummaryOfEmployeeLoans As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSummaryOfAccountsReceivable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTranslations As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemMessages As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCaptions As ToolStripMenuItem
        Private WithEvents ToolStripButtonTranslate As ToolStripButton
        Private WithEvents ToolStripButtonExit As ToolStripButton
        Friend WithEvents ToolStripMenuItemRevenueGroups As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDistributionSchemes As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDesignations As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBanks As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemAccountsPayableEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemAccountsReceivableEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemItems As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCategories As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCaptionsBatchEdit As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSalesJournalEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemAccountReconciliation As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPettyCash As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCreateAllMessages As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDefaultFieldValues As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPostPettyCashAccount As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeReceivable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemStatementOfEmployeeLoans As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSummaryOfAccountsPayable As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemClosing As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTBMonthly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTBQuarterly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTBSemestral As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTBYearly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTBCustom As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBSYearly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBSMonthly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemAccountingtLists As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemISYearly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemISMonthly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemISQuarterly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemISSemiAnnually As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemISCustomRange As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayElement As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemLeaves As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayGroups As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayCycles As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPensionProviders As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPensionSchemes As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSalesDepositTypes As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayrollTransaction As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBSQuarterly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBSSemestral As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemARAging As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemAPAging As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayrollEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCheckPrinting As ToolStripMenuItem
        Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
        Friend WithEvents ToolStripMenuItemClosePettyCashFund As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSettings As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemChangePassword As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemUtilities As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemRecreateSecurityObjectMenu As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTransactionNotesTranslator As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayrollReport As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPeriodicPayroll As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemRecurringPayrollEntry As ToolStripMenuItem
        Friend WithEvents ToolStripButtonDebug As ToolStripButton
        Friend WithEvents ToolStripMenuItemAccountActivity As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemJournalTransactionSummary As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTransactionJournalCodes As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBankTransferReport As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemShiftSummaryEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemUpdateMenuSecurityObjects As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemHRReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeIDPrinting As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemHR As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeLeaveNonHoliday As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeAbsenceLate As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemHolidayEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeLeaveApproval As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeHolidayTransfer As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeLeaveHoliday As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemReceptionReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemShiftDailySummary As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeLeaveReport As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeInformation As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSimplePasswordGenerator As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemAccountingReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemLaboratoryReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSalesReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemIGroup As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPharmacyItem As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeMedicalReport As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemLaboratory As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCbcResultRetrieval As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDocuments As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTestForm As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPMRReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemVATReport As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCodeGroup As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemItemCode As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDoctor As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPharmacyBarcodePrinting As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPrinters As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemStockInventory As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPharmacy As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDrugSale As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemGenerateDailyDrugTransfer As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDrugAcceptance As ToolStripMenuItem
    End Class
End NameSpace