Imports System.ComponentModel
Imports AATM.PresentationLayer.Forms

Namespace PresentationLayer.Views.Forms
    Partial Public Class Payroll
        Inherits BfMainNew
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
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payroll))
            Me.imageListMember = New System.Windows.Forms.ImageList(Me.components)
            Me.ToolStrip = New System.Windows.Forms.ToolStrip()
            Me.ToolStripButtonLogin = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButtonLogout = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButtonExit = New System.Windows.Forms.ToolStripButton()
            Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
            Me.ToolStripButtonArabic = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButtonEnglish = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButtonTranslate = New System.Windows.Forms.ToolStripButton()
            Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
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
            Me.ToolStripMenuItemPhoneTypes = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemReligions = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBanks = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCategories = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemItems = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemDefaultFieldValues = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSalesDepositTypes = New System.Windows.Forms.ToolStripMenuItem()
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
            Me.ToolStripMenuItemPayrolls = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPensionProviders = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPensionSchemes = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemSupplierVendors = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCustomerClients = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTransactions = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPayrollMenu = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPayrollAttendance = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemGeneratePayroll = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPayrollEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemRecurringPayrollEntry = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeLeave = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemEmployeeAbsencesLate = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
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
            Me.ToolStripMenuItemIGroupReports = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCashIncomePerDoctorService = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemNumberOfCashPatientsPerDoctor = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemBlankReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemARAging = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemAPAging = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemCheckPrinting = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPayrollReport = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemPeriodicPayroll = New System.Windows.Forms.ToolStripMenuItem()
            Me.GenerateCSVFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemUtilities = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemRecreateSecurityObjectMenu = New System.Windows.Forms.ToolStripMenuItem()
            Me.ToolStripMenuItemTransactionNotesTranslator = New System.Windows.Forms.ToolStripMenuItem()
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
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ToolStrip.SuspendLayout()
            Me.AccountsMenu.SuspendLayout()
            Me.contextMenuStripMember.SuspendLayout()
            Me.contextMenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'TranslatorDAC
            '
            Me.TranslatorDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
            '
            'AppDataDAC
            '
            Me.AppDataDAC.Cs = "Data Source=;Initial Catalog=;Integrated Security=True;Connection Timeout=5"
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
            Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonLogin, Me.ToolStripButtonLogout, Me.ToolStripButtonExit, Me.toolStripSeparator1, Me.ToolStripButtonArabic, Me.ToolStripButtonEnglish, Me.ToolStripButtonTranslate, Me.ToolStripButton1})
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
            'ToolStripButton1
            '
            resources.ApplyResources(Me.ToolStripButton1, "ToolStripButton1")
            Me.ToolStripButton1.Name = "ToolStripButton1"
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
            Me.ToolStripMenuItemMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemGeneral, Me.ToolStripMenuItemSecurity, Me.ToolStripMenuItemEmployee, Me.ToolStripMenuItemTranslations, Me.ToolStripMenuItemPayroll, Me.ToolStripMenuItemSupplierVendors, Me.ToolStripMenuItemCustomerClients})
            Me.ToolStripMenuItemMasters.Name = "ToolStripMenuItemMasters"
            resources.ApplyResources(Me.ToolStripMenuItemMasters, "ToolStripMenuItemMasters")
            '
            'ToolStripMenuItemGeneral
            '
            Me.ToolStripMenuItemGeneral.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemBranches, Me.ToolStripMenuItemChartOfAccounts, Me.ToolStripMenuItemDepartments, Me.ToolStripMenuItemRevCostCenters, Me.ToolStripMenuItemRevenueGroups, Me.ToolStripMenuItemDistributionSchemes, Me.ToolStripSeparator4, Me.ToolStripMenuItemCountries, Me.ToolStripMenuItemPhoneTypes, Me.ToolStripMenuItemReligions, Me.ToolStripMenuItemBanks, Me.ToolStripMenuItemCategories, Me.ToolStripMenuItemItems, Me.ToolStripMenuItemDefaultFieldValues, Me.ToolStripMenuItemSalesDepositTypes})
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
            Me.ToolStripMenuItemPayroll.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPayElement, Me.ToolStripMenuItemLeaves, Me.ToolStripMenuItemPayGroups, Me.ToolStripMenuItemPayCycles, Me.ToolStripMenuItemPayrolls, Me.ToolStripMenuItemPensionProviders, Me.ToolStripMenuItemPensionSchemes})
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
            'ToolStripMenuItemPayrolls
            '
            Me.ToolStripMenuItemPayrolls.Name = "ToolStripMenuItemPayrolls"
            resources.ApplyResources(Me.ToolStripMenuItemPayrolls, "ToolStripMenuItemPayrolls")
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
            'ToolStripMenuItemTransactions
            '
            Me.ToolStripMenuItemTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPayrollMenu, Me.ToolStripSeparator2})
            Me.ToolStripMenuItemTransactions.Name = "ToolStripMenuItemTransactions"
            resources.ApplyResources(Me.ToolStripMenuItemTransactions, "ToolStripMenuItemTransactions")
            '
            'ToolStripMenuItemPayrollMenu
            '
            Me.ToolStripMenuItemPayrollMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPayrollAttendance, Me.ToolStripMenuItemGeneratePayroll, Me.ToolStripMenuItemPayrollEntry, Me.ToolStripMenuItemRecurringPayrollEntry, Me.ToolStripMenuItemEmployeeLeave, Me.ToolStripMenuItemEmployeeAbsencesLate})
            Me.ToolStripMenuItemPayrollMenu.Name = "ToolStripMenuItemPayrollMenu"
            resources.ApplyResources(Me.ToolStripMenuItemPayrollMenu, "ToolStripMenuItemPayrollMenu")
            '
            'ToolStripMenuItemPayrollAttendance
            '
            Me.ToolStripMenuItemPayrollAttendance.Name = "ToolStripMenuItemPayrollAttendance"
            resources.ApplyResources(Me.ToolStripMenuItemPayrollAttendance, "ToolStripMenuItemPayrollAttendance")
            '
            'ToolStripMenuItemGeneratePayroll
            '
            Me.ToolStripMenuItemGeneratePayroll.Name = "ToolStripMenuItemGeneratePayroll"
            resources.ApplyResources(Me.ToolStripMenuItemGeneratePayroll, "ToolStripMenuItemGeneratePayroll")
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
            'ToolStripMenuItemEmployeeLeave
            '
            Me.ToolStripMenuItemEmployeeLeave.Name = "ToolStripMenuItemEmployeeLeave"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeLeave, "ToolStripMenuItemEmployeeLeave")
            '
            'ToolStripMenuItemEmployeeAbsencesLate
            '
            Me.ToolStripMenuItemEmployeeAbsencesLate.Name = "ToolStripMenuItemEmployeeAbsencesLate"
            resources.ApplyResources(Me.ToolStripMenuItemEmployeeAbsencesLate, "ToolStripMenuItemEmployeeAbsencesLate")
            '
            'ToolStripSeparator2
            '
            Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
            resources.ApplyResources(Me.ToolStripSeparator2, "ToolStripSeparator2")
            '
            'ToolStripMenuItemReports
            '
            Me.ToolStripMenuItemReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemStatementOfAccountsPayable, Me.ToolStripMenuItemStatementOfAccountsReceivable, Me.ToolStripMenuItemStatementOfEmployeeLoans, Me.ToolStripMenuItemSummaryOfEmployeeLoans, Me.ToolStripMenuItemSummaryOfAccountsPayable, Me.ToolStripMenuItemSummaryOfAccountsReceivable, Me.ToolStripMenuItemTrialBalance, Me.ToolStripMenuItemBalanceSheet, Me.ToolStripMenuItemIncomeStatement, Me.ToolStripMenuItemAccountingtLists, Me.ToolStripMenuItemIGroupReports, Me.ToolStripMenuItemARAging, Me.ToolStripMenuItemAPAging, Me.ToolStripMenuItemCheckPrinting, Me.ToolStripMenuItemPayrollReport})
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
            'ToolStripMenuItemIGroupReports
            '
            Me.ToolStripMenuItemIGroupReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemCashIncomePerDoctorService, Me.ToolStripMenuItemNumberOfCashPatientsPerDoctor, Me.ToolStripMenuItemBlankReport})
            Me.ToolStripMenuItemIGroupReports.Name = "ToolStripMenuItemIGroupReports"
            resources.ApplyResources(Me.ToolStripMenuItemIGroupReports, "ToolStripMenuItemIGroupReports")
            '
            'ToolStripMenuItemCashIncomePerDoctorService
            '
            Me.ToolStripMenuItemCashIncomePerDoctorService.Name = "ToolStripMenuItemCashIncomePerDoctorService"
            resources.ApplyResources(Me.ToolStripMenuItemCashIncomePerDoctorService, "ToolStripMenuItemCashIncomePerDoctorService")
            '
            'ToolStripMenuItemNumberOfCashPatientsPerDoctor
            '
            Me.ToolStripMenuItemNumberOfCashPatientsPerDoctor.Name = "ToolStripMenuItemNumberOfCashPatientsPerDoctor"
            resources.ApplyResources(Me.ToolStripMenuItemNumberOfCashPatientsPerDoctor, "ToolStripMenuItemNumberOfCashPatientsPerDoctor")
            '
            'ToolStripMenuItemBlankReport
            '
            Me.ToolStripMenuItemBlankReport.Name = "ToolStripMenuItemBlankReport"
            resources.ApplyResources(Me.ToolStripMenuItemBlankReport, "ToolStripMenuItemBlankReport")
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
            'ToolStripMenuItemPayrollReport
            '
            Me.ToolStripMenuItemPayrollReport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemPeriodicPayroll, Me.GenerateCSVFileToolStripMenuItem})
            Me.ToolStripMenuItemPayrollReport.Name = "ToolStripMenuItemPayrollReport"
            resources.ApplyResources(Me.ToolStripMenuItemPayrollReport, "ToolStripMenuItemPayrollReport")
            '
            'ToolStripMenuItemPeriodicPayroll
            '
            Me.ToolStripMenuItemPeriodicPayroll.Name = "ToolStripMenuItemPeriodicPayroll"
            resources.ApplyResources(Me.ToolStripMenuItemPeriodicPayroll, "ToolStripMenuItemPeriodicPayroll")
            '
            'GenerateCSVFileToolStripMenuItem
            '
            Me.GenerateCSVFileToolStripMenuItem.Name = "GenerateCSVFileToolStripMenuItem"
            resources.ApplyResources(Me.GenerateCSVFileToolStripMenuItem, "GenerateCSVFileToolStripMenuItem")
            '
            'ToolStripMenuItemUtilities
            '
            Me.ToolStripMenuItemUtilities.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemRecreateSecurityObjectMenu, Me.ToolStripMenuItemTransactionNotesTranslator})
            Me.ToolStripMenuItemUtilities.Name = "ToolStripMenuItemUtilities"
            resources.ApplyResources(Me.ToolStripMenuItemUtilities, "ToolStripMenuItemUtilities")
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
            'Payroll
            '
            Me.AllowDrop = True
            resources.ApplyResources(Me, "$this")
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackgroundImage = Global.AATM.Accounts.My.Resources.Resources.GreenGradientBackgroundLarge
            Me.Controls.Add(Me.ToolStrip)
            Me.Controls.Add(Me.AccountsMenu)
            Me.IsMdiContainer = True
            Me.Name = "Payroll"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ToolStrip.ResumeLayout(False)
            Me.ToolStrip.PerformLayout()
            Me.AccountsMenu.ResumeLayout(False)
            Me.AccountsMenu.PerformLayout()
            Me.contextMenuStripMember.ResumeLayout(False)
            Me.contextMenuStrip1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Friend WithEvents ToolStripMenuItemItems As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCategories As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCaptionsBatchEdit As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCreateAllMessages As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemDefaultFieldValues As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemStatementOfEmployeeLoans As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSummaryOfAccountsPayable As ToolStripMenuItem
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
        Friend WithEvents ToolStripMenuItemPayrolls As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPensionProviders As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPensionSchemes As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSalesDepositTypes As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayrollMenu As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemIGroupReports As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCashIncomePerDoctorService As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemNumberOfCashPatientsPerDoctor As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBlankReport As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBSQuarterly As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemBSSemestral As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemARAging As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemAPAging As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayrollAttendance As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayrollEntry As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemCheckPrinting As ToolStripMenuItem
        Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
        Friend WithEvents ToolStripMenuItemGeneratePayroll As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemSettings As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemChangePassword As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemUtilities As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemRecreateSecurityObjectMenu As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTransactionNotesTranslator As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPayrollReport As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemPeriodicPayroll As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemRecurringPayrollEntry As ToolStripMenuItem
        Friend WithEvents ToolStripButton1 As ToolStripButton
        Friend WithEvents ToolStripMenuItemAccountActivity As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemJournalTransactionSummary As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemTransactionJournalCodes As ToolStripMenuItem
        Friend WithEvents GenerateCSVFileToolStripMenuItem As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeLeave As ToolStripMenuItem
        Friend WithEvents ToolStripMenuItemEmployeeAbsencesLate As ToolStripMenuItem
    End Class
End NameSpace