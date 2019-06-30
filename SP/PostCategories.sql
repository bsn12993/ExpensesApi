create proc PostCategories
@name varchar(250),
@description varchar(250),
@status int,
@iduser int
as
begin
	INSERT INTO Categories
           (name
           ,description
           ,status
           ,iduser)
     VALUES
           (@name
           ,@description
           ,@status
           ,@iduser)
end