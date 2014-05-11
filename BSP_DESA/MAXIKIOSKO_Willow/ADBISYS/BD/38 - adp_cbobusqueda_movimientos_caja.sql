Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_cbobusqueda_movimientos_caja')
  Drop Procedure adp_cbobusqueda_movimientos_caja
Go 

-- SP QUE TRAE LAS DIFERENTES COLUMNAS DE LA TABLA DE MOVIMIENTOS_CAJA, PARA LLENAR EL COMBO DE BÚSQUEDA DE MOVIMIENTOS.

Create procedure adp_cbobusqueda_movimientos_caja 
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	SELECT case when c.name = 'ID_Movimiento' then 'CÓDIGO'
							when c.name = 'ID_TipoMovimiento' then 'MOVIMIENTO'
							when c.name = 'Valor' then 'VALOR'
							else upper(c.name)
				 end as CAMPO
	FROM sys.columns c JOIN sys.tables t
	ON c.object_id = t.object_id
	WHERE t.name = 'MOVIMIENTOS_CAJA' 
  and c.name not in ('Fecha', 'Hora', 'Estado')

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
