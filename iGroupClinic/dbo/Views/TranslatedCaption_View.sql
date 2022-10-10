CREATE VIEW [dbo].[TranslatedCaption_View]
AS
SELECT        dbo.TranslatedCaption.idno, dbo.TranslatedCaption.CaptionIdNo, dbo.TranslatedCaption.LanguageIdNo, dbo.TranslatedCaption.TranslatedCaption, dbo.Languages.CultureInfoCode, dbo.OriginalCaptions.Caption, 
                         dbo.Languages.LanguageCode2, dbo.TranslatedCaption.DateTimeStamp
FROM            dbo.TranslatedCaption LEFT OUTER JOIN
                         dbo.Languages ON dbo.TranslatedCaption.LanguageIdNo = dbo.Languages.IdNo RIGHT OUTER JOIN
                         dbo.OriginalCaptions ON dbo.TranslatedCaption.CaptionIdNo = dbo.OriginalCaptions.idno
