Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_actualizacionMasiva_Articulo')
  Drop Procedure adp_actualizacionMasiva_Articulo
Go 

-- SP QUE MODIFICA MASIVAMENTE LOS ARTICULOS
Create procedure dbo.adp_actualizacionMasiva_Articulo (	@Articulo_IdRubro	INT = NULL,
														@Articulo_TipoAct	NUMERIC(1), --1 POR PORCENTAJE, 0 POR $
														@Articulo_SumaResta	NUMERIC(1), --1 SUMA, 0 RESTA
														@Articulo_Valor		NUMERIC(10,2), --VALOR QE SE SUMA O RESTA AL CAMPO PRECIO_VENTA
														@Articulo_Login		VARCHAR(255) = NULL)
as

BEGIN TRY

	SET NOCOUNT ON

	--=================================================================================================================================
	--ACTUALIZACIÓN POR PORCENTAJE ****************************************************************************************************
	--=================================================================================================================================
	IF (@Articulo_TipoAct = 1) 
		BEGIN
			UPDATE A
				SET A.Precio_Venta = Precio_Venta + ( ( (Precio_Venta * @Articulo_Valor)/100) * (CASE WHEN @Articulo_SumaResta = 1 THEN 1 ELSE -1 END) ),		
					A.fecha_modif  = GETDATE(),
					A.login_modif  = @Articulo_Login,
					A.term_modif   = HOST_NAME()
			FROM ARTICULOS A			
			WHERE A.Rubro		 = ISNULL(@Articulo_IdRubro, A.Rubro)
			AND A.Rubro <> 1
		END
	--=================================================================================================================================
	
	--=================================================================================================================================
	--ACTUALIZACIÓN POR VALOR / PRECIO ************************************************************************************************
	--=================================================================================================================================
	IF (@Articulo_TipoAct = 0) 
		BEGIN
			UPDATE A
				SET A.Precio_Venta = Precio_Venta + ( @Articulo_Valor * (CASE WHEN @Articulo_SumaResta = 1 THEN 1 ELSE -1 END) ),		
					A.fecha_modif  = GETDATE(),
					A.login_modif  = @Articulo_Login,
					A.term_modif   = HOST_NAME()
			FROM ARTICULOS A			
			WHERE A.Rubro	=	ISNULL(@Articulo_IdRubro, A.Rubro)
			AND A.Rubro <> 1
		END
	--=================================================================================================================================	
	
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
