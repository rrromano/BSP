Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_info_proveedores')
  Drop Procedure adp_info_proveedores
Go 

-- SP QUE TRAE INFORMACIÓN DE LOS PROVEEDORES.
Create procedure adp_info_proveedores (@ID_proveedor INT = NULL)
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT * 
	FROM PROVEEDORES 
	WHERE ID_proveedor = ISNULL(@ID_proveedor,ID_proveedor)
		AND ESTADO = 1 
	
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