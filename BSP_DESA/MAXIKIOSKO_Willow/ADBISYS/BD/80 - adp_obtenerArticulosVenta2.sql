Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtenerArticulosVenta2')
  Drop Procedure adp_obtenerArticulosVenta2
Go 

-- SP PARA OBTENER ARTICULOS DE UNA VENTA EN PARTICULAR
Create procedure dbo.adp_obtenerArticulosVenta2 (@Id_Venta NUMERIC(30))
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT  A.ID_Venta      as 'ID_VENTA',
          A.ID_Item_Venta as 'ID_ITEM_VENTA', 
          A.ID_Articulo   as 'ID_ARTICULO',
          A.Cantidad      as 'CANTIDAD',
          A.Precio_Venta  as 'PRECIO_VENTA'
	FROM ARTICULOS_VENTAS A
  WHERE A.ID_VENTA = @Id_Venta
  
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
