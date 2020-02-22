using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace AATM.Libraries.LocalizationUtilities.Design
{
    /// <summary>
    ///     Contains utility methods for <see cref="System.ComponentModel" />
    ///     development.
    /// </summary>
    public static class ComponentDesignUtility
    {
        /// <summary>
        ///     Get next component name for a given container.
        /// </summary>
        /// <param name="componentType">Type of component.</param>
        /// <param name="container">Container that component will reside in.</param>
        /// <returns>Unique name (in the context of the parent container).</returns>
        public static string GetNextComponentName(Type componentType, IEnumerable container)
        {
            // build up a dictionary for disqualifying names
            var h = new Hashtable();
            foreach (IComponent c in container) h[c.Site.Name] = null;

            var typeNameShort = componentType.Name;

            // make the type name camel case:
            typeNameShort = string.Format("{0}{1}",
                char.ToLower(typeNameShort[0]), typeNameShort.Substring(1));
            string name;
            var i = 0;
            do
            {
                i++;
                name = string.Format("_{0}{1}", typeNameShort, i);
            } while (h.ContainsKey(name));

            return name;
        }

        /// <summary>
        ///     Adapted from
        ///     http://www.dotnetmonster.com/Uwe/Forum.aspx/winform-design-time/825/Setting-GenerateMember-property-from-ControlDesigner.
        /// </summary>
        /// <param name="service">Service (from designer).</param>
        /// <param name="component">Component.</param>
        /// <param name="value">Generate property value.</param>
        /// <returns><c>true</c> if property set, <c>false</c> otherwise.</returns>
        public static bool SetGenerateMemberProperty(
            IExtenderListService service,
            Component component,
            bool value)
        {
            var provider =
                Array.Find(
                    service.GetExtenderProviders(),
                    item => item.GetType().FullName ==
                            "System.ComponentModel.Design.Serialization.CodeDomDesignerLoader+ModifiersExtenderProvider");

            var methodInfo =
                provider.GetType().GetMethod(
                    "SetGenerateMember", BindingFlags.Public |
                                         BindingFlags.Instance);

            if (methodInfo != null)
            {
                methodInfo.Invoke(
                    provider, new object[]
                    {
                        component,
                        value
                    });
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Create dummy arguments (e.g. for passing to a format string).
        /// </summary>
        /// <returns>Dummy arguments.</returns>
        public static object[] CreateDummyArgs()
        {
            var dummyArgs = new List<string>();
            for (var i = 1; i <= 100; i++) dummyArgs.Add("<<Argument #i>>");
            return dummyArgs.ToArray();
        }

        /// <summary>
        ///     Create a form to host a single control.
        /// </summary>
        /// <param name="control">Control.</param>
        /// <returns>Form.</returns>
        public static Form CreateWrapperForm(Control control)
        {
            var form = new Form {StartPosition = FormStartPosition.CenterParent, Size = new Size(400, 200)};
            control.Dock = DockStyle.Fill;
            form.Controls.Add(control);

            return form;
        }
    }
}