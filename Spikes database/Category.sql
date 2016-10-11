CREATE TABLE [dbo].[Category]
(
    [Id] INT NOT NULL PRIMARY KEY Identity( 1, 1),
    [Name] nvarchar(25) not null,
    [Description] nvarchar (250) null,
    [CreationDate] DATETIME NOT NULL DEFAULT GetUtcDate(),
    [LastModificationDate] datetime null
)
