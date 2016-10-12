CREATE TABLE [dbo].[Category]
(
    [Id] INT NOT NULL Identity( 1, 1) PRIMARY KEY ,
    [Name] nvarchar(25) not null,
    [Description] nvarchar (250) null,
    [CreationDate] DATETIME NOT NULL DEFAULT GetUtcDate(),
    [LastModificationDate] datetime null
)
