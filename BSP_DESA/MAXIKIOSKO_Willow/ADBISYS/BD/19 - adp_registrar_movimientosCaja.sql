Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_registrar_movimientosCaja')
  Drop Procedure adp_registrar_movimientosCaja
Go 

-- SP QUE REGISTRAN LOS MOVIMIENTOS PARAMETRIZADOS DE LA CAJA
Create procedure adp_registrar_movimientosCaja (	@fecha           datetime, 
																									@hora            varchar(8)
																								) 
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACIÓN'
  
  INSERT INTO MOVIMIENTOS_CAJA (ID_TipoMovimiento,  
                                Valor, 
                                Fecha, 
                                Hora)
	SELECT	Id_TipoMovimiento,
					0.00,
          @Fecha, 
          @Hora
	FROM TIPOMOVIMIENTO_CAJA
	WHERE ID_TipoMovimiento != 0 --NO INSERTO EL CIERRE DE CAJA
          
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
