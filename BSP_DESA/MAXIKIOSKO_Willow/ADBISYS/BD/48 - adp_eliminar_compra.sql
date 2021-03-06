Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_eliminar_compra')
  Drop Procedure adp_eliminar_compra
Go 

-- SP QUE ELIMINA A UNA COMPRA.

Create procedure adp_eliminar_compra (@Id_COMPRA VARCHAR(255),
																			@Compra_Login AS VARCHAR(255) = NULL)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	UPDATE COMPRAS SET Estado = 0,
										 fecha_modif = GETDATE(),
										 login_modif = @Compra_Login,
										 term_modif = HOST_NAME()
		WHERE Id_Compra = @Id_COMPRA

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
