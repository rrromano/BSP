Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_rubros')
  Drop Procedure adp_busqueda_rubros
Go 

-- SP QUE BUSCA RUBROS DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_rubros @tabla       varchar(255),
																		 @campo_tabla varchar(255),
																		 @texto				varchar(255)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACI�N'
  
		exec ('select  UPPER(ID_Rubro)		AS C�DIGO,
									 UPPER(Descripcion) AS DESCRIPCI�N,
									 convert(varchar,fecha_modif,120) AS FECHA_MODIF,
									 UPPER(login_modif) AS LOGIN_MODIF,
									 UPPER(term_modif)  AS TERM_MODIF from ' + @tabla + ' where ESTADO = 1 AND ' + @campo_tabla + ' like ''' + @texto + '%''')
							
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
