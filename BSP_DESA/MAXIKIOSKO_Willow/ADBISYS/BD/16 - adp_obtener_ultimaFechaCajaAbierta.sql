Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtener_ultimaFechaCajaAbierta')
  Drop Procedure adp_obtener_ultimaFechaCajaAbierta
Go 

-- SP QUE OBTIENE LA ULTIMA FECHA DE CAJA ABIERTA
Create procedure adp_obtener_ultimaFechaCajaAbierta 
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT ISNULL(MAX(FECHA),'19000101') FechaCajaAbierta 
	FROM MOVIMIENTOS_CAJA 

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
