Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtenerTotal_ventas')
  Drop Procedure adp_obtenerTotal_ventas
Go 

-- SP PARA OBTENER EL TOTAL LAS DIFERENTES VENTAS ENTRE LAS FECHAS RECIBIDAS COMO PARÁMETRO.
Create procedure dbo.adp_obtenerTotal_ventas (@fechaDesde datetime,
																				 @fechaHasta datetime)
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT  SUM(A.IMPORTE) AS 'IMPORTE'
	FROM VENTAS A
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
