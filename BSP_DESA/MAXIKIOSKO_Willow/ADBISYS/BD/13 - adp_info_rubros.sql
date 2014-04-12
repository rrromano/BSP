Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_info_rubros')
  Drop Procedure adp_info_rubros
Go 

-- SP QUE TRAE INFORMACIÓN DE LOS RUBROS.
Create procedure adp_info_rubros 
as

SELECT * FROM RUBROS 
go