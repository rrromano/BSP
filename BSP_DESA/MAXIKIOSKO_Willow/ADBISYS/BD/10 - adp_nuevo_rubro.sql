Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_nuevo_rubro')
  Drop Procedure adp_nuevo_rubro
Go 

-- SP QUE INSERTA UN NUEVO RUBRO.
Create procedure adp_nuevo_rubro (@Desccripcion	varchar(255),
								  @Login		varchar(255))
as

INSERT INTO RUBROS (Descripcion,fecha_modif,login_modif,term_modif) 
	VALUES (upper(@Desccripcion), GETDATE(), @Login, HOST_NAME())
go
