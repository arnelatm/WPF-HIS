using System;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace AATM.Libraries.LocalizationUtilities.Design
{
    /// <summary>
    ///     Designer for <see cref="LocalizableMessageBox" />.
    /// </summary>
    internal class LocalizableMessageBoxDesigner : ComponentDesigner
    {
        private LocalizableMessageBox _localizableMessageBox;

        /// <summary>
        ///     Override to support preview of message box.
        /// </summary>
        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (_localizableMessageBox == null) return base.Verbs;
                return new DesignerVerbCollection(new[] { new DesignerVerb("Preview...", OnPreviewMessageBox) });
            }
        }

        /// <summary>
        ///     See <see cref="ComponentDesigner.Initialize" />.
        /// </summary>
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            _localizableMessageBox = (LocalizableMessageBox)component;
        }

        private void OnPreviewMessageBox(object sender, EventArgs e)
        {
            _localizableMessageBox.Show(null, ComponentDesignUtility.CreateDummyArgs());
        }
    }
}