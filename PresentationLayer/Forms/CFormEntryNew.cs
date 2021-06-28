using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using AATM.Libraries;
using AATM.Libraries.AatmInterfaces;
using AATM.Libraries.CBaseControlsLibrary;
using AATM.Libraries.GlobalFuncNSub;
using AATM.Libraries.MessagingLibrary;
using AATM.PresentationLayer.Events;
using AATM.PresentationLayer.Presenters;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace AATM.PresentationLayer.Forms
{
    public partial class CFormEntryNew : IViewDataEntry
    {
        public CFormEntryNew() : base()
        {
            // This call is required by the designer.
            this.InitializeComponent();
            this.KeyPreview = true;
            this.DoubleBuffered = true;
            Ea = new EventAggregator();
            _btnFirst.Name = "btnFirst";
            _btnPrev.Name = "btnPrev";
            _btnNext.Name = "btnNext";
            _btnLast.Name = "btnLast";
            _btnDelete.Name = "btnDelete";
            _btnAdd.Name = "btnAdd";
            _btnEdit.Name = "btnEdit";
            _btnSave.Name = "btnSave";
            _btnFind.Name = "btnFind";
            _btnUndo.Name = "btnUndo";
            _btnDebug.Name = "btnDebug";
            _CutToolStripButton.Name = "CutToolStripButton";
            _CopyToolStripButton.Name = "CopyToolStripButton";
            _PasteToolStripButton.Name = "PasteToolStripButton";
            _btnPrint.Name = "btnPrint";
            _btnFilter.Name = "btnFilter";
            _btnArabic.Name = "btnArabic";
            _btnTranslate.Name = "btnTranslate";
            _btnOriginal.Name = "btnOriginal";
            _btnQuit.Name = "btnQuit";
            // Add any initialization after the InitializeComponent() call.

        }

        public Dictionary<string, object> MainFieldsDictionary = new Dictionary<string, object>();
        public BackgroundWorker<string> GotoTargetRecordWorker;
        public BackgroundWorker<string> ShowWaitForm;
        protected const bool TurnOff = false;
        protected static AutoResetEvent _resetEvent = new AutoResetEvent(false);
        protected Control FirstControl;
        protected string ParentFieldName = "";
        protected object RecordDateTimeStampValue;
        protected bool SingleData = false;
        private byte _debugSwitch = 0;
        private bool _addMode = false;
        private bool _editMode = false;
        private int _recordCount = 0;
        private int _recordPositionNumber = 0;
        private readonly NumberFormatInfo _nfi = new CultureInfo(CultureInfo.CurrentCulture.ToString(), false).NumberFormat;
        public EventAggregator Ea;
        private bool _editingMode = false;
        private bool _displayOnly = false;
        private bool _translatable = true;

        public delegate void SafeCallDelegate(ref Control controlObject, string textString);

        [DllImport("kernel32.dll")]
        private static extern int SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        [Bindable(true)]
        [Category("Properties")]
        [DefaultValue(typeof(bool))]
        [Description("Type here the Child Table name if any, otherwise leave it blank.")]
        [Browsable(true)]
        public string ChildTableName { get; set; } = "";
        public Array TableProperties { get; set; }
        protected string FormTitleCaption { get; set; } = "";

        public int RecordCount
        {
            get
            {
                return _recordCount;
            }

            set
            {
                _recordCount = value;
                this.tsbTotalRecords.Text = value.ToString();
                UpdateNavigationButtonDisplay(false, false);
            }
        }

        public int RecordPositionNumber
        {
            get
            {
                return _recordPositionNumber;
            }

            set
            {
                _recordPositionNumber = value;
                this.tsbCurrentRecord.Text = value.ToString();
                UpdateNavigationButtonDisplay(false, false);
            }
        }

        public bool QuitOnSave { get; set; }

        public void CheckDataChanges()
        {
        }

        public EventAggregator GetEventAggregator()
        {
            return Ea;
        }

        public bool AddMode
        {
            get
            {
                return _addMode;
            }

            set
            {
                _addMode = value;
                UpdateNavigationButtonDisplay(EditMode, value);
            }
        }

        public bool EditMode
        {
            get
            {
                return _editMode;
            }

            set
            {
                _editMode = value;
                UpdateNavigationButtonDisplay(value, AddMode);
            }
        }

        public void FindFieldNew(IFindableControl findableControl)
        {
            Ea.PublishEvent(new FindFieldRequested(findableControl));
        }

        public object GetMainFieldsDictionary()
        {
            return MainFieldsDictionary;
        }

        public void HideButton(ToolStripButton button)
        {
            button.Visible = false;
        }

        public void SetFormTitleCaption()
        {
            this.lblFormDescription.Text = this.Text;
            this.lblFormDescription.Left = 0;
            this.lblFormDescription.Width = this.Width;
            this.lblFormDescription.TextAlign = ContentAlignment.MiddleCenter;
        }

        public void ShowFormTitle()
        {
            this.lblFormDescription.Text = FormTitleCaption;
            this.lblFormDescription.Width = this.Width;
            this.lblFormDescription.Left = 0;
            this.lblFormDescription.TextAlign = ContentAlignment.MiddleCenter;
        }

        protected void TurnOffInputs()
        {
            Inputs(false);
            InputsTurnedOff();
        }

        protected void TurnOnInputs()
        {
            Inputs(true);
            InputsTurnedOn();
            if (FirstControl is object)
            {
                FirstControl.Focus();
            }
        }

        protected virtual void InputsTurnedOn()
        {
        }

        protected virtual void InputsTurnedOff()
        {
        }

        protected virtual void CreateDataSources()
        {
            // 
        }

        protected virtual void CreateMainFieldsDictionary()
        {
            // 
        }

        protected virtual void OnTextDisplayLanguageChanged()
        {
            CultureInfo.CurrentCulture = new CultureInfo(this.TextDisplayLanguage, false);
            if (CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)
            {
                GlobalVariables.RightToLeftLayout = true;
            }
            else
            {
                GlobalVariables.RightToLeftLayout = false;
            }

            CreateDataSources();
        }

        protected void UpdateNavigationButtonDisplay(bool editing, bool adding)
        {
            if (SingleData)
            {
                this.btnAdd.Visible = false;
                this.btnFind.Visible = false;
                HideNavigatorButtons = true;
            }
            else
            {
                if (AddMode | EditMode)
                {
                    this.btnFirst.Enabled = false;
                    this.btnPrev.Enabled = false;
                    this.btnNext.Enabled = false;
                    this.btnLast.Enabled = false;
                    this.btnEdit.Enabled = false;
                    this.btnAdd.Enabled = false;
                    this.btnDelete.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnFind.Enabled = false;
                    this.btnQuit.Enabled = false;
                    this.btnSave.Enabled = true;
                    this.btnUndo.Enabled = true;
                }
                else
                {
                    this.btnFirst.Enabled = true;
                    this.btnPrev.Enabled = true;
                    this.btnNext.Enabled = true;
                    this.btnLast.Enabled = true;
                    this.btnEdit.Enabled = true;
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = true;
                    this.btnPrint.Enabled = true;
                    this.btnFind.Enabled = true;
                    this.btnQuit.Enabled = true;
                    this.btnSave.Enabled = false;
                    this.btnUndo.Enabled = false;
                }

                if (RecordCount == 0)
                {
                    this.btnFirst.Enabled = false;
                    this.btnPrev.Enabled = false;
                    this.btnNext.Enabled = false;
                    this.btnLast.Enabled = false;
                    this.btnEdit.Enabled = false;
                    this.btnAdd.Enabled = true;
                    this.btnDelete.Enabled = false;
                    this.btnFind.Enabled = false;
                    this.btnPrint.Enabled = false;
                    this.btnUndo.Enabled = false;
                    this.btnSave.Enabled = false;
                }
                else if (RecordPositionNumber == 1)
                {
                    this.btnFirst.Enabled = false;
                    this.btnPrev.Enabled = false;
                    if (RecordCount == 1)
                    {
                        this.btnNext.Enabled = false;
                        this.btnLast.Enabled = false;
                    }
                }
                else if (RecordPositionNumber == RecordCount)
                {
                    this.btnNext.Enabled = false;
                    this.btnLast.Enabled = false;
                }
            }
        }

        private static void SetControlVisibility(ref Control cCtrl, bool controlVisible)
        {
            // if Visible is false, Don't show the controls content by masking content with '*' asterisk
            if (!controlVisible)
            {
                GlobalSubs.SetPropertyValue(cCtrl, "PasswordChar", Convert.ToChar("*"));
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            AddMode = true;
            PublishClickedButton(ButtonClicked.Add);
            Inputs(true);
            UpdateNavigationButtonDisplay(false, true);
        }

        private void BtnArabic_Click(object sender, EventArgs e)
        {
            SwitchUiLanguage(false);
        }

        private void BtnDebug_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 0)
            {
                _debugSwitch = 1;
                Debugger.Break();
                this.btnDebug.Checked = false;
            }
            else
            {
                _debugSwitch = 0;
                this.btnDebug.Checked = true;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.Delete);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.Edit);
            if (EditMode)
            {
                TurnOnInputs();
            }
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.Find);
        }

        private void BtnFirst_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.First);
        }

        private void BtnLast_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.Last);
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.Next);
        }

        private void BtnOriginal_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            SwitchUiLanguage(true);
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.Previous);
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            bool adding;
            if (AddMode)
            {
                adding = true;
            }
            else
            {
                adding = false;
            }

            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            var allControls = new List<Control>();
            foreach (Control cCtrl in this.FindControlRecursive(allControls, this))
            {
                if (cCtrl is DataGridView)
                {
                    DataGridView cGrid = (DataGridView)cCtrl;
                    cGrid.EndEdit();
                    GridValidator();
                }
            }

            if (Ea is object)
            {
                Ea.PublishEvent(new SaveDataRequested(this));
            }

            if (EditMode | AddMode)
            {
                TurnOnInputs();
            }
            else
            {
                TurnOffInputs();
                UpdateNavigationButtonDisplay(false, false);
                if (adding)
                {
                    if (Messaging.Show(true, "AskAddAnotherRecord", "Do you want to add another record?", "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        AddMode = true;
                        PublishClickedButton(ButtonClicked.Add);
                        Inputs(true);
                        UpdateNavigationButtonDisplay(false, true);
                    }
                }
            }

            if (QuitOnSave)
            {
                this.Close();
            }
        }

        private void PublishClickedButton(ButtonClicked buttonClicked)
        {
            if (Ea is object)
            {
                Ea.PublishEvent(new ViewButtonClicked(buttonClicked));
            }
        }

        protected virtual void GridValidator()
        {
            // 
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            if (_debugSwitch == 1)
            {
                Debugger.Break();
            }

            PublishClickedButton(ButtonClicked.Print);
        }

        private void BtnTranslate_Click(object sender, EventArgs e)
        {
            if (Conversions.ToBoolean(_debugSwitch))
            {
                Debugger.Break();
            }

            this.RunTranslator((object)this.VSystemViewIdNo);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            PublishClickedButton(ButtonClicked.Undo);
            if (EditMode | AddMode)
            {
                TurnOnInputs();
            }
            else
            {
                TurnOffInputs();
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            PublishClickedButton(ButtonClicked.Filter);
        }

        private void CFormEntry_Closing(object sender, CancelEventArgs e)
        {
            PublishClickedButton(ButtonClicked.Quit);
            if (this.CancelClose)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void CFormEntry_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void CFormEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            {
                if (this.btnSave.Enabled)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    PublishClickedButton(ButtonClicked.Save);
                    if (EditMode | AddMode)
                    {
                        TurnOnInputs();
                    }
                    else
                    {
                        TurnOffInputs();
                    }
                }
                else
                {
                    Interaction.Beep();
                }
            }
            else if (e.KeyCode == Keys.F2)
            {
                if (this.btnSave.Enabled)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;
                    PublishClickedButton(ButtonClicked.Edit);
                }
                else
                {
                    Interaction.Beep();
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = false;
            }
        }

        private void CFormEntry_Load(object sender, EventArgs e)
        {
            if (!(LicenseManager.UsageMode == LicenseUsageMode.Designtime))
            {
                TextDisplayLanguageChanged += this.OnTextDisplayLanguageChanged;
                this.TextDisplayLanguage = CultureInfo.CurrentCulture.Name;
                CreateDataSources();
                CreateMainFieldsDictionary();
                PublishClickedButton(ButtonClicked.Last);
                Inputs(false);
                if (Ea is object)
                {
                    Ea.PublishEvent(new EntryFormLoaded(this));
                }

                if (GlobalVariables.RightToLeftLayout)
                {
                    this.btnArabic.Visible = false;
                    this.btnOriginal.Visible = true;
                }
                else
                {
                    this.btnArabic.Visible = true;
                    this.btnOriginal.Visible = false;
                }

                if (FirstControl is object)
                {
                    FirstControl.Focus();
                }

                if ((GlobalVariables.UserName.ToLower() ?? "") != ($"arnel" ?? ""))
                {
                    this.HideButton(this.btnDebug);
                }

                if (SingleData | HideNavigatorButtons)
                {
                    this.btnFirst.Visible = false;
                    this.btnNext.Visible = false;
                    this.btnLast.Visible = false;
                    this.btnPrev.Visible = false;
                    this.tsbCurrentRecord.Visible = false;
                    this.tsbTotalRecords.Visible = false;
                    this.tssNavigator2.Visible = false;
                    this.tssnavigator1.Visible = false;
                    this.btnOf.Visible = false;
                }

                UpdateNavigationButtonDisplay(false, false);
            }
        }

        private void CloseForm()
        {
            if ((GlobalVariables.AppCurrentCultureInfo.Name ?? "") != (this.TextDisplayLanguage ?? ""))
            {
                this.TextDisplayLanguage = GlobalVariables.AppCurrentCultureInfo.Name;
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
            }

            this.Dispose();
        }

        private void CopyToolStripButton_Click(object sender, EventArgs e)
        {
            this.CopyText();
        }

        private void CutToolStripButton_Click(object sender, EventArgs e)
        {
            this.CutText();
        }

        public void Inputs(bool onOff)
        {
            var allCtrl = new List<Control>();
            foreach (var ctrl in this.FindControlRecursive(allCtrl, this))
            {
                if (ctrl is IEntryControl)
                {
                    GlobalSubs.SetPropertyValue(ctrl, "EditingMode", (object)onOff);
                }
            }

            if (onOff)
            {
                InputsTurnedOn();
            }
            else
            {
                InputsTurnedOff();
            }

            if (FirstControl is object)
            {
                FirstControl.Focus();
            }
        }

        private void OnBeforeLoad()
        {
            SetFormTitleCaption();
        }

        private void PasteToolStripButton_Click(object sender, EventArgs e)
        {
            this.PasteText();
        }

        protected virtual void SwitchUiLanguage(bool originalUi)
        {
            if (Conversions.ToBoolean(_debugSwitch))
            {
                Debugger.Break();
            }

            if (originalUi)
            {
                this.TextDisplayLanguage = GlobalVariables.DefaultUnmirroredCultureInfoStr;
            }
            else
            {
                this.TextDisplayLanguage = GlobalVariables.DefaultMirroredCultureInfoStr;
            }

            this.TranslateForm();
            PublishClickedButton(ButtonClicked.Undo);
            this.btnArabic.Visible = originalUi;
            this.btnOriginal.Visible = !originalUi;
            RecordPositionNumber = RecordPositionNumber;
        }

        protected virtual bool DataIsValid()
        {
            Debugger.Break();
            return false;
        }

        public static void EnableDoubleBuff(Control cont)
        {
            var DemoProp = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            DemoProp.SetValue(cont, true, null);
        }

        public bool HideNavigatorButtons { get; set; }
        public bool IgnoreTextBoxNumParserMessage { get; set; }

        protected T TextBoxNumParser<T>(ref CTextBox control) where T : struct
        {
            T retValue;
            try
            {
                retValue = Parser<T>.Parser(control.Text);
                this.Text = retValue.ToString();
            }
            catch (Exception ex)
            {
                if (!IgnoreTextBoxNumParserMessage)
                {
                    string description;
                    if (control is ILinkedLabel)
                    {
                        description = Conversions.ToString(((ILinkedLabel)control).GetControlDescription());
                    }
                    else
                    {
                        description = control.Name;
                    }
                }

                retValue = Parser<T>.Parser("0");
            }

            return retValue;
        }

        protected void CreateDataSource(string tableName, ref Control control)
        {
            if (Ea is object)
            {
                Ea.PublishEvent(new GetDataSource(tableName, ref control));
            }
        }

        protected void GetLookUpData(string tableName, string targetProperty)
        {
            Control argview = (Control)this;
            Ea.PublishEvent(new GetLookupDataRequested(tableName, ref argview, targetProperty));
        }

        public void CreateEnumDataSource<TE>(ref CaComboBox comboControl)
        {
            var dataList = new List<ClassesLibrary.LookupData>();
            foreach (var c in Enum.GetValues(typeof(TE)))
            {
                var data = new ClassesLibrary.LookupData()
                {
                    IdNo = Conversions.ToInteger(c),
                    Code = GlobalFunctions.EnumToCode(c),
                    Name = Messaging.TranslateCaption(c.ToString().SplitCamelCase())
                };
                dataList.Add(data);
            }

            comboControl.DataSource = dataList;
        }
    }
}