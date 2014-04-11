Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_maximo_rubro')
  Drop Procedure adp_maximo_rubro
Go 

-- SP QUE TRAE EL MÁXIMO CÓDIGO DE RUBRO.
Create procedure adp_maximo_rubro 
as

select (isnull(MAX(ID_Rubro),0) + 1) as maximo from RUBROS
go
