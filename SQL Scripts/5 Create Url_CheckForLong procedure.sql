USE [UrlShortner]
GO

/****** Object:  StoredProcedure [dbo].[Url_CheckForLongUrl]    Script Date: 13/10/2021 01:31:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Stephen Faulkner>
-- Create date: <2021-10-12>
-- Description:	<Get Url record by long url>
-- =============================================

--exec Url_CheckForLongUrl ''

CREATE PROCEDURE [dbo].[Url_CheckForLongUrl]
	-- Add the parameters for the stored procedure here
	@url_long nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select url_id, url_long, url_short, created_date from Urls with(nolock) where lower(Urls.url_long) = lower(@url_long)
END
GO


