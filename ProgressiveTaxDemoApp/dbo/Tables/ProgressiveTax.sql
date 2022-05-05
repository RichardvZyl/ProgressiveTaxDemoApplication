CREATE TABLE [dbo].[ProgressiveTax] (
    [Id]          INT                IDENTITY (1, 1) NOT NULL,
    [Rate]        INT                NOT NULL,
    [From]        INT                NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_ProgressiveTax] PRIMARY KEY CLUSTERED ([Id] ASC)
);

