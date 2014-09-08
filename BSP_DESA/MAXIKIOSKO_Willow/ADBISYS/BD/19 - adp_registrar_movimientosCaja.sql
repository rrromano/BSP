Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_registrar_movimientosCaja')
  Drop Procedure adp_registrar_movimientosCaja
Go 

-- SP QUE REGISTRAN LOS MOVIMIENTOS PARAMETRIZADOS DE LA CAJA
Create procedure adp_registrar_movimientosCaja (	@FECHA           datetime, 
																									@HORA            varchar(8)
																								) 
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
  INSERT INTO MOVIMIENTOS_CAJA (ID_TIPOMOVIMIENTO,  
                                VALOR, 
                                FECHA, 
                                HORA)
	SELECT	A.ID_TIPOMOVIMIENTO,
					0.00,
          @FECHA, 
          @HORA
	FROM TIPOMOVIMIENTO_CAJA A
	WHERE 1 = 1
		AND A.ESTADO = 1
		AND A.ID_TipoMovimiento != 0 --NO INSERTO EL CIERRE DE CAJA
          
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
