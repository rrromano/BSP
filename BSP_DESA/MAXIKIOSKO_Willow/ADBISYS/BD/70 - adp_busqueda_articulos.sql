Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_articulos')
  Drop Procedure adp_busqueda_articulos
Go 

-- SP QUE BUSCA COMPRAS DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_articulos @tabla       varchar(255),
																				@campo_tabla varchar(255),
																				@texto			 varchar(255)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	IF (@CAMPO_TABLA = 'Rubro')
		begin
			exec ('select  UPPER(A.ID_Articulo)		AS CÓDIGO,
										 UPPER(A.Descripcion)		AS DESCRIPCIÓN,
										 PRECIO_VENTA						AS PRECIO_VENTA,
										 PRECIO_COMPRA					AS PRECIO_COMPRA,
										 UPPER(B.Descripcion)		AS RUBRO,
										 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
										 UPPER(A.login_modif) AS LOGIN_MODIF,
										 UPPER(A.term_modif)  AS TERM_MODIF from ' + @tabla + ' A INNER JOIN RUBROS B ON (A.RUBRO = B.ID_RUBRO) WHERE A.ESTADO = 1 AND B.DESCRIPCION LIKE ''' + @texto + '%''')
		end else
		begin
			exec ('select  UPPER(A.ID_Articulo)		AS CÓDIGO,
										 UPPER(A.Descripcion)		AS DESCRIPCIÓN,
										 PRECIO_VENTA						AS PRECIO_VENTA,
										 PRECIO_COMPRA					AS PRECIO_COMPRA,
										 UPPER(B.Descripcion)		AS RUBRO,
										 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
										 UPPER(A.login_modif) AS LOGIN_MODIF,
										 UPPER(A.term_modif)  AS TERM_MODIF from ' + @tabla + ' A INNER JOIN RUBROS B ON (A.RUBRO = B.ID_RUBRO)' + ' WHERE A.ESTADO = 1 AND A.' + @campo_tabla + ' like ''' + @texto + '%''')
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
