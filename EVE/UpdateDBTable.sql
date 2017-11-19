CREATE PROCEDURE [dbo].[UpdateDBTable]
	@tableName varchar(50),
	@otherDB varchar(200)
AS
	EXEC( 'select * from [' + @otherDB + '].[sys].[tables] where name = ''' + @tableName + '''')
	IF @@ROWCOUNT = 0
		RETURN 0
	ELSE 
		EXEC sp_MSforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'
		EXEC('DELETE FROM [dbo].[' + @tableName + ']')
		DECLARE @ex AS varchar(200) = 'INSERT INTO [dbo].[' + @tableName + ' ]
			SELECT * 
			FROM [' + @otherDB + '].[dbo].[' + @tableName + ']'
		EXEC(@ex)
		EXEC sp_MSforeachtable 'ALTER TABLE ? WITH CHECK CONSTRAINT all'
RETURN 0
