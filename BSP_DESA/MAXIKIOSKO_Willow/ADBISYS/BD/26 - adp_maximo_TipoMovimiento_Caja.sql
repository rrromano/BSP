Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_maximo_TipoMovimiento_Caja')
  Drop Procedure adp_maximo_TipoMovimiento_Caja
Go 

-- SP QUE TRAE EL M�XIMO C�DIGO DE TIPO DE MOVIMIENTO DE CAJA
Create procedure adp_maximo_TipoMovimiento_Caja 
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT (ISNULL(MAX(ID_TipoMovimiento),0) + 1) AS MAXIMO 
	FROM TIPOMOVIMIENTO_CAJA
	
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
