Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_actualizar_estado_global')
  Drop Procedure adp_actualizar_estado_global
Go 

-- SP QUE BUSCA USUARIO.
Create procedure adp_actualizar_estado_global (@estado numeric(1)) 
as

UPDATE PARAMETROS_GENERALES SET Estado_Caja = @estado

go
