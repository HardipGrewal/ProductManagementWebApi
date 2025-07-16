CREATE TABLE [dbo].[products]
(
	[productId] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(10) NULL, 
    [priceId] INT NOT NULL, 
    CONSTRAINT [FK_products_price_priceId] FOREIGN KEY ([priceId]) REFERENCES [price]([priceId])
)
