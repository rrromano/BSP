Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_actualizar_MovCaja')
  Drop Procedure adp_actualizar_MovCaja
Go 

-- SP QUE BUSCA RUBROS DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_actualizar_MovCaja (	@ID_MOVIMIENTO NUMERIC(30), 
																					@VALOR NUMERIC(10,2), 
																					@FECHA DATETIME, 
																					@HORA VARCHAR(8))
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
  UPDATE A
  SET A.VALOR = @VALOR,
			A.FECHA = @FECHA,
			A.HORA  = @HORA
  FROM MOVIMIENTOS_CAJA A
  inner join TIPOMOVIMIENTO_CAJA B ON (A.ID_TipoMovimiento = B.ID_TipoMovimiento)
  WHERE 1 = 1
		AND A.ID_MOVIMIENTO = @ID_MOVIMIENTO
		AND B.ESTADO = 1
							
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
