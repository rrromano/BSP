Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_actualiza_usuario')
  Drop Procedure adp_actualiza_usuario
Go 

-- SP QUE ACTUALIZA LOS DATOS DEL USUARIO.
Create procedure adp_actualiza_usuario (@USER					VARCHAR(255),
																				@DESCCRIPCION	VARCHAR(255),
																				@PASSWORD			VARCHAR(255))
as

BEGIN TRY

	SET NOCOUNT ON

	UPDATE A
	SET A.DESCRIPCION = @DESCCRIPCION,
			A.PASS				= @PASSWORD
	FROM USUARIOS A
	WHERE	A.USERNAME	= @USER		
			
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
