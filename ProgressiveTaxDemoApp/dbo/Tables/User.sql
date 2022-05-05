CREATE TABLE [dbo].[User] (
    [Id]          UNIQUEIDENTIFIER   NOT NULL,
    [Email]       NVARCHAR (250)     NOT NULL,
    [PostalCode]  NVARCHAR (MAX)     NOT NULL,
    [Salary]      DECIMAL (9, 2)     NOT NULL,
    [LastUpdated] DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

