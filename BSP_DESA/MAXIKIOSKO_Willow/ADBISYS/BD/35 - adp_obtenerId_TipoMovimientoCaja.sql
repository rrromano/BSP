Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtenerId_TipoMovimientoCaja')
  Drop Procedure adp_obtenerId_TipoMovimientoCaja
Go 

-- SP QUE BUSCA RUBROS DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_obtenerId_TipoMovimientoCaja (@ID_Movimiento NUMERIC(30))
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	SELECT ID_TipoMovimiento
	FROM MOVIMIENTOS_CAJA
	WHERE ID_Movimiento = @ID_Movimiento
							
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
