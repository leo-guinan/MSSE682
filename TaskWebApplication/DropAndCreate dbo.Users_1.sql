USE [TaskManagement]
GO

/****** Object: Table [dbo].[Users] Script Date: 11/24/2013 12:21:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Users];


GO
CREATE TABLE [dbo].[Users] (
    [userId]   INT           NOT NULL,
    [username] VARCHAR (50)  NOT NULL,
    [password] VARCHAR (50)  NOT NULL,
    [email]    VARCHAR (MAX) NOT NULL
);


