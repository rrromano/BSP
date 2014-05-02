Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_actualiza_mov_compras')
  Drop Procedure adp_actualiza_mov_compras
Go 

-- SP QUE ACTUALIZA EL MOVIMIENTO DE COMPRAS.

Create procedure adp_actualiza_mov_compras @fecha_sistema DATETIME
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	UPDATE MOVIMIENTOS_CAJA 
		SET VALOR = (SELECT SUM(IMPORTE) FROM COMPRAS WHERE FECHA_COMPRA = @fecha_sistema AND ESTADO = 1),
				HORA	= (select (substring(convert(varchar,GETDATE(),114),1,8)))
		WHERE ID_TipoMovimiento = 2 AND FECHA = @fecha_sistema
							
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
