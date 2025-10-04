using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Winforms.My.Resources;

namespace AATM.UI.Winforms.Localization
{

    public sealed class ControlLocalizer
    {
        private ControlLocalizer()
        {
        }

        // Wrapper indices & sentinel
        private const int IDX_ORIGINAL = 0;
        private const int IDX_USERDATA = 1;
        private const int IDX_SENTINEL = 2;
        private const string LOC_SENTINEL = "__LOC_SENTINEL__";
        private static string _languageCode;
        #region Public Orchestrators
        public static void TranslateControls(Control root, IDictionary<string, string> translationDict, string languageCode, Action<ToolStripButton> toolStripButtonImageTranslator = null, ResourceManager imageResourceManager = null)
        {
            _languageCode = languageCode;
            if (root is null || translationDict is null)
                return;
            var q = new Queue<Control>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                TranslateSingleControl(current, translationDict, toolStripButtonImageTranslator, imageResourceManager);
                foreach (Control child in current.Controls)
                    q.Enqueue(child);
            }
        }

        public static void ResetControls(Control root, Action<ToolStripButton> resetToolStripButtonImage = null, ResourceManager imageResourceManager = null)
        {
            if (root is null)
                return;
            var q = new Queue<Control>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                ResetSingleControl(current, resetToolStripButtonImage, imageResourceManager);
                foreach (Control child in current.Controls)
                    q.Enqueue(child);
            }
        }
        #endregion

        #region Single Control Translation / Reset
        private static void TranslateSingleControl(Control ctrl, IDictionary<string, string> translationDict, Action<ToolStripButton> toolStripButtonImageTranslator, ResourceManager imageResourceManager)
        {

            if (IsStandardTextControl(ctrl) && !(ctrl is TabPage) && !(ctrl is TabControl))
            {
                EnsureWrapped(ctrl);
                ApplyTextTranslation(ctrl, translationDict);
            }

            if (ctrl is MenuStrip)
            {
                TranslateMenuStrip((MenuStrip)ctrl, translationDict, applyRtl: false, rightToLeft: CultureInfo.CurrentCulture.TextInfo.IsRightToLeft, font: default, buttonImageTranslator: toolStripButtonImageTranslator, imageResourceManager: imageResourceManager);
                return;
            }
            else if (ctrl is ToolStrip)
            {
                TranslateToolStrip((ToolStrip)ctrl, translationDict, toolStripButtonImageTranslator, imageResourceManager);
                return;
            }

            if (ctrl is DataGridView)
            {
                TranslateDataGridView((DataGridView)ctrl, translationDict);
                return;
            }
            else if (ctrl is DataGrid)
            {
                TranslateDataGrid((DataGrid)ctrl, translationDict);
                return;
            }

            if (ctrl.GetType().Name.Equals("CTabControl", StringComparison.OrdinalIgnoreCase) || ctrl is TabControl)
            {
                TranslateTabControl((TabControl)ctrl, translationDict);
            }

            if (ctrl.GetType().Name.Equals("CButton", StringComparison.OrdinalIgnoreCase))
            {
                TranslateCButton(ctrl, imageResourceManager);
            }
        }

        private static void ResetSingleControl(Control ctrl, Action<ToolStripButton> resetToolStripButtonImage, ResourceManager imageResourceManager)
        {

            if (ctrl is MenuStrip)
            {
                ResetMenuStripToOriginalTags((MenuStrip)ctrl);
                return;
            }
            else if (ctrl is ToolStrip)
            {
                ResetToolStripToOriginalTags((ToolStrip)ctrl);
                if (resetToolStripButtonImage is not null)
                {
                    foreach (ToolStripItem it in ((ToolStrip)ctrl).Items)
                    {
                        ToolStripButton btn = it as ToolStripButton;
                        if (btn is not null)
                            resetToolStripButtonImage(btn);
                    }
                }
                return;
            }

            if (ctrl is DataGridView)
            {
                ResetDataGridView((DataGridView)ctrl);
                return;
            }
            else if (ctrl is DataGrid)
            {
                ResetDataGrid((DataGrid)ctrl);
                return;
            }

            if (ctrl.GetType().Name.Equals("CButton", StringComparison.OrdinalIgnoreCase))
            {
                ResetCButton(ctrl, imageResourceManager);
            }

            if (ctrl is TabControl)
            {
                foreach (TabPage page in ((TabControl)ctrl).TabPages)
                    ResetFromWrapper(page);
            }

            if (IsStandardTextControl(ctrl))
            {
                ResetFromWrapper(ctrl);
            }
        }
        #endregion

        #region Wrapper / Preservation / Lookup
        // Ensure Tag is wrapped with our sentinel, preserving any existing value (including Object()).
        private static void EnsureWrapped(Control ctrl)
        {
            // Already wrapped?
            if (IsWrapped(ctrl.Tag))
            {
                // If original slot empty, fill it
                object[] arr = (object[])ctrl.Tag;
                if (arr[IDX_ORIGINAL] is null || string.IsNullOrEmpty(arr[IDX_ORIGINAL].ToString()))
                {
                    arr[IDX_ORIGINAL] = string.IsNullOrEmpty(ctrl.Text) ? ctrl.Name : ctrl.Text;
                }
                return;
            }

            var originalText = string.IsNullOrEmpty(ctrl.Text) ? ctrl.Name : ctrl.Text;

            if (ctrl.Tag is null)
            {
                ctrl.Tag = new object[] { originalText, null, LOC_SENTINEL };
            }
            else
            {
                // If Tag was Object(), preserve entire array as user payload
                object userPayload = ctrl.Tag;
                ctrl.Tag = new object[] { originalText, userPayload, LOC_SENTINEL };
            }
        }

        private static bool IsWrapped(object tagObj)
        {
            if (tagObj is null)
                return false;
            if (tagObj is object[])
            {
                object[] arr = (object[])tagObj;
                if (arr.Length >= 3 && arr[arr.Length - 1] is string && string.Equals(arr[arr.Length - 1].ToString(), LOC_SENTINEL, StringComparison.Ordinal))
                {
                    return true;
                }
            }
            return false;
        }

        private static string GetOriginal(Control ctrl)
        {
            if (!IsWrapped(ctrl.Tag))
                return null;
            object[] arr = (object[])ctrl.Tag;
            return (arr[IDX_ORIGINAL] ?? null)?.ToString();
        }

        private static object GetUserPayload(Control ctrl)
        {
            if (!IsWrapped(ctrl.Tag))
                return ctrl.Tag;
            object[] arr = (object[])ctrl.Tag;
            return arr[IDX_USERDATA];
        }

        private static string GetLookupKey(Control ctrl)
        {

            if (_languageCode == "en-US")
            {
                return GetLookupKeyOriginal(ctrl);
            }
            else
            {
                //if (!IsWrapped(ctrl.Tag))
                //{
                //    // Legacy behavior: plain Tag value or Name
                //    if (ctrl.Tag is null)
                //        return ctrl.Name;
                //    return ctrl.Tag.ToString();
                //}

                //string original = GetOriginal(ctrl);
                //var userPayload = GetUserPayload(ctrl);

                //// If user payload is a non-empty string treat it as translation key
                //string userKey = userPayload as string;
                //if (!string.IsNullOrEmpty(userKey))
                //    return userKey;

                //// Fallback to original text
                //if (!string.IsNullOrEmpty(original))
                //    return original;

                return ctrl.Name;
            }
        }

        private static string GetLookupKeyOriginal(Control ctrl)
        {
            if (!IsWrapped(ctrl.Tag))
            {
                // Legacy behavior: plain Tag value or Name
                if (ctrl.Tag is null)
                    return ctrl.Name;
                return ctrl.Tag.ToString();
            }

            string original = GetOriginal(ctrl);
            var userPayload = GetUserPayload(ctrl);

            // If user payload is a non-empty string treat it as translation key
            string userKey = userPayload as string;
            if (!string.IsNullOrEmpty(userKey))
                return userKey;

            // Fallback to original text
            if (!string.IsNullOrEmpty(original))
                return original;

            return ctrl.Name;
        }

        private static void ApplyTextTranslation(Control ctrl, IDictionary<string, string> translationDict)
        {
            string key = GetLookupKey(ctrl);
            string translated = null;
            if (translationDict.TryGetValue(key, out translated))
            {
                if (ctrl.Text != translated)
                    ctrl.Text = translated;
            }
            else
            {
                ResetFromWrapper(ctrl);
            }
        }

        private static void ResetFromWrapper(Control ctrl)
        {
            string orig = GetOriginal(ctrl);
            if (!string.IsNullOrEmpty(orig) && ctrl.Text != orig)
            {
                ctrl.Text = orig;
            }
        }
        #endregion

        #region Classification
        private static bool IsStandardTextControl(Control ctrl)
        {
            return ctrl is Label || ctrl is Button || ctrl is CheckBox || ctrl is RadioButton || ctrl is GroupBox || ctrl is TabPage;
        }
        #endregion

        #region Custom Button (CButton via reflection)
        private static void TranslateCButton(Control ctrl, ResourceManager imageResourceManager)
        {
            var origProp = ctrl.GetType().GetProperty("OriginalImageName");
            if (origProp is null)
                return;
            string original = origProp.GetValue(ctrl, default) as string;
            if (string.IsNullOrWhiteSpace(original))
                return;
            string baseKey = "btn" + original.ToLower();
            string key = CultureInfo.CurrentCulture.TextInfo.IsRightToLeft ? baseKey + "_" + CultureInfo.CurrentCulture.Name.Replace("-", "_").ToLower() : baseKey;
            var img = ResolveImage(imageResourceManager, key, baseKey);
            if (img is not null)
                ctrl.GetType().GetProperty("Image")?.SetValue(ctrl, img, default);
        }

        private static void ResetCButton(Control ctrl, ResourceManager imageResourceManager)
        {
            var origProp = ctrl.GetType().GetProperty("OriginalImageName");
            if (origProp is null)
                return;
            string original = origProp.GetValue(ctrl, null) as string;
            if (string.IsNullOrWhiteSpace(original))
                return;
            string baseKey = "btn" + original.ToLower();
            var img = ResolveImage(imageResourceManager, baseKey);
            if (img is not null)
                ctrl.GetType().GetProperty("Image")?.SetValue(ctrl, img, default);
        }

        private static Image ResolveImage(ResourceManager rm, params string[] keys)
        {
            var mgr = rm ?? Resources.ResourceManager;
            foreach (var k in keys)
            {
                if (string.IsNullOrWhiteSpace(k))
                    continue;
                var obj = mgr.GetObject(k);
                if (obj is not null)
                    return obj as Image;
            }
            return default;
        }
        #endregion

        #region Tabs
        private static void TranslateTabControl(TabControl tc, IDictionary<string, string> translationDict)
        {
            if (tc is null)
                return;
            foreach (TabPage page in tc.TabPages)
            {
                EnsureWrapped(page);
                ApplyTextTranslation(page, translationDict);
            }
        }
        #endregion

        #region DataGrid / DataGridView
        private static void TranslateDataGridView(DataGridView dgv, IDictionary<string, string> translationDict)
        {
            if (dgv is null)
                return;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                var key = col.Tag is not null ? col.Tag.ToString() : col.Name;
                string translated = null;
                if (translationDict.TryGetValue(Conversions.ToString(key), out translated))
                {
                    col.HeaderText = translated;
                }
                else if (col.Tag is not null)
                {
                    col.HeaderText = col.Tag.ToString();
                }
            }
        }

        private static void ResetDataGridView(DataGridView dgv)
        {
            if (dgv is null)
                return;
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Tag is null)
                {
                    col.Tag = col.HeaderText;
                }
                else
                {
                    col.HeaderText = col.Tag.ToString();
                }
            }
        }

        private static void TranslateDataGrid(DataGrid grid, IDictionary<string, string> translationDict)
        {
            if (grid is null)
                return;
            var key = grid.Tag is not null ? grid.Tag.ToString() : grid.Name;
            string translated = null;
            if (translationDict.TryGetValue(Conversions.ToString(key), out translated))
            {
                grid.CaptionText = translated;
            }
            else if (grid.Tag is not null)
            {
                grid.CaptionText = grid.Tag.ToString();
            }
        }

        private static void ResetDataGrid(DataGrid grid)
        {
            if (grid is null)
                return;
            if (grid.Tag is not null)
                grid.CaptionText = grid.Tag.ToString();
        }
        #endregion

        #region ToolStrip / MenuStrip
        public static void TranslateToolStrip(ToolStrip tool, IDictionary<string, string> translationDict, Action<ToolStripButton> buttonImageTranslator = null, ResourceManager imageResourceManager = null)
        {
            if (tool is null || translationDict is null)
                return;
            foreach (ToolStripItem item in tool.Items)
                TranslateToolStripItem(item, translationDict, buttonImageTranslator, imageResourceManager);
        }

        public static void TranslateMenuStrip(MenuStrip menu, IDictionary<string, string> translationDict, bool applyRtl = false, bool rightToLeft = false, Font font = default, Action<ToolStripButton> buttonImageTranslator = null, ResourceManager imageResourceManager = null)
        {
            if (menu is null || translationDict is null)
                return;
            foreach (ToolStripItem item in menu.Items)
                TranslateToolStripItem(item, translationDict, buttonImageTranslator, imageResourceManager);
            if (applyRtl)
                menu.RightToLeft = rightToLeft ? System.Windows.Forms.RightToLeft.Yes : System.Windows.Forms.RightToLeft.No;
            if (font is not null)
                menu.Font = font;
            menu.Refresh();
        }

        public static void TranslateContextMenuStrip(ContextMenuStrip ctx, IDictionary<string, string> translationDict, Action<ToolStripButton> buttonImageTranslator = null, ResourceManager imageResourceManager = null)
        {
            if (ctx is null || translationDict is null)
                return;
            foreach (ToolStripItem item in ctx.Items)
                TranslateToolStripItem(item, translationDict, buttonImageTranslator, imageResourceManager);
            ctx.Refresh();
        }

        public static void TranslateToolStripItem(ToolStripItem item, IDictionary<string, string> translationDict, Action<ToolStripButton> buttonImageTranslator = null, ResourceManager imageResourceManager = null)
        {
            EnsureWrappedToolStripItem(item);
            if (item is null || translationDict is null)
                return;
            string textKey = null;
            string tipKey = null;
            GetKeysFromTag(item, ref textKey, ref tipKey);

            if (string.IsNullOrWhiteSpace(textKey))
            {
                textKey = Conversions.ToString(!string.IsNullOrWhiteSpace(item.Text) ? item.Text : item.Name);
            }
            if (string.IsNullOrWhiteSpace(tipKey))
                tipKey = item.ToolTipText;

            string translated = null;
            if (translationDict.TryGetValue(textKey, out translated) && item.Text != translated)
            {
                item.Text = translated;
            }
            if (!string.IsNullOrWhiteSpace(tipKey) && translationDict.TryGetValue(tipKey, out translated) && item.ToolTipText != translated)
            {
                item.ToolTipText = translated;
            }

            ToolStripButton btn = item as ToolStripButton;
            if (btn is not null && buttonImageTranslator is not null)
            {
                buttonImageTranslator(btn);
            }

            ToolStripDropDownItem dd = item as ToolStripDropDownItem;
            if (dd is not null)
            {
                foreach (ToolStripItem subItem in dd.DropDownItems)
                    TranslateToolStripItem(subItem, translationDict, buttonImageTranslator, imageResourceManager);
            }
        }

        private static void EnsureWrappedToolStripItem(ToolStripItem item)
        {
            if (item.Tag is null || !(item.Tag is object[]) || !IsWrapped(item.Tag))
            {
                var originalText = string.IsNullOrEmpty(item.Text) ? item.Name : item.Text;
                var originalTip = string.IsNullOrEmpty(item.ToolTipText) ? (object)null : item.ToolTipText;
                item.Tag = new object[] { originalText, originalTip, LOC_SENTINEL };
            }
        }

        public static void ResetToolStripToOriginalTags(ToolStrip tool)
        {
            if (tool is null)
                return;
            foreach (ToolStripItem item in tool.Items)
                ResetItemToOriginalTag(item);
        }

        public static void ResetMenuStripToOriginalTags(MenuStrip menu)
        {
            if (menu is null)
                return;
            foreach (ToolStripItem item in menu.Items)
                ResetItemToOriginalTag(item);
            menu.Refresh();
        }

        public static void TranslateToolStripButtonImage(ToolStripButton btn)
        {
            if (btn is null)
                return;
            var resourceName = btn.Name.ToLower();
            if (CultureInfo.CurrentCulture.TextInfo.IsRightToLeft)
            {
                resourceName += "_" + CultureInfo.CurrentCulture.Name.Replace("-", "_").ToLower();
            }
            else if (btn.Image is not null && btn.Image.Tag is not null)
            {
                resourceName = btn.Image.Tag.ToString();
            }
            Image img = Resources.ResourceManager.GetObject(resourceName) as Image;
            if (img is not null)
                btn.Image = img;
        }

        public static void ResetToolStripButtonImage(ToolStripButton btn)
        {
            if (btn is null)
                return;
            var resourceName = btn.Name.ToLower();
            Image img = Resources.ResourceManager.GetObject(resourceName) as Image;
            if (img is not null)
                btn.Image = img;
        }

        private static void GetKeysFromTag(ToolStripItem item, ref string textKey, ref string tipKey)
        {
            textKey = null;
            tipKey = null;
            if (item.Tag is null)
                return;
            if (item.Tag is object[])
            {
                object[] arr = (object[])item.Tag;
                if (arr.Length > 0 && arr[0] is not null)
                    textKey = arr[0].ToString();
                if (arr.Length > 1 && arr[1] is not null)
                    tipKey = arr[1].ToString();
            }
            else
            {
                textKey = item.Tag.ToString();
            }
        }

        private static void ResetItemToOriginalTag(ToolStripItem item)
        {
            if (item is null)
                return;
            if (item.Tag is not null && item.Tag is object[])
            {
                object[] arr = (object[])item.Tag;
                if (arr.Length > 0 && arr[0] is not null)
                    item.Text = Conversions.ToString(arr[0]);
                if (arr.Length > 1 && arr[1] is not null)
                    item.ToolTipText = Conversions.ToString(arr[1]);
            }
            else if (item.Tag is not null)
            {
                item.Text = item.Tag.ToString();
                item.ToolTipText = "";
            }
            ToolStripDropDownItem dd = item as ToolStripDropDownItem;
            if (dd is not null)
            {
                foreach (ToolStripItem subItem in dd.DropDownItems)
                    ResetItemToOriginalTag(subItem);
            }
        }


        #endregion

        // ---------------------------------------------------------------------------------
        // NEW: Central Right-To-Left applier so forms don't re-implement layout toggling.
        // ---------------------------------------------------------------------------------
        /// <summary>
        /// Applies (or clears) a Right-To-Left layout on the root control (Form or container)
        /// and its immediate children, ensuring MenuStrip instances are also flipped using
        /// existing TranslateMenuStrip infrastructure (without changing any text).
        /// </summary>
        /// <param name="root">Root form or container.</param>
        /// <param name="languageCode">
        /// The BCP-47 culture code (e.g. "ar-SA", "en-US"). Only used to infer RTL if <paramref name="rtlOverride"/> is null.
        /// </param>
        /// <param name="rtlOverride">
        /// Optional explicit RTL flag. If null, culture's TextInfo.IsRightToLeft is used.
        /// </param>
        public static void ApplyRightToLeftLayout(Control root, string languageCode, bool? rtlOverride = null)
        {
            if (root == null)
                return;

            bool rtl = false;
            if (rtlOverride.HasValue)
            {
                rtl = rtlOverride.Value;
            }
            else
            {
                try
                {
                    if (!string.IsNullOrWhiteSpace(languageCode))
                    {
                        var culture = new CultureInfo(languageCode);
                        rtl = culture.TextInfo.IsRightToLeft;
                    }
                }
                catch
                {
                    // Fallback: keep rtl = false
                }
            }

            root.SuspendLayout();
            try
            {
                root.RightToLeft = rtl ? RightToLeft.Yes : RightToLeft.No;

                // Only forms have RightToLeftLayout
                var form = root as Form;
                if (form != null)
                    form.RightToLeftLayout = rtl;

                // Flip each direct child; let them inherit where possible
                foreach (Control child in root.Controls)
                {
                    // Preserve explicit Inherit where developer set it; only force if different
                    if (child.RightToLeft != RightToLeft.Inherit)
                        child.RightToLeft = RightToLeft.Inherit;
                }

                // Handle any MenuStrip(s) using existing API so internal items follow direction.
                // Empty dictionary = no text changes, only RTL application.
                var empty = new Dictionary<string, string>();
                foreach (var menu in root.Controls.OfType<MenuStrip>())
                {
                    TranslateMenuStrip(menu, empty, applyRtl: true, rightToLeft: rtl);
                }
            }
            finally
            {
                root.ResumeLayout(true);
            }
        }
    }
}