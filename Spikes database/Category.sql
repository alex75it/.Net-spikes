CREATE TABLE [dbo].[Category]
(
    [Id] INT NOT NULL PRIMARY KEY, 
    [Code] VARCHAR(10) NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [CreateDate] DATETIME NOT NULL DEFAULT GetUtcDate()
)
