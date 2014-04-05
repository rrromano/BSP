Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_info_usuario')
  Drop Procedure adp_info_usuario
Go 

-- SP QUE TRAE LA INFORMACIÓN DEL USUARIO.
Create procedure adp_info_usuario (@user varchar(255))
as

SELECT * FROM USUARIOS WHERE Username = @user
go
