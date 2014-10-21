Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtenerArticulosVenta')
  Drop Procedure adp_obtenerArticulosVenta
Go 

-- SP PARA OBTENER INFORMACIÓN SOBRE LOS ARTÍCULOS DE LA VENTA RECIBIDA COMO PARÁMETRO.
Create procedure dbo.adp_obtenerArticulosVenta (@codigo_venta varchar(255))
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT  A.ID_Item_Venta  AS 'ID',
	        A.ID_ARTICULO  AS 'CÓDIGO',
	        UPPER(B.DESCRIPCION)	AS 'DESCRIPCIÓN',
	        A.Cantidad AS 'CANTIDAD',
	        A.Precio_Venta AS 'PRECIO_VENTA',
	        A.Precio_Compra AS 'PRECIO_COMPRA',
	        C.Descripcion AS 'RUBRO'	        
	        
	FROM ARTICULOS_VENTAS A
		INNER JOIN ARTICULOS B ON (A.ID_ARTICULO = B.ID_ARTICULO)
		INNER JOIN RUBROS C ON (B.RUBRO = C.ID_RUBRO)
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
