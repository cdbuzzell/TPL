CREATE PROCEDURE [dbo].[GetGolfersToSMS]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
SELECT	Mobile
FROM	Golfer
WHERE	MobileEnabled = 1

END