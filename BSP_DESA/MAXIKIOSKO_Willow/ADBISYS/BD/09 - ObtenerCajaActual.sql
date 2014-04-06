Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'ObtenerCajaActual')
  Drop Procedure dbo.ObtenerCajaActual
Go 

Create procedure dbo.ObtenerCajaActual (@fecha_mov datetime)
as

SELECT SUM(Importe_Total) AS 'TOTAL'
FROM CAJA
WHERE Fecha = @fecha_mov
		  
go
