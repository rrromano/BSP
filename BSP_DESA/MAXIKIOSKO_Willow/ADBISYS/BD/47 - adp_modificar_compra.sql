Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_modificar_compra')
  Drop Procedure adp_modificar_compra
Go 

-- SP QUE MODIFICA UNA COMPRA.
Create procedure adp_modificar_compra (@Compra_IdCompra			varchar(255),
																			 @Compra_IdProveedor	varchar(255),
																			 @Compra_Importe			numeric(10,2),
																			 @Compra_Fecha_Compra datetime,
																			 @Compra_Login				varchar(255) = null)
as

BEGIN TRY

	SET NOCOUNT ON

	UPDATE COMPRAS
		SET Id_Proveedor = @Compra_IdProveedor,
				Importe			 = @Compra_Importe,		
			  fecha_modif  = GETDATE(),
				login_modif  = @Compra_Login,
				term_modif	 = HOST_NAME()
				
	WHERE Id_Compra		 = @Compra_IdCompra
		and Fecha_Compra = @Compra_Fecha_Compra
	
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
