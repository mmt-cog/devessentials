CREATE TABLE [dbo].[Products](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[message] [varchar](2000) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[id] ASC
);