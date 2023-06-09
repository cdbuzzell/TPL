﻿CREATE TABLE [dbo].[Round] (
    [RoundId]          UNIQUEIDENTIFIER CONSTRAINT [DF_Round_RoundId] DEFAULT (newid()) NOT NULL,
    [Date]             DATETIME         NOT NULL,
    [Name]             NVARCHAR (250)   NULL,
    [Details]          NVARCHAR (500)   NULL,
    [CourseId]         UNIQUEIDENTIFIER NULL,
    [BeerDutyGolferId] UNIQUEIDENTIFIER NULL,
    [Game]             NVARCHAR (500)   NULL,
    [RoundNum]         INT              NULL,
    [IsMajor]          BIT              CONSTRAINT [DF_Round_IsMajor] DEFAULT ((0)) NULL,
    [FoodDutyGolferId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Round] PRIMARY KEY CLUSTERED ([RoundId] ASC),
    CONSTRAINT [FK_Round_Course] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([CourseId]),
    CONSTRAINT [FK_Round_Golfer] FOREIGN KEY ([BeerDutyGolferId]) REFERENCES [dbo].[Golfer] ([GolferId])
);

