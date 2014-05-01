Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_maxima_compra')
  Drop Procedure adp_maxima_compra
Go 

-- SP QUE TRAE EL MÁXIMO CÓDIGO DE COMPRA.
Create procedure adp_maxima_compra 
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT (ISNULL(MAX(Id_Compra),0) + 1) AS MAXIMO 
	FROM COMPRAS
	
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
