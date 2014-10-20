Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_ventas')
  Drop Procedure adp_busqueda_ventas
Go 

-- SP QUE BUSCA VENTAS DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_ventas @tabla       varchar(255),
																		 @campo_tabla varchar(255),
																		 @texto			  varchar(255),
																		 @fecha				varchar(8)
as

BEGIN TRY 
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'

	exec ('select UPPER(Id_Venta) AS CÓDIGO,
								A.IMPORTE AS IMPORTE,
								A.CANTIDAD_ARTICULOS AS ARTÍCULOS,
								CONVERT(VARCHAR,A.FECHA_MODIF,120) AS FECHA_MODIF,
								UPPER(A.LOGIN_MODIF) AS LOGIN_MODIF,
								UPPER(A.TERM_MODIF) AS TERM_MODIF from ' + @tabla + ' A WHERE A.ESTADO = 1 AND A.FECHA_VENTA = convert(varchar,' + @fecha + ',120) AND ' + @campo_tabla + ' like ''' + @texto + '%''')
							
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
