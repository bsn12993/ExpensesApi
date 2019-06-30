create proc GetCategoriesById
@idcategory int
as
begin
	SELECT 
		idcategory
		,name
		,description
		,status
		,iduser
	FROM Categories
	WHERE idcategory=@idcategory
end