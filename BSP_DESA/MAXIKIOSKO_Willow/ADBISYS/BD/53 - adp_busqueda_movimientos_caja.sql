Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_movimientos_caja')
  Drop Procedure adp_busqueda_movimientos_caja
Go 

-- SP QUE BUSCA MOVIMIENTOS DE CAJA DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_movimientos_caja @tabla       varchar(255),
																							 @campo_tabla varchar(255),
																							 @texto			  varchar(255),
																							 @Fecha				datetime
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	IF (@CAMPO_TABLA = 'ID_TipoMovimiento')
		begin
		
			exec ('select  UPPER(ID_Movimiento)				AS CÓDIGO,
										 UPPER(B.Descripcion)	AS MOVIMIENTO,
										 UPPER(Valor)								AS Valor,
										 LEFT(CONVERT(VARCHAR,A.FECHA,120),10) AS Fecha,
										 CONVERT(VARCHAR,A.HORA,8)	AS HORA,
										 CASE B.INGRESO_SALIDA 
												WHEN 1 THEN ''INGRESO''  
												ELSE ''SALIDA'' 
										 END									AS	''INGRESO/SALIDA''
										 from ' + @tabla + ' A INNER JOIN TIPOMOVIMIENTO_CAJA B ON (A.ID_TipoMovimiento = B.ID_TipoMovimiento) WHERE B.ESTADO = 1 AND A.FECHA = ''' + @Fecha + ''' AND B.DESCRIPCION LIKE ''' + @texto + '%''')
		end else
		begin
			exec ('select  UPPER(ID_Movimiento)				AS CÓDIGO,
										 UPPER(B.Descripcion)	AS MOVIMIENTO,
										 UPPER(Valor)								AS Valor,
										 LEFT(CONVERT(VARCHAR,A.FECHA,120),10) AS Fecha,
										 CONVERT(VARCHAR,A.HORA,8)	AS HORA,
										 CASE B.INGRESO_SALIDA 
												WHEN 1 THEN ''INGRESO''  
												ELSE ''SALIDA'' 
										 END									AS	''INGRESO/SALIDA''
										 from ' + @tabla + ' A INNER JOIN TIPOMOVIMIENTO_CAJA B ON (A.ID_TipoMovimiento = B.ID_TipoMovimiento)'  + ' WHERE B.ESTADO = 1 AND A.FECHA = ''' + @Fecha + ''' AND ' + @campo_tabla + ' like ''' + @texto + '%''')
		end
							
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
