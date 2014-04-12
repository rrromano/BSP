Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_maximo_rubro')
  Drop Procedure adp_maximo_rubro
Go 

-- SP QUE TRAE EL MÁXIMO CÓDIGO DE RUBRO.
Create procedure adp_maximo_rubro 
as


BEGIN TRY

	SET NOCOUNT ON
	
	SELECT (ISNULL(MAX(ID_RUBRO),0) + 1) AS MAXIMO 
	FROM RUBROS

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
