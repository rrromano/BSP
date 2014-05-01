Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_nueva_compra')
  Drop Procedure adp_nueva_compra
Go 

-- SP QUE INSERTA UNA NUEVA COMPRA.
Create procedure adp_nueva_compra (@Compra_IdProveedor	varchar(255),
																	 @Compra_Importe			numeric(10,2),
																	 @Compra_Fecha_Compra datetime,
																	 @Compra_Login				varchar(255) = null)
as


BEGIN TRY

	SET NOCOUNT ON

	INSERT INTO COMPRAS (Id_Proveedor,
 											 Importe,
											 Fecha_Compra,
											 Estado,
											 fecha_modif,
											 login_modif,
											 term_modif	)
													 
	VALUES (@Compra_IdProveedor,	
					@Compra_Importe,
					@Compra_Fecha_Compra,
					1,
					GETDATE(),
					@Compra_Login,
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
GO