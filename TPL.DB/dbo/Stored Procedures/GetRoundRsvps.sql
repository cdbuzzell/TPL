CREATE PROCEDURE [dbo].[GetRoundRsvps]
	@Date datetime
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT	RR.RoundId, RR.GolferId, G.Alias, G.[Name], RR.ResponseDateTime, RR.IsGolfing
FROM	RoundRsvp RR
		LEFT OUTER JOIN Golfer G ON RR.GolferId = G.GolferId
WHERE	RoundId = (SELECT TOP 1 RoundId FROM [dbo].[Round] WHERE @Date <= [Date] ORDER BY [Date])

END
