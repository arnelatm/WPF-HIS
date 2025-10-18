namespace AATM.Modules.Localization
{
    public class LanguageItem
    {
        public string Display { get; }
        public string Code { get; }
        public LanguageItem(string display, string code)
        {
            Display = display;
            Code = code;
        }
        public override string ToString() => Display;
    }
}   