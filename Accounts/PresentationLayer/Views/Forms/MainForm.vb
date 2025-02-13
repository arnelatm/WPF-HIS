Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Common
Imports AATM.Common.Models
Imports AATM.Common.PresentationLayer.Models
Imports AATM.Common.PresentationLayer.Presenters
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Libraries
Imports AATM.Libraries.ErrorsAndEvents
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Forms
Imports AATM.PresentationLayer.Models
Imports AATM.PresentationLayer.Presenters
Imports AATM.PresentationLayer.Views.Interfaces
Imports AutoMapper


Namespace PresentationLayer.Views.Forms

    ''' <summary>
    '''     Main window for Windows Forms application. Most business logic resides
    '''     in this window as it responds to local control events, menu events, and
    '''     closed dialog events. This is usually the preferred model, unless the
    '''     child windows have significant processing requirements, then they handle
    '''     that themselves.
    ''' </summary>
    ''' <remarks>
    '''     All communications required for this application runs via the Service layer.
    '''     The application uses the Model View Presenter design pattern. Each of these
    '''     reside in its own Visual Studio project.
    '''     MV Patterns: MVP design pattern is used throughout this WinForms application.
    ''' </remarks>
    Partial Public Class MainForm
        Implements IUserView

        Public IdleTimer As New System.Windows.Forms.Timer()
        Const MinuteMicroseconds As Integer = 10000

        Public Shared AccountsMapper As IMapper
        Private _logStatus As LoginStatus
        Public Event UserLoggedIn(sender As Object, formControls As List(Of Control))

        'Private ReadOnly _presenterObj

        ''' <summary>
        '''     Default form constructor.
        ''' </summary>
        Public Sub New()

            InitializeComponent()

            If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
                AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledExceptionHandler
                AddHandler Application.ThreadException, AddressOf ThreadExceptionHandler
                Dim mySettings = AppSettings.Load()
                GlobalVariables.TranslationMode = True ' mySettings.TranslationInitializer
                GlobalVariables.PreferredLanguage = mySettings.PreferredLanguage
                _logStatus = LoginStatus.LoggedOut
                GlobalFunctions.SetCulture(GlobalVariables.AppCultureInfo.ToString())
                GlobalVariables.AppCultureInfo = CultureInfo.CurrentCulture
                GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture
                If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                    GlobalVariables.RightToLeftLayout = True
                Else
                    GlobalVariables.RightToLeftLayout = False
                End If
                SetLanguageChangeButtons()
                SetupMapper()
                Presenter = New UserPresenter(Of UserModel)(Me)
                GlobalVariables.EstablishmentName = Presenter.EstablishmentName
                GlobalVariables.EstablishmentNameAra = Presenter.EstablishmentNameAra
            End If
        End Sub

        Public Event FormCultureChanged()

        'Enumerates login Menu: Logged In or Logged Out.
        Public Enum LoginStatus
            LoggedIn
            LoggedOut
        End Enum

        Public MainFieldsDictionary As New Dictionary(Of String, Object)

        Public Property IdNo As Int32 Implements IUserView.IdNo
        Public Property SecurityGroupIdNo As Int16 Implements IUserView.SecurityGroupIdNo
        Public Property EmployeeIdNo As Int32? Implements IUserView.EmployeeIdNo
        Public Property UserName As String Implements IUserView.UserName

        Public Property LogStatus As LoginStatus
            Get
                Return _logStatus
            End Get
            Set
                _logStatus = Value
                If _logStatus = LoginStatus.LoggedIn Then
                    Dim allControls As New List(Of Control)
                    allControls = FindControlRecursive(allControls, Me)
                    GlobalVariables.IsUserLoggedIn = True
                    SecurityGroupIdNo = GlobalVariables.SecurityGroupIdNo
                    If UserIsASuperAdmin() Then
                        GlobalSubs.ShowAndEnableMenuItems(AccountsMenu)
                        If _addSecurityObject Then
                            For Each cCtrl As Control In allControls
                                SetObjectSecurityNew(cCtrl)
                            Next
                        End If
                    Else
                        For Each cCtrl As Control In allControls
                            SetObjectSecurityNew(cCtrl)
                        Next
                    End If
                    RaiseEvent UserLoggedIn(Me, allControls)
                    DisableLogin()
                Else
                    GlobalVariables.IsUserLoggedIn = False
                    GlobalSubs.HideAndDisableMenuItems(AccountsMenu)
                    EnableLogin()
                End If
                EnableEssentials()
            End Set
        End Property

        Public Property MainTableName As String
        Public Property Password As String Implements IUserView.Password
        Public Property SecurityLevel As Short Implements IUserView.SecurityLevel

        Public Property Active As Boolean Implements IUserView.Active

        Public Sub ResetMenuSecurity(ByRef cCtrl As Control)
            Static sw = 0
            Static mainParentIdNo As Int32
            If sw = 0 Then
                Dim securityObject As New SecurityObject With {.SecurityObjectName = MenuFormName,
                        .SystemViewIdNo = VSystemViewIdNo,
                        .ParentIdNo = Nothing}
                mainParentIdNo = Presenter.AddSecurityObject(securityObject)
                sw = 1
            End If
            If TypeOf cCtrl Is MenuStrip Then
                ' check for MenuStrip first because MenuStrip is also a ToolStrip
                Dim subMenuName = MenuFormName + " > " + cCtrl.Name.Trim()
                Dim menuStripMain As MenuStrip = cCtrl
                Dim securityObject As New SecurityObject With {.SecurityObjectName = cCtrl.Name.Trim(),
                        .SystemViewIdNo = VSystemViewIdNo,
                        .ParentIdNo = mainParentIdNo}
                Dim parentIdNo As Int32
                parentIdNo = Presenter.AddSecurityObject(securityObject)
                AddChildMenuSecurityObjects(menuStripMain.Items, subMenuName, parentIdNo)
            ElseIf TypeOf cCtrl Is ToolStrip Then
                Dim subMenuName = MenuFormName + " > " + cCtrl.Name.TrimEnd()
                Dim toolStripMain As ToolStrip = cCtrl
                Dim securityObject As New SecurityObject With {.SecurityObjectName = cCtrl.Name.TrimEnd(),
                        .SystemViewIdNo = VSystemViewIdNo,
                        .ParentIdNo = mainParentIdNo}
                Dim parentIdNo As Int32
                parentIdNo = Presenter.AddSecurityObject(securityObject)
                AddChildMenuSecurityObjects(toolStripMain.Items, subMenuName, parentIdNo)
            End If
        End Sub

        Public Sub SetupMapper()
            Dim mapperConfigurationAccounts = New MapperConfiguration(Sub(cfg)
                                                                          cfg.AddProfile(New MappingProfileAccounts)
                                                                          cfg.AddProfile(New MappingProfileCommon)
                                                                      End Sub)
            GlobalVariables.Mapper = mapperConfigurationAccounts.CreateMapper()
            'mapperConfigurationAccounts.AssertConfigurationIsValid()
        End Sub


        Public Sub UpdateViewDisplay(editMode As Boolean, addMode As Boolean, recordPositionNumber As Integer, targetIdNo As Integer, recordCount As Integer)
        End Sub

#Region "MenuActions"

        ''' <summary>
        '''     Opens the about dialog window.
        ''' </summary>
        Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAbout.Click
            Dim form = New FormAbout()
            form.ShowDialog()
        End Sub

        Private Sub AccountReconciliationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAccountReconciliation.Click
            RunForm(Of AccountReconciliationEntry, AccountReconciliationPresenter(Of AccountReconciliationModel))()
        End Sub

        Private Sub AccountsPayableEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAccountsPayableEntry.Click
            RunForm(Of ApJournalEntry, ApJournalPresenter(Of ApJournalModel))()
        End Sub

        Private Sub AccountsReceivableEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAccountsReceivableEntry.Click
            RunForm(Of ArJournalEntry, ArJournalPresenter(Of ArJournalModel))()
        End Sub

        Private Sub AccountsReceivableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemARAging.Click
            Dim reportTitle = Messaging.TranslateCaption("Aging of Accounts Receivable")
            reportTitle = reportTitle + " " + GlobalFuncNSub.GregorianLongDate(Now(), CultureInfo.CurrentCulture)
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            Dim estName As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            If language = "ar" Then
                estName = GlobalVariables.EstablishmentName
            Else
                estName = GlobalVariables.EstablishmentNameAra
            End If
            Dim cForm As New ReportForm("Aging of Accounts Receivable.Rpt", reportTitle, "ReportTitle", estName, "EstablishmentName", language, "Language")
            cForm.Show()
        End Sub

        Private Sub AgingOfAccountsPayableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAPAging.Click
            Dim reportTitle = Messaging.TranslateCaption("Aging of Accounts Payable as of ")
            reportTitle = reportTitle + " " + GlobalFuncNSub.GregorianLongDate(Now(), CultureInfo.CurrentCulture)
            Dim curCulture = CultureInfo.CurrentCulture
            CultureInfo.CurrentCulture = New CultureInfo("En-GB", False)
            Dim language As String
            Dim estName As String
            language = Strings.Left(curCulture.Name, curCulture.Name.IndexOf("-", StringComparison.Ordinal))
            If language = "ar" Then
                estName = GlobalVariables.EstablishmentName
            Else
                estName = GlobalVariables.EstablishmentNameAra
            End If
            Dim cForm As New ReportForm("Aging of Accounts Payable.Rpt", reportTitle, "ReportTitle", language, "Language", estName, "EstablishmentName")
            cForm.Presenter = New PrintReportPresenter(Of ReportModel)
            cForm.Show()
        End Sub

        Private Sub BankTransferToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim formToRun = New DisbursementJournalEntry("CdJournal")
            formToRun.Presenter = New DisbursementJournalPresenter(Of DisbursementJournalModel)(formToRun, "CdJournal")
            formToRun.Show()
        End Sub

        Private Sub BranchesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBranches.Click
            RunForm(Of BranchEntryTv, BranchPresenter(Of BranchModel))()
        End Sub

        Private Sub CashDisbursementEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCashDisbursementEntry.Click
            Dim formToRun = New DisbursementJournalEntry("CdJournal")
            formToRun.Presenter = New DisbursementJournalPresenter(Of DisbursementJournalModel)(formToRun, "CdJournal")
            formToRun.Show()
        End Sub

        Private Sub CashIncomePerDoctorServiceToolStripMenuItem_Click(sender As Object, e As EventArgs)
            RunForm(Of CashIncomePerDoctorPerService)()
        End Sub

        Private Sub CashReceiptEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemCashReceiptEntry.Click
            RunForm(Of CashReceiptJournalEntry, CashReceiptJournalPresenter(Of CashReceiptJournalModel))()
        End Sub

        Private Sub ChartOfAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemChartOfAccounts.Click
            RunForm(Of AccountEntryTv, AccountPresenter(Of AccountModel))()
        End Sub

        Private Sub CheckPrintingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCheckPrinting.Click
            Dim formToRun As CheckPrinter
            formToRun = New CheckPrinter()
            formToRun.Show()
        End Sub

        Private Sub ClosePettyCashFundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemClosePettyCashFund.Click
            RunForm(Of PettyCashClosingEntry, PettyCashClosingPresenter(Of PettyCashClosingModel))()
        End Sub

        Private Sub CountriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCountries.Click
            RunForm(Of CountryEntryTv, CountryPresenter(Of CountryModel))()
        End Sub

        Private Sub CreateAllMessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCreateAllMessages.Click
            Dim x = New OneTimeRun
            OneTimeRun.CreateAllMessages()
        End Sub

        Private Sub CustomerClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCustomerClients.Click
            RunForm(Of CustomerEntryTv, CustomerPresenter(Of CustomerModel))()
        End Sub

        Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBCustom.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("TrialBalance", "C")
        End Sub

        Private Sub ToolStripMenuItemISCustomRange_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISCustomRange.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("IncomeStatement", "C")
        End Sub

        Private Sub DefaultFieldValuesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDefaultFieldValues.Click
            RunForm(Of DefaultFieldValueEntryTv, DefaultFieldValuePresenter(Of DefaultFieldValueModel))()
        End Sub

        Private Sub DepartmentNewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDepartments.Click
            RunForm(Of DepartmentEntryTv, DepartmentPresenter(Of DepartmentModel))()
        End Sub

        Private Sub DesignationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDesignations.Click
            RunForm(Of DesignationEntryTv, DesignationPresenter(Of DesignationModel))()
        End Sub

        Private Sub DistributionSchemesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDistributionSchemes.Click
            RunForm(Of DistributionSchemeEntry, DistributionSchemePresenter(Of DistributionSchemeModel))()
        End Sub

        Private Sub EarningsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPayElement.Click
            RunForm(Of PayElementEntryTv, PayElementPresenter(Of PayElementModel))()
        End Sub

        Private Sub EmployeeReceivableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeReceivable.Click
            RunForm(Of ErJournalEntry, ErJournalPresenter(Of ErJournalModel))()
        End Sub

        Private Sub EmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployees.Click
            RunForm(Of EmployeeEntryTv, EmployeePresenter(Of EmployeeModel))()
        End Sub

        Private Sub GeneralJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemGeneralJournalEntry.Click
            RunForm(Of GeneralJournalEntry, GeneralJournalPresenter(Of GeneralJournalModel), Boolean)(False)
        End Sub

        ''' <summary>
        '''     Help menu item event handler.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub IndexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemIndex.Click
            MessageBox.Show("Help Is Not implemented... ", "Help")
        End Sub

        Private Sub LeavesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLeaves.Click
            RunForm(Of LeaveEntryTv, LeavePresenter(Of LeaveModel))()
        End Sub

        Private Sub MessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMessages.Click
            RunForm(Of OriginalMessagesEntryTv, OriginalMessagesPresenter(Of OriginalMessagesModel))()
        End Sub

        Private Sub MonthlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBMonthly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("TrialBalance", "M")
        End Sub

        Private Sub MonthlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSMonthly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("BalanceSheet", "M")
        End Sub

        Private Sub MonthlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISMonthly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("IncomeStatement", "M")
        End Sub

        Private Sub NumberOfCashPatientsPerDoctorToolStripMenuItem_Click(sender As Object, e As EventArgs)
            RunForm(Of NumberOfCashPatientsPerDoctorPerDay)()
        End Sub

        Private Sub PayCyclesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPayCycles.Click
            RunForm(Of PayCycleEntryTv, PayCyclePresenter(Of PayCycleModel))()
        End Sub

        Private Sub PayGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPayGroups.Click
            RunForm(Of PayGroupEntryTv, PayGroupPresenter(Of PayGroupModel))()
        End Sub

        Private Sub PayrollEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPayrollEntry.Click
            RunForm(Of PayrollEntryTv, PayrollPresenter(Of PayrollModel))()
        End Sub

        Private Sub PensionProvidersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPensionProviders.Click
            RunForm(Of PensionProviderEntryTv, PensionProviderPresenter(Of PensionProviderModel))()
        End Sub

        Private Sub PensionSchemesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPensionSchemes.Click
            RunForm(Of PensionSchemeEntryTv, PensionSchemePresenter(Of PensionSchemeModel))()
        End Sub

        Private Sub PettyCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPettyCash.Click
            RunForm(Of DisbursementJournalEntry, DisbursementJournalPresenter(Of DisbursementJournalModel), String)("PcJournal")
        End Sub


        Private Sub QuarterlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBQuarterly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("TrialBalance", "Q")
        End Sub

        Private Sub QuarterlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISQuarterly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("IncomeStatement", "Q")
        End Sub

        Private Sub QuarterlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSQuarterly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("BalanceSheet", "Q")
        End Sub

        Private Sub ReligionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemReligions.Click
            RunBasicForm("Religion", "Religion Entry")
            'RunForm(Of ReligionEntryTv, ReligionPresenter(Of ReligionModel))()
        End Sub

        Private Sub RevCostCentersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRevCostCenters.Click
            RunForm(Of RevCostCenterEntryTv, RevCostCenterPresenter(Of RevCostCenterModel))()
        End Sub

        Private Sub RevenueGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRevenueGroups.Click
            RunForm(Of RevenueGroupEntryTv, RevenueGroupPresenter(Of RevenueGroupModel))()
        End Sub

        Private Sub RunBasicForm(ByVal tableOrViewName As String, ByVal formCaption As String)
            RunBaseForm(Of BasicEntry, BasicPresenter(Of BasicModel))(tableOrViewName, formCaption)
        End Sub

        Private Sub SalesDepositTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSalesDepositTypes.Click
            RunForm(Of DepositTypeEntryTv, DepositTypePresenter(Of DepositTypeModel))()
        End Sub

        Private Sub ClosingEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemClosing.Click
            RunForm(Of GeneralJournalEntry, GeneralJournalPresenter(Of GeneralJournalModel), Boolean)(True)
        End Sub

        Private Sub SalesJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSalesJournalEntry.Click
            RunForm(Of SalesJournalEntry, SalesJournalPresenter(Of SalesJournalModel))()
        End Sub

        Private Sub SecurityObjectsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ToolStripMenuItemSecurityObjects.Click
            RunForm(Of SecurityObjectEntryTv, SecurityObjectPresenter(Of SecurityObjectModel))()
        End Sub

        Private Sub SemestralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBSemestral.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("TrialBalance", "S")
        End Sub

        Private Sub SemestralToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSSemestral.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("BalanceSheet", "S")
        End Sub

        Private Sub SemiAnnuallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISSemiAnnually.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("IncomeStatement", "S")
        End Sub

        Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSettings.Click
            RunForm(Of SetSettings)()
        End Sub

        Private Sub SummaryOfAccountsPayableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSummaryOfAccountsPayable.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("ApSummary", Nothing)
        End Sub

        Private Sub SupplierVendorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSupplierVendors.Click
            RunForm(Of SupplierEntryTv, SupplierPresenter(Of SupplierModel))()
        End Sub

        Private Sub TestToolStripMenuItem1_Click(sender As Object, e As EventArgs)
            Dim cForm As New ReportFormTest("Blank Report.Rpt")
            cForm.Show()
        End Sub

        Private Sub ToolStripButtonTranslate_Click(sender As Object, e As EventArgs) Handles ToolStripButtonTranslate.Click
            Dim frm As New TranslationTableManager With {
                    .SystemViewIdNoToTranslate = VSystemViewIdNo,
                    .AppDataDAC = AppDataDAC,
                    .TranslatorDAC = TranslatorDAC
                    }
            frm.Show()
        End Sub

        Private Sub ToolStripMenuItemCaptions_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCaptions.Click
            RunForm(Of OriginalCaptionEntryTv, OriginalCaptionsPresenter(Of OriginalCaptionsModel))()
        End Sub

        Private Sub ToolStripMenuItemSecurityGroups_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSecurityGroups.Click
            RunForm(Of SecurityGroupEntryTv, SecurityGroupPresenter(Of SecurityGroupModel))()
        End Sub

        Private Sub StatementOfEmployeeLoansToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfEmployeeLoans.Click
            RunForm(Of ApArEmReport, ApArEmReportPresenter(Of AccountModel), String)("ErStatement")
        End Sub

        Private Sub ToolStripMenuItemStatementOfAccountsPayable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfAccountsPayable.Click
            RunForm(Of ApArEmReport, ApArEmReportPresenter(Of AccountModel), String)("ApStatement")
        End Sub

        Private Sub ToolStripMenuItemStatementOfAccountsReceivable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfAccountsReceivable.Click
            RunForm(Of ApArEmReport, ApArEmReportPresenter(Of AccountModel), String)("ArStatement")
        End Sub

        Private Sub ToolStripMenuItemEmployeeLeaveReport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeLeaveReport.Click
            RunForm(Of ApArEmReport, ApArEmReportPresenter(Of AccountModel), String)("LeaveStatement")
        End Sub

        Private Sub ToolStripMenuItemEmployeeInformation_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeInformation.Click
            RunForm(Of ApArEmReport, ApArEmReportPresenter(Of AccountModel), String)("EmployeeInfo")
        End Sub

        Private Sub ToolStripMenuItemStateOfEmployeeLoans_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSummaryOfEmployeeLoans.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("ErSummary", Nothing)
        End Sub

        Private Sub ToolStripMenuItemSummaryOfAccountsReceivable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSummaryOfAccountsReceivable.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("ArSummary", Nothing)
        End Sub

        Private Sub ToolStripMenuItemUsers_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemUsers.Click
            RunForm(Of UserEntryTv, UserPresenter(Of UserModel))()
        End Sub

        Private Sub TranslationFormToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim frm As New TranslationTableManager With {
                .AppDataDAC = AppDataDAC,
                .TranslatorDAC = TranslatorDAC
            }
            frm.Show()
        End Sub

        Private Sub TranslationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCaptionsBatchEdit.Click
            'frm.SystemViewIdNoToTranslate = 0
            Dim frm As New TranslationTableManager With {
                .AppDataDAC = AppDataDAC,
                .TranslatorDAC = TranslatorDAC
            }
            frm.Show()
        End Sub

        Private Sub YearlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBYearly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("TrialBalance", "Y")
        End Sub

        Private Sub YearlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSYearly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("BalanceSheet", "Y")
        End Sub

        Private Sub YearlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISYearly.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("IncomeStatement", "Y")
        End Sub

        Private Sub JournalListingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemJournalTransactionSummary.Click
            RunReportNew(Of TransactionSummary)()
        End Sub

        Private Sub RecurringPayElementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRecurringPayrollEntry.Click
            RunForm(Of RecurringPayElementEntry, RecurringPayElementPresenter(Of RecurringPayElementModel))()
        End Sub

        Private Sub ToolStripMenuItemAccountActivity_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAccountActivity.Click
            RunReportNew(Of AccountActivity)()
        End Sub

        Private Sub ToolStripMenuItemTransactionJournalCodes_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTransactionJournalCodes.Click
            RunForm(Of JournalPrefixEntry, JournalPrefixPresenter(Of JournalPrefixModel))()
        End Sub

        Private Sub TransactionNotesTranslatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTransactionNotesTranslator.Click
            RunForm(Of NotesTranslator)()
        End Sub

        Private Sub BankTransferReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBankTransferReport.Click
            RunForm(Of GeneratePayrollBankCsv, GeneratePayrollBankCsvPresenter(Of PayrollModel))()
        End Sub

        Private Sub ToolStripMenuItemPostPettyCashAccount_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPostPettyCashAccount.Click
            RunForm(Of PettyCashClosingEntry, PettyCashClosingPresenter(Of PettyCashClosingModel))()
        End Sub

        Private Sub ShiftSummaryEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemShiftSummaryEntry.Click
            RunForm(Of ShiftSummaryEntry, ShiftSummaryPresenter(Of ShiftSummaryModel))()
        End Sub

#End Region

        'Protected Sub SwitchUiLanguage(originalUi As Boolean)
        '    If originalUi Then
        '        TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
        '    Else
        '        TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
        '    End If
        '    TranslateForm()
        '    ToolStripButtonEnglish.Visible = Not originalUi
        '    ToolStripButtonArabic.Visible = originalUi
        'End Sub

        Private Sub AddChildMenuSecurityObjects(dropDownItems As ToolStripItemCollection, pParentMenuName As String, pParentIdNo As Int32)
            Dim parentIdNo As Int32
            For Each dropDownItem As Object In dropDownItems
                If TypeOf dropDownItem Is ToolStripMenuItem Then
                    Dim parentMenuName = pParentMenuName
                    parentIdNo = AddSecurityObject(Of ToolStripMenuItem)(dropDownItem, parentMenuName, pParentIdNo, 17)
                    If dropDownItem.HasDropDown Then
                        'Dim childSubMenuName As String = pParentMenuName + " > " + Mid(dropDownItem.Name, 18)
                        AddChildMenuSecurityObjects(dropDownItem.DropDownItems, pParentMenuName, parentIdNo)
                    End If
                ElseIf TypeOf dropDownItem Is ToolStripButton Then
                    'Dim childSubMenuName = pParentMenuName + " > " + Mid(dropDownItem.Name, 16)
                    AddSecurityObject(Of ToolStripButton)(dropDownItem, pParentMenuName, pParentIdNo, 15)
                End If
            Next
        End Sub

        Private Function AddSecurityObject(Of T)(ByRef obj As T, ByRef subMenuName As String, ByVal parentIdNo As Int32, loc As Int16) As Int32
            Dim toolStripMenuItem As T = obj
            'Dim objName = CallByName(obj, "Name", CallType.Get)
            Dim objName = Invoker.GetProperty(obj, "Name")
            Dim securityObject As New SecurityObject With {.SecurityObjectName = objName.SubString(loc),
                    .SystemViewIdNo = VSystemViewIdNo,
                    .ParentIdNo = parentIdNo}
            parentIdNo = Presenter.AddSecurityObject(securityObject)
            Return parentIdNo
        End Function

        Private Sub DisableLogin()
            ToolStripButtonLogin.Enabled = False
            ToolStripMenuItemLogin.Enabled = False
            ToolStripButtonLogin.Visible = True
            ToolStripMenuItemLogin.Visible = True
            ToolStripButtonLogout.Enabled = True
            ToolStripMenuItemLogout.Enabled = True
            ToolStripButtonLogout.Visible = True
            ToolStripMenuItemLogout.Visible = True
            SetLanguageChangeButtons()
        End Sub

        Private Sub EnableEssentials()
            AccountsMenu.Enabled = True
            AccountsMenu.Visible = True
            ToolStrip.Enabled = True
            ToolStrip.Visible = True
            ToolStripButtonExit.Visible = True
            ToolStripMenuItemFile.Visible = True
            ToolStripMenuItemExit.Visible = True
            ToolStripButtonExit.Enabled = True
            ToolStripMenuItemFile.Enabled = True
            ToolStripMenuItemExit.Enabled = True
        End Sub

        Private Sub EnableLogin()
            ToolStripButtonLogin.Enabled = True
            ToolStripMenuItemLogin.Enabled = True
            ToolStripButtonLogin.Visible = True
            ToolStripMenuItemLogin.Visible = True
            ToolStripButtonLogout.Enabled = False
            ToolStripMenuItemLogout.Enabled = False
            ToolStripButtonLogout.Visible = True
            ToolStripMenuItemLogout.Visible = True
            SetLanguageChangeButtons()
        End Sub

        ''' <summary>
        '''     Exits application.
        ''' </summary>
        Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
            SaveMirroredLanguageSetting()
            Close()
        End Sub

        Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
            GetNSaveCaptions()
            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                ToolStripButtonArabic.Visible = False
                ToolStripButtonEnglish.Visible = True
            Else
                ToolStripButtonArabic.Visible = True
                ToolStripButtonEnglish.Visible = False
            End If
            ToolStripButtonLogin.Enabled = True
            ToolStripButtonLogin.PerformClick()
            ToolStripButtonExit.Enabled = True
            If Presenter.UsePayGroups() Then
                ToolStripMenuItemPayGroups.Visible = True
            Else
                ToolStripMenuItemPayGroups.Visible = False
            End If
            ' Add any initialization after the InitializeComponent() call.
            Dim mySettings = AppSettings.Load()
            Dim mirroredLanguage = My.Settings.MirroredLanguage
            If mirroredLanguage Then
                GlobalFunctions.SetCulture(GlobalVariables.DefaultMirroredCultureInfoStr)
                SetLanguageChangeButtons()
                SwitchUiLanguage(False)
            End If
            '_appSettings = PropertyGrid.SelectedObject
            ' Attribute for the user-scope settings.

        End Sub

        ''' <summary>
        '''     Displays login dialog box and loads member list in treeview.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLogin.Click
            'RunForm(Of UserEntryTv, UserPresenter(Of UserModel))()
            Using form As New LoginEntry(False)
                Try
                    If form.ShowDialog() = DialogResult.OK Then
                        If form.LoginOk Then
                            LogStatus = LoginStatus.LoggedIn
                        Else
                            LogStatus = LoginStatus.LoggedOut
                        End If
                    Else
                        LogStatus = LoginStatus.LoggedOut
                    End If
                    If LogStatus = LoginStatus.LoggedIn Then
                        Dim mirroredLanguage = My.Settings.MirroredLanguage
                        If mirroredLanguage Then
                            GlobalFunctions.SetCulture(GlobalVariables.DefaultMirroredCultureInfoStr)
                            SetLanguageChangeButtons()
                            SwitchUiLanguage(False)
                        End If
                    End If

                    'Presenter.ResetMenuSecurity(Me)
                Catch ex As TypeInitializationException
                    MessageBox.Show("Invalid Connection String, specified connection String doesn't exist.",
                                    "Connection String Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrLogger.LogError(ex, True)
                    LogStatus = LoginStatus.LoggedOut
                Catch ex As Exception
                    LogStatus = LoginStatus.LoggedIn
                End Try
            End Using
        End Sub

        'End Sub
        ''' <summary>
        '''     Logoff user, empties datagridviews, and disables menus.
        ''' </summary>
        Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemLogout.Click
            If LogStatus = LoginStatus.LoggedIn Then
                SaveLanguagePreference()
            End If
            LogStatus = LoginStatus.LoggedOut
        End Sub

        Private Sub SaveLanguagePreference()
            My.Settings.PreferredLanguage = GlobalVariables.PreferredLanguage
            My.Settings.Save()
        End Sub

        Private Sub RecreateSecurityObjectMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRecreateSecurityObjectMenu.Click
            Dim allControls As New List(Of Control)
            Dim nRecCount = Presenter.GetRecordCount("SecurityObject")
            If UserIsASuperAdmin() Then
                Dim addSecurityObject As Boolean = False
                If nRecCount <= 12 Then
                    If nRecCount = 0 Then
                        If Presenter.InitializeSecurityObject() > 0 Then
                            addSecurityObject = True
                        End If
                    Else
                        addSecurityObject = True
                    End If
                Else
                    MessageBox.Show("Security Objects not changed there already exists security objects. You must delete them (except the basic 12 security groups) before you can Initialize the security objects.")
                    addSecurityObject = False
                End If
                If addSecurityObject Then
                    For Each cCtrl As Control In FindControlRecursive(allControls, Me)
                        ResetMenuSecurity(cCtrl)
                    Next
                End If
            End If
        End Sub

        Private Sub SetLanguageChangeButtons()
            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                ToolStripButtonArabic.Visible = False
                ToolStripButtonArabic.Enabled = True
                ToolStripButtonEnglish.Visible = True
                ToolStripButtonEnglish.Enabled = True
            Else
                ToolStripButtonArabic.Visible = True
                ToolStripButtonArabic.Enabled = True
                ToolStripButtonEnglish.Visible = False
                ToolStripButtonEnglish.Enabled = True
            End If
        End Sub

        Private Sub ShowEntryForm(Of T As New)(ByRef formEntry As T)
            If (MdiChildren.Length > GlobalVariables.MaximumOpenForms - 1) Then
                Dim maxOpenForms As String = GlobalVariables.MaximumOpenForms.ToString()
                Messaging.Show(True, "MsgTooManyFormsOpen", "Too many forms open. You can only open up to {maxOpenForms} forms at the same time.", "Too many forms open", {"maxOpenForms", maxOpenForms})
            Else
                Invoker.InvokeFunction(formEntry, "Show")
            End If
        End Sub

        Private Sub ThreadExceptionHandler(sender As Object, e As ThreadExceptionEventArgs)
            ErrLogger.LogError(e.Exception)
        End Sub

        Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExit.Click
            SaveMirroredLanguageSetting()
            Close()
        End Sub

        Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButtonDebug.Click
            Debugger.Break()
        End Sub

        Private Sub ToolStripButtonHelp_Click(sender As Object, e As EventArgs)
            Dim maxOpenForms As String = GlobalVariables.MaximumOpenForms.ToString()
            Messaging.Show(True, "MsgTooManyFormsOpen", "Too many forms open. You can only open up to {maxOpenForms} forms at the same time.", "Too many forms open", {"maxOpenForms", maxOpenForms})
        End Sub

        ''' <summary>
        '''     Redirects login request to equivalent menu event handler.
        ''' </summary>
        Private Sub ToolStripButtonLogin_Click(sender As Object, e As EventArgs) Handles ToolStripButtonLogin.Click
            LoginToolStripMenuItem_Click(Me, Nothing)
        End Sub

        ''' <summary>
        '''     Redirects logout request to equivalent menu event handler.
        ''' </summary>
        Private Sub ToolStripButtonLogout_Click(sender As Object, e As EventArgs) Handles ToolStripButtonLogout.Click
            LogoutToolStripMenuItem_Click(Me, Nothing)
            SetLanguageChangeButtons()
            SaveMirroredLanguageSetting()
            Refresh()
        End Sub

        Private Sub SaveMirroredLanguageSetting()
            If LogStatus = LoginStatus.LoggedIn Then
                If GlobalVariables.RightToLeftLayout Then
                    If Not My.Settings.MirroredLanguage Then
                        My.Settings.MirroredLanguage = True
                        My.Settings.Save()
                    End If
                Else
                    If My.Settings.MirroredLanguage Then
                        My.Settings.MirroredLanguage = False
                        My.Settings.Save()
                    End If
                End If
            End If
        End Sub

        Private Sub ToolStripButtonLTR_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEnglish.Click
            'If GlobalVariables.RightToLeftLayout Then
            GlobalVariables.RightToLeftLayout = False
            'End If
            SwitchUiLanguage(True)
            SetLanguageChangeButtons()
            'ToolStripButtonArabic.Visible = True
            'ToolStripButtonArabic.Enabled = True
            'ToolStripButtonEnglish.Visible = False
            'ToolStripButtonEnglish.Enabled = False
        End Sub

        Private Sub ToolStripButtonRTL_Click(sender As Object, e As EventArgs) Handles ToolStripButtonArabic.Click
            'If Not GlobalVariables.RightToLeftLayout Then
            GlobalVariables.RightToLeftLayout = True
            'End If
            SwitchUiLanguage(False)
            SetLanguageChangeButtons()
            'ToolStripButtonArabic.Visible = False
            'ToolStripButtonArabic.Enabled = False
            'ToolStripButtonEnglish.Visible = True
            'ToolStripButtonEnglish.Enabled = True
        End Sub

        Private Sub ToolStripMenuItemChangePassword_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemChangePassword.Click
            Using form As New LoginEntry(True)
                Try
                    If form.ShowDialog() = DialogResult.OK Then
                        If form.LoginOk Then
                            LogStatus = LoginStatus.LoggedIn
                        Else
                            Messaging.Show(True, "MsgOldPasswordError")
                            LogStatus = LoginStatus.LoggedOut
                            LogStatus = LoginStatus.LoggedOut
                        End If
                    Else
                        LogStatus = LoginStatus.LoggedOut
                    End If
                    ToolStripButtonExit.Enabled = True
                Catch ex As TypeInitializationException
                    MessageBox.Show("Invalid Connection String, specified connection String doesn't exist.",
                                    "Connection String Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrLogger.LogError(ex, True)
                    LogStatus = LoginStatus.LoggedOut
                Catch ex As Exception
                    LogStatus = LoginStatus.LoggedIn
                End Try
            End Using
        End Sub

        Private Sub ToolStripMenuItemEmployeeLeave_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeLeaveNonHoliday.Click
            RunForm(Of EmployeeLeaveEntry, EmployeeLeavePresenter(Of EmployeeLeaveModel), Boolean)(False)
        End Sub

        Private Sub ToolStripMenuItemHolidayEntry_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemHolidayEntry.Click
            RunForm(Of HolidayEntry, HolidayPresenter(Of HolidayModel))()
        End Sub

        Private Sub ToolStripMenuItemEmployeeAbsenceLate_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeAbsenceLate.Click
            RunForm(Of EmployeeAbsenceEntry, EmployeeAbsencePresenter(Of EmployeeAbsenceModel))()
        End Sub

        Private Sub UnhandledExceptionHandler(sender As Object, e As UnhandledExceptionEventArgs)
            ErrLogger.LogError(CType(e.ExceptionObject, Exception))
        End Sub

        Private Sub ToolStripMenuItemPayrollAttendance_Click(sender As Object, e As EventArgs)

        End Sub

        Private Overloads Sub RunForm(Of TV)()
            Dim formToRun = Activator.CreateInstance(GetType(TV))
            ShowEntryForm(formToRun)
        End Sub

        Private Overloads Sub RunForm(Of TV, TX)(param As TX)
            Dim formToRun = Activator.CreateInstance(GetType(TV), param)
            ShowEntryForm(formToRun)
        End Sub

        Private Overloads Sub RunForm(Of TV, TP)()
            Dim formToRun = Activator.CreateInstance(GetType(TV))
            Dim pType As Type = GetType(TP)
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun})
            Dim form As Form = formToRun
            'form.SuspendLayout()
            'form.SuspendDrawingNew()
            Invoker.InvokeFunction(formToRun, "Show")
            'form.ResumeDrawingNew()
            'form.ResumeLayout()
        End Sub

        Private Overloads Sub RunForm(Of TV, TP, TX)(param As TX)
            Dim formToRun = Activator.CreateInstance(GetType(TV), param)
            Dim pType As Type = GetType(TP)
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun, param})
            ShowEntryForm(formToRun)
        End Sub

        Private Overloads Sub RunForm(Of TV, TP, TX, TY)(param1 As TX, param2 As TY)
            Dim formToRun = Activator.CreateInstance(GetType(TV), param1, param2)
            Dim pType As Type = GetType(TP)
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun})
            ShowEntryForm(formToRun)
        End Sub

        Private Overloads Sub RunReportNew(Of TV)()
            Dim formToRun = Activator.CreateInstance(GetType(TV))
            formToRun.Presenter = New PrintReportPresenter(Of ReportModel)(formToRun)
            Invoker.InvokeFunction(formToRun, "Show")
        End Sub



        Private Overloads Sub RunBaseForm(Of TV, TP)(tableName As String, formName As String)
            Dim formToRun = Activator.CreateInstance(GetType(TV), tableName, formName)
            Dim pType As Type = GetType(TP)
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun, tableName})
            ShowEntryForm(formToRun)
        End Sub

        Private Overloads Sub RunReport(Of TV)()
            Dim formToRun = Activator.CreateInstance(GetType(TV))
            Dim pType As Type = GetType(PrintReportPresenter(Of ReportModel))
            formToRun.Presenter = Activator.CreateInstance(pType, {formToRun})
            Invoker.InvokeFunction(formToRun, "Show")
        End Sub

        Private Sub UpdateMenuSecurityObjectsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemUpdateMenuSecurityObjects.Click
            Dim allControls As New List(Of Control)
            If UserIsASuperAdmin() Then
                For Each cCtrl As Control In FindControlRecursive(allControls, Me)
                    UpdateMenuSecurity(cCtrl)
                Next
            End If
        End Sub

        Public Sub UpdateMenuSecurity(ByRef cCtrl As Control)
            Static sw = 0
            Static mainParentIdNo As Int32
            If sw = 0 Then
                mainParentIdNo = Presenter.GetRecordFieldWithKey(MenuFormName, "SecurityObject", "SecurityObjectName", "IdNo")
                sw = 1
            End If
            If TypeOf cCtrl Is MenuStrip Then
                ' check for MenuStrip first because MenuStrip is also a ToolStrip
                Dim subMenuName = MenuFormName + " > " + cCtrl.Name.Trim()
                Dim menuStripMain As MenuStrip = cCtrl
                Dim securityObject As New SecurityObject With {.SecurityObjectName = cCtrl.Name.Trim(),
                        .SystemViewIdNo = VSystemViewIdNo,
                        .ParentIdNo = mainParentIdNo}
                Dim parentIdNo As Int32
                parentIdNo = Presenter.UpdateSecurityObject(securityObject)
                UpdateChildMenuSecurityObjects(menuStripMain.Items, subMenuName, parentIdNo)
            ElseIf TypeOf cCtrl Is ToolStrip Then
                Dim subMenuName = MenuFormName + " > " + cCtrl.Name.TrimEnd()
                Dim toolStripMain As ToolStrip = cCtrl
                Dim securityObject As New SecurityObject With {.SecurityObjectName = cCtrl.Name.TrimEnd(),
                        .SystemViewIdNo = VSystemViewIdNo,
                        .ParentIdNo = mainParentIdNo}
                Dim parentIdNo As Int32
                parentIdNo = Presenter.UpdateSecurityObject(securityObject)
                UpdateChildMenuSecurityObjects(toolStripMain.Items, subMenuName, parentIdNo)
            End If
        End Sub

        Private Sub UpdateChildMenuSecurityObjects(dropDownItems As ToolStripItemCollection, pParentMenuName As String, pParentIdNo As Int32)
            Dim parentIdNo As Int32
            For Each dropDownItem As Object In dropDownItems
                If TypeOf dropDownItem Is ToolStripMenuItem Then
                    Dim parentMenuName = pParentMenuName
                    If dropDownItem.Name.SubString(0, 17) <> "ToolStripMenuItem" Then
                        Debugger.Break()
                        MessageBox.Show($"Invalid ToolStripMenuItem Name <" + dropDownItem.Name.SubString(0, 17) + ">!")
                    End If
                    parentIdNo = UpdateSecurityObject(Of ToolStripMenuItem)(dropDownItem, parentMenuName, pParentIdNo, 17)
                    If dropDownItem.HasDropDown Then
                        UpdateChildMenuSecurityObjects(dropDownItem.DropDownItems, pParentMenuName, parentIdNo)
                    End If
                ElseIf TypeOf dropDownItem Is ToolStripButton Then
                    If dropDownItem.Name.Length > 15 AndAlso dropDownItem.Name.SubString(0, 15) <> "ToolStripButton" Then
                        Debugger.Break()
                        MessageBox.Show($"Invalid ToolStripButton Name <" + dropDownItem.Name.SubString(0, 15) + ">!")
                    End If
                    UpdateSecurityObject(Of ToolStripButton)(dropDownItem, pParentMenuName, pParentIdNo, 15)
                End If
            Next
        End Sub

        Private Function UpdateSecurityObject(Of T)(ByRef obj As T, ByRef subMenuName As String, ByVal parentIdNo As Int32, loc As Int16) As Int32
            Dim toolStripMenuItem As T = obj
            Dim objName = Invoker.GetProperty(obj, "Name")
            Dim securityObject As New SecurityObject With {.SecurityObjectName = objName.SubString(loc),
                    .SystemViewIdNo = VSystemViewIdNo,
                    .ParentIdNo = parentIdNo}
            parentIdNo = Presenter.UpdateSecurityObject(securityObject)
            Return parentIdNo
        End Function

        Private Sub ToolStripMenuItemEmployeeIDPrinting_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeIDPrinting.Click
            RunForm(Of EmployeeIdPrinting, EmployeeIdPrintingPresenter(Of EmployeeIdModel))()
        End Sub

        Private Sub ToolStripMenuItemEmployeeLeaveApproval_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeLeaveApproval.Click
            RunForm(Of EmployeeLeaveApprovalEntry, EmployeeLeaveApprovalPresenter(Of EmployeeLeaveApprovalModel))()
        End Sub

        Private Sub EmployeeHolidayTransferToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeHolidayTransfer.Click
            RunForm(Of HolidayTransferEntry, HolidayTransferPresenter(Of HolidayTransferModel))()
        End Sub

        Private Sub ToolStripMenuItemHolidayTransferAvailment_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeLeaveHoliday.Click
            RunForm(Of EmployeeLeaveEntry, EmployeeLeavePresenter(Of EmployeeLeaveModel), Boolean)(True)
        End Sub

        Private Sub ShiftDailySummaryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemShiftDailySummary.Click
            RunReportNew(Of ShiftDailyReport)()
            'RunForm(Of ShiftDailyReport)()
        End Sub

        Private Sub SimplePasswordGeneratorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSimplePasswordGenerator.Click
            PasswordGenerator.Show()
        End Sub

        'Private Sub LaboratoryReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLaboratoryReports.Click
        '    RunForm(Of ReportSelectorForm, ReportSelectorPresenter(Of ReportSelectorModel), String)($"IGLAB")
        'End Sub

        Private Sub SalesReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemOtherReports.Click
            RunForm(Of ReportSelectorForm, ReportSelectorPresenter(Of ReportSelectorModel), String)($"IGSALES")
        End Sub

        Private Sub DrugListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPharmacyItem.Click
            RunForm(Of ItemDetailsEntry, ItemDetailsPresenter(Of ItemDetailsModel))()
        End Sub

        Private Sub ToolStripMenuItemEmployeeMedicalReport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeMedicalReport.Click
            RunForm(Of EmployeeMedicalReport)()
        End Sub

        Private Sub ToolStripMenuItemCbcResultRetrieval_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCbcResultRetrieval.Click
            RunForm(Of CbcRetrievalEntry, Lab_InvoiceGroupPresenter(Of Lab_InvoiceGroupModel), Boolean)(True)
        End Sub

        Private Sub ToolStripMenuItemCbcResultRetrievalSampleId_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCbcResultRetrievalSampleId.Click
            RunForm(Of CbcRetrievalEntry, Lab_InvoiceGroupPresenter(Of Lab_InvoiceGroupModel), Boolean)(False)
        End Sub

        Private Sub ToolStripMenuItemDocuments_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDocuments.Click
            RunForm(Of DocumentEntryTv, DocumentPresenter(Of DocumentModel))()
        End Sub

        Private Sub TestFormToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTestForm.Click
            Dim form As New TestForm3
            form.Show()
            'Dim formToRun = Activator.CreateInstance(GetType(TestForm))
            'formToRun.Presenter = New DepartmentPresenter(Of DepartmentModel)(formToRun)
            'formToRun.Show()
        End Sub

        'Private Sub ToolStripMenuItemPMRReports_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPMRReports.Click
        '    RunForm(Of PmrInvestigationRequestForm, PmrInvestigationRequestPresenter(Of PmrInvestigationRequestModel))()
        'End Sub

        Private Sub ToolStripMenuItemCodeGroup_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCodeGroup.Click
            RunForm(Of CodeGroupEntryTv, CodeGroupPresenter(Of CodeGroupModel))()
        End Sub

        Private Sub ToolStripMenuItemItemCode_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemItemCode.Click
            RunForm(Of ItemCodeEntryTv, ItemCodePresenter(Of ItemCodeModel))()
        End Sub

        Private Sub ToolStripMenuItemDoctor_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDoctor.Click
            RunForm(Of DoctorEntryTv, DoctorPresenter(Of DoctorModel))()
        End Sub

        'Private Sub PrintReport(reportFileName As String, databaseConnectionName As String, Optional args() As Object = Nothing)
        '    'Dim prPresenter As New PrintReportPresenter()
        '    'prPresenter.PrintReport(reportFileName, databaseConnectionName, args)
        '    RunReport(Of SterilizationLabelPrinter)()
        'End Sub

        Private Sub ToolStripMenuItemStockInventory_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStockInventory.Click
            RunForm(Of StockInventoryEntry, StockInventoryPresenter(Of StockInventoryModel))()
        End Sub

        Private Sub ToolStripMenuItemDrugSale_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDrugSale.Click, ToolStripButtonDrugSale.Click
            RunForm(Of DrugSaleEntry, DrugSalePresenter(Of DrugSaleModel))()
        End Sub

        Private Sub ToolStripMenuItemDrugAcceptance_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDrugAcceptance.Click
            RunForm(Of DrugAcceptEntry, DrugAcceptPresenter(Of DrugAcceptModel))()
        End Sub

        Private Sub ToolStripMenuItemPharmacyBarcodePrinting_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPharmacyBarcodePrinting.Click
            Dim args As Object() = {Environment.MachineName, "Workstation"}
            'PrintReport("BarcodePharmacy.Rpt", $"IGROUPCLINIC", args)
        End Sub

        Private Sub ToolStripMenuItemGenerateDailyDrugTransferFile_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemGenerateDailyDrugTransferFile.Click
            RunForm(Of GenerateDrugCsv, String)("DrugSale")
        End Sub

        Private Sub ToolStripMenuItemGenerateDrugAcceptanceFile_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemGenerateDrugAcceptanceFile.Click
            RunForm(Of GenerateDrugCsv, String)("DrugAccept")
        End Sub

        Private Sub ToolStripMenuItemItemMatcher_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemItemMatcher.Click
            RunForm(Of GTinMatcherEntry, GTinMatcherPresenter(Of GTinMatcherModel))()
        End Sub

        Private Sub ToolStripMenuItemIqamaCBCResult_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemIqamaCBCResultByInvoiceNo.Click
            RunForm(Of IqamaCbcReport, String)("InvoiceNo")
        End Sub

        Private Sub ToolStripMenuItemDiagnosticTestSummary_Click(sender As Object, e As EventArgs)
            RunReportNew(Of DiagnosticTestSummary)()
        End Sub

        Private Sub ToolStripMenuItemIqamaCBCResultBySampleNo_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemIqamaCBCResultBySampleNo.Click
            RunForm(Of IqamaCbcReport, String)("SampleNo")
        End Sub

        Private Sub DosageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDosagePrinting.Click, ToolStripButtonDoseLabel.Click
            RunForm(Of DosagePrintingForm, DosagePrintingPresenter(Of DosagePrintingModel))()
        End Sub

        Private Sub ToolStripMenuItemDosage_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDosage.Click
            RunForm(Of DosageEntryTv, DosagePresenter(Of DosageModel))()
        End Sub

        Private Sub ToolStripMenuItemProduct_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemProduct.Click
            RunForm(Of ProductEntry, ProductPresenter(Of ProductModel))()
        End Sub

        Private Sub ToolStripMenuItemCategory_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCategory.Click
            RunForm(Of CategoryEntryTv, CategoryPresenter(Of CategoryModel))()
        End Sub

        Private Sub ToolStripMenuItemPrinters_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPrinters.Click
            RunForm(Of PrinterEntryTv, PrinterPresenter(Of PrinterModel))()
        End Sub

        Private Sub ToolStripMenuItemPrintJob_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPrintJobs.Click
            RunForm(Of PrintJobEntryTv, PrintJobPresenter(Of PrintJobModel))()
        End Sub

        Private Sub ToolStripMenuItemPrintSetups_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPrintSetups.Click
            RunForm(Of PrintSetupEntry, PrintSetupPresenter(Of PrintSetupModel))()
        End Sub

        Private Sub ToolStripMenuItemUnit_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemUnit.Click
            RunBasicForm("Unit", "Product Units Entry")
        End Sub

        Private Sub ToolStripMenuItemWarehouse_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemWarehouse.Click
            RunBasicForm("Warehouse", "Warehouse Entry")
        End Sub

        Private Sub BanksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBanks.Click
            RunBasicForm("Bank", "Bank Entry")
        End Sub

        Private Sub PhoneTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPhoneTypes.Click
            RunBasicForm("PhoneType", "Phone Type Entry")
        End Sub

        Private Sub ToolStripMenuItemPurchase_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPurchase.Click
            Dim formToRun = New PurchaseEntry(False, False)
            formToRun.Presenter = New PurchasePresenter(Of PurchaseModel)(formToRun, {False, False})
            formToRun.Show()
        End Sub

        Private Sub ToolStripMenuItemSalesEntry_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSalesEntry.Click
            RunForm(Of SaleEntry, SalePresenter(Of SaleModel))()
        End Sub

        Private Sub ToolStripMenuItemSterilizationLabels_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSterilizationLabels.Click
            RunReportNew(Of SterilizationLabelPrinter)()
        End Sub

        Private Sub ToolStripMenuItemReportMaster_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemReportMaster.Click
            RunForm(Of ReportEntry, ReportPresenter(Of ReportModel))()
        End Sub

        Private Sub ToolStripMenuItemDoctorsPrescriptions_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDoctorsPrescriptions.Click
            RunForm(Of DoctorsPrescriptionForm, DoctorsPrescriptionPresenter(Of DoctorsPrescriptionModel))()
        End Sub

        Private Sub ToolStripMenuItemPrescription_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPrescription.Click, ToolStripButtonPrescription.Click
            RunForm(Of PrescriptionForm, PrescriptionPresenter(Of PrescriptionModel))()
        End Sub

        Private Sub ToolStripMenuItemOldDosageTranslation_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemOldDosageTranslation.Click
            RunForm(Of DosageTableManager, DosageMasterListPresenter(Of DosageMasterModel))()
        End Sub

        Private Sub ToolStripMenuItemDurationTranslation_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDurationTranslation.Click
            RunForm(Of DurationTableManager, DurationListPresenter(Of DurationModel))()
        End Sub

        Private Sub ToolStripMenuItemInventoryTransactionType_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemInventoryTransactionType.Click
            RunForm(Of InvTransTypeEntryTv, InvTransTypePresenter(Of InvTransTypeModel))()
        End Sub

        Private Sub InventoryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemInventoryTransactions.Click
            RunForm(Of InvTransactionEntry, InvTransactionPresenter(Of InvTransactionModel))()
        End Sub

        Private Sub ToolStripMenuItemInventoryReport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemInventoryReport.Click
            RunReportNew(Of InventoryReportByWarehouse)()
        End Sub

        Private Sub ToolStripMenuItemProductExpiryReport_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemProductExpiryReport.Click
            RunReportNew(Of ExpiryReportByWarehouse)()
        End Sub

        Private Sub ToolStripMenuItemApplicationSetting_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemApplicationSetting.Click
            RunForm(Of AppSettingEntry, AppSettingPresenter(Of AppSettingModel))()
        End Sub

        Private Sub ToolStripMenuItemBSCustom_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSCustom.Click
            RunForm(Of FinancialReport, FinancialReportPresenter(Of AccountModel), String, String)("BalanceSheet", "C")
        End Sub

        Private Sub ToolStripMenuItemDocDetail_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDocManagement.Click
            RunForm(Of DocumentDetailEntry, DocumentDetailPresenter(Of DocumentDetailModel))()
        End Sub

        Private Sub ToolStripMenuItemPurchaseOrder_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPurchaseOrder.Click
            Dim formToRun = New PurchaseEntry(True, False)
            formToRun.Presenter = New PurchasePresenter(Of PurchaseModel)(formToRun, {True, False})
            formToRun.Show()
            'RunForm(Of PurchaseOrderEntry, PurchaseOrderPresenter(Of PurchaseOrderModel))()
        End Sub

        Private Sub ToolStripMenuItemRequestApproval_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRequestApproval.Click
            RunForm(Of InvRequestForm, InvRequestPresenter(Of InvTransactionModel))()
        End Sub

        Private Sub ToolStripMenuItemProductMovement_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemProductMovement.Click
            RunReportNew(Of ProductMovementReport)()
        End Sub

        Private Sub ToolStripMenuItemPurchaseReturn_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPurchaseReturn.Click
            Dim formToRun = New PurchaseEntry(False, True)
            formToRun.Presenter = New PurchasePresenter(Of PurchaseModel)(formToRun, {False, True})
            formToRun.Show()
        End Sub

        Private Sub ListToolStripMenuItemDocumentExpiry_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDocumentExpiryList.Click
            RunReportNew(Of DocumentExpiryList)()
        End Sub

        Private Sub ToolStripMenuItemDocumentReportList_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDocumentReportList.Click
            RunReportNew(Of DocumentReportList)()
        End Sub

        Private Sub ToolStripMenuItemPeriodicPayroll_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPeriodicPayroll.Click
            RunReportNew(Of PayrollPrinting)()
        End Sub

        Private Sub ToolStripMenuItemPurchaseOrderApproval_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPurchaseOrderApproval.Click
            RunForm(Of PurchaseOrderApprovalForm, PurchaseOrderApprovalPresenter(Of PurchaseModel))()
        End Sub

        Private Sub DiagnosticSamplesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDiagnosticSamples.Click
            RunForm(Of IbLabSampleForm, IbLabSamplePresenter(Of IbLabSampleModel), String)("IGroupClinic")
        End Sub

        Private Sub ToolStripMenuItemClinicTestSummary_Click(sender As Object, e As EventArgs)
            RunReportNew(Of ClinicTestSummary)()
        End Sub

        Private Sub ToolStripMenuItemClinicSamples_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemClinicSamples.Click
            RunForm(Of ClinicLabSampleForm, ClinicLabSamplePresenter(Of ClinicLabSampleModel))()
        End Sub

        Private Sub ToolStripMenuItemOtherLab_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemOtherLab.Click
            RunForm(Of ReportSelectorForm, ReportSelectorPresenter(Of ReportSelectorModel), String)($"IGLAB")
        End Sub

        Private Sub ToolStripMenuItemEmployeeLeaveEarned_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeLeaveEarned.Click
            RunForm(Of EmployeeLeaveEarnedEntry, EmployeeLeaveEarnedPresenter(Of EmployeeLeaveEarnedModel))()
        End Sub

        Private Sub ToolStripMenuItemEmployeeLeavesEarnedApproval_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeLeavesEarnedApproval.Click
            RunForm(Of EmployeeLeaveEarnedApprovalEntry, EmployeeLeaveEarnedApprovalPresenter(Of EmployeeLeaveEarnedApprovalModel))()
        End Sub

        Private Sub ToolStripMenuItemDrInvestigationsPrescriptions_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDrInvestigationsPrescriptions.Click
            RunForm(Of PmrInvestigationRequestForm, PmrInvestigationRequestPresenter(Of PmrInvestigationRequestModel))()
            'RunForm(Of DoctorsPrescriptionForm, PMRInvestigationPresenter(Of PmrInvestigationModel))()
        End Sub

        Private Sub ToolStripMenuItemSupplierProductLink_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSupplierProductLink.Click
            RunForm(Of SupplierProductEntry, SupplierProductPresenter(Of SupplierProductModel))()
        End Sub

        Private Sub ToolStripMenuItemReportGroup_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemReportGroup.Click
            RunForm(Of ReportGroupEntry, ReportGroupPresenter(Of ReportGroupModel))()
        End Sub

        Private Sub IqamaResultEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemIqamaResultEntryIGroup.Click
            RunForm(Of IbLabResultForm, IbLabResultPresenter(Of IbLabResultModel), Object)({"IGroupClinic", "Iqama"})
        End Sub

        Private Sub BaladiyaResultEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBaladiyaResultEntryIGroup.Click
            RunForm(Of IbLabResultForm, IbLabResultPresenter(Of IbLabResultModel), Object)({"IGroupClinic", "Baladiya"})
        End Sub

        Private Sub DiagnosticResultEntryKizenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemIqamaResultEntryKizen.Click
            RunForm(Of IbLabResultForm, IbLabResultPresenter(Of IbLabResultModel), Object)({"Kizen", "Iqama"})
        End Sub

        Private Sub DiagnosticSamplesKizenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDiagnosticSamplesKizen.Click
            RunForm(Of IbLabSampleForm, IbLabSamplePresenter(Of IbLabSampleModel), String)("Kizen")
        End Sub

        Private Sub ToolStripMenuItemBaladiyaResultEntryKizen_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBaladiyaResultEntryKizen.Click
            RunForm(Of IbLabResultForm, IbLabResultPresenter(Of IbLabResultModel), Object)({"Kizen", "Baladiya"})
        End Sub

        Private Sub ToolStripMenuItemReports_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemReports.Click

        End Sub

        Private Sub ToolStripMenuItemInvoiceNoteEditor_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemInvoiceNoteEditor.Click
            RunForm(Of InvMedNotesForm, InvMedNotesPresenter(Of InvMedNotesModel))()
        End Sub

        Private Sub ToolStripMenuItemLabReportStatus_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLabReportStatus.Click
            RunForm(Of LabReportStatusForm, LabReportStatusPresenter(Of LabReportStatusModel))()
        End Sub
    End Class

End Namespace



'    Module Program

'        Public IdleTimer As New System.Windows.Forms.Timer()
'        Const MinuteMicroseconds As Integer = 60000
'        Dim f As Form1 = Nothing

'        <STAThread>
'        Private Sub Main()
'            Application.EnableVisualStyles()
'            Application.SetCompatibleTextRenderingDefault(False)
'            Dim limf As LeaveIdleMessageFilter = New LeaveIdleMessageFilter()
'            Application.AddMessageFilter(limf)
'            AddHandler Application.Idle, New EventHandler(AddressOf Application_Idle)
'            IdleTimer.Interval = MinuteMicroseconds
'            AddHandler IdleTimer.Tick, AddressOf TimeDone

'            IdleTimer.Start()
'            f = New Form1()
'            Application.Run(f)
'            RemoveHandler Application.Idle, New EventHandler(AddressOf Application_Idle)
'        End Sub

'        Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
'            If Not IdleTimer.Enabled Then IdleTimer.Start()
'        End Sub

'        Private Sub TimeDone(ByVal sender As Object, ByVal e As EventArgs)
'            IdleTimer.[Stop]()
'            MessageBox.Show("Auto logoff")
'            f.Close()
'        End Sub
'    End Module

'    <SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)>
'    Public Class LeaveIdleMessageFilter
'        Implements System.Windows.Forms.IMessageFilter

'        Const WM_NCLBUTTONDOWN As Integer = &HA1
'        Const WM_NCLBUTTONUP As Integer = &HA2
'        Const WM_NCRBUTTONDOWN As Integer = &HA4
'        Const WM_NCRBUTTONUP As Integer = &HA5
'        Const WM_NCMBUTTONDOWN As Integer = &HA7
'        Const WM_NCMBUTTONUP As Integer = &HA8
'        Const WM_NCXBUTTONDOWN As Integer = &HAB
'        Const WM_NCXBUTTONUP As Integer = &HAC
'        Const WM_KEYDOWN As Integer = &H100
'        Const WM_KEYUP As Integer = &H101
'        Const WM_MOUSEMOVE As Integer = &H200
'        Const WM_LBUTTONDOWN As Integer = &H201
'        Const WM_LBUTTONUP As Integer = &H202
'        Const WM_RBUTTONDOWN As Integer = &H204
'        Const WM_RBUTTONUP As Integer = &H205
'        Const WM_MBUTTONDOWN As Integer = &H207
'        Const WM_MBUTTONUP As Integer = &H208
'        Const WM_XBUTTONDOWN As Integer = &H20B
'        Const WM_XBUTTONUP As Integer = &H20C
'        Shared Messages As Integer() = New Integer() {WM_NCLBUTTONDOWN, WM_NCLBUTTONUP, WM_NCRBUTTONDOWN, WM_NCRBUTTONUP, WM_NCMBUTTONDOWN, WM_NCMBUTTONUP, WM_NCXBUTTONDOWN, WM_NCXBUTTONUP, WM_KEYDOWN, WM_KEYUP, WM_LBUTTONDOWN, WM_LBUTTONUP, WM_RBUTTONDOWN, WM_RBUTTONUP, WM_MBUTTONDOWN, WM_MBUTTONUP, WM_XBUTTONDOWN, WM_XBUTTONUP}

'        Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
'            If m.Msg = WM_MOUSEMOVE Then Return False
'            If Not IdleTimer.Enabled Then Return False
'            If Array.BinarySearch(Messages, m.Msg) >= 0 Then Program.IdleTimer.[Stop]()
'            Return False
'        End Function

'    End Class

'End Namespace

