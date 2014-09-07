Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_TipoMovimientos_caja')
  Drop Procedure adp_busqueda_TipoMovimientos_caja
Go 

-- SP QUE BUSCA TIPOS DE MOVIMIENTOS DE CAJA DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_TipoMovimientos_caja @tabla       varchar(255),
																									 @campo_tabla varchar(255),
																									 @texto			  varchar(255)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
			exec ('select  ID_TIPOMOVIMIENTO	AS CÓDIGO,
										 UPPER(DESCRIPCION) AS MOVIMIENTO,
										 CASE INGRESO_SALIDA 
				  							WHEN 1 THEN ''INGRESO''
												ELSE ''SALIDA''
										 END AS	''INGRESO/SALIDA'',
										 CONVERT(VARCHAR,fecha_modif,120) AS FECHA_MODIF,
										 UPPER(login_modif) AS LOGIN_MODIF,
										 UPPER(term_modif) AS TERM_MODIF
							from ' + @tabla + ' WHERE ESTADO = 1 AND ' + @campo_tabla + ' like ''' + @texto + '%''')
							
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
