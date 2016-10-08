CREATE TABLE [dbo].[Subcategory]
(
	[Id] INT NOT NULL PRIMARY KEY,
	CategoryId int not null,
	Code varchar(20) not null,
	Name nvarchar(50) not null,
	CreateDate datetime not null default GetUtcDate()
)
