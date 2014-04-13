Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_modificar_proveedor')
  Drop Procedure adp_modificar_proveedor
Go 

-- SP QUE MODIFICA A UN PROVEEDOR.
Create procedure adp_modificar_proveedor (@Proveedor_ID_Proveedor int,
																					@Proveedor_IdRubro			int,
																					@Proveedor_Nombre				varchar(255) ,
																					@Proveedor_Contacto			varchar(255) = null,
																					@Proveedor_Direccion		varchar(255) = null,
																					@Proveedor_Localidad		varchar(255) = null,
																					@Proveedor_Provincia		varchar(255) = null,
																					@Proveedor_Telefono			numeric(20)	 = null,
																					@Proveedor_Cuit					numeric(20)	 = null,
																					@Proveedor_Login				varchar(255) = null)
as

BEGIN TRY

	SET NOCOUNT ON

	UPDATE PROVEEDORES 
		SET ID_Rubro		= @Proveedor_IdRubro,
				NOMBRE			= @Proveedor_Nombre,
			  CONTACTO		= @Proveedor_Contacto,
			  DIRECCION		= @Proveedor_Direccion,
			  LOCALIDAD		=	@Proveedor_Localidad,
			  PROVINCIA		=	@Proveedor_Provincia,
			  TELEFONO		=	@Proveedor_Telefono,
			  CUIT				=	@Proveedor_Cuit,
			  FECHA_MODIF	= GETDATE(),
			  LOGIN_MODIF	= @Proveedor_Login,
			  TERM_MODIF	= HOST_NAME()
													 
	WHERE ID_Proveedor = @Proveedor_ID_Proveedor

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
GO