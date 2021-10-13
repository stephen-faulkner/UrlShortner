USE [UrlShortner]
GO

/****** Object:  StoredProcedure [dbo].[Url_GetByShortUrl]    Script Date: 13/10/2021 01:31:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Stephen Faulkner>
-- Create date: <2021-10-12>
-- Description:	<Get Url record by shortened url>
-- =============================================

--exec Url_GetByShortUrl ''

CREATE PROCEDURE [dbo].[Url_GetByShortUrl]
	-- Add the parameters for the stored procedure here
	@url_short nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select url_id, url_long, url_short, created_date from Urls with(nolock) where Urls.url_short = @url_short
END
GO


