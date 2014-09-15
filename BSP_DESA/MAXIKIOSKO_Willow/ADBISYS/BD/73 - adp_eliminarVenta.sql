Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_eliminarVenta')
  Drop Procedure adp_eliminarVenta
Go 

-- SP PARA TODOS LOS REGISTROS DE TMP_ARTICULOS_VENTAS 
Create procedure dbo.adp_eliminarVenta  (@Id_Venta AS NUMERIC(30), @LOGIN AS VARCHAR(255) = NULL)
as

BEGIN TRY
    
	  SET NOCOUNT ON
  	
  	UPDATE A
  	SET A.Estado = 0, 
  	    A.fecha_modif = GETDATE(),
  	    A.login_modif = ISNULL(@LOGIN,'USUARIO NO LOGUEADO'),
  	    A.term_modif = HOST_NAME()
  	FROM VENTAS A
  	WHERE A.ID_Venta = @Id_Venta
  	
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
