﻿-- =============================================
-- Author:		Buzzell, Corey
-- Create date: 3/30/2016
-- Description:	Get Schedule list by year
-- =============================================
CREATE PROCEDURE [dbo].[GetSchedule] 
	@Season int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

SELECT	R.RoundId, R.[Date], R.Name AS RoundName, R. Details, R.Game, R.IsMajor,  
		R.CourseId, C.Name AS CourseName, C.Url AS CourseUrl, C.Zip, C.Latitude, C.Longitude, C.Par, C.Rating, C.Slope, 
		R.BeerDutyGolferId, G.Alias, G.Name AS GolferName, G.Avatar, G.[Enabled],
		R.FoodDutyGolferId, G2.Alias AS FoodAlias, G2.Name AS FoodName, G2.Avatar AS FoodAvatar, G2.[Enabled] AS FoodEnabled
FROM	dbo.[Round] R 
		LEFT OUTER JOIN dbo.Course C ON R.CourseId = C.CourseId
		LEFT OUTER JOIN dbo.Golfer G ON R.BeerDutyGolferId = G.GolferId
		LEFT OUTER JOIN dbo.Golfer G2 ON R.FoodDutyGolferId = G2.GolferId
WHERE	YEAR(R.[Date]) = @Season
ORDER BY R.[Date]

END