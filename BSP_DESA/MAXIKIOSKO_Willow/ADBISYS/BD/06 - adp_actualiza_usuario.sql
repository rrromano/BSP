Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_actualiza_usuario')
  Drop Procedure adp_actualiza_usuario
Go 

-- SP QUE ACTUALIZA LOS DATOS DEL USUARIO.
Create procedure adp_actualiza_usuario (@user			varchar(255),
										@Desccripcion	varchar(255),
										@Password		varchar(255))
as

UPDATE USUARIOS SET Descripcion = @Desccripcion,
					Pass		= @Password
			WHERE	Username	= @user					  
go
