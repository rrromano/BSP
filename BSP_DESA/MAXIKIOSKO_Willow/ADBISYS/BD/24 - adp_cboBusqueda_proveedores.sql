Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_cboBusqueda_proveedores')
  Drop Procedure adp_cboBusqueda_proveedores
Go 

-- SP QUE TRAE LAS DIFERENTES COLUMNAS DE LA TABLA DE PROVEEDORES, PARA LLENAR EL COMBO DE B�SQUEDA DE PROVEEDORES.

Create procedure adp_cboBusqueda_proveedores 
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACI�N'
  
	SELECT case when c.name = 'ID_Proveedor' then 'C�DIGO'
							when c.name = 'ID_Rubro' then 'RUBRO'
							when c.name = 'Direccion' then 'DIRECCI�N'
							else upper(c.name)
				 end as CAMPO
	FROM sys.columns c JOIN sys.tables t
	ON c.object_id = t.object_id
	WHERE t.name = 'PROVEEDORES'

  PRINT 'FIN ACTUALIZACI�N OK'
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
