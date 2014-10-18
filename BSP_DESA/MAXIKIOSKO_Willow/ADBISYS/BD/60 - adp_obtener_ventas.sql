Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtener_ventas')
  Drop Procedure adp_obtener_ventas
Go 

-- SP PARA OBTENER LAS DIFERENTES VENTAS ENTRE LAS FECHAS RECIBIDAS COMO PARÁMETRO.
Create procedure dbo.adp_obtener_ventas (@fechaDesde datetime,
																				 @fechaHasta datetime)
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT  A.ID_VENTA AS 'CÓDIGO',
	        A.IMPORTE  AS 'IMPORTE',
	        A.CANTIDAD_ARTICULOS  AS 'ARTÍCULOS',
	        CONVERT(VARCHAR,A.FECHA_MODIF,120) AS 'FECHA_MODIF',
	        A.LOGIN_MODIF  AS 'LOGIN_MODIF',
	        A.TERM_MODIF   AS 'TERM_MODIF'
	FROM VENTAS A
	--	INNER JOIN ARTICULOS_VENTAS B ON (A.ID_Venta = B.ID_Venta)
		WHERE A.ESTADO = 1
			AND A.FECHA_VENTA between @fechaDesde and @fechaHasta
      
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
