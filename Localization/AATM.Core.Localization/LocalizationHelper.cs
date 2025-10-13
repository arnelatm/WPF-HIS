using System;
using System.Collections.Generic;
using AATM.Contracts.Interfaces.Services;

namespace AATM.Core.Localization
{
    public static class LocalizationHelper
    {
        public static List<(string display, string code)> SafeGetLanguages(ILocalizationService localizationService)
        {
            try
            {
                return localizationService?.GetAvailableLanguages()
                       ?? new List<(string display, string code)>
                          {
                              ("English","en-US"),
                              ("Arabic","ar-SA")
                          };
            }
            catch
            {
                return new List<(string display, string code)>
                {
                    ("English","en-US"),
                    ("Arabic","ar-SA")
                };
            }
        }
    }
}
