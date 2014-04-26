Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_verificar_rubro_proveedor')
  Drop Procedure adp_verificar_rubro_proveedor
Go 

-- VERIFICO QUE CUANDO ELIMINO UN RUBRO, NO EXISTA UN PROVEEDOR QUE TENGA DICHO RUBRO.

Create procedure adp_verificar_rubro_proveedor (@Id_Rubro int)
as


BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	SELECT 1 FROM PROVEEDORES WHERE ID_Rubro = @Id_Rubro
	
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
