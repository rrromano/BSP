Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'ObtenerTotales')
  Drop Procedure dbo.ObtenerTotales
Go 

Create procedure dbo.ObtenerTotales (@FECHA_MOV DATETIME, @TIPOMOVIMIENTO INT)
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT SUM(A.VALOR) AS 'TOTAL'
	FROM MOVIMIENTOS_CAJA A
	INNER JOIN TIPOMOVIMIENTO_CAJA B ON (A.ID_TIPOMOVIMIENTO = B.ID_TIPOMOVIMIENTO)
	WHERE 1 = 1
		AND A.FECHA = @FECHA_MOV
		AND B.ID_TIPOMOVIMIENTO = @TIPOMOVIMIENTO

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
