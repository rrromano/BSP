Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_insertarArticuloVenta_Temporal')
  Drop Procedure adp_insertarArticuloVenta_Temporal
Go 

-- SP PARA GUARDAR ARTICULOS DE LA VENTA EN LA TABLA TEMPORAL (TABLA QUE TENDRA DATOS HASTA EL MOMENTO DE CONFIRMAR LA VENTA)
Create procedure dbo.adp_insertarArticuloVenta_Temporal (@Id_Articulo As NUMERIC(20) = NULL, @Cantidad AS NUMERIC(10))
as

BEGIN TRY

	SET NOCOUNT ON
	
  INSERT INTO TMP_ARTICULOS_VENTAS (ID_Articulo, Cantidad)
  VALUES (@Id_Articulo, @Cantidad)
  
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
