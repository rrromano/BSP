Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_articulos_eliminados')
  Drop Procedure adp_articulos_eliminados
Go 

-- SP QUE PASA AL HISTÓRICO DE ARTICULOS ELIMINADOS.

Create procedure adp_articulos_eliminados (@Id_articulo VARCHAR(255),
																					 @Articulo_login VARCHAR(255) = null)

as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	insert into ARTICULOS_ELIMINADOS (ID_Articulo, Descripcion, Precio_Venta, Rubro, Estado, fecha_modif, login_modif, term_modif)
	select ID_Articulo,
				 Descripcion,
				 Precio_Venta,
				 Rubro,
				 Estado,
				 GETDATE(),
				 @Articulo_login,
				 HOST_NAME()
		from ARTICULOS
	where ID_Articulo = @Id_articulo
		

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
