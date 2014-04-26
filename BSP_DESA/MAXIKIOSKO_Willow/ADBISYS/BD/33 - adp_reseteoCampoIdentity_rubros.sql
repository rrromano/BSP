Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_reseteoCampoIdentity_rubros')
  Drop Procedure adp_reseteoCampoIdentity_rubros
Go 

-- SP QUE SI SE ELIMINARON TODOS LOS RUBROS, REINICIA EL CAMPO IDENTITY.

Create procedure adp_reseteoCampoIdentity_rubros 
as


BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	if not exists (select 1 from RUBROS)
		DBCC CHECKIDENT (RUBROS, RESEED, 0)

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
