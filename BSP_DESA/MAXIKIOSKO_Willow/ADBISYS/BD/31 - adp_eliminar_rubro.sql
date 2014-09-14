Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_eliminar_rubro')
  Drop Procedure adp_eliminar_rubro
Go 

-- SP QUE ELIMINA A UN RUBRO.

Create procedure adp_eliminar_rubro (@Id_Rubro INT,
																		 @Rubro_Login AS VARCHAR(255) = NULL)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	UPDATE RUBROS SET Estado = 0,
										fecha_modif = GETDATE(),
										login_modif = @Rubro_Login,
										term_modif = HOST_NAME()	
		WHERE ID_Rubro = @Id_Rubro

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
