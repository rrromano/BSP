Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busquedaArticuloPorDescripcion')
  Drop Procedure adp_busquedaArticuloPorDescripcion
Go 

-- SP QUE BUSCA ARTICULOS POR DESCRIPCION

Create procedure dbo.adp_busquedaArticuloPorDescripcion (@DescripcionArticulo varchar(255))
as

BEGIN TRY
  SET NOCOUNT ON
  
  SELECT  ID_ARTICULO As 'ID', 
          UPPER(DESCRIPCION) As 'ARTICULO', 
          PRECIO_VENTA As 'PRECIO'
  FROM ARTICULOS
  WHERE DESCRIPCION like '%' + @DescripcionArticulo + '%'
							
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
