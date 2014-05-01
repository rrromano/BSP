Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_verificoExistencia_proveedor')
  Drop Procedure adp_verificoExistencia_proveedor
Go 

-- SP QUE VERIFICA EXISTENCIA DE UN PROVEEDOR.

Create procedure adp_verificoExistencia_proveedor (@Id_Proveedor INT,
																									 @Id_Rubro INT, 
																									 @Nombre	 VARCHAR(255))
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	select 1 from PROVEEDORES where ID_Rubro		 = @Id_Rubro 
															and Nombre			 = @Nombre 
															and ID_Proveedor <> @Id_Proveedor 
															and ESTADO			 = 1

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
