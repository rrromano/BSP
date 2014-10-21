Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_modificar_articulo')
  Drop Procedure adp_modificar_articulo
Go 

-- SP QUE MODIFICA A UN ARTICULO.

Create procedure adp_modificar_articulo (@Articulo_ID_Articulo		numeric(20),
																				 @Articulo_Descripcion		varchar(255),
																				 @Articulo_Precio_Venta		numeric(10,2),
																				 @Articulo_Precio_Compra	numeric(10,2),
																				 @Articulo_Rubro					numeric(20),
																				 @Articulo_Login					varchar(255) = null)
as

BEGIN TRY

	SET NOCOUNT ON

	UPDATE ARTICULOS 
		SET DESCRIPCION = @Articulo_Descripcion,
				PRECIO_VENTA = @Articulo_Precio_Venta,
				PRECIO_COMPRA = @Articulo_Precio_Compra,
				RUBRO = @Articulo_Rubro,
			  FECHA_MODIF	= GETDATE(),
			  LOGIN_MODIF	= @Articulo_Login,
			  TERM_MODIF	= HOST_NAME()
													 
	WHERE ID_Articulo = @Articulo_ID_Articulo

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
