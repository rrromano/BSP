Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_eliminarTipoMovCaja')
  Drop Procedure adp_eliminarTipoMovCaja
Go 

-- SP QUE ELIMINA UN TIPO DE MOVIMIENTO DE CAJA
Create procedure dbo.adp_eliminarTipoMovCaja (@ID_TIPOMOVIMIENTO AS NUMERIC(2),
																							@TipoMovCaja_Login AS VARCHAR(255) = NULL)
as


BEGIN TRY

	SET NOCOUNT ON

	UPDATE A 
	SET A.ESTADO = 0,
			A.fecha_modif = GETDATE(),
			A.login_modif = @TipoMovCaja_Login,
			A.term_modif = HOST_NAME()
	FROM TIPOMOVIMIENTO_CAJA A
	WHERE ID_TIPOMOVIMIENTO = @ID_TIPOMOVIMIENTO

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
