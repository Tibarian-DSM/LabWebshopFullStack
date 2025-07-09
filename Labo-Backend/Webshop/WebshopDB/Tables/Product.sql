CREATE TABLE [dbo].[Product]
(
	[Id] INT IDENTITY, 
	[Name] NVARCHAR(50),
	[Price] DECIMAL(6,2),
	[Description] NVARCHAR(50),
	[Category] NVARCHAR(50),
	[Image] NVARCHAR(250)
	CONSTRAINT [PK_Product] PRIMARY KEY ([Id])

)
