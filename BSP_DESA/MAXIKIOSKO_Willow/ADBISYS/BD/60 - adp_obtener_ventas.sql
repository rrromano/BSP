Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtener_ventas')
  Drop Procedure adp_obtener_ventas
Go 

-- SP PARA OBTENER LAS DIFERENTES VENTAS DEL DÍA
Create procedure dbo.adp_obtener_ventas (@D_16_FECHA datetime)
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT  A.ID_VENTA,
	        A.CANTIDAD_ARTICULOS,
	        A.IMPORTE,
	        A.FECHA_VENTA,
	        A.HORA_VENTA,
	        A.FECHA_MODIF,
	        A.LOGIN_MODIF,
	        A.TERM_MODIF
	FROM VENTAS A
	--	INNER JOIN ARTICULOS_VENTAS B ON (A.ID_Venta = B.ID_Venta)
		WHERE A.ESTADO = 1
			AND A.FECHA_VENTA = ISNULL(@D_16_FECHA, A.FECHA_VENTA) 
      
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
