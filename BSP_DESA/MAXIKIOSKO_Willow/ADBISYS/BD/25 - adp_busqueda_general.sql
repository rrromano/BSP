Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_general')
  Drop Procedure adp_busqueda_general
Go 

-- SP QUE BUSCA EN CUALQUIER TABLA, DEPENDIENDO DE LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_general @tabla       varchar(255),
																			@campo_tabla varchar(255),
																			@texto			 varchar(255)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	declare @cadenaSql varchar(1000) 
	exec ('select * from ' + @tabla + ' where ' + @campo_tabla + ' like ''' + @texto + '%''')
	
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
