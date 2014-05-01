Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtener_compras')
  Drop Procedure dbo.adp_obtener_compras
Go 

-- SP PARA OBTENER LAS DIFERENTES COMPRAS DEL D�A
Create procedure dbo.adp_obtener_compras
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT UPPER(A.Id_Compra)		AS C�DIGO,
				 UPPER(B.Nombre)			AS PROVEEDOR,
				 UPPER(A.Importe)			AS IMPORTE,	
				 convert(varchar,A.Fecha_Compra,120) AS 'FECHA DE COMPRA',
				 convert(varchar,A.fecha_modif,120) AS FECHA_MODIF,
				 UPPER(A.login_modif) AS LOGIN_MODIF,
				 UPPER(A.term_modif)  AS TERM_MODIF

	FROM COMPRAS A
		INNER JOIN PROVEEDORES B ON (A.Id_Proveedor = B.ID_Proveedor)
		WHERE A.ESTADO = 1

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
