Imports System.Globalization
Imports System.Threading
Imports AATM.Accounts.BusinessLayer
Imports AATM.Accounts.PresentationLayer.Models
Imports AATM.Accounts.PresentationLayer.Views
Imports AATM.PresentationLayer.Forms
Imports AATM.Libraries.ErrorsAndEvents
Imports AATM.Libraries.GlobalFuncNSub
Imports AATM.PresentationLayer.Presenters
Imports AutoMapper
Imports AATM.Common
Imports AATM.PresentationLayer.Forms.PresentationLayer.Forms
Imports AATM.Common.PresentationLayer.Forms

Namespace PresentationLayer.Forms

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

        Private _formCurrentCulture As CultureInfo
        Private _logStatus As LoginStatus
        Public Shared AccountsMapper As IMapper

        'Public Shared DefaultLanguage As String = "English"
        ''' <summary>
        '''     Default form constructor.
        ''' </summary>
        Public Sub New()

            AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf UnhandledExceptionHandler
            AddHandler Application.ThreadException, AddressOf ThreadExceptionHandler

            _logStatus = LoginStatus.LoggedOut
            InitializeComponent()
            If Not DesignMode Then
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
            SetupMapper()
            '' Disable logout
            'Me.toolStripButtonLogout.Enabled = False
            'Me.logoutToolStripMenuItem.Enabled = False

            ' Create two Presenters. Note: the form is the view.
            '_membersPresenter = New MembersPresenter(Me)
            '_ordersPresenter = New OrdersPresenter(Me)
        End Sub

        Public Sub SetupMapper()
            Dim mapperConfiguration = New MapperConfiguration(Function(cfg)
                                                                  Return {cfg.CreateMap(Of Category, CategoryModel)().ReverseMap(),
                                                                          cfg.CreateMap(Of CategoryModel, ICategoryView)().ReverseMap(),
                                                                          cfg.CreateMap(Of ICategoryView, Category)()
                                                                          }
                                                              End Function)
            AccountsMapper = mapperConfiguration.CreateMapper()
            mapperConfiguration.AssertConfigurationIsValid()
            GlobalVariables.Mapper = AccountsMapper
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

        Protected Property FormCultureInfo As CultureInfo

        Protected Property FormCurrentCulture As CultureInfo
            Get
                Return _formCurrentCulture
            End Get
            Set(value As CultureInfo)
                _formCurrentCulture = value
                If value.TextInfo.IsRightToLeft Then
                    RightToLeftLayout = True
                    RightToLeft = RightToLeft.Yes
                Else
                    RightToLeftLayout = False
                    RightToLeft = RightToLeft.No
                End If
                RaiseEvent FormCultureChanged()
            End Set
        End Property

        'Protected Shared Property Service As New Service

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
            SecurityPresenterObj = New SecurityPresenter
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
        End Sub

        ''' <summary>
        '''     Help menu item event handler.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub IndexToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemindex.Click
            MessageBox.Show(" Help is not implemented... ", "Help")
        End Sub

        ''' <summary>
        '''     Displays login dialog box and loads member list in treeview.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub LoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemLogin.Click
            Dim form As LoginEntry
            Try
                form = New LoginEntry()
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
            'Dim childMdiForm = formEntry
            If (MdiChildren.Length > GlobalVariables.MaximumOpenForms - 1) Then
                MessageBox.Show("Too Many Forms Open. You can only open up to " + GlobalVariables.MaximumOpenForms.ToString() + " forms at the same time.")
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

        ''' <summary>
        '''     Help toolbutton clicked event handler.
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        Private Sub ToolStripButtonHelp_Click(sender As Object, e As EventArgs) Handles ToolStripButtonHelp.Click
            Dim parameter1 = 25
            Dim parameter2 = "$"
            Dim message As String()
            message = MyMessage.CreateMessage("MsgCurrentPriceDisplay", "The current price is {0}{1:C2} per ounce.", "none")
            MyMessage.Show("MsgCurrentPriceDisplay", String.Format(message(0), parameter1, parameter2), message(1))
            MyMessage.Show("MsgNewMessageKey", "Message Information")
            MyMessage.Show("MsgNewMessageKey", "Message Information", "With Caption")
        End Sub

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
            Dim frm As New TranslationTableManager()
            frm.FormIdNoToTranslate = FormIdNo
            frm.AppDataDAC = AppDataDAC
            frm.TranslatorDAC = TranslatorDAC
            frm.Show()
        End Sub

        Private Sub TranslationFormToolStripMenuItem_Click(sender As Object, e As EventArgs)
            Dim frm As New TranslationTableManager
            frm.AppDataDAC = AppDataDAC
            frm.TranslatorDAC = TranslatorDAC
            frm.Show()
        End Sub

        Private Sub UnhandledExceptionHandler(sender As Object, e As UnhandledExceptionEventArgs)
            ErrLogger.LogError(CType(e.ExceptionObject, Exception))
        End Sub


        Private Sub CategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriesToolStripMenuItem.Click
            Dim childMdiForm As CategoryEntryTv
            'Set the Parent Form of the Child window.
            childMdiForm = New CategoryEntryTv With {
                .MdiParent = Me
                }
            'Display the new form.
            childMdiForm.Show()
        End Sub

        'Public Sub SetupMapper()
        '    Dim mapperConfiguration = New MapperConfiguration(Function(cfg)
        '                                                          Return {cfg.CreateMap(Of PcsOiItem, PcsOiItemModel)(),
        '                                                                  cfg.CreateMap(Of PcsOiItemModel, IPcsOiItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IPcsOiItemView, PcsOiItem)(),
        '                                                                  cfg.CreateMap(Of PettyCashJournal, PettyCashJournalModel)(),
        '                                                                  cfg.CreateMap(Of PettyCashJournalModel, IPettyCashJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IPettyCashJournalView, PettyCashJournal)(),
        '                                                                  cfg.CreateMap(Of Supplier, SupplierModel)(),
        '                                                                  cfg.CreateMap(Of SupplierModel, ISupplierView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ISupplierView, Supplier)(),
        '                                                                  cfg.CreateMap(Of CashCode, CashCodeModel)(),
        '                                                                  cfg.CreateMap(Of CashCodeModel, ICashCodeView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ICashCodeView, CashCode)(),
        '                                                                  cfg.CreateMap(Of SalesJournal, SalesJournalModel)(),
        '                                                                  cfg.CreateMap(Of SalesJournalModel, ISalesJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ISalesJournalView, SalesJournal)(),
        '                                                                  cfg.CreateMap(Of SalesCashItem, SalesCashItemModel)(),
        '                                                                  cfg.CreateMap(Of SalesCashItemModel, ISalesCashItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ISalesCashItemView, SalesCashItem)(),
        '                                                                  cfg.CreateMap(Of CashDisbursementJournalModel, CashDisbursementJournal)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of CashDisbursementJournalModel, ICashDisbursementJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of CashDisbursementJournal, ICashDisbursementJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of GeneralJournalModel, GeneralJournal)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of GeneralJournalModel, IGeneralJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of GeneralJournal, IGeneralJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of PurchaseJournal, PurchaseJournalModel)(),
        '                                                                  cfg.CreateMap(Of PurchaseJournalModel, IPurchaseJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IPurchaseJournalView, PurchaseJournal)(),
        '                                                                  cfg.CreateMap(Of CashReceiptJournal, CashReceiptJournalModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of CashReceiptJournalModel, ICashReceiptJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ICashReceiptJournalView, CashReceiptJournal)(),
        '                                                                  cfg.CreateMap(Of ApJournal, ApJournalModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ApJournalModel, IApJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IApJournalView, ApJournal)(),
        '                                                                  cfg.CreateMap(Of ArJournal, ArJournalModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ArJournalModel, IArJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IArJournalView, ArJournal)(),
        '                                                                  cfg.CreateMap(Of ChequeDisbursementJournal, ChequeDisbursementJournalModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ChequeDisbursementJournalModel, IChequeDisbursementJournalView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IChequeDisbursementJournalView, ChequeDisbursementJournal)(),
        '                                                                  cfg.CreateMap(Of Category, CategoryModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of CategoryModel, ICategoryView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ICategoryView, Category)(),
        '                                                                  cfg.CreateMap(Of PurchaseItem, PurchaseItemModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of PurchaseItemModel, IPurchaseItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IPurchaseItemView, PurchaseItem)(),
        '                                                                  cfg.CreateMap(Of Chart, ChartModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ChartModel, IChartView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IChartView, Chart)(),
        '                                                                  cfg.CreateMap(Of CkdOiItem, CkdOiItemModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of CkdOiItemModel, ICkdOiItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ICkdOiItemView, CkdOiItem)(),
        '                                                                  cfg.CreateMap(Of CadOiItem, CadOiItemModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of CadOiItemModel, ICadOiItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ICadOiItemView, CadOiItem)(),
        '                                                                  cfg.CreateMap(Of CsrOiItem, CsrOiItemModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of CsrOiItemModel, ICsrOiItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of ICsrOiItemView, CsrOiItem)(),
        '                                                                  cfg.CreateMap(Of JournalItem, JournalItemModel)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of JournalItemModel, IJournalItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IJournalItemView, JournalItem)(),
        '                                                                  cfg.CreateMap(Of BusinessLayer.AccountReconciliation, AccountReconciliationModel)(),
        '                                                                  cfg.CreateMap(Of AccountReconciliationModel, IAccountReconciliationView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IAccountReconciliationView, BusinessLayer.AccountReconciliation)(),
        '                                                                  cfg.CreateMap(Of AccountReconciliationItem, AccountReconciliationItemModel)(),
        '                                                                  cfg.CreateMap(Of AccountReconciliationItemModel, IAccountReconciliationItemView)().ReverseMap(),
        '                                                                  cfg.CreateMap(Of IAccountReconciliationItemView, AccountReconciliationItem)()
        '                                                                 }
        '                                                      End Function)
        '    AccountsMapper = mapperConfiguration.CreateMapper()
        '    mapperConfiguration.AssertConfigurationIsValid()
        '    GlobalVariables.Mapper = AccountsMapper
        'End Sub

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

        'Private Sub BanksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BanksToolStripMenuItem.Click
        '    Dim childMdiForm As BankEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New BankEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub BranchesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemBranches.Click
        '    Dim childMdiForm As BranchEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New BranchEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub CashDisbursementEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemCashDisbursementEntry.Click
        '    ShowEntryForm(CashDisbursementJournalEntry)
        'End Sub

        'Private Sub CashReceiptEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemCashReceiptEntry.Click
        '    ShowEntryForm(CashReceiptJournalEntry)
        'End Sub

        'Private Sub ChartOfAccountsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemChartOfAccounts.Click
        '    ShowEntryForm(ChartEntryTv)
        'End Sub

        'Private Sub CostCentersToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemCostCenters.Click
        '    Dim childMdiForm As CostCenterEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New CostCenterEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub CountriesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemCountries.Click
        '    Dim childMdiForm As CountryEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New CountryEntryTv With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub CustomerClientsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemCustomersClients.Click
        '    ShowEntryForm(CustomerEntryTv)
        'End Sub

        'Private Sub DepartmentNewToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemDepartments.Click
        '    Dim childMdiForm As DepartmentEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New DepartmentEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub DesignationsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DesignationsToolStripMenuItem.Click
        '    Dim childMdiForm As DesignationEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New DesignationEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        Private Sub DisableLogin()
            ToolStripButtonLogin.Enabled = False
            ToolStripButtonLogout.Enabled = True
            ToolStripMenuItemLogin.Enabled = False
            ToolStripMenuItemLogout.Enabled = True
            SetLanguageChangeButtons()
        End Sub

        'Private Sub DistributionSchemesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DistributionSchemesToolStripMenuItem.Click
        '    Dim childMdiForm As DistributionSchemeEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New DistributionSchemeEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub EmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemEmployees.Click
        '    Dim myForm = New EmployeeEntryTv
        '    myForm.Show()
        '    'ShowEntryForm(EmployeeEntryTv)
        'End Sub

        'Private Sub EnableLogin()
        '    ToolStripButtonLogin.Enabled = True
        '    ToolStripButtonLogout.Enabled = False
        '    ToolStripMenuItemLogin.Enabled = True
        '    ToolStripMenuItemLogout.Enabled = False
        '    ToolStripMenuItemExit.Enabled = True
        '    SetLanguageChangeButtons()
        'End Sub

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

        'Private Sub GeneralJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemGeneralJournalEntry.Click
        '    ShowEntryForm(GeneralJournalEntry)
        'End Sub

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

        'Private Sub MessagesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemMessages.Click
        '    Dim childMdiForm As OriginalMessagesEntryTv
        '    childMdiForm = New OriginalMessagesEntryTv() With {.MdiParent = Me}
        '    childMdiForm.Show()
        'End Sub

        'Private Sub PhoneTypesToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemPhoneTypes.Click
        '    Dim childMdiForm As PhoneTypeEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New PhoneTypeEntryTv With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub ProfitCentersToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemProfitCenters.Click
        '    Dim childMdiForm As ProfitCenterEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New ProfitCenterEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub PurchaseJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs)

        '    ShowEntryForm(PurchaseJournalEntry)
        'End Sub

        'Private Sub ReligionsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemReligions.Click
        '    Dim childMdiForm As ReligionEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New ReligionEntryTv With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub ReveneGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReveneGroupsToolStripMenuItem.Click
        '    Dim childMdiForm As RevenueGroupEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New RevenueGroupEntryTv() With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        Private Sub SecurityGroupsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
            Handles ToolStripMenuItemSecurityGroups.Click
            Try
                Dim childMdiForm As SecurityGroupEntryTv
                childMdiForm = New SecurityGroupEntryTv With {
                    .MdiParent = Me
                    }
                childMdiForm.Show()
            Catch ex As Exception
                Debugger.Break()
            End Try
        End Sub

        ''Private Sub UsersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemUsers.Click
        ''    Dim childMdiForm As AATM.PresentationLayer.UserEntry
        ''    'Set the Parent Form of the Child window.
        ''    childMdiForm = New AATM.PresentationLayer.UserEntry  With {
        ''        .MdiParent = Me
        ''        }
        ''    'Display the new form.
        ''    childMdiForm.Show()
        ''End Sub
        'Private Sub SecurityObjectsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) _
        '    Handles ToolStripMenuItemSecurityObjects.Click
        '    Dim childMdiForm As SecurityObjectEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New SecurityObjectEntryTv With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

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

        'Private Sub SupplierVendorsToolStripMenuItem_Click(sender As Object, e As EventArgs) _
        '            Handles ToolStripMenuItemSuppliersVendors.Click
        '    ShowEntryForm(SupplierEntryTv)
        'End Sub

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
        '    message = MyMessage.CreateMessage("MsgCurrentPriceDisplay", "The current price is {0}{1:C2} per ounce.", "none")
        '    MyMessage.Show("MsgCurrentPriceDisplay", String.Format(message(0), parameter1, parameter2), message(1))
        '    MyMessage.Show("MsgNewMessageKey", "Message Information")
        '    MyMessage.Show("MsgNewMessageKey", "Message Information", "With Caption")
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

        'Private Sub AccountsPayableEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsPayableEntryToolStripMenuItem.Click
        '    Dim childMdiForm As ApJournalEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New ApJournalEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub AccountsReceivableEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountsReceivableEntryToolStripMenuItem.Click
        '    Dim childMdiForm As ArJournalEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New ArJournalEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem8.Click
        '    Dim childMdiForm As CheckDisbursementJournalEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New CheckDisbursementJournalEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub ItemsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemsToolStripMenuItem.Click
        '    Dim childMdiForm As PurchaseItemEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New PurchaseItemEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub CategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CategoriesToolStripMenuItem.Click
        '    Dim childMdiForm As CategoryEntryTv
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New CategoryEntryTv With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub ToolStripMenuItemTestForm_Click(sender As Object, e As EventArgs)
        '    Dim childMdiForm As CheckDisbursementJournalEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New CheckDisbursementJournalEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub SalesJournalEntryToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesJournalEntryToolStripMenuItem.Click
        '    Dim childMdiForm As SalesJournalEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New SalesJournalEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub AccountReconciliationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountReconciliationToolStripMenuItem.Click
        '    Dim childMdiForm As AccountReconciliationEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New AccountReconciliationEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

        'Private Sub PettyCashToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PettyCashToolStripMenuItem.Click
        '    Dim childMdiForm As PettyCashJournalEntry
        '    'Set the Parent Form of the Child window.
        '    childMdiForm = New PettyCashJournalEntry With {
        '        .MdiParent = Me
        '        }
        '    'Display the new form.
        '    childMdiForm.Show()
        'End Sub

    End Class

End Namespace