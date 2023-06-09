﻿CREATE TABLE [dbo].[Golfer] (
    [GolferId]      UNIQUEIDENTIFIER NOT NULL,
    [Alias]         NVARCHAR (50)    NOT NULL,
    [Name]          NVARCHAR (250)   NOT NULL,
    [FullName]      NVARCHAR (250)   NULL,
    [Avatar]        IMAGE            NULL,
    [Enabled]       BIT              CONSTRAINT [DF_Golfer_Enabled] DEFAULT ((1)) NOT NULL,
    [BringsBeer]    BIT              CONSTRAINT [DF_Golfer_BringsBeer] DEFAULT ((0)) NOT NULL,
    [Mobile]        NCHAR (12)       NULL,
    [MobileEnabled] BIT              DEFAULT ((0)) NULL,
    CONSTRAINT [PK_Golfer] PRIMARY KEY CLUSTERED ([GolferId] ASC)
);



