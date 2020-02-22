using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using AATM.Libraries.LocalizationUtilities.Design;

namespace AATM.Libraries.LocalizationUtilities
{
    /// <summary>
    ///     A component that can be used to represent a message box that is localizable.
    /// </summary>
    [ToolboxItem(false)]
    [DesignTimeVisible(false)]
    [DefaultProperty("Text")]
    [Designer(typeof(LocalizableMessageBoxDesigner))]
    public partial class LocalizableMessageBox : Component
    {
        /// <summary>
        ///     Constructor.
        /// </summary>
        public LocalizableMessageBox()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     The type of message box.
        /// </summary>
        [Category("MessageType")]
        [DefaultValue(MessageBoxType.Info)]
        public MessageBoxType Type { get; set; } = MessageBoxType.Info;

        /// <summary>
        ///     The string to display in the message header.
        /// </summary>
        [Category("MessageStrings")]
        [Description("The caption header for the message.")]
        [DefaultValue(null)]
        [Localizable(true)]
        public string Caption { get; set; }

        /// <summary>
        ///     The detailed message to display.
        /// </summary>
        [Category("MessageStrings")]
        [Description("The details of message, shown below the caption, can be a format string.")]
        [Editor(
            "System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(UITypeEditor))]
        [DefaultValue(null)]
        [Localizable(true)]
        public string Text { get; set; }

        /// <summary>
        ///     Get / set the buttons to show.
        /// </summary>
        [Category("MessageButtons")]
        [Description("The buttons to show.")]
        [DefaultValue(MessageBoxButtons.OK)]
        public MessageBoxButtons Buttons { get; set; } = MessageBoxButtons.OK;

        /// <summary>
        ///     Get / set the default button.
        /// </summary>
        [Category("MessageButtons")]
        [Description("The default button.")]
        [DefaultValue(MessageBoxDefaultButton.Button1)]
        public MessageBoxDefaultButton DefaultButton { get; set; } = MessageBoxDefaultButton.Button1;

        /// <summary>
        ///     Show the localized message box.
        /// </summary>
        /// <param name="owner">Parent owner.</param>
        /// <param name="textFormatStringParameters">Parameters if <c>Text</c> is a format string.</param>
        /// <returns>Dialog result.</returns>
        public DialogResult Show(IWin32Window owner, params object[] textFormatStringParameters)
        {
            return MessageBox.Show(
                owner,
                Text == null ? null : string.Format(Text, textFormatStringParameters),
                Caption,
                Buttons,
                MessageBoxTypeUtility.GetIcon(Type),
                DefaultButton);
        }
    }
}