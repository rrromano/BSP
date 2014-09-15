Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_items_eliminados')
  Drop Procedure adp_items_eliminados
Go 

-- SP QUE OBTIENE LOS DIFERENTES ITEMS ELIMINADOS.
Create procedure adp_items_eliminados (@Proveedor_IdRubro		varchar(255) ,
																			@Proveedor_Nombre			varchar(255) ,
																			@Proveedor_Contacto		varchar(255) = null,
																			@Proveedor_Direccion	varchar(255) = null,
																			@Proveedor_Localidad	varchar(255) = null,
																			@Proveedor_Provincia	varchar(255) = null,
																			@Proveedor_Telefono		varchar(20)	 = null,
																			@Proveedor_Cuit				numeric(20)	 = null,
																			@Proveedor_Login			varchar(255) = null)
as


BEGIN TRY

	SET NOCOUNT ON

	INSERT INTO PROVEEDORES (ID_RUBRO		,
													 NOMBRE			,
													 CONTACTO		,
													 DIRECCION	,
													 LOCALIDAD	,
													 PROVINCIA	,
													 TELEFONO		,
													 CUIT				,
													 ESTADO			,
													 FECHA_MODIF,
													 LOGIN_MODIF,
													 TERM_MODIF	)
													 
	VALUES (@Proveedor_IdRubro					,	
					UPPER(@Proveedor_Nombre	  )	,	
					UPPER(@Proveedor_Contacto )	,	
					UPPER(@Proveedor_Direccion)	,	
					UPPER(@Proveedor_Localidad)	,
					UPPER(@Proveedor_Provincia)	,
					@Proveedor_Telefono					,
					@Proveedor_Cuit							,
					1														,
					GETDATE()										,
					@Proveedor_Login						,
					HOST_NAME()					)	

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