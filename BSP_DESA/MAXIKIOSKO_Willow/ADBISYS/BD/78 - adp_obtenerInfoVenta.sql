Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtenerInfoVenta')
  Drop Procedure adp_obtenerInfoVenta
Go 

-- SP PARA OBTENER INFORMACIÓN SOBRE LA VENTA RECIBIDA COMO PARÁMETRO
Create procedure dbo.adp_obtenerInfoVenta (@codigo_venta varchar(255))
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT  A.ID_VENTA AS 'CÓDIGO',
	        A.IMPORTE  AS 'IMPORTE',
	        A.CANTIDAD_ARTICULOS  AS 'ARTÍCULOS',
	        CONVERT(VARCHAR,A.FECHA_VENTA,103) AS 'FECHA_VENTA',
	        A.HORA_VENTA  AS 'HORA_VENTA'

	FROM VENTAS A
			WHERE A.ID_Venta = @codigo_venta
      
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
