CREATE TABLE [dbo].[Subcategory]
(
    [Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
    CategoryId int not null,
    [Description] NVARCHAR(250) null,
    Name nvarchar(25) not null,
    [CreationDate] datetime not null default GetUtcDate(), 
    [LastModificationDate] DATETIME NULL
)
