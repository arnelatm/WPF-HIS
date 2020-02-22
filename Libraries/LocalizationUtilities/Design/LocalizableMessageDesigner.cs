using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace AATM.Libraries.LocalizationUtilities.Design
{
    /// <summary>
    ///     Designer for <see cref="LocalizableMessage" />.
    /// </summary>
    internal class LocalizableMessageDesigner : ComponentDesigner
    {
        private LocalizableMessage _localizableMessage;

        /// <summary>
        ///     Override to support preview of message box.
        /// </summary>
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (_localizableMessage == null) return base.Verbs;
                return new DesignerVerbCollection(new[] { new DesignerVerb("Preview...", OnPreviewMessageBox) });
            }
        }

        /// <summary>
        ///     See <see cref="ComponentDesigner.Initialize" />.
        /// </summary>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            _localizableMessage = (LocalizableMessage)component;
        }

        private void OnPreviewMessageBox(object sender, EventArgs e)
        {
            using (var label = new Label())
            using (var form = ComponentDesignUtility.CreateWrapperForm(label))
            {
                label.Text = _localizableMessage.Value == null
                    ? null
                    : string.Format(_localizableMessage.Value, ComponentDesignUtility.CreateDummyArgs());

                label.Dock = DockStyle.Fill;
                form.Controls.Add(label);
                form.ShowDialog(null);
            }
        }
    }
}