Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_verifico_rubro_existente')
  Drop Procedure adp_verifico_rubro_existente
Go 

-- SP QUE VERIFICA SI EXISTE LA MISMA DESCRIPCION PARA UN RUBRO EXISTENTE
Create procedure adp_verifico_rubro_existente (@RUBRO_DESCRIPCION VARCHAR(255),
																							 @ID_RUBRO					INT)
as


BEGIN TRY

	SET NOCOUNT ON
	
	IF EXISTS(SELECT 1 FROM RUBROS WHERE UPPER(DESCRIPCION) = UPPER(@RUBRO_DESCRIPCION) AND (ID_Rubro <> @ID_RUBRO) AND ESTADO = 1)
		SELECT 1 AS 'RESULTADO'
	ELSE
		SELECT 0 AS 'RESULTADO'

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
