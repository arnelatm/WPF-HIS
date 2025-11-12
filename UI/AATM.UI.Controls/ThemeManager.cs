using Microsoft.Win32;
using System;
using System.Windows;

namespace AATM.UI.Controls
{
    public enum ThemeType
    {
        Light,
        Dark,
        Auto
    }

    public sealed class ThemeManager
    {
        private static readonly Lazy<ThemeManager> _instance =
            new(() => new ThemeManager());

        /// <summary>
        /// Gets the singleton instance of ThemeManager.
        /// </summary>
        public static ThemeManager Instance => _instance.Value;

        private ThemeManager() { }

        private const string RegistryPath = @"Software\AATM";
        private const string RegistryKey = "PreferredTheme";

        public void ApplyTheme(ThemeType theme)
        {
            // Save theme choice
            SaveThemeToRegistry(theme);

            switch (theme)
            {
                case ThemeType.Light:
                    ApplyResource("/AATM.UI.Controls;component/Themes/FluentColors.Light.xaml");
                    break;
                case ThemeType.Dark:
                    ApplyResource("/AATM.UI.Controls;component/Themes/FluentColors.Dark.xaml");
                    break;
                case ThemeType.Auto:
                    ApplyThemeFromSystem();
                    break;
            }
        }

        public void ApplyThemeFromSystem()
        {
            try
            {
                var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize");
                var isLight = key != null && Convert.ToInt32(key.GetValue("AppsUseLightTheme", 1)) == 1;

                ApplyTheme(isLight ? ThemeType.Light : ThemeType.Dark);
            }
            catch
            {
                ApplyTheme(ThemeType.Light);
            }
        }

        public void ApplyThemeFromRegistry()
        {
            try
            {
                using var key = Registry.CurrentUser.OpenSubKey(RegistryPath);
                if (key != null && Enum.TryParse(key.GetValue(RegistryKey)?.ToString(), out ThemeType theme))
                {
                    ApplyTheme(theme);
                }
                else
                {
                    ApplyThemeFromSystem();
                }
            }
            catch
            {
                ApplyThemeFromSystem();
            }
        }

        private void SaveThemeToRegistry(ThemeType theme)
        {
            try
            {
                using var key = Registry.CurrentUser.CreateSubKey(RegistryPath);
                key?.SetValue(RegistryKey, theme.ToString());
            }
            catch
            {
                // non-fatal if registry write fails
            }
        }

        private void ApplyResource(string path)
        {
            try
            {
                var dict = new ResourceDictionary { Source = new Uri(path, UriKind.RelativeOrAbsolute) };

                // Clear current theme dictionaries
                for (int i = Application.Current.Resources.MergedDictionaries.Count - 1; i >= 0; i--)
                {
                    var src = Application.Current.Resources.MergedDictionaries[i].Source?.ToString() ?? "";
                    if (src.Contains("FluentColors.", StringComparison.OrdinalIgnoreCase))
                        Application.Current.Resources.MergedDictionaries.RemoveAt(i);
                }

                // Add the chosen theme
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Theme apply failed: {ex.Message}");
            }
        }
    }
}
