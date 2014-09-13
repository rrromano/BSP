Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_verificoExistencia_articulo')
  Drop Procedure adp_verificoExistencia_articulo
Go 

-- SP QUE VERIFICA EXISTENCIA DE UN ARTICULO.

Create procedure adp_verificoExistencia_articulo (@Codigo varchar(20))
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	select 1 from ARTICULOS where ID_Articulo	= @Codigo 
															and ESTADO		= 1

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
