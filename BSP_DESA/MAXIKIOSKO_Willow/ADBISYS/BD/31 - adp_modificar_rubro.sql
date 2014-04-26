Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_modificar_rubro')
  Drop Procedure adp_modificar_rubro
Go 

-- SP QUE MODIFICA UN RUBRO.
Create procedure adp_modificar_rubro (@ID_RUBRO					INT,
																		  @RUBRO_DESCRIPCION	VARCHAR(255),
																		  @RUBRO_LOGIN				VARCHAR(255) = NULL)
as

BEGIN TRY

	SET NOCOUNT ON

	UPDATE RUBROS
		SET Descripcion = @RUBRO_DESCRIPCION,
			  fecha_modif = GETDATE(),
				login_modif = @RUBRO_LOGIN,
				term_modif = HOST_NAME()
	WHERE ID_Rubro = @ID_RUBRO
	
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
