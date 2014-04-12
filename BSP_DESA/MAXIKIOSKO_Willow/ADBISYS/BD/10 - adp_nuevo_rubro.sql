Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_nuevo_rubro')
  Drop Procedure adp_nuevo_rubro
Go 

-- SP QUE INSERTA UN NUEVO RUBRO.
Create procedure adp_nuevo_rubro (@DESCRIPCION	VARCHAR(255),
																	@LOGIN				VARCHAR(255))
as

BEGIN TRY

	SET NOCOUNT ON

	INSERT INTO RUBROS (DESCRIPCION,
											FECHA_MODIF,
											LOGIN_MODIF,
											TERM_MODIF) 
	VALUES (UPPER(@DESCRIPCION), 
					GETDATE(), 
					@LOGIN, 
					HOST_NAME())
	
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
