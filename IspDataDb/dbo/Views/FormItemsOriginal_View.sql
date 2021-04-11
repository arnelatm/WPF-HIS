

CREATE VIEW [dbo].[FormItemsOriginal_View]
AS
SELECT        dbo.FormItems.idno, dbo.FormItems.formIdNo, dbo.FormItems.CaptionIdNo, dbo.OriginalCaptions.Caption, dbo.FormItems.idno AS Expr1, dbo.FormItems.formIdNo AS Expr2, dbo.FormItems.CaptionIdNo AS Expr3, 
                         dbo.SystemForms.FormName, dbo.TranslatedCaption.TranslatedCaption, dbo.Languages.LanguageCode2, dbo.Languages.CultureInfoCode, dbo.Languages.Language, dbo.TranslatedCaption.LanguageIdNo
FROM            dbo.Languages RIGHT OUTER JOIN
                         dbo.TranslatedCaption ON dbo.Languages.IdNo = dbo.TranslatedCaption.LanguageIdNo RIGHT OUTER JOIN
                         dbo.FormItems LEFT OUTER JOIN
                         dbo.SystemForms ON dbo.FormItems.formIdNo = dbo.SystemForms.IdNo ON dbo.TranslatedCaption.CaptionIdNo = dbo.FormItems.CaptionIdNo LEFT OUTER JOIN
                         dbo.OriginalCaptions ON dbo.FormItems.CaptionIdNo = dbo.OriginalCaptions.idno