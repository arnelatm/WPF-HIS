Imports System.ComponentModel
Imports System.Globalization
Imports System.Threading
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Presenters
Imports AATM.Accounts.PresentationLayer.Views.Forms.Reports
Imports AATM.Common
Imports AATM.Common.PresentationLayer.Views
Imports AATM.Common.PresentationLayer.Views.Forms
Imports AATM.Common.PresentationLayer.Views.Interface
Imports AATM.Libraries
Imports AATM.Libraries.ErrorsAndEvents
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.Libraries.MessagingLibrary
Imports AATM.PresentationLayer.Forms
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

        'Private _formCurrentCulture As CultureInfo
        Private _logStatus As LoginStatus

        Public Shared AccountsMapper As IMapper
        Public Property MainTableName As String
        Protected Shared Property Service As New Service

        'Public Shared DefaultLanguage As String = "English"
        ''' <summary>
        '''     Default form constructor.
        ''' </summary>
        Public Sub New()

            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledExceptionHandler
            AddHandler Application.ThreadException, AddressOf ThreadExceptionHandler
            _logStatus = LoginStatus.LoggedOut
            InitializeComponent()
            If Not (LicenseManager.UsageMode = LicenseUsageMode.Designtime) Then
                MenuFormName = "Main"
                GlobalFunctions.SetCulture(GlobalVariables.AppCultureInfo.ToString())
                GlobalVariables.AppCultureInfo = CultureInfo.CurrentCulture
                GlobalVariables.AppCurrentCultureInfo = CultureInfo.CurrentCulture

                If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                    GlobalVariables.RightToLeftLayout = True
                Else
                    GlobalVariables.RightToLeftLayout = False
                End If
                SetLanguageChangeButtons()
            End If
            MainTableName = "User"
            PresenterObj = New MainPresenter(Me)
            SetupMapper()
            GlobalVariables.EventAggregator = New EventAggregator
            'CreateEnums()
            '' Disable logout
            'Me.toolStripButtonLogout.Enabled = False
            'Me.logoutToolStripMenuItem.Enabled = False

            ' Create two Presenters. Note: the form is the itemView.
            '_membersPresenter = New MembersPresenter(Me)
            '_ordersPresenter = New OrdersPresenter(Me)
        End Sub

        Public Sub SetupMapper()
            Dim mapperConfigurationAccounts = New MapperConfiguration(Sub(cfg)
                                                                          cfg.AddProfile(New MappingProfileAccounts)
                                                                          cfg.AddProfile(New MappingProfileCommon)
                                                                      End Sub)
            GlobalVariables.Mapper = mapperConfigurationAccounts.CreateMapper()
            'mapperConfigurationAccounts.AssertConfigurationIsValid()
        End Sub

        Public Event FormCultureChanged()

        'Enumerates login Menu: Logged In or Logged Out.
        Public Enum LoginStatus
            LoggedIn
            LoggedOut
        End Enum

        Public Property LogStatus As LoginStatus
            Get
                Return _logStatus
            End Get
            Set
                _logStatus = Value
                Dim allControls As New List(Of Control)
                For Each cCtrl As Control In FindControlRecursive(allControls, Me)
                    SetControlSecurity(cCtrl)
                Next

                If Value = LoginStatus.LoggedIn Then
                    DisableLogin()
                Else
                    EnableLogin()
                End If
            End Set
        End Property

        'Protected Property FormCultureInfo As CultureInfo

        'Protected Property FormCurrentCulture As CultureInfo
        '    Get
        '        Return _formCurrentCulture
        '    End Get
        '    Set(value As CultureInfo)
        '        _formCurrentCulture = value
        '        If value.TextInfo.IsRightToLeft Then
        '            RightToLeftLayout = True
        '            RightToLeft = RightToLeft.Yes
        '        Else
        '            RightToLeftLayout = False
        '            RightToLeft = RightToLeft.No
        '        End If
        '        RaiseEvent FormCultureChanged()
        '    End Set
        'End Property

        ''' <summary>
        '''     Opens the about dialog window.
        ''' </summary>
        Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAbout.Click
            Dim form = New FormAbout()
            form.ShowDialog()
        End Sub

        Private Sub EnableLogin()
            ToolStripButtonLogin.Enabled = True
            ToolStripButtonLogout.Enabled = False
            ToolStripMenuItemLogin.Enabled = True
            ToolStripMenuItemLogout.Enabled = False
            ToolStripMenuItemExit.Enabled = True
            SetLanguageChangeButtons()
        End Sub

        ''' <summary>
        '''     Exits application.
        ''' </summary>
        Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
            Close()
        End Sub

        Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            If PresenterObj.UsePayGroups() Then
                PayGroupsToolStripMenuItem.Visible = True
            Else
                PayGroupsToolStripMenuItem.Visible = False
            End If
        End Sub

        ''' <summary>
        '''     Help menu item event handler.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub IndexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemindex.Click
            MessageBox.Show("Help is not implemented... ", "Help")
        End Sub

        ''' <summary>
        '''     Displays login dialog box and loads member list in treeview.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLogin.Click
            Using form As New LoginEntry
                Try
                    If form.ShowDialog() = DialogResult.OK Then
                        If form.LoginOk Then
                            GlobalVariables.IsUserLoggedIn = True
                            LogStatus = LoginStatus.LoggedIn
                        Else
                            GlobalVariables.IsUserLoggedIn = False
                            LogStatus = LoginStatus.LoggedOut
                            ToolStripButtonLogin.Enabled = True
                        End If
                    Else
                        GlobalVariables.IsUserLoggedIn = False
                        LogStatus = LoginStatus.LoggedOut
                        ToolStripButtonLogin.Enabled = True
                    End If
                    ToolStripButtonExit.Enabled = True
                Catch ex As TypeInitializationException
                    MessageBox.Show("Invalid Connection String, specified connection string doesn't exist.",
                                    "Connection String Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ErrLogger.LogError(ex, True)
                Catch ex As Exception
                    'LogStatus = LoginStatus.LoggedOut
                    GlobalVariables.IsUserLoggedIn = True
                    LogStatus = LoginStatus.LoggedIn
                    'GlobalVariables.IsUserLoggedIn = False
                    'MessageBox.Show("Unsuccessful Login")
                    'Throw ex
                End Try
            End Using
        End Sub

        'End Sub
        ''' <summary>
        '''     Logoff user, empties datagridviews, and disables menus.
        ''' </summary>
        Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemLogout.Click
            'CType(New LogoutPresenter(Nothing), LogoutPresenter).Logout()
            'Call New LogoutPresenter(Nothing).Logout()
            GlobalVariables.IsUserLoggedIn = False
            LogStatus = LoginStatus.LoggedOut
            'labelAnnouncement.Visible = True
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

        'Private Sub InitializeDac()

        '    ' Read data access component settings from App.Config file.
        '    Dim accessType As String = ConfigurationManager.AppSettings.Get("AccessTypeTranslator") ' "SQL", "MDB", "DBF"
        '    Dim server As String = ConfigurationManager.AppSettings.Get("ServerTranslator") ' SQL only
        '    Dim database As String = ConfigurationManager.AppSettings.Get("DatabaseTranslator") ' SQL only
        '    Dim uid As String = ConfigurationManager.AppSettings.Get("UIDTranslator") ' SQL, MDB
        '    Dim pwd As String = ConfigurationManager.AppSettings.Get("PWDTranslator") ' SQL, MDB
        '    Dim fileName As String = ConfigurationManager.AppSettings.Get("FileNameTranslator") ' DBF, MDB

        '    With TranslatorDAC
        '        .DacAccessType = accessType
        '        .DacServer = server
        '        .DacDatabase = database
        '        .DacUID = uid
        '        .DacPassword = pwd
        '        .DacFileName = fileName
        '    End With

        '    accessType = ConfigurationManager.AppSettings.Get("AccessTypeAppData") ' "SQL", "MDB", "DBF"
        '    server = ConfigurationManager.AppSettings.Get("ServerAppData") ' SQL only
        '    database = ConfigurationManager.AppSettings.Get("DatabaseAppData") ' SQL only
        '    uid = ConfigurationManager.AppSettings.Get("UIDAppData") ' SQL, MDB
        '    pwd = ConfigurationManager.AppSettings.Get("PWDAppData") ' SQL, MDB
        '    fileName = ConfigurationManager.AppSettings.Get("FileNameAppData") ' DBF, MDB

        Private Sub ShowEntryForm(Of T As New)(ByRef formEntry As T)
            If (MdiChildren.Length > GlobalVariables.MaximumOpenForms - 1) Then
                Dim maxOpenForms As String = GlobalVariables.MaximumOpenForms.ToString()
                Messaging.Show(True, "MsgTooManyFormsOpen", "Too many forms open. You can only open up to {maxOpenForms} forms at the same time.", "Too many forms open", {"maxOpenForms", maxOpenForms})
            Else
                CallByName(formEntry, "MdiParent", CallType.Set, Me)
                CallByName(formEntry, "Show", CallType.Method)
            End If
        End Sub

        Private Sub ThreadExceptionHandler(sender As Object, e As ThreadExceptionEventArgs)
            ErrLogger.LogError(e.Exception)
        End Sub

        Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExit.Click
            Close()
        End Sub

        '''' <summary>
        ''''     Help toolbutton clicked event handler.
        '''' </summary>
        '''' <param name="sender"></param>
        '''' <param name="e"></param>
        'Private Sub ToolStripButtonHelp_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHelp.Click
        '    Dim parameter1 = 25
        '    Dim parameter2 = "$"
        '    Dim message As String()
        '    message = Messaging.CreateMessage("MsgCurrentPriceDisplay", "The current price is {0}{1:C2} per ounce.", "none")
        '    Messaging.Show(True, "MsgCurrentPriceDisplay", String.Format(message(0), parameter1, parameter2), message(1))
        '    Messaging.Show("MsgNewMessageKey", "Message Information")
        '    Messaging.Show(True, "MsgNewMessageKey", "Message Information", "With Caption")
        'End Sub

        '    ' Apply them to the Data Access Component
        '    With AppDataDAC
        '        .DacAccessType = accessType
        '        .DacServer = server
        '        .DacDatabase = database
        '        .DacUID = uid
        '        .DacPassword = pwd
        '        .DacFileName = fileName
        '    End With
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
            ToolStripButtonExit.Enabled = True
            ToolStripButtonLogin.Enabled = True
        End Sub

        Private Sub ToolStripButtonLTR_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEnglish.Click
            TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
            If GlobalFunctions.IsCultureOk(TextDisplayLanguage) Then
                CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage)
            Else
                TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            End If
            ToolStripButtonArabic.Visible = True
            ToolStripButtonEnglish.Visible = False
            GlobalVariables.RightToLeftLayout = False
            If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
                CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
            End If
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                'GlobalVariables.RightToLeftLayout = True
                RightToLeftLayout = True
                RightToLeft = RightToLeft.Yes
            Else
                'GlobalVariables.RightToLeftLayout = False
                RightToLeftLayout = False
                RightToLeft = RightToLeft.No
            End If
            TextDisplayLanguage = CultureInfo.CurrentCulture.ToString()
            GlobalVariables.AppCurrentCultureInfo = New CultureInfo(TextDisplayLanguage)
            'If GlobalFunctions.NeedToTranslateText(TextDisplayLanguage) Then
            TranslateForm()
            'End If
            'Refresh()
        End Sub

        Private Sub ToolStripButtonRTL_Click(sender As Object, e As EventArgs) Handles ToolStripButtonArabic.Click
            TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
            If GlobalFunctions.IsCultureOk(TextDisplayLanguage) Then
                CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage)
            Else
                TextDisplayLanguage = CultureInfo.CurrentCulture.Name
            End If
            ToolStripButtonArabic.Visible = False
            ToolStripButtonEnglish.Visible = True
            GlobalVariables.RightToLeftLayout = True
            If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
                CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
            End If
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
            If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
                'GlobalVariables.RightToLeftLayout = True
                RightToLeftLayout = True
                RightToLeft = RightToLeft.Yes
            Else
                'GlobalVariables.RightToLeftLayout = False
                RightToLeftLayout = False
                RightToLeft = RightToLeft.No
            End If
            TextDisplayLanguage = CultureInfo.CurrentCulture.ToString()
            GlobalVariables.AppCurrentCultureInfo = New CultureInfo(TextDisplayLanguage)
            'If GlobalFunctions.NeedToTranslateText(TextDisplayLanguage) Then
            TranslateForm()
            'End If
            'Refresh()
        End Sub

        Private Sub ToolStripButtonTranslate_Click(sender As Object, e As EventArgs) Handles ToolStripButtonTranslate.Click
            Dim frm As New TranslationTableManager With {
                .FormIdNoToTranslate = FormIdNo,
                .AppDataDAC = AppDataDAC,
                .TranslatorDAC = TranslatorDAC
            }
            frm.Show()
        End Sub

        Private Sub TranslationFormToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim frm As New TranslationTableManager With {
                .AppDataDAC = AppDataDAC,
                .TranslatorDAC = TranslatorDAC
            }
            frm.Show()
        End Sub

        Private Sub UnhandledExceptionHandler(sender As Object, e As UnhandledExceptionEventArgs)
            ErrLogger.LogError(CType(e.ExceptionObject, Exception))
        End Sub

        Private Sub CategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCategories.Click
            RunBasicForm("Category", "Categories Maintenance Form")
        End Sub

        'Public Event FormCultureChanged()

        ''Enumerates login Menu: Logged In or Logged Out.
        'Public Enum LoginStatus
        '    LoggedIn
        '    LoggedOut
        'End Enum

        'Public Property LogStatus As LoginStatus
        '    Get
        '        Return _logStatus
        '    End Get
        '    Set
        '        _logStatus = Value
        '        Dim allControls As New List(Of Control)
        '        For Each cCtrl As Control In FindControlRecursive(allControls, Me)
        '            SetControlSecurity(cCtrl)
        '        Next

        '        If Value = LoginStatus.LoggedIn Then
        '            DisableLogin()
        '        Else
        '            EnableLogin()
        '        End If
        '    End Set
        'End Property

        'Protected Property FormCultureInfo As CultureInfo

        'Protected Property FormCurrentCulture As CultureInfo
        '    Get
        '        Return _formCurrentCulture
        '    End Get
        '    Set(value As CultureInfo)
        '        _formCurrentCulture = value
        '        If value.TextInfo.IsRightToLeft Then
        '            RightToLeftLayout = True
        '            RightToLeft = RightToLeft.Yes
        '        Else
        '            RightToLeftLayout = False
        '            RightToLeft = RightToLeft.No
        '        End If
        '        RaiseEvent FormCultureChanged()
        '    End Set
        'End Property

        ''Protected Shared Property Service As New Service

        '''' <summary>
        ''''     Opens the about dialog window.
        '''' </summary>
        'Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAbout.Click
        '    Dim form = New FormAbout()
        '    form.ShowDialog()
        'End Sub

        'Private Sub BalanceSheetForAGivenYearToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemBalanceSheetForAGivenYear.Click
        '    ShowEntryForm(BalanceSheetYearlyReport)
        'End Sub

        'Private Sub BalanceSheetToolStripMenuItem1_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemBalanceSheet.Click
        '    ShowEntryForm(BalanceSheetMonthlyReport)
        'End Sub

        Private Sub BanksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemBanks.Click
            Dim childMdiForm As BankEntryTv
            ''Set the Parent Form of the Child window.
            childMdiForm = New BankEntryTv With {
                .MdiParent = Me
                }
            ''Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub RunBasicForm(ByVal tableOrViewName As String, ByVal formCaption As String)
            Dim childMdiForm As BasicEntry
            ''Set the Parent Form of the Child window.
            childMdiForm = New BasicEntry(tableOrViewName, formCaption) With {
                .MdiParent = Me
                }
            ''Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub BranchesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemBranches.Click
            Dim childMdiForm As BranchEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New BranchEntryTv() With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub CashDisbursementEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemCashDisbursementEntry.Click
            Dim childMdiForm
            childMdiForm = New DisbursementJournalEntry("CdJournal") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub CashReceiptEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemCashReceiptEntry.Click
            ShowEntryForm(CashReceiptJournalEntry)
        End Sub

        Private Sub AccountOfAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemAccountOfAccounts.Click
            ShowEntryForm(AccountEntryTv)
        End Sub

        Private Sub RevCostCentersToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemRevCostCenters.Click
            Dim childMdiForm As RevCostCenterEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New RevCostCenterEntryTv() With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub CountriesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemCountries.Click
            Dim childMdiForm As CountryEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New CountryEntryTv With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub CustomerClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemCustomerClients.Click
            ShowEntryForm(CustomerEntryTv)
        End Sub

        Private Sub DepartmentNewToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemDepartments.Click
            Dim childMdiForm As DepartmentEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New DepartmentEntryTv() With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub DesignationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDesignations.Click
            Dim myForm = New DesignationEntryTv
            myForm.Show()
        End Sub

        Private Sub DisableLogin()
            ToolStripButtonLogin.Enabled = False
            ToolStripButtonLogout.Enabled = True
            ToolStripMenuItemLogin.Enabled = False
            ToolStripMenuItemLogout.Enabled = True
            SetLanguageChangeButtons()
        End Sub

        Private Sub DistributionSchemesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemDistributionSchemes.Click
            Dim childMdiForm As DistributionSchemeEntry
            'Set the Parent Form of the Child window.
            childMdiForm = New DistributionSchemeEntry() With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub EmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemEmployees.Click
            Dim myForm = New EmployeeEntryTv
            myForm.Show()
        End Sub

        '''' <summary>
        ''''     Exits application.
        '''' </summary>
        'Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemExit.Click
        '    Close()
        'End Sub

        'Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    SecurityPresenterObj = New SecurityPresenter
        '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '        ToolStripButtonArabic.Visible = False
        '        ToolStripButtonEnglish.Visible = True
        '    Else
        '        ToolStripButtonArabic.Visible = True
        '        ToolStripButtonEnglish.Visible = False
        '    End If
        '    ToolStripButtonLogin.Enabled = True
        '    ToolStripButtonLogin.PerformClick()
        '    ToolStripButtonExit.Enabled = True
        'End Sub

        Private Sub GeneralJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemGeneralJournalEntry.Click
            Dim myForm = New GeneralJournalEntry(False)
            myForm.Show()
        End Sub

        'Private Sub IncomeStatementForAGivenMonthToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemIncomeStatementForAGivenMonth.Click
        '    ShowEntryForm(IncomeStatementMonthlyReport)
        'End Sub

        'Private Sub IncomeStatementForAGivenYearToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemIncomeStatementForAGivenYear.Click
        '    ShowEntryForm(IncomeStatementYearly)
        'End Sub

        '''' <summary>
        ''''     Help menu item event handler.
        '''' </summary>
        '''' <param name="sender"></param>
        '''' <param name="e"></param>
        'Private Sub IndexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemindex.Click
        '    MessageBox.Show(" Help is not implemented... ", "Help")
        'End Sub

        '''' <summary>
        ''''     Displays login dialog box and loads member list in treeview.
        '''' </summary>
        '''' <param name="sender"></param>
        '''' <param name="e"></param>
        'Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLogin.Click
        '    Dim form As LoginEntry
        '    Try
        '        form = New LoginEntry()
        '        If form.ShowDialog() = DialogResult.OK Then
        '            If form.LoginOk Then
        '                GlobalVariables.IsUserLoggedIn = True
        '                LogStatus = LoginStatus.LoggedIn
        '            Else
        '                GlobalVariables.IsUserLoggedIn = False
        '                LogStatus = LoginStatus.LoggedOut
        '                ToolStripButtonLogin.Enabled = True
        '            End If
        '        Else
        '            GlobalVariables.IsUserLoggedIn = False
        '            LogStatus = LoginStatus.LoggedOut
        '            ToolStripButtonLogin.Enabled = True
        '        End If
        '        ToolStripButtonExit.Enabled = True
        '    Catch ex As TypeInitializationException
        '        MessageBox.Show("Invalid Connection String, specified connection string doesn't exist.",
        '                        "Connection String Error!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        ErrLogger.LogError(ex, True)
        '    Catch ex As Exception
        '        'LogStatus = LoginStatus.LoggedOut
        '        GlobalVariables.IsUserLoggedIn = True
        '        LogStatus = LoginStatus.LoggedIn
        '        'GlobalVariables.IsUserLoggedIn = False
        '        'MessageBox.Show("Unsuccessful Login")
        '        'Throw ex
        '    End Try
        'End Sub

        ''End Sub
        '''' <summary>
        ''''     Logoff user, empties datagridviews, and disables menus.
        '''' </summary>
        'Private Sub LogoutToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemLogout.Click
        '    'CType(New LogoutPresenter(Nothing), LogoutPresenter).Logout()
        '    'Call New LogoutPresenter(Nothing).Logout()
        '    GlobalVariables.IsUserLoggedIn = False
        '    LogStatus = LoginStatus.LoggedOut
        '    'labelAnnouncement.Visible = True
        'End Sub

        Private Sub MessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMessages.Click
            Dim childMdiForm As OriginalMessagesEntryTv
            childMdiForm = New OriginalMessagesEntryTv() With {.MdiParent = Me}
            childMdiForm.Show()
        End Sub

        Private Sub PhoneTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemPhoneTypes.Click
            Dim childMdiForm As PhoneTypeEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New PhoneTypeEntryTv With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        'Private Sub RevCostCentersToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemRevCostCenters.Click
        '    Dim childMdiForm As RevCostCenterEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New RevCostCenterEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub PurchaseJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '    Dim childMdiForm As PurchaseJournalEntry
        '    childMdiForm = New PurchaseJournalEntry() With {.MdiParent = Me}
        '    childMdiForm.Show()
        'End Sub

        Private Sub ReligionsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemReligions.Click
            Dim childMdiForm As ReligionEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New ReligionEntryTv With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub RevenueGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemRevenueGroups.Click
            Dim childMdiForm As RevenueGroupEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New RevenueGroupEntryTv() With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        'Private Sub SecurityGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemSecurityGroups.Click
        '    Try
        '        Dim childMdiForm As SecurityGroupEntryTv
        '        childMdiForm = New SecurityGroupEntryTv With {
        '            .MdiParent = Me
        '            }
        '        childMdiForm.Show()
        '    Catch ex As Exception
        '        Debugger.Break()
        '    End Try
        'End Sub

        ''Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemUsers.Click
        ''    Dim childMdiForm As AATM.PresentationLayer.UserEntry
        ''    'Set the Parent Form of the Child window.
        ''    childMdiForm = New AATM.PresentationLayer.UserEntry  With {
        ''        .MdiParent = Me
        ''        }
        ''    'Display the new form.
        ''    childMdiForm.Show()
        ''End Sub

        Private Sub SecurityObjectsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemSecurityObjects.Click
            Dim childMdiForm As SecurityObjectEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New SecurityObjectEntryTv With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        'Private Sub SetLanguageChangeButtons()
        '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '        ToolStripButtonArabic.Visible = False
        '        ToolStripButtonArabic.Enabled = True
        '        ToolStripButtonEnglish.Visible = True
        '        ToolStripButtonEnglish.Enabled = True
        '    Else
        '        ToolStripButtonArabic.Visible = True
        '        ToolStripButtonArabic.Enabled = True
        '        ToolStripButtonEnglish.Visible = False
        '        ToolStripButtonEnglish.Enabled = True
        '    End If
        'End Sub

        ''Private Sub InitializeDac()

        ''    ' Read data access component settings from App.Config file.
        ''    Dim accessType As String = ConfigurationManager.AppSettings.Get("AccessTypeTranslator") ' "SQL", "MDB", "DBF"
        ''    Dim server As String = ConfigurationManager.AppSettings.Get("ServerTranslator") ' SQL only
        ''    Dim database As String = ConfigurationManager.AppSettings.Get("DatabaseTranslator") ' SQL only
        ''    Dim uid As String = ConfigurationManager.AppSettings.Get("UIDTranslator") ' SQL, MDB
        ''    Dim pwd As String = ConfigurationManager.AppSettings.Get("PWDTranslator") ' SQL, MDB
        ''    Dim fileName As String = ConfigurationManager.AppSettings.Get("FileNameTranslator") ' DBF, MDB

        ''    With TranslatorDAC
        ''        .DacAccessType = accessType
        ''        .DacServer = server
        ''        .DacDatabase = database
        ''        .DacUID = uid
        ''        .DacPassword = pwd
        ''        .DacFileName = fileName
        ''    End With

        ''    accessType = ConfigurationManager.AppSettings.Get("AccessTypeAppData") ' "SQL", "MDB", "DBF"
        ''    server = ConfigurationManager.AppSettings.Get("ServerAppData") ' SQL only
        ''    database = ConfigurationManager.AppSettings.Get("DatabaseAppData") ' SQL only
        ''    uid = ConfigurationManager.AppSettings.Get("UIDAppData") ' SQL, MDB
        ''    pwd = ConfigurationManager.AppSettings.Get("PWDAppData") ' SQL, MDB
        ''    fileName = ConfigurationManager.AppSettings.Get("FileNameAppData") ' DBF, MDB

        'Private Sub ShowEntryForm(Of T As New)(ByRef formEntry As T)
        '    'Dim childMdiForm = formEntry
        '    If (MdiChildren.Length > GlobalVariables.MaximumOpenForms - 1) Then
        '        MessageBox.Show("Too Many Forms Open. You can only open up to " + GlobalVariables.MaximumOpenForms.ToString() + " forms at the same time.")
        '    Else
        '        CallByName(formEntry, "MdiParent", CallType.Set, Me)
        '        CallByName(formEntry, "Show", CallType.Method)
        '    End If

        'End Sub

        'Private Sub StatementOfAccountsPayableToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '            Handles ToolStripMenuItemStatementOfAccountsPayable.Click
        '    ShowEntryForm(ApStatementReport)
        'End Sub

        'Private Sub StatementOfAccountsReceivableToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '            Handles ToolStripMenuItemStatementOfAccountsReceivable.Click
        '    ShowEntryForm(ArStatementReport)
        'End Sub

        'Private Sub SummaryOfAccountsPayableToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '            Handles ToolStripMenuItemSummaryOfAccountsPayable.Click
        '    ShowEntryForm(ApSummaryReport)
        'End Sub

        'Private Sub SummaryOfAccountsReceivableToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '            Handles ToolStripMenuItemSummaryOfAccountsReceivable.Click
        '    ShowEntryForm(ArSummaryReport)
        'End Sub

        Private Sub SupplierVendorsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
                    Handles ToolStripMenuItemSupplierVendors.Click
            ShowEntryForm(SupplierEntryTv)
        End Sub

        'Private Sub ThreadExceptionHandler(sender As Object, e As ThreadExceptionEventArgs)
        '    ErrLogger.LogError(e.Exception)
        'End Sub

        'Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButtonExit.Click
        '    Close()
        'End Sub

        '''' <summary>
        ''''     Help toolbutton clicked event handler.
        '''' </summary>
        '''' <param name="sender"></param>
        '''' <param name="e"></param>
        'Private Sub ToolStripButtonHelp_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHelp.Click
        '    Dim parameter1 = 25
        '    Dim parameter2 = "$"
        '    Dim message As String()
        '    message = Messaging.AddMessage("MsgCurrentPriceDisplay", "The current price is {0}{1:C2} per ounce.", "none")
        '    Messaging.Show("MsgCurrentPriceDisplay", String.Format(message(0), parameter1, parameter2), message(1))
        '    Messaging.Show("MsgNewMessageKey", "Message Information")
        '    Messaging.Show("MsgNewMessageKey", "Message Information", "With Caption")
        'End Sub

        ''    ' Apply them to the Data Access Component
        ''    With AppDataDAC
        ''        .DacAccessType = accessType
        ''        .DacServer = server
        ''        .DacDatabase = database
        ''        .DacUID = uid
        ''        .DacPassword = pwd
        ''        .DacFileName = fileName
        ''    End With
        '''' <summary>
        ''''     Redirects login request to equivalent menu event handler.
        '''' </summary>
        'Private Sub ToolStripButtonLogin_Click(sender As Object, e As EventArgs) Handles ToolStripButtonLogin.Click
        '    LoginToolStripMenuItem_Click(Me, Nothing)
        'End Sub

        '''' <summary>
        ''''     Redirects logout request to equivalent menu event handler.
        '''' </summary>
        'Private Sub ToolStripButtonLogout_Click(sender As Object, e As EventArgs) Handles ToolStripButtonLogout.Click
        '    LogoutToolStripMenuItem_Click(Me, Nothing)
        '    SetLanguageChangeButtons()
        '    ToolStripButtonExit.Enabled = True
        '    ToolStripButtonLogin.Enabled = True
        'End Sub

        'Private Sub ToolStripButtonLTR_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEnglish.Click
        '    TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr
        '    If GlobalFunctions.IsCultureOk(TextDisplayLanguage) Then
        '        CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage)
        '    Else
        '        TextDisplayLanguage = CultureInfo.CurrentCulture.Name
        '    End If
        '    ToolStripButtonArabic.Visible = True
        '    ToolStripButtonEnglish.Visible = False
        '    GlobalVariables.RightToLeftLayout = False
        '    If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
        '        CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
        '    End If
        '    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
        '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '        'GlobalVariables.RightToLeftLayout = True
        '        RightToLeftLayout = True
        '        RightToLeft = RightToLeft.Yes
        '    Else
        '        'GlobalVariables.RightToLeftLayout = False
        '        RightToLeftLayout = False
        '        RightToLeft = RightToLeft.No
        '    End If
        '    TextDisplayLanguage = CultureInfo.CurrentCulture.ToString()
        '    GlobalVariables.AppCurrentCultureInfo = New CultureInfo(TextDisplayLanguage)
        '    'If GlobalFunctions.NeedToTranslateText(TextDisplayLanguage) Then
        '    TranslateForm()
        '    'End If
        '    'Refresh()
        'End Sub

        'Private Sub ToolStripButtonRTL_Click(sender As Object, e As EventArgs) Handles ToolStripButtonArabic.Click
        '    TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr
        '    If GlobalFunctions.IsCultureOk(TextDisplayLanguage) Then
        '        CultureInfo.CurrentCulture = New CultureInfo(TextDisplayLanguage)
        '    Else
        '        TextDisplayLanguage = CultureInfo.CurrentCulture.Name
        '    End If
        '    ToolStripButtonArabic.Visible = False
        '    ToolStripButtonEnglish.Visible = True
        '    GlobalVariables.RightToLeftLayout = True
        '    If CultureInfo.CurrentUICulture.Name <> CultureInfo.CurrentCulture.Name Then
        '        CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture
        '    End If
        '    CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture
        '    If CultureInfo.CurrentCulture.TextInfo.IsRightToLeft Then
        '        'GlobalVariables.RightToLeftLayout = True
        '        RightToLeftLayout = True
        '        RightToLeft = RightToLeft.Yes
        '    Else
        '        'GlobalVariables.RightToLeftLayout = False
        '        RightToLeftLayout = False
        '        RightToLeft = RightToLeft.No
        '    End If
        '    TextDisplayLanguage = CultureInfo.CurrentCulture.ToString()
        '    GlobalVariables.AppCurrentCultureInfo = New CultureInfo(TextDisplayLanguage)
        '    'If GlobalFunctions.NeedToTranslateText(TextDisplayLanguage) Then
        '    TranslateForm()
        '    'End If
        '    'Refresh()
        'End Sub

        'Private Sub ToolStripButtonTranslate_Click(sender As Object, e As EventArgs) Handles ToolStripButtonTranslate.Click
        '    Dim frm As New TranslationTableManager()
        '    frm.FormIdNoToTranslate = FormIdNo
        '    frm.AppDataDAC = AppDataDAC
        '    frm.TranslatorDAC = TranslatorDAC
        '    frm.Show()
        'End Sub

        Private Sub ToolStripMenuItemUsers_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemUsers.Click
            Dim childMdiForm As UserEntryTv
            childMdiForm = New UserEntryTv With {.MdiParent = Me}
            childMdiForm.Show()
        End Sub

        'Private Sub TranslationFormToolStripMenuItem_Click(sender As Object, e As EventArgs)
        '    Dim frm As New TranslationTableManager
        '    frm.AppDataDAC = AppDataDAC
        '    frm.TranslatorDAC = TranslatorDAC
        '    frm.Show()
        'End Sub

        'Private Sub TrialBalanceForAGivenYearToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemTrialBalanceForAGivenYear.Click
        '    ShowEntryForm(TrialBalanceYearlyReport)
        'End Sub

        'Private Sub TrialBalanceToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemTrialBalance.Click
        '    ShowEntryForm(TrialBalanceMonthlyReport)
        'End Sub

        'Private Sub UnhandledExceptionHandler(sender As Object, e As UnhandledExceptionEventArgs)
        '    ErrLogger.LogError(CType(e.ExceptionObject, Exception))
        'End Sub

        Private Sub AccountsPayableEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsPayableEntryToolStripMenuItem.Click
            Dim childMdiForm As ApJournalEntry
            'Set the Parent Form of the Child window.
            childMdiForm = New ApJournalEntry With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub AccountsReceivableEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsReceivableEntryToolStripMenuItem.Click
            Dim childMdiForm As ArJournalEntry
            'Set the Parent Form of the Child window.
            childMdiForm = New ArJournalEntry With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs)
            Dim childMdiForm = New DisbursementJournalEntry("CkJournal") With {.MdiParent = Me}
            childMdiForm.Show()
        End Sub

        Private Sub ItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemItems.Click
            Dim childMdiForm As PurchaseItemEntry
            'Set the Parent Form of the Child window.
            childMdiForm = New PurchaseItemEntry With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub SalesJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesJournalEntryToolStripMenuItem.Click
            Dim childMdiForm As SalesJournalEntry
            'Set the Parent Form of the Child window.
            childMdiForm = New SalesJournalEntry With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub AccountReconciliationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountReconciliationToolStripMenuItem.Click
            Dim childMdiForm As AccountReconciliationEntry
            'Set the Parent Form of the Child window.
            childMdiForm = New AccountReconciliationEntry With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub PettyCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PettyCashToolStripMenuItem.Click
            Dim childMdiForm ' As New DisbursementJournalEntry("PcJournal")
            'Set the Parent Form of the Child window.
            childMdiForm = New DisbursementJournalEntry("PcJournal") With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        Private Sub CreateAllMessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCreateAllMessages.Click
            Dim x = New OneTimeRun
            'Debugger.Break()
            OneTimeRun.CreateAllMessages()
            'OneTimeRun.CreateEnums()
        End Sub

        Private Sub ToolStripButtonHelp_Click(sender As Object, e As EventArgs)
            Dim maxOpenForms As String = GlobalVariables.MaximumOpenForms.ToString()
            Messaging.Show(True, "MsgTooManyFormsOpen", "Too many forms open. You can only open up to {maxOpenForms} forms at the same time.", "Too many forms open", {"maxOpenForms", maxOpenForms})
        End Sub

        'Private Function ShowError(translate As Boolean, key As String, message As String, caption As String, ParamArray variables As String())
        '    Dim oldValue As String = ""
        '    Dim newValue As String = ""
        '    message = Messaging.GetMessage(True, key, message, caption)
        '    For i = 0 To variables.Count - 1 Step 2
        '        oldValue = "{" & variables(i) & "}"
        '        newValue = variables(i + 1)
        '        message = Replace(message, oldValue, newValue, 1, -1, CompareMethod.Text)
        '    Next
        '    Return Messaging.Show(message, caption)
        'End Function

        Private Sub TranslationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCaptionsBatchEdit.Click
            'frm.FormIdNoToTranslate = 0
            Dim frm As New TranslationTableManager With {
                .AppDataDAC = AppDataDAC,
                .TranslatorDAC = TranslatorDAC
            }
            frm.Show()
        End Sub

        Private Sub ToolStripMenuItemCaptions_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemCaptions.Click
            Dim childMdiForm As OriginalCaptionEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New OriginalCaptionEntryTv With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        'Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        '    Dim x, y As Integer?
        '    x = Nothing
        '    y = Nothing

        '    MessageBox.Show(x = y)
        '    Dim unused = MessageBox.Show(EqualityComparer(Of String).[Default].Equals(x, y))
        '    x = 5
        'End Sub

        Public Property IUserView_IdNo As Int32 Implements IUserView.IdNo
        Public Property Password As String Implements IUserView.Password
        Public Property FullName As String Implements IUserView.FullName
        Public Property FullNameAra As String Implements IUserView.FullNameAra
        Public Property SecurityLevel As Short Implements IUserView.SecurityLevel
        Public Property SecurityGroupIdNo As Int16 Implements IUserView.SecurityGroupIdNo
        Public Property IUserView_UserName As String Implements IUserView.UserName

        Private Sub ToolStripMenuItemSecurityGroups_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSecurityGroups.Click
            Dim childMdiForm As SecurityGroupEntryTv
            childMdiForm = New SecurityGroupEntryTv With {
                    .MdiParent = Me
                    }
            childMdiForm.Show()
        End Sub

        Private Sub DefaultFieldValuesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultFieldValuesToolStripMenuItem.Click
            Dim childMdiForm As DefaultFieldValueEntryTv
            childMdiForm = New DefaultFieldValueEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub ClosePettyCashAccountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClosePettyCashAccountToolStripMenuItem.Click
            Dim childMdiForm As PostPettyCash
            childMdiForm = New PostPettyCash With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub ToolStripMenuItemStatementOfAccountsReceivable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfAccountsReceivable.Click
            Dim childMdiForm As StatementOfAr
            childMdiForm = New StatementOfAr With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub StatementOfAccountsReToolStripMenuItem_Click(sender As Object, e As EventArgs)

        End Sub

        Private Sub ToolStripMenuItemIncomeStatementForAGivenYear_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemIncomeStatementForAGivenYear.Click

        End Sub

        Private Sub ToolStripMenuItemStatementOfAccountsPayable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStatementOfAccountsPayable.Click
            Dim childMdiForm As StatementOfAp
            childMdiForm = New StatementOfAp With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub EmployeeReceivableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeReceivableToolStripMenuItem.Click
            Dim childMdiForm As ErJournalEntry
            childMdiForm = New ErJournalEntry With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub StatementOfEmployeeLoansToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StatementOfEmployeeLoansToolStripMenuItem.Click
            Dim childMdiForm As StatementOfEr
            childMdiForm = New StatementOfEr With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub ToolStripMenuItemSummaryOfAccountsReceivable_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSummaryOfAccountsReceivable.Click
            Dim childMdiForm As ArSummary
            childMdiForm = New ArSummary With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub SummaryOfAccountsPayableToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SummaryOfAccountsPayableToolStripMenuItem1.Click
            Dim childMdiForm As ApSummary
            childMdiForm = New ApSummary With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub ToolStripMenuItemStateOfEmployeeLoans_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemStateOfEmployeeLoans.Click
            Dim childMdiForm As ErSummary
            childMdiForm = New ErSummary With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub ClosingEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClosingEntryToolStripMenuItem.Click
            Dim myForm = New GeneralJournalEntry(True)
            myForm.Show()
        End Sub

        Private Sub YearlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles YearlyToolStripMenuItem.Click
            Dim childMdiForm As TrialBalance
            childMdiForm = New TrialBalance("Y") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub MonthlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyToolStripMenuItem.Click
            Dim childMdiForm As TrialBalance
            childMdiForm = New TrialBalance("M") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub QuarterlyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuarterlyToolStripMenuItem.Click
            Dim childMdiForm As TrialBalance
            childMdiForm = New TrialBalance("Q") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub SemestralToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SemestralToolStripMenuItem.Click
            Dim childMdiForm As TrialBalance
            childMdiForm = New TrialBalance("S") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub CustomToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomToolStripMenuItem.Click
            Dim childMdiForm As TrialBalance
            childMdiForm = New TrialBalance("C") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub YearlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles YearlyToolStripMenuItem1.Click
            Dim childMdiForm As BalanceSheet
            childMdiForm = New BalanceSheet("Y") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub MonthlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles MonthlyToolStripMenuItem1.Click
            Dim childMdiForm As BalanceSheet
            childMdiForm = New BalanceSheet("M") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub GeneralLedgerDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountActivityToolStripMenuItem.Click
            Dim childMdiForm As AccountActivity
            childMdiForm = New AccountActivity With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub YearlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles YearlyToolStripMenuItem2.Click
            Dim childMdiForm As IncomeStatement
            childMdiForm = New IncomeStatement("Y") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub EarningsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EarningsToolStripMenuItem.Click
            Dim childMdiForm As EarningEntryTv
            childMdiForm = New EarningEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub DeductionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeductionsToolStripMenuItem.Click
            Dim childMdiForm As DeductionEntryTv
            childMdiForm = New DeductionEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub LeavesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LeavesToolStripMenuItem.Click
            Dim childMdiForm As LeaveEntry
            childMdiForm = New LeaveEntry With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub PayGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayGroupsToolStripMenuItem.Click
            Dim childMdiForm As PayGroupEntry
            childMdiForm = New PayGroupEntry With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub PayCyclesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayCyclesToolStripMenuItem.Click
            Dim childMdiForm As PayCycleEntryTv
            childMdiForm = New PayCycleEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub PayPeriodsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayPeriodsToolStripMenuItem.Click
            Dim childMdiForm As PayPeriodEntryTv
            childMdiForm = New PayPeriodEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub PensionProvidersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PensionProvidersToolStripMenuItem.Click
            Dim childMdiForm As PensionProviderEntryTv
            childMdiForm = New PensionProviderEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub PensionSchemesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PensionSchemesToolStripMenuItem.Click
            Dim childMdiForm As PensionSchemeEntryTv
            childMdiForm = New PensionSchemeEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub SalesDepositTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesDepositTypesToolStripMenuItem.Click
            Dim childMdiForm As DepositTypeEntryTv
            childMdiForm = New DepositTypeEntryTv With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub MonthlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MonthlyToolStripMenuItem2.Click
            Dim childMdiForm As IncomeStatement
            childMdiForm = New IncomeStatement("M") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub QuarterlyToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuarterlyToolStripMenuItem1.Click
            Dim childMdiForm As IncomeStatement
            childMdiForm = New IncomeStatement("Q") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub SemiAnnuallyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SemiAnnuallyToolStripMenuItem.Click
            Dim childMdiForm As IncomeStatement
            childMdiForm = New IncomeStatement("S") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub CustomRangeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomRangeToolStripMenuItem.Click
            Dim childMdiForm As IncomeStatement
            childMdiForm = New IncomeStatement("C") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub CashIncomePerDoctorServiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashIncomePerDoctorServiceToolStripMenuItem.Click
            Dim childMdiForm As CashIncomePerDoctorPerService
            childMdiForm = New CashIncomePerDoctorPerService With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub NumberOfCashPatientsPerDoctorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NumberOfCashPatientsPerDoctorToolStripMenuItem.Click
            Dim childMdiForm As NumberOfCashPatientsPerDoctorPerDay
            childMdiForm = New NumberOfCashPatientsPerDoctorPerDay With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub TestToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem1.Click
            Dim cForm As New ReportFormTest("Blank Report.Rpt")
            cForm.Show()
        End Sub

        Private Sub QuarterlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles QuarterlyToolStripMenuItem2.Click
            Dim childMdiForm As BalanceSheet
            childMdiForm = New BalanceSheet("Q") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub SemestralToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SemestralToolStripMenuItem1.Click
            Dim childMdiForm As BalanceSheet
            childMdiForm = New BalanceSheet("S") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub AgingOfAccountsPayableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgingOfAccountsPayableToolStripMenuItem.Click
            Dim reportTitle = Messaging.TranslateCaption("Aging of Accounts Payable as of ")
            reportTitle = reportTitle + " " + GlobalFuncNSub.GregorianLongDate(Now(), CultureInfo.CurrentCulture)
            Dim cForm As New ReportFormNew("Aging of Accounts Payable.Rpt", reportTitle, CultureInfo.CurrentCulture)
            cForm.Show()
        End Sub

        Private Sub AccountsReceivableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsReceivableToolStripMenuItem.Click
            Dim reportTitle = Messaging.TranslateCaption("Aging of Accounts Receivable")
            reportTitle = reportTitle + " " + GlobalFuncNSub.GregorianLongDate(Now(), CultureInfo.CurrentCulture)
            Dim cForm As New ReportFormNew("Aging of Accounts Receivable.Rpt", reportTitle, CultureInfo.CurrentCulture)
            cForm.Show()
        End Sub

        Private Sub CheckPrintingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CheckPrintingToolStripMenuItem.Click
            Dim childMdiForm As CheckPrinter
            childMdiForm = New CheckPrinter("S") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        Private Sub BankTransferToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim childMdiForm
            childMdiForm = New DisbursementJournalEntry("CdJournal") With {
                .MdiParent = Me
                }
            childMdiForm.Show()
        End Sub

        'Private Sub PayPeriodAttendanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayPeriodAttendanceToolStripMenuItem.Click
        '    Dim childMdiForm As AttendanceItemEntry
        '    childMdiForm = New AttendanceItemEntry With {
        '        .MdiParent = Me
        '        }
        '    childMdiForm.Show()
        'End Sub

        'Private Sub PayrollEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PayrollEntryToolStripMenuItem1.Click
        '    Dim childMdiForm As PayrollTvEntry
        '    childMdiForm = New PayrollTvEntry With {
        '        .MdiParent = Me
        '        }
        '    childMdiForm.Show()
        'End Sub

        'Private Sub MonthlyToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles MonthlyToolStripMenuItem2.Click

        'End Sub

        'Private Sub IncomeStatementForAGivenMonthToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemIncomeStatementForAGivenMonth.Click
        '    ShowEntryForm(IncomeStatementMonthlyReport)
        'End Sub

        'Private Sub btnPrint_ClickButtonArea(sender As Object, e As MouseEventArgs)
        '    Dim cForm As New AccountReconciliationReport(IdNo)
        '    cForm.Show()
        'End Sub

    End Class

End Namespace