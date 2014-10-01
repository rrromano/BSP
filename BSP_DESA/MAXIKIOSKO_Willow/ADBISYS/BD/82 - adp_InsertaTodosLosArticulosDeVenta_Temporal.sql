Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_InsertaTodosLosArticulosDeVenta_Temporal')
  Drop Procedure adp_InsertaTodosLosArticulosDeVenta_Temporal
Go 

-- SP QUE INSERTA EN LA TABLA TMP_ARTICULOS_VENTAS TODOS LOS ARTICULOS DE UNA VENTA
Create procedure dbo.adp_InsertaTodosLosArticulosDeVenta_Temporal (@Id_Venta NUMERIC(30))
as

BEGIN TRY

	SET NOCOUNT ON
	
	INSERT INTO TMP_ARTICULOS_VENTAS  (ID_Articulo, Cantidad)
	SELECT  A.ID_Articulo, A.Cantidad
	FROM ARTICULOS_VENTAS A
	WHERE A.ID_Venta = @Id_Venta
  
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
