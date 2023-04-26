CREATE PROCEDURE [dbo].[AddRoundRsvp]
	@Date datetime,
	@Mobile nchar(12),
	@IsGolfing bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO [dbo].[RoundRsvp] (RoundId, GolferId, ResponseDateTime, IsGolfing) 
VALUES ((SELECT TOP 1 RoundId FROM [dbo].[Round] WHERE @Date <= [Date] ORDER BY [Date]), (SELECT GolferId FROM [dbo].[Golfer] WHERE Mobile = @Mobile), GETUTCDATE(), @IsGolfing)

END