using System.Collections.Generic;
using System.ComponentModel;
using AATM.Libraries.LocalizationUtilities.Design;

namespace AATM.Libraries.LocalizationUtilities
{
    /// <summary>
    ///     A component that can be used to localize various content, e.g. message boxes.
    /// </summary>
    [Designer(typeof(LocalizableContentDesigner))]
    public class LocalizableContent : Component
    {
        /// <summary>
        ///     A collection of <see cref="LocalizableMessage" />s.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [MergableProperty(false)]
        public List<LocalizableMessage> Messages { get; } = new List<LocalizableMessage>();

        /// <summary>
        ///     A collection of <see cref="LocalizableMessageBox" />s.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [MergableProperty(false)]
        public List<LocalizableMessageBox> MessageBoxes { get; } = new List<LocalizableMessageBox>();
    }
}