using AATM.Contracts.Interfaces.Services;

namespace AATM.Contracts.Dtos
{
    public class TranslationDto : IEntityWithId
    {
        public int ID { get; set; }
        public required string ModuleName { get; set; }
        public required string UIIdentifier { get; set; }
        public required string OriginalString { get; set; }
        public required string LanguageCode { get; set; }
        public required string LocalizedString { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}