using System.ComponentModel;
using System.Drawing.Design;
using AATM.Libraries.LocalizationUtilities.Design;

namespace AATM.Libraries.LocalizationUtilities
{
    /// <summary>
    ///     A component that can be used to represent a message box that is localizable.
    /// </summary>
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    [DefaultProperty("Value")]
    [Designer(typeof(LocalizableMessageDesigner))]
    public partial class LocalizableMessage : Component
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public LocalizableMessage()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     The detailed message to display.
        /// </summary>
        [Category("MessageStrings")]
        [Description("The message, shown below the caption, can be a format string.")]
        [Editor(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(UITypeEditor))]
        [DefaultValue(null)]
        [Localizable(true)]
        public string Value { get; set; } = null;
    }
}