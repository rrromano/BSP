Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_nuevo_proveedor')
  Drop Procedure adp_nuevo_proveedor
Go 

-- SP QUE INSERTA UN NUEVO PROVEEDOR.
Create procedure adp_nuevo_proveedor (@Rubro		varchar(255),
									  @Nombre		varchar(255),
									  @Contacto		varchar(255),
									  @Direccion	varchar(255),
									  @Localidad	varchar(255),
									  @Provincia	varchar(255),
									  @Telefono		numeric(20)= null,
									  @Cuit			numeric(20)= null,
									  @Login		varchar(255))
as

INSERT INTO PROVEEDORES (Rubro,
						 Nombre,
						 Contacto,
						 Direccion,
						 Localidad,
						 Provincia,
						 Telefono,
						 Cuit,
						 fecha_modif,
						 login_modif,
						 term_modif)

SELECT					 a.ID_Rubro,
						 UPPER(@Nombre),
						 @Contacto,
						 @Direccion,
 						 @Localidad,
 						 @Provincia,
						 CASE rtrim(ltrim(@Telefono)) WHEN '' THEN 0
													  ELSE @Telefono
						 END,
						 CASE rtrim(ltrim(@Cuit)) WHEN '' THEN 0
												  ELSE @Cuit
						 END,
						 GETDATE(),
						 @Login,
						 HOST_NAME()					 
	
FROM RUBROS a WHERE Descripcion = @Rubro
GO