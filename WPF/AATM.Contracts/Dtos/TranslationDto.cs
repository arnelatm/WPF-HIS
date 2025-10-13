using AATM.Contracts.Interfaces.Services;

namespace AATM.Contracts.Dtos
{
    public class TranslationDto : IEntityWithId
    {
        public int ID { get; set; }
        public string ModuleName { get; set; }
        public string UIIdentifier { get; set; }
        public string OriginalString { get; set; }
        public string LanguageCode { get; set; }
        public string LocalizedString { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}