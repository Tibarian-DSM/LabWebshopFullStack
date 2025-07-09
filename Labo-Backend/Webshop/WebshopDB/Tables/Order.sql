CREATE TABLE [dbo].[Order]
(
	[Id] INT IDENTITY,
	[Date] DATETIME,
	[User_Id] INT,
	[OrderStatus] NVARCHAR(64) DEFAULT 'Active',
	CONSTRAINT [PK_Order] PRIMARY KEY ([Id]),
	CONSTRAINT [FK_User_Id] FOREIGN KEY ([User_Id])
		REFERENCES [dbo].[User]([Id])
)
