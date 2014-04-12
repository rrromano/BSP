Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_buscar_usuario')
  Drop Procedure adp_buscar_usuario
Go 

-- SP QUE BUSCA USUARIO.
Create procedure adp_buscar_usuario (	@user varchar(255) ,
																			@Pass varchar(255) ) 
as

BEGIN TRY

SET NOCOUNT ON

	SELECT * 
	FROM USUARIOS 
	WHERE 1 = 1
		AND Username	= @user 
		AND Pass			= @Pass

SET NOCOUNT OFF
	
END TRY

BEGIN CATCH
  SET NOCOUNT OFF
  PRINT 'ACTUALIZACION CANCELADA POR ERROR'
  SELECT ERROR_NUMBER()     'ERROR_NUMBER' , 
         ERROR_MESSAGE()    'ERROR_MESSAGE', 
         ERROR_LINE()       'ERROR_LINE', 
         ERROR_PROCEDURE()  'ERROR_PROCEDURE', 
         ERROR_SEVERITY ()  'ERROR_SEVERITY',   
         ERROR_STATE()      'ERROR_STATE'
END CATCH
	
go
