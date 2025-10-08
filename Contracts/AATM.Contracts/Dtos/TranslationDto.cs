using AATM.Contracts.Attributes;
using AATM.Contracts.Interfaces.Services;
using System;

namespace AATM.Contracts.Dtos
{
    // ... (Documentation)
    public class TranslationDto : IEntityWithId
    {
        // ID is defined as a column, but typically handled specially in the base class.
        [GridColumn("ID", Order = 0, Width = 60)]
        public int ID { get; set; }

        // ** [OPTIMIZATION]: Declarative binding/column setup **
        [FieldControl(("System.Windows.Forms.TextBox"), "txtModuleName")]
        [GridColumn("Module", Order = 1, Width = 140)]
        public string ModuleName { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "txtUIIdentifier")]
        [GridColumn("UI Identifier", Order = 2, Width = 160)]
        public string UIIdentifier { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "txtOriginalString")]
        [GridColumn("Original", Order = 3, Width = 120, Fill = true)]
        public string OriginalString { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "txtLanguageCode")]
        [GridColumn("Lang", Order = 4, Width = 70)]
        public string LanguageCode { get; set; }

        [FieldControl(("System.Windows.Forms.TextBox"), "txtLocalizedString")]
        [GridColumn("Localized", Order = 5, Width = 120, Fill = true)]
        public string LocalizedString { get; set; }


        [GridColumn("Creation Date", Order = 6, Width = 120)]
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