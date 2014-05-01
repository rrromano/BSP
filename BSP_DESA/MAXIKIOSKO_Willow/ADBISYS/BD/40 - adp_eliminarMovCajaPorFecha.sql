Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_eliminarMovCajaPorFecha')
  Drop Procedure adp_eliminarMovCajaPorFecha
Go 


Create procedure dbo.adp_eliminarMovCajaPorFecha (@FECHA_MOV AS DATETIME, @ID_TIPOMOVIMIENTO AS NUMERIC(2) = NULL)
as


BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACI�N'
  
	--DELETE A
	--FROM MOVIMIENTOS_CAJA A
	--WHERE A.ID_Movimiento = @ID_MovimientoCaja
	
	UPDATE A
	SET A.ESTADO = 0
	FROM MOVIMIENTOS_CAJA A
	WHERE 1 = 1
		AND A.FECHA = @FECHA_MOV
		AND A.ID_TIPOMOVIMIENTO = ISNULL(@ID_TIPOMOVIMIENTO,A.ID_TIPOMOVIMIENTO)
	
	
  PRINT 'FIN ACTUALIZACI�N OK'
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