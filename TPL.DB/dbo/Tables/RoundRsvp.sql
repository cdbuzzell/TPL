CREATE TABLE [dbo].[RoundRsvp] (
    [RoundRsvpId]      UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [RoundId]          UNIQUEIDENTIFIER NOT NULL,
    [GolferId]         UNIQUEIDENTIFIER NOT NULL,
    [ResponseDateTime] DATETIME         NOT NULL,
    [IsGolfing]        BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([RoundRsvpId] ASC)
);

