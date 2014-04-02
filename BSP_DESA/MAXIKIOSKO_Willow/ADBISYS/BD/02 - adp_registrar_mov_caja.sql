USE WIAdbisys
GO

If Exists ( Select 1 From SysObjects Where Name = 'adp_registrar_mov_caja')
  Drop Procedure adp_registrar_mov_caja
Go 

Create procedure adp_registrar_mov_caja (@) --Sp que registra cada movimiento de la caja
