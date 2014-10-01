Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtenerDatosVenta')
  Drop Procedure adp_obtenerDatosVenta
Go 

-- SP PARA OBTENER INFORMACIÓN SOBRE LOS ARTÍCULOS DE LA VENTA RECIBIDA COMO PARÁMETRO.
Create procedure dbo.adp_obtenerDatosVenta (@Id_Venta NUMERIC(30))
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT  A.ID_Venta            as 'ID_VENTA',
	        A.Cantidad_Articulos  as 'CANTIDAD_ARTICULOS',
	        A.Importe             as 'IMPORTE',
	        A.Estado              as 'ESTADO',
	        A.Fecha_Venta         as 'FECHA_VENTA',
	        A.Hora_Venta          as 'HORA_VENTA',
	        A.fecha_modif         as 'FECHA_MODIF',
	        A.login_modif         as 'LOGIN_MODIF',
	        A.term_modif          as 'TERM_MODIF'        
	FROM VENTAS A
  WHERE A.ID_Venta = ISNULL(@Id_Venta, A.ID_VENTA)
  
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
