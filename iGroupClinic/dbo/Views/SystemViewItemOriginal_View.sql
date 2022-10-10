


CREATE VIEW [dbo].[SystemViewItemOriginal_View]
AS
SELECT        dbo.SystemViewItem.idno, dbo.SystemViewItem.SystemViewIdNo, dbo.SystemViewItem.CaptionIdNo, dbo.OriginalCaptions.Caption, dbo.SystemViewItem.idno AS 'SystemViewItemIdNo', dbo.SystemViewItem.SystemViewIdNo AS Expr2, dbo.SystemViewItem.CaptionIdNo AS Expr3, 
                         dbo.SystemView.SystemViewName, dbo.TranslatedCaption.TranslatedCaption, dbo.Languages.LanguageCode2, dbo.Languages.CultureInfoCode, dbo.Languages.Language, dbo.TranslatedCaption.LanguageIdNo
FROM            dbo.Languages RIGHT OUTER JOIN
                         dbo.TranslatedCaption ON dbo.Languages.IdNo = dbo.TranslatedCaption.LanguageIdNo RIGHT OUTER JOIN
                         dbo.SystemViewItem LEFT OUTER JOIN
                         dbo.SystemView ON dbo.SystemViewItem.SystemViewIdNo = dbo.SystemView.IdNo ON dbo.TranslatedCaption.CaptionIdNo = dbo.SystemViewItem.CaptionIdNo LEFT OUTER JOIN
                         dbo.OriginalCaptions ON dbo.SystemViewItem.CaptionIdNo = dbo.OriginalCaptions.idno
