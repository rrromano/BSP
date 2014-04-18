Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_eliminar_proveedor')
  Drop Procedure adp_eliminar_proveedor
Go 

-- SP QUE ELIMINA A UN PROVEEDOR.

Create procedure adp_eliminar_proveedor (@Id_Proveedor INT)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACI�N'
  
	DELETE FROM PROVEEDORES WHERE ID_Proveedor = @Id_proveedor

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