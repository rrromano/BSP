Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_maximo_proveedor')
  Drop Procedure adp_maximo_proveedor
Go 

-- SP QUE TRAE EL MÁXIMO CÓDIGO DE PROVEEDOR.
Create procedure adp_maximo_proveedor 
as

select (isnull(MAX(ID_Proveedor),0) + 1) as maximo from PROVEEDORES
go
