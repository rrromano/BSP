Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'ObtenerTotales')
  Drop Procedure dbo.ObtenerTotales
Go 

Create procedure dbo.ObtenerTotales (@fecha_mov datetime, @TipoMovimiento int)
as

SELECT SUM(A.Valor) AS 'TOTAL'
FROM MOVIMIENTOS_CAJA A
INNER JOIN TIPOMOVIMIENTO_CAJA B ON (A.ID_TipoMovimiento = B.ID_TipoMovimiento)
WHERE 1 = 1
  AND A.Fecha = @fecha_mov
  AND B.ID_TipoMovimiento = @TipoMovimiento
		  
go
