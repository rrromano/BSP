Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_verificar_articulo_ventas')
  Drop Procedure adp_verificar_articulo_ventas
Go 

-- VERIFICO QUE CUANDO ELIMINO UN ARTICULO, NO EXISTA UNA VENTA QUE TENGA DICHO ARTICULO.

Create procedure adp_verificar_articulo_ventas (@Id_Articulo varchar(20))
as


BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	SELECT 1 AS VALOR FROM ARTICULOS_VENTAS WHERE ID_Articulo = @Id_Articulo
	
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
