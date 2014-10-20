Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_cboBusqueda_ventas')
  Drop Procedure adp_cboBusqueda_ventas
Go 

-- SP QUE TRAE LAS DIFERENTES COLUMNAS DE LA TABLA DE VENTAS, PARA LLENAR EL COMBO DE BÚSQUEDA DE VENTAS.

Create procedure adp_cboBusqueda_ventas 
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	SELECT case when c.name = 'ID_Venta' then 'CÓDIGO'
							when c.name = 'IMPORTE' then 'IMPORTE'
							when c.name = 'CANTIDAD_ARTICULOS' then 'ARTÍCULOS'
							--else upper(c.name)
				 end as CAMPO
	FROM sys.columns c JOIN sys.tables t
	ON c.object_id = t.object_id
	WHERE t.name = 'VENTAS' and c.name not in ('fecha_modif', 'login_modif', 'term_modif', 'estado', 'fecha_venta','hora_venta')

  PRINT 'FIN ACTUALIZACIÓN OK'
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
