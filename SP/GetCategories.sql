create proc GetCategories
as
begin
	SELECT 
		idcategory
		,name
		,description
		,status
		,iduser
	FROM Categories
end