CREATE TABLE [dbo].[TaxCalculationType]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PostalCode] NCHAR(10) NOT NULL, 
    [TaxType] INT NOT NULL
)
