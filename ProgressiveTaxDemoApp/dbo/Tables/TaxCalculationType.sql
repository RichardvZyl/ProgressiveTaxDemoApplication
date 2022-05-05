CREATE TABLE [dbo].[TaxCalculationType] (
    [Id]          INT                IDENTITY (1, 1) NOT NULL,
    [PostalCode]  NVARCHAR (10)      NOT NULL,
    [TaxType]     INT                NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_TaxCalculationType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

