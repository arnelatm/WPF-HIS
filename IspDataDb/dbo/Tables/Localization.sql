CREATE TABLE Localization (
    ID INT PRIMARY KEY IDENTITY(1,1),
    OriginalString NVARCHAR(MAX),
    ModuleName NVARCHAR(50),
    UIIdentifier NVARCHAR(100),
    LanguageCode NVARCHAR(10),
    LocalizedString NVARCHAR(MAX)
);
