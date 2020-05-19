





CREATE VIEW [dbo].[Captions_View]
AS
SELECT        dbo.TranslatedCaptions.idno, dbo.TranslatedCaptions.CaptionIdNo, dbo.TranslatedCaptions.LanguageIdNo, dbo.TranslatedCaptions.Translated, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, dbo.Languages.LanguageCode2
FROM            dbo.TranslatedCaptions 
				INNER JOIN dbo.Languages 
				ON dbo.TranslatedCaptions.LanguageIdNo = dbo.Languages.IdNo 
				RIGHT OUTER JOIN dbo.OriginalCaptions
				ON dbo.TranslatedCaptions.CaptionIdNo = dbo.OriginalCaptions.idno
