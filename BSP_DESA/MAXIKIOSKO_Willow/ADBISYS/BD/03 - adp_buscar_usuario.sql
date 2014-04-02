Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_buscar_usuario')
  Drop Procedure adp_buscar_usuario
Go 

-- SP QUE BUSCA USUARIO.
Create procedure adp_buscar_usuario (@user varchar(255),
									 @Pass varchar(255)) 
as

SELECT * FROM USUARIOS WHERE Username = @user AND Pass = @Pass
go
