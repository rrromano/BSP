Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_compras')
  Drop Procedure adp_busqueda_compras
Go 

-- SP QUE BUSCA COMPRAS DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_compras @tabla       varchar(255),
																			@campo_tabla varchar(255),
																			@texto			 varchar(255),
																			@fecha			 varchar(8)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	IF (@CAMPO_TABLA = 'Id_Proveedor')
		begin
			exec ('select  UPPER(Id_Compra)			AS CÓDIGO,
										 UPPER(B.Nombre)			AS PROVEEDOR,
										 IMPORTE							AS IMPORTE,
										 convert(varchar,A.FECHA_COMPRA,120) AS FECHA_COMPRA,
										 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
										 UPPER(A.login_modif) AS LOGIN_MODIF,
										 UPPER(A.term_modif)  AS TERM_MODIF from ' + @tabla + ' A INNER JOIN PROVEEDORES B ON (A.ID_PROVEEDOR = B.ID_PROVEEDOR) WHERE A.ESTADO = 1 AND A.FECHA_COMPRA = convert(varchar,' + @fecha + ',120) AND B.NOMBRE LIKE ''' + @texto + '%''')
		end else
		begin
			exec ('select  UPPER(Id_Compra)			AS CÓDIGO,
										 UPPER(B.Nombre)			AS PROVEEDOR,
										 IMPORTE							AS IMPORTE,
										 convert(varchar,A.FECHA_COMPRA,120) AS FECHA_COMPRA,
										 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
										 UPPER(A.login_modif) AS LOGIN_MODIF,
										 UPPER(A.term_modif)  AS TERM_MODIF from ' + @tabla + ' A INNER JOIN PROVEEDORES B ON (A.ID_PROVEEDOR = B.ID_PROVEEDOR)' + ' WHERE A.ESTADO = 1 AND A.FECHA_COMPRA = convert(varchar,' + @fecha + ',120) AND ' + @campo_tabla + ' like ''' + @texto + '%''')
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
