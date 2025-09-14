CREATE TABLE Localization (
    OriginalString NVARCHAR(MAX) PRIMARY KEY,
    ModuleName NVARCHAR(50),
    LanguageCode NVARCHAR(10),
    LocalizedString NVARCHAR(MAX)
);
