Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_obtener_rubros')
  Drop Procedure dbo.adp_obtener_rubros
Go 

-- SP PARA OBTENER LOS DIFERENTES RUBROS
Create procedure dbo.adp_obtener_rubros
as

BEGIN TRY

	SET NOCOUNT ON
	
	SELECT UPPER(ID_Rubro)		AS CÓDIGO,
				 UPPER(Descripcion)	AS DESCRIPCIÓN,
				 convert(varchar,fecha_modif,120) AS FECHA_MODIF,
				 UPPER(login_modif) AS LOGIN_MODIF,
				 UPPER(term_modif)  AS TERM_MODIF

	FROM RUBROS
		WHERE ESTADO = 1

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
