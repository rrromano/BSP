Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_cbobusqueda_tipoMovimientos_caja')
  Drop Procedure adp_cbobusqueda_tipoMovimientos_caja
Go 

-- SP QUE TRAE LAS DIFERENTES COLUMNAS DE LA TABLA DE TIPOMOVIMIENTO_CAJA, PARA LLENAR EL COMBO DE BÚSQUEDA DE TIPOS DE MOVIMIENTOS.

Create procedure adp_cbobusqueda_tipoMovimientos_caja 
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	SELECT case when c.name = 'ID_TipoMovimiento' then 'CÓDIGO'
							when c.name = 'Descripcion' then 'MOVIMIENTO'
							when c.name = 'INGRESO_SALIDA' then 'INGRESO/SALIDA'
							else upper(c.name)
				 end as CAMPO
	FROM sys.columns c JOIN sys.tables t
	ON c.object_id = t.object_id
	WHERE t.name = 'TIPOMOVIMIENTO_CAJA' 
  and c.name not in ('Estado','fecha_modif','login_modif','term_modif')

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
