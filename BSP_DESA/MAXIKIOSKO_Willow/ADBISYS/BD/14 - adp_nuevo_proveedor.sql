Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_nuevo_proveedor')
  Drop Procedure adp_nuevo_proveedor
Go 

-- SP QUE INSERTA UN NUEVO PROVEEDOR.
Create procedure adp_nuevo_proveedor (@Proveedor_IdRubro		varchar(255) ,
																			@Proveedor_Nombre			varchar(255) ,
																			@Proveedor_Contacto		varchar(255) = null,
																			@Proveedor_Direccion	varchar(255) = null,
																			@Proveedor_Localidad	varchar(255) = null,
																			@Proveedor_Provincia	varchar(255) = null,
																			@Proveedor_Telefono		numeric(20)	 = null,
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
													 FECHA_MODIF,
													 LOGIN_MODIF,
													 TERM_MODIF	)
													 
	VALUES (@Proveedor_IdRubro  ,	
					@Proveedor_Nombre	  ,	
					@Proveedor_Contacto ,	
					@Proveedor_Direccion,
					@Proveedor_Localidad,
					@Proveedor_Provincia,
					@Proveedor_Telefono	,
					@Proveedor_Cuit			,
					GETDATE()						,
					@Proveedor_Login		,
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