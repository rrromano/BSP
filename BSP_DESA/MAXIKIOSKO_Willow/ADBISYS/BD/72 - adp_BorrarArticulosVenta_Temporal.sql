Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_BorrarArticulosVenta_Temporal')
  Drop Procedure adp_BorrarArticulosVenta_Temporal
Go 

-- SP PARA BORRAR UNO O TODOS LOS REGISTROS DE TMP_ARTICULOS_VENTAS 
Create procedure dbo.adp_BorrarArticulosVenta_Temporal (@Id_ItemVenta NUMERIC(30) = NULL)
as

BEGIN TRY
    
	  SET NOCOUNT ON
  	
  	IF EXISTS(SELECT 1 FROM TMP_ARTICULOS_VENTAS WHERE ID_Item_Venta = ISNULL(@Id_ItemVenta, ID_Item_Venta))
  	  DELETE TMP_ARTICULOS_VENTAS 
  	  WHERE ID_Item_Venta = ISNULL(@Id_ItemVenta, ID_Item_Venta) 
  	
  	If @Id_ItemVenta IS NOT NULL  
  	  BEGIN
  	    DBCC CHECKIDENT ('TMP_ARTICULOS_VENTAS', RESEED,0)
      END
  	
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
