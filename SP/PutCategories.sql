create proc PutCategories
@name varchar(250),
@description varchar(250),
@status int,
@iduser int,
@idcategory int
as
begin
	UPDATE Categories
	SET name = @name
      ,description = @description
      ,status = @status
      ,iduser = @iduser
	WHERE idcategory=@idcategory
end