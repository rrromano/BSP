Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_eliminar_articulo')
  Drop Procedure adp_eliminar_articulo
Go 

-- SP QUE ELIMINA A UNA COMPRA.

Create procedure adp_eliminar_articulo (@Id_articulo			VARCHAR(255),
																				@Articulo_Login		VARCHAR(255) = NULL)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	UPDATE ARTICULOS SET ESTADO = 0,
											 FECHA_MODIF = GETDATE(),
											 LOGIN_MODIF = @ARTICULO_LOGIN,
											 TERM_MODIF = HOST_NAME()
		WHERE ID_Articulo = @Id_articulo

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
