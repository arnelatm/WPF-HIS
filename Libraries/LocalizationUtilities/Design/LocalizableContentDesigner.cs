using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace AATM.Libraries.LocalizationUtilities.Design
{
    /// <summary>
    ///     Designer for <see cref="LocalizableContent" />.
    /// </summary>
    internal class LocalizableContentDesigner : ComponentDesigner
    {
        private LocalizableContent _localizableContent;

        /// <summary>
        ///     This method is overridden so that the various sub-components are
        ///     shown in Document Outline as being owned by the
        ///     <see cref="LocalizableContent" /> component.
        /// </summary>
        public override ICollection AssociatedComponents
        {
            get
            {
                if (_localizableContent == null) return base.AssociatedComponents;

                var list = new ArrayList();
                list.AddRange(_localizableContent.Messages);
                list.AddRange(_localizableContent.MessageBoxes);

                // sort the collection by type, then name
                var sortedList = new SortedList();
                foreach (IComponent component in list)
                    sortedList.Add(
                        string.Format(
                            "{0}{1}",
                            component.GetType(), component.Site.Name), component);

                return sortedList.Values;
            }
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                if (_localizableContent == null) return base.Verbs;
                return new DesignerVerbCollection(new[]
                {
                    new DesignerVerb("Add Message...", OnAddLocalizableMessage),
                    new DesignerVerb("Add Message Box...", OnAddLocalizableMessageBox)
                });
            }
        }

        /// <summary>
        ///     See <see cref="ComponentDesigner.Initialize" />.
        /// </summary>
        public override void Initialize(IComponent component)
        {
            string existingComponentName = null;
            foreach (IComponent c in component.Site.Container.Components)
                if (c is LocalizableContent && c != component)
                    existingComponentName = c.Site.Name;

            if (existingComponentName != null)
                throw new Exception(string.Format(
                    "Cannot host more than 1 LocalizableContent, add localizable content to existing component ({0})",
                    existingComponentName));

            _localizableContent = (LocalizableContent)component;

            base.Initialize(component);

            var changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            if (changeService != null) changeService.ComponentRemoved += OnComponentRemoved;
        }

        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            // no reason to create a member since container has no use aside from logical grouping at design time
            ComponentDesignUtility.SetGenerateMemberProperty(
                (IExtenderListService)GetService(typeof(IExtenderListService)),
                _localizableContent,
                false);

            base.InitializeNewComponent(defaultValues);

            // CAP: Apparently, when you remove GenerateMember from the list of properties
            // in PostFilterProperties, it generates the member, even if you set the value to
            // false, so don't bother removing the properties, just default the value to false.
            //properties.Remove("GenerateMember");
            //properties.Remove("Modifiers");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            var changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            if (changeService != null) changeService.ComponentRemoved -= OnComponentRemoved;

            foreach (IComponent component in AssociatedComponents) component.Dispose();
        }

        /// <summary>
        ///     Handle when components are removed, removing any references to disposed
        ///     component.
        /// </summary>
        private void OnComponentRemoved(object sender, ComponentEventArgs e)
        {
            ((IList)_localizableContent.Messages).Remove(e.Component);
            ((IList)_localizableContent.MessageBoxes).Remove(e.Component);
        }

        private void OnAddLocalizableMessage(object sender, EventArgs e)
        {
            var dh = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (dh != null)
            {
                var dt = dh.CreateTransaction("Added new localizable message");

                var name = ComponentDesignUtility.GetNextComponentName(
                    typeof(LocalizableMessage),
                    AssociatedComponents);
                var lm = (LocalizableMessage)dh.CreateComponent(typeof(LocalizableMessage), name);

                _localizableContent.Messages.Add(lm);

                dt.Commit();

                var selectionService = (ISelectionService)GetService(typeof(ISelectionService));
                if (selectionService != null) selectionService.SetSelectedComponents(new[] { lm });
            }
        }

        private void OnAddLocalizableMessageBox(object sender, EventArgs e)
        {
            var dh = (IDesignerHost)GetService(typeof(IDesignerHost));
            if (dh != null)
            {
                var dt = dh.CreateTransaction("Added new localizable message box");

                var name = ComponentDesignUtility.GetNextComponentName(
                    typeof(LocalizableMessageBox),
                    AssociatedComponents);
                var lmb = (LocalizableMessageBox)dh.CreateComponent(typeof(LocalizableMessageBox), name);

                _localizableContent.MessageBoxes.Add(lmb);

                dt.Commit();

                var selectionService = (ISelectionService)GetService(typeof(ISelectionService));
                if (selectionService != null) selectionService.SetSelectedComponents(new[] { lmb });
            }
        }
    }
}