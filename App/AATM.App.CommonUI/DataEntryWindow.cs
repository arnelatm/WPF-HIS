using System.Windows;
using System.Windows.Markup;
using AATM.Contracts.Interfaces.Services;

namespace AATM.App.CommonUI
{
    public partial class DataEntryWindowBase : Window
    {
        protected ILocalizationService LocalizationService { get; }
        protected string ModuleName { get; }

        public DataEntryWindowBase(ILocalizationService localizationService, string moduleName)
        {
            LocalizationService = localizationService;
            ModuleName = moduleName;
        }

        protected void SwitchLanguage()
        {
            var newLang = LocalizationService.IsRightToLeft ? "en-US" : "ar-SA";
            LocalizationService.SetLanguage(newLang, ModuleName);
            this.Language = XmlLanguage.GetLanguage(newLang);
            this.FlowDirection = LocalizationService.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
        }

        // Add other shared logic here
    }
}