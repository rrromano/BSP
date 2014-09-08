Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_verificoExistencia_TipoMovCaja')
  Drop Procedure adp_verificoExistencia_TipoMovCaja
Go 

-- SP QUE VERIFICA EXISTENCIA DE UN PROVEEDOR.

Create procedure adp_verificoExistencia_TipoMovCaja (	@Codigo numeric (2),     
																											@Descripcion	VARCHAR(255))
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	SELECT 1 FROM TIPOMOVIMIENTO_CAJA WHERE DESCRIPCION = @Descripcion AND ESTADO = 1 AND ID_TipoMovimiento <> @Codigo

  PRINT 'FIN ACTUALIZACIÓN OK'
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
