Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_registrar_mov_caja')
  Drop Procedure adp_registrar_mov_caja
Go 

-- SP QUE REGISTRA CADA MOVIMIENTO DE LA CAJA.
Create procedure adp_registrar_mov_caja ( @Ingreso_Salida numeric(1), 
                                          @Descripcion    varchar(255), 
                                          @Valor          numeric(10,2), 
                                          @fecha          datetime, 
                                          @hora           varchar(8)
                                        ) 
as

INSERT INTO MOVIMIENTOS_CAJA (Ingreso_Salida, Descripcion, Valor, Fecha, Hora)
VALUES (@Ingreso_Salida, @Descripcion, @Valor, @Fecha, @Hora)
go
