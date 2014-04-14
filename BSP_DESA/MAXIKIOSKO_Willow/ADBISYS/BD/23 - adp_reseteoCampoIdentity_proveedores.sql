Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_reseteoCampoIdentity_proveedores')
  Drop Procedure adp_reseteoCampoIdentity_proveedores
Go 

-- SP QUE SI SE ELIMINARON TODOS LOS PROVEEDORES, REINICIA EL CAMPO IDENTITY.

Create procedure adp_reseteoCampoIdentity_proveedores 
as


BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
	if not exists (select 1 from PROVEEDORES)
		DBCC CHECKIDENT (PROVEEDORES, RESEED, 0)

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
