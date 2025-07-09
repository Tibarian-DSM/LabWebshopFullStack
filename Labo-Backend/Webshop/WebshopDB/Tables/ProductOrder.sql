CREATE TABLE [dbo].[ProductOrder]
(
	[Id] INT IDENTITY,
	[Product_Id] INT,
	[Order_Id] INT, 
	[Quantity] INT
	CONSTRAINT [PK_ProductOrder] PRIMARY KEY ([Id]), 
	CONSTRAINT [FK_Product_Id] FOREIGN KEY ([Product_Id])
		REFERENCES [dbo].[Product]([Id]),
	CONSTRAINT [FK_Order_Id] FOREIGN KEY ([Order_Id])
		REFERENCES [dbo].[Order]([Id])

)
