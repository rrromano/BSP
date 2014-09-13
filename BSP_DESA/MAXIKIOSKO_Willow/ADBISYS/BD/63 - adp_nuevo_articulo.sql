Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_nuevo_articulo')
  Drop Procedure adp_nuevo_articulo
Go 

-- SP QUE INSERTA UN NUEVO ARTICULO
Create procedure adp_nuevo_articulo (@Articulo_ID_Articulo		numeric(20),
																		 @Articulo_Descripcion		varchar(255),
																		 @Articulo_Precio_Venta		numeric(10,2),
																		 @Articulo_Rubro					numeric(20),
																		 @Articulo_Login					varchar(255) = null)
as

BEGIN TRY

	SET NOCOUNT ON

	INSERT INTO ARTICULOS(ID_Articulo,
												Descripcion,
												Precio_Venta,
												Rubro,
												Estado,
												fecha_modif,
												login_modif,
												term_modif)
													 
	VALUES (@Articulo_ID_Articulo,
					UPPER(@Articulo_Descripcion),
					@Articulo_Precio_Venta,
					@Articulo_Rubro,
					1,
					GETDATE(),
					@Articulo_Login,
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
