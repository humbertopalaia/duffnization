CREATE DATABASE Duffnization

GO

USE Duffnization

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BeerStyle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[MinTemperature] [smallint] NOT NULL,
	[MaxTemperature] [smallint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[UpdateDate] [datetime] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BeerStyle] ADD PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

GO

INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('Weissbier', -1, 3, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('Pilsens', -2, 4, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('Weizenbier', -4, 6, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('Red ale', -5, 5, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('India pale ale', -6, 7, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('IPA', -7, 10, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('Dunkel', -8, 2, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('Imperial Stouts', -10, 13, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('Brown ale', 0, 14, GETDATE())
INSERT INTO BeerStyle ([Name], MinTemperature, MaxTemperature, CreateDate) VALUES('TesteUpdate', 5, 10, GETDATE())