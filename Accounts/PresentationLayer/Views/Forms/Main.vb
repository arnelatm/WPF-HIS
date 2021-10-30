Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.BusinessLayer.BusinessObjects
Imports AATM.Common
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
Imports AATM.ServicesLayer.Services
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
    Partial Public Class Main
        Implements IUserView

        Public Shared AccountsMapper As IMapper
        Private _logStatus As LoginStatus

        Public Event UserLoggedIn(sender As Object, formControls As List(Of Control))

        'Private ReadOnly _presenterObj

        ''' <summary>
        '''     Default form constructor.
        ''' </summary>
        Public Sub New()

            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledExceptionHandler
            AddHandler Application.ThreadException, AddressOf ThreadExceptionHandler

            Dim mySettings = AppSettings.Load()
            GlobalVariables.TranslationMode = mySettings.TranslationInitializer
            GlobalVariables.PreferredLanguage = mySettings.PreferredLanguage
            _logStatus = LoginStatus.LoggedOut
            InitializeComponent()
            If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
                GlobalFunctions.SetCulture(GlobalVariables.AppCultureInfo.ToString())
                GlobalVariables.AppCultureInfo = CultureInfo.CurrentCulture
                GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture

                'Dim mirroredLanguage = My.Settings.MirroredLanguage
                'If mirroredLanguage Then
                '    GlobalFunctions.SetCulture(GlobalVariables.DefaultMirroredCultureInfoStr)
                '    SetLanguageChangeButtons()
                '    SwitchUiLanguage(False)
                'End If

                'If GlobalVariables.PreferredLanguage = $"English (إنجليزي)" Then
                '    GlobalVariables.RightToLeftLayout = False
                'ElseIf GlobalVariables.PreferredLanguage = $"Arabic (عربي)" Then
                '    GlobalVariables.RightToLeftLayout = True
                'Else
                If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                    GlobalVariables.RightToLeftLayout = True
                Else
                    GlobalVariables.RightToLeftLayout = False
                End If
                'End If
                SetLanguageChangeButtons()
                'Else
                '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                '        GlobalVariables.RightToLeftLayout = True
                '    Else
                '        GlobalVariables.RightToLeftLayout = False
                '    End If
                '    SetLanguageChangeButtons()
            End If
            SetupMapper()
            Presenter = New UserPresenter(Of UserModel)(Me)

            'Dim builder As Autofac.ContainerBuilder = New ContainerBuilder()
            'builder.RegisterType(Of RecurringPayElementPresenter)().[As](Of ISalaryLoanSchedulePresenter)()
            'Dim x = builder.Build()
            '_salaryLoanSchedulePresenter = x.Resolve(Of ISalaryLoanSchedulePresenter)
            'GlobalVariables.EventAggregator = New EventAggregator

        End Sub

        Public Event FormCultureChanged()

        'Enumerates login Menu: Logged In or Logged Out.
        Public Enum LoginStatus
            LoggedIn
            LoggedOut
        End Enum

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
                    If GlobalVariables.UserName.ToLower() = $"arnel" Then
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
        Protected Shared Property Service As New Service

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
            Dim cForm As New ReportFormNew("Aging of Accounts Receivable.Rpt", reportTitle, CultureInfo.CurrentCulture)
            cForm.Show()
        End Sub

        Private Sub AgingOfAccountsPayableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAPAging.Click
            Dim reportTitle = Messaging.TranslateCaption("Aging of Accounts Payable as of ")
            reportTitle = reportTitle + " " + GlobalFuncNSub.GregorianLongDate(Now(), CultureInfo.CurrentCulture)
            Dim cForm As New ReportFormNew("Aging of Accounts Payable.Rpt", reportTitle, CultureInfo.CurrentCulture)
            cForm.Show()
        End Sub

        Private Sub BanksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBanks.Click
            RunForm(Of BankEntryTv, BankPresenter(Of BankModel))()
        End Sub

        Private Sub BankTransferToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim childMdiForm = New DisbursementJournalEntry("CdJournal")
            childMdiForm.Presenter = New DisbursementJournalPresenter(Of DisbursementJournalModel)(childMdiForm, "CdJournal")
            childMdiForm.MdiParent = Me
            childMdiForm.Show()
        End Sub

        Private Sub BranchesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBranches.Click
            RunForm(Of BranchEntryTv, BranchPresenter(Of BranchModel))()
        End Sub

        Private Sub CashDisbursementEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCashDisbursementEntry.Click
            Dim childMdiForm = New DisbursementJournalEntry("CdJournal")
            childMdiForm.Presenter = New DisbursementJournalPresenter(Of DisbursementJournalModel)(childMdiForm, "CdJournal")
            childMdiForm.MdiParent = Me
            childMdiForm.Show()
        End Sub

        Private Sub CashIncomePerDoctorServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCashIncomePerDoctorService.Click
            RunForm(Of CashIncomePerDoctorPerService)()
        End Sub

        Private Sub CashReceiptEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemCashReceiptEntry.Click
            RunForm(Of CashReceiptJournalEntry, CashReceiptJournalPresenter(Of CashReceiptJournalModel))()
        End Sub

        Private Sub CategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCategories.Click
            RunBasicForm("Category", "Categories Maintenance Form")
        End Sub

        Private Sub ChartOfAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemChartOfAccounts.Click
            RunForm(Of AccountEntryTv, AccountPresenter(Of AccountModel))()
        End Sub

        Private Sub CheckPrintingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCheckPrinting.Click
            'RunForm(Of CheckPrinter, DisbursementJournalPresenter(Of DisbursementJournalModel))()
            Dim childMdiForm As CheckPrinter
            childMdiForm = New CheckPrinter() With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub ClosePettyCashFundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemClosePettyCashFund.Click
            RunForm(Of PettyCashClosingEntry, PettyCashClosingPresenter(Of PettyCashClosingModel))()
        End Sub

        Private Sub CountriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCountries.Click
            RunForm(Of CountryEntryTv, CountryPresenter(Of CountryModel))()
        End Sub

        Private Sub CreateAllMessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCreateAllMessages.Click
            Dim x = New OneTimeRun
            'Debugger.Break()
            OneTimeRun.CreateAllMessages()
            'OneTimeRun.CreateEnums()
        End Sub

        Private Sub CustomerClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemCustomerClients.Click
            RunForm(Of CustomerEntryTv, CustomerPresenter(Of CustomerModel))()
        End Sub

        Private Sub CustomRangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISCustomRange.Click
            RunForm(Of IncomeStatement, String)("C")
        End Sub

        Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBCustom.Click
            Dim childMdiForm As TrialBalance
            childMdiForm = New TrialBalance("C") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
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

        Private Sub ItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemItems.Click
            RunForm(Of PurchaseItemEntry, PurchaseItemPresenter(Of PurchaseItemModel))()
        End Sub

        Private Sub LeavesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLeaves.Click
            RunForm(Of LeaveEntryTv, LeavePresenter(Of LeaveModel))()
        End Sub

        Private Sub MessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMessages.Click
            RunForm(Of OriginalMessagesEntryTv, OriginalMessagesPresenter(Of OriginalMessagesModel))()
        End Sub

        Private Sub MonthlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBMonthly.Click
            RunForm(Of TrialBalance, String)("M")
        End Sub

        Private Sub MonthlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSMonthly.Click
            RunForm(Of BalanceSheet, String)("M")
        End Sub

        Private Sub MonthlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISMonthly.Click
            RunForm(Of IncomeStatement, String)("M")
        End Sub

        Private Sub NumberOfCashPatientsPerDoctorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemNumberOfCashPatientsPerDoctor.Click
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

        Private Sub PayrollsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPayrolls.Click
            RunForm(Of PayrollEntryTv, PayrollPresenter(Of PayrollModel))()
        End Sub

        Private Sub PensionProvidersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPensionProviders.Click
            RunForm(Of PensionProviderEntryTv, PensionProviderPresenter(Of PensionProviderModel))()
        End Sub

        Private Sub PensionSchemesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPensionSchemes.Click
            RunForm(Of PensionSchemeEntryTv, PensionSchemePresenter(Of PensionSchemeModel))()
        End Sub

        Private Sub PettyCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPettyCash.Click
            Dim childMdiForm = New DisbursementJournalEntry("PcJournal")
            childMdiForm.Presenter = New DisbursementJournalPresenter(Of DisbursementJournalModel)(childMdiForm, "PcJournal")
            childMdiForm.MdiParent = Me
            childMdiForm.Show()
        End Sub

        Private Sub PhoneTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPhoneTypes.Click
            RunForm(Of PhoneTypeEntryTv, PhoneTypePresenter(Of PhoneTypeModel))()
        End Sub

        Private Sub QuarterlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemTBQuarterly.Click
            RunForm(Of TrialBalance, String)("Q")
        End Sub

        Private Sub QuarterlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISQuarterly.Click
            RunForm(Of IncomeStatement, String)("Q")
        End Sub

        Private Sub QuarterlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSQuarterly.Click
            RunForm(Of BalanceSheet, String)("Q")
        End Sub

        Private Sub ReligionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemReligions.Click
            RunForm(Of ReligionEntryTv, ReligionPresenter(Of ReligionModel))()
        End Sub

        Private Sub RevCostCentersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRevCostCenters.Click
            RunForm(Of RevCostCenterEntryTv, RevCostCenterPresenter(Of RevCostCenterModel))()
        End Sub

        Private Sub RevenueGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRevenueGroups.Click
            RunForm(Of RevenueGroupEntryTv, RevenueGroupPresenter(Of RevenueGroupModel))()
        End Sub

        Private Sub RunBasicForm(ByVal tableOrViewName As String, ByVal formCaption As String)
            'Dim childMdiForm As BasicEntry
            '''Set the Parent Form of the Child window.
            'childMdiForm = New BasicEntry(tableOrViewName, formCaption) With {
            '    .MdiParent = Me
            '    }
            '''Display the new form.
            'childMdiForm.Show()
            RunForm(Of BasicEntry, BasicPresenter(Of BasicModel))()
        End Sub

        '''' <summary>
        ''''     Opens the about dialog window.
        '''' </summary>
        'Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAbout.Click
        '    Dim form = New FormAbout()
        '    form.ShowDialog()
        'End Sub
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
            RunForm(Of TrialBalance, String)("S")
        End Sub

        Private Sub SemestralToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSSemestral.Click
            RunForm(Of BalanceSheet, String)("S")
        End Sub

        Private Sub SemiAnnuallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISSemiAnnually.Click
            RunForm(Of IncomeStatement, String)("S")
        End Sub

        Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSettings.Click
            RunForm(Of SetSettings)()
        End Sub

        Private Sub StatementOfEmployeeLoansToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfEmployeeLoans.Click
            RunForm(Of StatementOfEr)()
        End Sub

        Private Sub SummaryOfAccountsPayableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSummaryOfAccountsPayable.Click
            RunForm(Of ApSummary)()
        End Sub

        Private Sub SupplierVendorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSupplierVendors.Click
            RunForm(Of SupplierEntryTv, SupplierPresenter(Of SupplierModel))()
        End Sub

        Private Sub TestToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBlankReport.Click
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

        Private Sub ToolStripMenuItemStatementOfAccountsPayable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfAccountsPayable.Click
            RunForm(Of StatementOfAp)()
        End Sub

        Private Sub ToolStripMenuItemStatementOfAccountsReceivable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfAccountsReceivable.Click
            RunForm(Of StatementOfAr)()
        End Sub

        Private Sub ToolStripMenuItemStateOfEmployeeLoans_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSummaryOfEmployeeLoans.Click
            RunForm(Of ErSummary)()
        End Sub

        Private Sub ToolStripMenuItemSummaryOfAccountsReceivable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSummaryOfAccountsReceivable.Click
            RunForm(Of ArSummary)()
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
            RunForm(Of TrialBalance, String)("Y")
        End Sub

        Private Sub YearlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBSYearly.Click
            RunForm(Of BalanceSheet, String)("Y")
        End Sub

        Private Sub YearlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemISYearly.Click
            RunForm(Of IncomeStatement, String)("Y")
        End Sub

        Private Sub JournalListingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemJournalTransactionSummary.Click
            RunForm(Of TransactionSummary)()
        End Sub

        Private Sub RecurringPayElementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRecurringPayrollEntry.Click
            RunForm(Of RecurringPayElementEntry, RecurringPayElementPresenter(Of RecurringPayElementModel))()
        End Sub

        Private Sub ToolStripMenuItemAccountActivity_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAccountActivity.Click
            RunForm(Of AccountActivity)()
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

        Private Sub EmployeeLeaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeLeave.Click
            RunForm(Of EmployeeLeaveEntry, EmployeeLeavePresenter(Of EmployeeLeaveModel))()
        End Sub

        Private Sub EmployeeAbsencesLateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemEmployeeAbsencesLate.Click
            RunForm(Of EmployeeAbsenceEntry, EmployeeAbsencePresenter(Of EmployeeAbsenceModel))()
        End Sub

        Private Sub ToolStripMenuItemPostPettyCashAccount_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPostPettyCashAccount.Click
            RunForm(Of PettyCashClosingEntry, PettyCashClosingPresenter(Of PettyCashClosingModel))()
        End Sub

        Private Sub ShiftSummaryEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemShiftSummaryEntry.Click
            RunForm(Of ShiftSummaryEntry, ShiftSummaryPresenter(Of ShiftSummaryModel))()
        End Sub

#End Region

        Protected Sub SwitchUiLanguage(originalUi As Boolean)
            If originalUi Then
                TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
            Else
                TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
            End If
            TranslateForm()
            ToolStripButtonEnglish.Visible = Not originalUi
            ToolStripButtonArabic.Visible = originalUi
        End Sub

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
            parentIdNo = Service.AddSecurityObject(securityObject)
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
            If Service.UsePayGroups() Then
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

        Private Sub PayrollReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPeriodicPayroll.Click

        End Sub

        Private Sub RecreateSecurityObjectMenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRecreateSecurityObjectMenu.Click
            Dim allControls As New List(Of Control)
            Dim nRecCount = Service.GetRecordCount("SecurityObject")
            If GlobalVariables.UserName.ToLower() = $"arnel" Then
                Dim addSecurityObject As Boolean = False
                If nRecCount <= 12 Then
                    If nRecCount = 0 Then
                        If Service.InitializeSecurityObject() > 0 Then
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
                'CallByName(formEntry, "MdiParent", CallType.Set, Me)
                'CallByName(formEntry, "Show", CallType.Method)
                Invoker.SetProperty(formEntry, "MdiParent", {Me})
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

        Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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
            If Not GlobalVariables.RightToLeftLayout Then
                GlobalVariables.RightToLeftLayout = False
            End If
            SwitchUiLanguage(True)
            'TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
            'GetNSaveCaptions()
            'ToolStripButtonArabic.Visible = True
            'ToolStripButtonEnglish.Visible = False

            'TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
            'If GlobalFunctions.IsCultureOk(TextDisplayLanguage) Then
            '    CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage)
            'Else
            '    TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            'End If
            'ToolStripButtonArabic.Visible = True
            'ToolStripButtonEnglish.Visible = False
            'GlobalVariables.RightToLeftLayout = False
            'If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
            '    CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
            'End If
            'CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
            'If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            '    'GlobalVariables.RightToLeftLayout = True
            '    RightToLeftLayout = True
            '    RightToLeft = RightToLeft.Yes
            'Else
            '    'GlobalVariables.RightToLeftLayout = False
            '    RightToLeftLayout = False
            '    RightToLeft = RightToLeft.No
            'End If
            'TextDisplayLanguage = CultureInfo.CurrentCulture.ToString()
            'GlobalVariables.AppCurrentCultureInfo = New CultureInfo(TextDisplayLanguage)
            ''If GlobalFunctions.NeedToTranslateText(TextDisplayLanguage) Then
            'TranslateForm()
            ''End If
            ''Refresh()
        End Sub

        Private Sub ToolStripButtonRTL_Click(sender As Object, e As EventArgs) Handles ToolStripButtonArabic.Click
            If Not GlobalVariables.RightToLeftLayout Then
                GlobalVariables.RightToLeftLayout = True
            End If
            SwitchUiLanguage(False)
            'TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
            'GetNSaveCaptions()
            'ToolStripButtonArabic.Visible = False
            'ToolStripButtonEnglish.Visible = True
            'TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
            'If GlobalFunctions.IsCultureOk(TextDisplayLanguage) Then
            '    CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage)
            'Else
            '    TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            'End If
            'ToolStripButtonArabic.Visible = False
            'ToolStripButtonEnglish.Visible = True
            'GlobalVariables.RightToLeftLayout = True
            'If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
            '    CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
            'End If
            'CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
            'If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
            '    RightToLeftLayout = True
            '    RightToLeft = RightToLeft.Yes
            'Else
            '    RightToLeftLayout = False
            '    RightToLeft = RightToLeft.No
            'End If
            'TextDisplayLanguage = CultureInfo.CurrentCulture.ToString()
            'GlobalVariables.AppCurrentCultureInfo = New CultureInfo(TextDisplayLanguage)
            'TranslateForm()
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
                    'If LogStatus = LoginStatus.LoggedIn Then
                    '    Dim mirroredLanguage = My.Settings.MirroredLanguage
                    '    If mirroredLanguage Then
                    '        GlobalFunctions.SetCulture(GlobalVariables.DefaultMirroredCultureInfoStr)
                    '        SetLanguageChangeButtons()
                    '        SwitchUiLanguage(False)
                    '    End If
                    'End If
                Catch ex As TypeInitializationException
                    MessageBox.Show("Invalid Connection String, specified connection String doesn't exist.",
                                    "Connection String Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrLogger.LogError(ex, True)
                    LogStatus = LoginStatus.LoggedOut
                Catch ex As Exception
                    LogStatus = LoginStatus.LoggedIn
                End Try
            End Using
            'Using form As New LoginEntry(True)
            '    Try
            '        If form.ShowDialog() = DialogResult.OK Then
            '            If form.LoginOk Then
            '                LogStatus = LoginStatus.LoggedIn
            '            Else
            '                Messaging.Show(True, "MsgOldPasswordError")
            '                LogStatus = LoginStatus.LoggedOut
            '            End If
            '        Else
            '            LogStatus = LoginStatus.LoggedOut
            '        End If
            '        ToolStripButtonExit.Enabled = True
            '    Catch ex As TypeInitializationException
            '        MessageBox.Show("Invalid Connection String, specified connection string doesn't exist.",
            '                        "Connection String Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        ErrLogger.LogError(ex, True)
            '    Catch ex As Exception
            '        LogStatus = LoginStatus.LoggedIn
            '    End Try
            'End Using
        End Sub

        Private Sub UnhandledExceptionHandler(sender As Object, e As UnhandledExceptionEventArgs)
            ErrLogger.LogError(CType(e.ExceptionObject, Exception))
        End Sub

        Private Sub ToolStripMenuItemPayrollAttendance_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemPayrollAttendance.Click

        End Sub

        Private Overloads Sub RunForm(Of TV)()
            Dim childMdiForm = Activator.CreateInstance(GetType(TV))
            childMdiForm.MdiParent = Me
            childMdiForm.Show()
        End Sub

        Private Overloads Sub RunForm(Of TV, TX)(param As TX)
            Dim childMdiForm = Activator.CreateInstance(GetType(TV), param)
            childMdiForm.MdiParent = Me
            childMdiForm.Show()
        End Sub

        Private Overloads Sub RunForm(Of TV, TP)()
            Dim childMdiForm = Activator.CreateInstance(GetType(TV))
            Dim pType As Type = GetType(TP)
            childMdiForm.Presenter = Activator.CreateInstance(pType, {childMdiForm})
            childMdiForm.MdiParent = Me
            childMdiForm.Show()
        End Sub

        Private Overloads Sub RunForm(Of TV, TP, TX)(param As TX)
            Dim childMdiForm = Activator.CreateInstance(GetType(TV), param)
            Dim pType As Type = GetType(TP)
            childMdiForm.Presenter = Activator.CreateInstance(pType, {childMdiForm, param})
            childMdiForm.MdiParent = Me
            childMdiForm.Show()
        End Sub

        Private Sub HolidayEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HolidayEntryToolStripMenuItem.Click
            RunForm(Of HolidayEntry, HolidayPresenter(Of HolidayModel))()
        End Sub

    End Class

End Namespace