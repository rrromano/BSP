USE WIAdbisys
GO

-- RR 2014-03-21: CREACIÓN DE LAS DIFERENTES TABLAS QUE UTILIZARÁ EL SISTEMA ADBISYS.

SET NOCOUNT ON
BEGIN TRAN

PRINT REPLICATE('=',60)
PRINT 'INICIO DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',60)
GO


If Exists ( Select 1 From sysobjects Where Name = 'COMPRAS' )
  Drop Table COMPRAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'ESTADO_COMPRAS' )
  Drop Table ESTADO_COMPRAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'USUARIOS' )
  Drop Table USUARIOS
Go
If Exists ( Select 1 From sysobjects Where Name = 'TMP_ARTICULOS_VENTAS' )
  Drop Table TMP_ARTICULOS_VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'ARTICULOS_VENTAS' )
  Drop Table ARTICULOS_VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'ARTICULOS' )
  Drop Table ARTICULOS
Go
If Exists ( Select 1 From sysobjects Where Name = 'ESTADO_ARTICULOS' )
  Drop Table ESTADO_ARTICULOS
Go
If Exists ( Select 1 From sysobjects Where Name = 'PROVEEDORES' )
  Drop Table PROVEEDORES
Go
If Exists ( Select 1 From sysobjects Where Name = 'ESTADO_PROVEEDORES' )
  Drop Table ESTADO_PROVEEDORES
Go
If Exists ( Select 1 From sysobjects Where Name = 'RUBROS' )
  Drop Table RUBROS
Go
If Exists ( Select 1 From sysobjects Where Name = 'ESTADO_RUBROS' )
  Drop Table ESTADO_RUBROS
Go
If Exists ( Select 1 From sysobjects Where Name = 'TMP_VENTAS' )
  Drop Table TMP_VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'VENTAS' )
  Drop Table VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'ESTADO_VENTAS' )
  Drop Table ESTADO_VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'MOVIMIENTOS_CAJA' )
  Drop Table MOVIMIENTOS_CAJA
Go
If Exists ( Select 1 From sysobjects Where Name = 'TIPOMOVIMIENTO_CAJA' )
  Drop Table TIPOMOVIMIENTO_CAJA
Go
If Exists ( Select 1 From sysobjects Where Name = 'ESTADO_TIPOMOVIMIENTO_CAJA' )
  Drop Table ESTADO_TIPOMOVIMIENTO_CAJA
Go
If Exists ( Select 1 From sysobjects Where Name = 'PARAMETROS_GENERALES' )
  Drop Table PARAMETROS_GENERALES
Go
--=============================================================================================
------------------------------------ TABLE USUARIOS -------------------------------------------
--=============================================================================================
create table USUARIOS(
	ID_User			    int identity not null,
	Username		    varchar(255) not null,
	Pass			      varchar(255) not null,
	Descripcion		  varchar(255) not null,
	sino_bloqueado	numeric(1)   not null, -- 1: bloqueado.
	fecha_modif     datetime      null,
	login_modif     varchar(255)  null,
	term_modif      varchar(255)  null
	)
ALTER TABLE USUARIOS ADD PRIMARY KEY(ID_User)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA USUARIOS.'
GO
--=============================================================================================
------------------------------------ TABLE ESTADO_RUBROS --------------------------------------
--=============================================================================================
create table ESTADO_RUBROS(
	Estado			numeric(1)		not null,
	Descripcion	varchar(255)	not null,
	fecha_modif datetime      null,
	login_modif varchar(255)  null,
	term_modif  varchar(255)  null
)
ALTER TABLE ESTADO_RUBROS ADD PRIMARY KEY(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA ESTADO_RUBROS.'
GO
--=============================================================================================
------------------------------------ TABLE RUBROS ---------------------------------------------
--=============================================================================================
create table RUBROS(
	ID_Rubro    int identity  not null,
	Descripcion varchar(255)  not null,
	Estado			numeric(1)		not null,
	fecha_modif datetime      null,
	login_modif varchar(255)  null,
	term_modif  varchar(255)  null
)
ALTER TABLE RUBROS ADD PRIMARY KEY(ID_Rubro)
GO
ALTER TABLE RUBROS ADD CONSTRAINT FK_ESTADO_RUBROS 
	FOREIGN KEY(Estado) REFERENCES ESTADO_RUBROS(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA RUBROS.'
GO
--=============================================================================================
------------------------------------ TABLE ESTADO_ARTICULOS -----------------------------------
--=============================================================================================
create table ESTADO_ARTICULOS(
	Estado			numeric(1)		not null,
	Descripcion	varchar(255)	not null,
	fecha_modif datetime      null,
	login_modif varchar(255)  null,
	term_modif  varchar(255)  null
)
ALTER TABLE ESTADO_ARTICULOS ADD PRIMARY KEY(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA ESTADO_ARTICULOS.'
GO
--=============================================================================================
------------------------------------ TABLE ARTICULOS ------------------------------------------
--=============================================================================================
create table ARTICULOS(
	ID_Articulo  numeric(20)   not null, 
	Descripcion  varchar(255)  not null,
	Precio_Venta numeric(10,2) not null,
	Rubro        int           not null,
	Estado			 numeric(1)		 not null,
	fecha_modif  datetime      null,
	login_modif  varchar(255)  null,
	term_modif   varchar(255)  null
)
GO
ALTER TABLE ARTICULOS ADD PRIMARY KEY(ID_Articulo)
ALTER TABLE ARTICULOS ADD CONSTRAINT FK_RUBRO_ARTICULOS 
	FOREIGN KEY(Rubro) REFERENCES RUBROS(ID_Rubro)
ALTER TABLE ARTICULOS ADD CONSTRAINT FK_ESTADO_ARTICULOS 
	FOREIGN KEY(Estado) REFERENCES ESTADO_ARTICULOS(Estado)	
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ARTICULOS.'
GO
--=============================================================================================
------------------------------------ TABLE TMP_ARTICULOS_VENTAS -------------------------------
--=============================================================================================
create table TMP_ARTICULOS_VENTAS(
	ID_Item_Venta	  numeric(30) identity  not null,
	ID_Articulo     numeric(20)           not null, 
	Cantidad	      numeric(10)           not null
)
GO
ALTER TABLE TMP_ARTICULOS_VENTAS ADD CONSTRAINT FK_ID_ARTICULO_TMP_ARTICULOS_VENTAS
	FOREIGN KEY(ID_Articulo) REFERENCES ARTICULOS(ID_Articulo)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA TMP_ARTICULOS_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE ESTADO_VENTAS -------------------------------------
--=============================================================================================
create table ESTADO_VENTAS(
	Estado        numeric(1)		not null, 
	Descripcion		varchar(255)	not null,
	fecha_modif		datetime      NULL,
	login_modif		varchar(255)  NULL,
	term_modif		varchar(255)  NULL
)
GO
ALTER TABLE ESTADO_VENTAS ADD PRIMARY KEY(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ESTADO_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE VENTAS ---------------------------------------------
--=============================================================================================
create table VENTAS(
	ID_Venta            numeric(30) identity not null,
	Cantidad_Articulos  numeric(10)          not null,
	Importe             numeric(10,2)        not null, 
	Estado		          numeric(1)           not null, 
	Fecha_Venta         datetime             not null,
	Hora_Venta          varchar(8)           not null,
	fecha_modif		      datetime             NULL,
	login_modif		      varchar(255)         NULL,
	term_modif		      varchar(255)         NULL
)
GO
ALTER TABLE VENTAS ADD PRIMARY KEY(ID_Venta)
ALTER TABLE VENTAS ADD CONSTRAINT FK_ESTADO_VENTAS
	FOREIGN KEY(Estado) REFERENCES ESTADO_VENTAS(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE ARTICULOS_VENTAS -------------------------------
--=============================================================================================
create table ARTICULOS_VENTAS(
	ID_Venta        numeric(30)	not null, 
	ID_Item_Venta	  numeric(20)	not null,
	ID_Articulo     numeric(20)	not null, 
	Cantidad	      numeric(10)	not null,
	Precio_Venta    numeric(10,2)	not null  --Agrego el precio para que quede registrado a que precio se vendió el articulo ese día, ya que mañana ese artículo puede cambiar.
)
GO
ALTER TABLE ARTICULOS_VENTAS ADD PRIMARY KEY(ID_Venta,ID_Item_Venta)
ALTER TABLE ARTICULOS_VENTAS ADD CONSTRAINT FK_ID_ITEM_VENTA_ARTICULOS_VENTAS
	FOREIGN KEY(ID_Venta) REFERENCES VENTAS(ID_Venta)
ALTER TABLE ARTICULOS_VENTAS ADD CONSTRAINT FK_ID_ARTICULO_ARTICULOS_VENTAS
	FOREIGN KEY(ID_Articulo) REFERENCES ARTICULOS(ID_Articulo)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ARTICULOS_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE ESTADO_PROVEEDORES ---------------------------------
--=============================================================================================
create table ESTADO_PROVEEDORES(
	Estado        numeric(1)		not null, 
	Descripcion		varchar(255)	not null,
	fecha_modif		datetime      NULL,
	login_modif		varchar(255)  NULL,
	term_modif		varchar(255)  NULL
)
GO
ALTER TABLE ESTADO_PROVEEDORES ADD PRIMARY KEY(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ESTADO_PROVEEDORES.'
GO
--=============================================================================================
------------------------------------ TABLE PROVEEDORES ----------------------------------------
--=============================================================================================
create table PROVEEDORES(
	ID_Proveedor int identity not null,
	Nombre       varchar(255) not null,
	ID_Rubro     int		  not null,
	Contacto     varchar(255) null,
	Direccion    varchar(255) null,
	Localidad    varchar(255) null,
	Provincia    varchar(255) null,
	Telefono     varchar(20)  null,
	Cuit         numeric(11)  null,
	Estado			 numeric(1)   not null,	
	fecha_modif  datetime     null,
	login_modif  varchar(255) null,
	term_modif   varchar(255) null
)
GO
ALTER TABLE PROVEEDORES ADD PRIMARY KEY(ID_Proveedor)
ALTER TABLE PROVEEDORES ADD CONSTRAINT FK_ID_RUBRO_PROVEEDORES 
	FOREIGN KEY(ID_Rubro) REFERENCES RUBROS(ID_Rubro)
ALTER TABLE PROVEEDORES ADD CONSTRAINT FK_ESTADO_PROVEEDORES 
	FOREIGN KEY(Estado) REFERENCES ESTADO_PROVEEDORES(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA PROVEEDORES.'
GO
--=============================================================================================
------------------------------------ TABLE ESTADO_TIPOMOVIMIENTO_CAJA -------------------------
--=============================================================================================
create table ESTADO_TIPOMOVIMIENTO_CAJA(
	Estado        numeric(1)		not null, 
	Descripcion		varchar(255)	not null,
	fecha_modif		datetime      NULL,
	login_modif		varchar(255)  NULL,
	term_modif		varchar(255)  NULL	
)
GO
ALTER TABLE ESTADO_TIPOMOVIMIENTO_CAJA ADD PRIMARY KEY(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ESTADO_TIPOMOVIMIENTO_CAJA.'
GO
--=============================================================================================
------------------------------------ TABLE TIPOMOVIMIENTO_CAJA --------------------------------
--=============================================================================================
create table TIPOMOVIMIENTO_CAJA(
	ID_TipoMovimiento   numeric(2)    not null,
	Descripcion         varchar(255)  not null,
	Ingreso_Salida      numeric(1)    not null,
	Estado							numeric(1)    not null,
	fecha_modif         datetime      null,
	login_modif         varchar(255)  null,
	term_modif          varchar(255)  null
)
GO
ALTER TABLE TIPOMOVIMIENTO_CAJA ADD PRIMARY KEY(ID_TipoMovimiento)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA TIPOMOVIMIENTO_CAJA.'
ALTER TABLE TIPOMOVIMIENTO_CAJA ADD CONSTRAINT FK_ESTADO_TIPOMOVIMIENTO_CAJA 
	FOREIGN KEY(Estado) REFERENCES ESTADO_TIPOMOVIMIENTO_CAJA(Estado)
GO
--=============================================================================================
------------------------------------ TABLE MOVIMIENTOS_CAJA -----------------------------------
--=============================================================================================
create table MOVIMIENTOS_CAJA(
	ID_Movimiento     numeric(30) identity	not null,
	ID_TipoMovimiento numeric(2)        not null,
	Valor             numeric(10,2) 		not null,
	Fecha             DATETIME      		not null,
	Hora              varchar(8)    		not null	 						 
)
GO
ALTER TABLE MOVIMIENTOS_CAJA ADD PRIMARY KEY(ID_Movimiento)
ALTER TABLE MOVIMIENTOS_CAJA ADD CONSTRAINT FK_ID_TIPOMOVIMIENTO_TIPOMOVIMIENTO_CAJA 
	FOREIGN KEY(ID_TipoMovimiento) REFERENCES TIPOMOVIMIENTO_CAJA(ID_TipoMovimiento)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA MOVIMIENTOS_CAJA.'
GO
--=============================================================================================
------------------------------------ TABLE PARAMETROS_GENERALES -------------------------------
--=============================================================================================
create table PARAMETROS_GENERALES(
	Fecha_Sistema datetime			NOT NULL,
	Estado_Caja		numeric(1)		NOT NULL,
	fecha_modif		datetime      NULL,
	login_modif		varchar(255)  NULL,
	term_modif		varchar(255)  NULL
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA PARAMETROS_GENERALES.'
GO
--=============================================================================================
------------------------------------ TABLE ESTADO_COMPRAS -------------------------------------
--=============================================================================================
create table ESTADO_COMPRAS(
	Estado        numeric(1)		not null, 
	Descripcion		varchar(255)	not null,
	fecha_modif		datetime      NULL,
	login_modif		varchar(255)  NULL,
	term_modif		varchar(255)  NULL
)
GO
ALTER TABLE ESTADO_COMPRAS ADD PRIMARY KEY(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ESTADO_COMPRAS.'
GO
--=============================================================================================
------------------------------------ TABLE COMPRAS --------------------------------------------
--=============================================================================================
create table COMPRAS(
	Id_Compra			numeric(30) identity NOT NULL,
	Id_Proveedor  int						NOT NULL,
	Importe				numeric(10,2)	NOT NULL,
	Fecha_Compra	datetime			NOT NULL,
	Estado				numeric(1)		NOT NULL,
	fecha_modif		datetime      NULL,
	login_modif		varchar(255)  NULL,
	term_modif		varchar(255)  NULL
)
GO
ALTER TABLE COMPRAS ADD PRIMARY KEY(Id_Compra)
ALTER TABLE COMPRAS ADD CONSTRAINT FK_ID_PROVEEDOR_COMPRAS
	FOREIGN KEY(Id_Proveedor) REFERENCES PROVEEDORES(Id_Proveedor) 
ALTER TABLE COMPRAS ADD CONSTRAINT FK_ESTADO_COMPRAS
	FOREIGN KEY(Estado) REFERENCES ESTADO_COMPRAS(Estado) 	
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA COMPRAS.'
GO
-- ============================================================================================
-- ============================== Administrador General =======================================
-- =============== Password: w23e (encriptada con el algoritmo SHA256) ========================
-- ============================================================================================
DELETE FROM USUARIOS WHERE USERNAME = 'ADMIN'
INSERT INTO USUARIOS(Username,Pass,Descripcion,sino_bloqueado)
	VALUES ('admin', '80-81-66-6D-1D-2E-4A-84-7C-19-B8-3A-6D-09-C5-21-75-96-20-5D-FE-54-4B-28-15-BA-B2-B0-50-12-95-AE','Administrador General','0')
PRINT 'SE CREÓ CORRECTAMENTE EL USUARIO ADMIN.'
-- ============================================================================================
-- ============================================================================================
INSERT INTO PARAMETROS_GENERALES (Fecha_Sistema, Estado_Caja,fecha_modif,login_modif,term_modif) VALUES (GETDATE(), 0, GETDATE(), 'BSP', 'BSP')
-- ============================================================================================
-- ============================================================================================
INSERT INTO ESTADO_COMPRAS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (0, 'ELIMINADO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_COMPRAS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (1, 'ACTIVO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_COMPRAS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (2, 'ELIMINADO_INICIO_CAJA', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_ARTICULOS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (0, 'ELIMINADO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_ARTICULOS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (1, 'ACTIVO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_PROVEEDORES (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (0, 'ELIMINADO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_PROVEEDORES (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (1, 'ACTIVO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_RUBROS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (0, 'ELIMINADO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_RUBROS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (1, 'ACTIVO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_VENTAS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (0, 'ELIMINADO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_VENTAS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (1, 'ACTIVO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_VENTAS (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (2, 'ELIMINADO_INICIO_CAJA', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_TIPOMOVIMIENTO_CAJA (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (0, 'ELIMINADO', GETDATE(), 'BSP', 'BSP')
INSERT INTO ESTADO_TIPOMOVIMIENTO_CAJA (Estado, Descripcion, fecha_modif, login_modif, term_modif) VALUES (1, 'ACTIVO', GETDATE(), 'BSP', 'BSP')
-- ============================================================================================
-- ============================================================================================
INSERT INTO TIPOMOVIMIENTO_CAJA (ID_TipoMovimiento, Descripcion, Ingreso_Salida, Estado, fecha_modif, login_modif, term_modif) VALUES (0,'CIERRE CAJA'		, 0, 1,GETDATE(), 'BSP', 'BSP')
INSERT INTO TIPOMOVIMIENTO_CAJA (ID_TipoMovimiento, Descripcion, Ingreso_Salida, Estado, fecha_modif, login_modif, term_modif) VALUES (1,'INICIO CAJA'		, 1, 1,GETDATE(), 'BSP', 'BSP')
INSERT INTO TIPOMOVIMIENTO_CAJA (ID_TipoMovimiento, Descripcion, Ingreso_Salida, Estado, fecha_modif, login_modif, term_modif) VALUES (2,'COMPRAS'				, 0, 1,GETDATE(), 'BSP', 'BSP')
INSERT INTO TIPOMOVIMIENTO_CAJA (ID_TipoMovimiento, Descripcion, Ingreso_Salida, Estado, fecha_modif, login_modif, term_modif) VALUES (3,'VENTAS'					, 1, 1,GETDATE(), 'BSP', 'BSP')
INSERT INTO TIPOMOVIMIENTO_CAJA (ID_TipoMovimiento, Descripcion, Ingreso_Salida, Estado, fecha_modif, login_modif, term_modif) VALUES (4,'OTROS GASTOS'		, 0, 1,GETDATE(), 'BSP', 'BSP')
INSERT INTO TIPOMOVIMIENTO_CAJA (ID_TipoMovimiento, Descripcion, Ingreso_Salida, Estado, fecha_modif, login_modif, term_modif) VALUES (5,'OTROS INGRESOS'	, 1, 1,GETDATE(), 'BSP', 'BSP')
INSERT INTO TIPOMOVIMIENTO_CAJA (ID_TipoMovimiento, Descripcion, Ingreso_Salida, Estado, fecha_modif, login_modif, term_modif) VALUES (6,'RETIROS'				, 0, 1,GETDATE(), 'BSP', 'BSP')

GO

COMMIT

PRINT REPLICATE('=',60)
PRINT 'FIN DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',60)
