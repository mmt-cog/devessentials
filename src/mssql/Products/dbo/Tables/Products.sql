CREATE TABLE [dbo].[Products](
    [id] [bigint] IDENTITY(1000,1) NOT NULL,
    [message] [varchar](2000) NULL,
    [product_code] [varchar](50) NOT NULL UNIQUE,
    CONSTRAINT [PK_Products] PRIMARY KEY ([id])
);

