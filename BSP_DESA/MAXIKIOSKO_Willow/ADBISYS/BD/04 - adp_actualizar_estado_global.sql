Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_actualizar_estado_global')
  Drop Procedure adp_actualizar_estado_global
Go 

-- SP QUE BUSCA USUARIO.
Create procedure adp_actualizar_estado_global (@ESTADO NUMERIC(1)) 
as

BEGIN TRY

SET NOCOUNT ON

	UPDATE A
	SET A.ESTADO_CAJA = @ESTADO
	FROM PARAMETROS_GENERALES A

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
