Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtenerTotal_compras')
  Drop Procedure adp_obtenerTotal_compras
Go 

-- SP PARA OBTENER EL TOTAL LAS DIFERENTES COMPRAS ENTRE LAS FECHAS RECIBIDAS COMO PARÁMETRO.
Create procedure dbo.adp_obtenerTotal_compras (@fechaDesde datetime,
																					@fechaHasta datetime)
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT SUM(Importe) AS IMPORTE
			FROM COMPRAS A
		WHERE A.ESTADO = 1
			AND A.Fecha_Compra between @fechaDesde and @fechaHasta

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
