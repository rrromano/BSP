Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_registrar_mov_caja')
  Drop Procedure adp_registrar_mov_caja
Go 

-- SP QUE REGISTRA CADA MOVIMIENTO DE LA CAJA.
Create procedure adp_registrar_mov_caja ( @Tipo_Movimiento numeric(2), 
                                          @Descripcion     varchar(255), 
                                          @Valor           numeric(10,2), 
                                          @fecha           datetime, 
                                          @hora            varchar(8)
                                        ) 
as

BEGIN TRY
  SET NOCOUNT ON
  PRINT 'INICIO ACTUALIZACI�N'
  
  INSERT INTO MOVIMIENTOS_CAJA (ID_TipoMovimiento, 
                                Descripcion, 
                                Valor, 
                                Fecha, 
                                Hora)
  VALUES (@Tipo_Movimiento, 
          @Descripcion, 
          @Valor, 
          @Fecha, 
          @Hora)
          
  PRINT 'FIN ACTUALIZACI�N OK'
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
