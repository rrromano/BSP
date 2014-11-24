Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_info_rubros')
  Drop Procedure adp_info_rubros
Go 

-- SP QUE TRAE INFORMACIÓN DE LOS RUBROS.
Create procedure adp_info_rubros (@ID_RUBRO INT = NULL)
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT * 
	FROM RUBROS 
	WHERE ID_RUBRO = ISNULL(@ID_RUBRO,ID_RUBRO)
		AND Estado = 1 
		AND ID_RUBRO <> 1
	
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