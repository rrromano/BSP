Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_FecSis')
  Drop Procedure adp_FecSis
Go 

-- SP PARA OBTENER LOS MOVIMIENTOS DE LA CAJA DEL D�A @FECHA_MOV
Create procedure dbo.adp_FecSis (@FECHA DATETIME = NULL)
as


BEGIN TRY

	SET NOCOUNT ON
	
	IF (@FECHA IS NULL)
	BEGIN
	
		SELECT Fecha_Sistema FROM PARAMETROS_GENERALES
		
	END ELSE BEGIN
	
		SELECT 'FECHA DE SISTEMA ACTUALIZADA CORRECTAMENTE'
		SELECT  'FECHA ANTERIOR ' + CONVERT(VARCHAR,Fecha_Sistema) FROM PARAMETROS_GENERALES
		
		UPDATE A
		SET A.Fecha_Sistema = @FECHA
		FROM PARAMETROS_GENERALES A
		
		SELECT  'FECHA ACTUAL ' + CONVERT(VARCHAR,Fecha_Sistema) FROM PARAMETROS_GENERALES
	END
	

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