Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtener_proveedores')
  Drop Procedure dbo.adp_obtener_proveedores
Go 

-- SP PARA OBTENER LOS DIFERENTES PROVEEDORES
Create procedure dbo.adp_obtener_proveedores
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT UPPER(ID_Proveedor)  AS CÓDIGO,
				 UPPER(Nombre)				AS NOMBRE,
				 UPPER(B.DESCRIPCION) AS RUBRO ,
				 UPPER(Contacto)			AS CONTACTO,
				 UPPER(Direccion)		  AS DIRECCION,
				 UPPER(Localidad)		  AS LOCALIDAD,
				 UPPER(Provincia)		  AS PROVINCIA,
				 UPPER(Telefono)			AS TELEFONO,
				 UPPER(Cuit)					AS CUIT,
				 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
				 UPPER(A.login_modif) AS LOGIN_MODIF,
				 UPPER(A.term_modif)  AS TERM_MODIF

	FROM PROVEEDORES A 
		INNER JOIN RUBROS B ON (A.ID_RUBRO = B.ID_RUBRO) 				 

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
