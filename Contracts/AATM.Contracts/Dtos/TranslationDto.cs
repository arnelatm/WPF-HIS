using AATM.Contracts.Attributes;
using AATM.Contracts.Interfaces.Services;
using System;

namespace AATM.Contracts.Dtos
{
    // ... (Documentation)
    public class TranslationDto : IEntityWithId
    {
        // ID is defined as a column, but typically handled specially in the base class.
        [GridColumn("ID", 60)]
        public int ID { get; set; }

        // ** [OPTIMIZATION]: Declarative binding/column setup **
        [FieldControl(("System.Windows.Forms.TextBox"), "_txtModuleName")]
        [GridColumn("Module", 140)]
        public string ModuleName { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "_txtUIIdentifier")]
        [GridColumn("UI Identifier", 160)]
        public string UIIdentifier { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "_txtOriginalString")]
        [GridColumn("Original", 100, isFillColumn: true)]
        public string OriginalString { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "_txtLanguageCode")]
        [GridColumn("Lang", 70)]
        public string LanguageCode { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "_txtLocalizedString")]
        [GridColumn("Localized", 100, isFillColumn: true)]
        public string LocalizedString { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
//using AATM.Contracts.Attributes;
//using AATM.Contracts.Interfaces.Services;
//using System;

//namespace AATM.Contracts.Dtos
//{
//    // ... (Documentation)
//    public class TranslationDto : IEntityWithId
//    {
//        // ID is defined as a column, but typically handled specially in the base class.
//        [GridColumn("ID", 60)]
//        public int ID { get; set; }

//        // ** [OPTIMIZATION]: Declarative binding/column setup **
//        [FieldControl("_txtModuleName", "System.Windows.Forms.TextBox")]
//        [GridColumn("Module", 140)]
//        public string ModuleName { get; set; }

//        [FieldControl("_txtUIIdentifier", "System.Windows.Forms.TextBox")]
//        [GridColumn("UI Identifier", 160)]
//        public string UIIdentifier { get; set; }

//        [FieldControl("_txtOriginalString", "System.Windows.Forms.TextBox")]
//        [GridColumn("Original", 100, isFillColumn: true)]
//        public string OriginalString { get; set; }

//        [FieldControl("_txtLanguageCode", "System.Windows.Forms.TextBox")]
//        [GridColumn("Lang", 70)]
//        public string LanguageCode { get; set; }

//        [FieldControl("_txtLocalizedString", "System.Windows.Forms.TextBox")]
//        [GridColumn("Localized", 100, isFillColumn: true)]
//        public string LocalizedString { get; set; }

//        public DateTime CreationDate { get; set; }
//    }
//}