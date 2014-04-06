Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'ObtenerMovimientosCaja')
  Drop Procedure dbo.ObtenerMovimientosCaja
Go 

-- SP PARA OBTENER LOS MOVIMIENTOS DE LA CAJA DEL DÍA @FECHA_MOV
Create procedure dbo.ObtenerMovimientosCaja (@fecha_mov datetime)
as

SELECT  
        CONVERT(VARCHAR,Fecha,112) 'FECHA',
        CONVERT(VARCHAR,HORA,8) 'HORA',
        CASE WHEN B.Ingreso_Salida = 1 THEN 'INGRESO' ELSE 'SALIDA' END AS 'INGRESO/SALIDA',
        UPPER(A.Descripcion) AS 'MOVIMIENTO',
        valor AS 'VALOR'
FROM MOVIMIENTOS_CAJA A
INNER JOIN TIPOMOVIMIENTO_CAJA B ON (A.ID_TipoMovimiento = B.ID_TipoMovimiento)
WHERE Fecha = @fecha_mov
		  
go
