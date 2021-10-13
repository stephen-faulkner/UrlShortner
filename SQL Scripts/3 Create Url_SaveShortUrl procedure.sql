USE [UrlShortner]
GO

/****** Object:  StoredProcedure [dbo].[Url_SaveShortUrl]    Script Date: 13/10/2021 01:31:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Stephen Faulkner>
-- Create date: <2021-10-12>
-- Description:	<Save new short url>
-- =============================================

--exec Url_GetByShortUrl ''

CREATE PROCEDURE [dbo].[Url_SaveShortUrl]
	-- Add the parameters for the stored procedure here
	@url_id uniqueidentifier, @url_long nvarchar(max), @url_short nvarchar(20), @created_date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	insert into Urls
	(url_id, url_long, url_short, created_date)
	values
	(@url_id, @url_long, @url_short, @created_date)
END
GO


