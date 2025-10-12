using AATM.Contracts.Interfaces.Services;
using System;

namespace AATM.Contracts.Dtos
{
    public class TranslationDto : IEntityWithId
    {
        // ID is defined as a column, but typically handled specially in the base class.
        public int ID { get; set; }

        // ** [OPTIMIZATION]: Declarative binding/column setup **
        public string ModuleName { get; set; }

        public string UIIdentifier { get; set; }

        public string OriginalString { get; set; }

        public string LanguageCode { get; set; }
        public string LocalizedString { get; set; }

        public DateTime CreationDate { get; set; }

    }
}