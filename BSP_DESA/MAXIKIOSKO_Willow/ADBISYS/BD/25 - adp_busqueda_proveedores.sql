Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_busqueda_proveedores')
  Drop Procedure adp_busqueda_proveedores
Go 

-- SP QUE BUSCA PROVEEDORES DE ACUERDO A LOS PARAMETROS QUE RECIBA.

Create procedure adp_busqueda_proveedores @tabla       varchar(255),
																					@campo_tabla varchar(255),
																					@texto			 varchar(255)
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	IF (@CAMPO_TABLA = 'Id_Rubro')
		begin
			exec ('select  UPPER(ID_Proveedor)  AS CÓDIGO,
										 UPPER(Nombre)				AS NOMBRE,
										 UPPER(B.DESCRIPCION) AS RUBRO ,
										 UPPER(Contacto)			AS CONTACTO,
										 UPPER(Direccion)		  AS DIRECCIÓN,
										 UPPER(Localidad)		  AS LOCALIDAD,
										 UPPER(Provincia)		  AS PROVINCIA,
										 UPPER(Telefono)			AS TELÉFONO,
										 UPPER(Cuit)					AS CUIT,
										 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
										 UPPER(A.login_modif) AS LOGIN_MODIF,
										 UPPER(A.term_modif)  AS TERM_MODIF from ' + @tabla + ' A INNER JOIN RUBROS B ON (A.ID_RUBRO = B.ID_RUBRO) WHERE B.DESCRIPCION LIKE ''' + @texto + '%''')
		end else
		begin
			exec ('select  UPPER(ID_Proveedor)  AS CÓDIGO,
										 UPPER(Nombre)				AS NOMBRE,
										 UPPER(B.DESCRIPCION) AS RUBRO ,
										 UPPER(Contacto)			AS CONTACTO,
										 UPPER(Direccion)		  AS DIRECCIÓN,
										 UPPER(Localidad)		  AS LOCALIDAD,
										 UPPER(Provincia)		  AS PROVINCIA,
										 UPPER(Telefono)			AS TELÉFONO,
										 UPPER(Cuit)					AS CUIT,
										 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
										 UPPER(A.login_modif) AS LOGIN_MODIF,
										 UPPER(A.term_modif)  AS TERM_MODIF from ' + @tabla + ' A INNER JOIN RUBROS B ON (A.ID_RUBRO = B.ID_RUBRO)'  + ' where ' + @campo_tabla + ' like ''' + @texto + '%''')
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
