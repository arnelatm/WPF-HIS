using System.Collections.Generic;

namespace AATM.Core.WpfLocalization
{
    public static class LocalizationHelper
    {
        public static List<(string display, string code)> SafeGetLanguages(ILocalizationService service)
        {
            try
            {
                return service.GetAvailableLanguages();
            }
            catch
            {
                return new List<(string, string)> { ("English", "en-US") };
            }
        }
    }
}