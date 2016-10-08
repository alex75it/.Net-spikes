ALTER TABLE dbo.Subcategory
	ADD CONSTRAINT [Category_of_Subcategory]
	FOREIGN KEY (CategoryId)
	REFERENCES dbo.Category (Id)
