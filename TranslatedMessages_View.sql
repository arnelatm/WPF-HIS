USE [ISPDATA]
GO

/****** Object:  View [dbo].[TranslatedMessages_View]    Script Date: 23/03/2020 06:52:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[TranslatedMessages_View]
AS
SELECT        dbo.TranslatedMessages.idno, dbo.TranslatedMessages.OriginalIdNo, dbo.TranslatedMessages.TranslatedMessage, dbo.TranslatedMessages.TranslatedCaption, dbo.TranslatedMessages.DateTimeStamp, 
                         dbo.TranslatedMessages.LanguageIdNo, dbo.OriginalMessages.MessageKey, dbo.OriginalMessages.Message, dbo.OriginalMessages.Caption, dbo.OriginalMessages.Notes, dbo.Languages.LanguageCode2, 
                         dbo.Languages.CultureInfoCode
FROM            dbo.TranslatedMessages LEFT OUTER JOIN
                         dbo.Languages ON dbo.TranslatedMessages.LanguageIdNo = dbo.Languages.IdNo RIGHT OUTER JOIN
                         dbo.OriginalMessages ON dbo.TranslatedMessages.OriginalIdNo = dbo.OriginalMessages.idno
GO