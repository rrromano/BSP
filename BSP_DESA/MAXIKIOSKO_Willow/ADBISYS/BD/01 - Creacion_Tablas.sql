USE WIAdbisys
GO

-- RR 2014-03-21: CREACIÓN DE LAS DIFERENTES TABLAS QUE UTILIZARÁ EL SISTEMA ADBISYS.

SET NOCOUNT ON
BEGIN TRAN

PRINT REPLICATE('=',60)
PRINT 'INICIO DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',60)
GO


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
If Exists ( Select 1 From sysobjects Where Name = 'PROVEEDORES' )
  Drop Table PROVEEDORES
Go
If Exists ( Select 1 From sysobjects Where Name = 'RUBROS' )
  Drop Table RUBROS
Go
If Exists ( Select 1 From sysobjects Where Name = 'TMP_VENTAS' )
  Drop Table TMP_VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'VENTAS' )
  Drop Table VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'ESTADOS_VENTAS' )
  Drop Table ESTADOS_VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'MOVIMIENTOS_CAJA' )
  Drop Table MOVIMIENTOS_CAJA
Go
If Exists ( Select 1 From sysobjects Where Name = 'CAJA' )
  Drop Table CAJA
Go
If Exists ( Select 1 From sysobjects Where Name = 'PARAMETROS_GENERALES' )
  Drop Table PARAMETROS_GENERALES
Go

--=============================================================================================
------------------------------------ TABLE USUARIOS -------------------------------------------
--=============================================================================================
create table USUARIOS(
	ID_User			int identity not null,
	Username		varchar(255) not null,
	Pass			varchar(255) not null,
	Descripcion		varchar(255) not null,
	sino_bloqueado	numeric(1)   not null, -- 1: bloqueado.
	)
ALTER TABLE USUARIOS ADD PRIMARY KEY(ID_User)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA USUARIOS.'
GO
--=============================================================================================
------------------------------------ TABLE RUBROS ---------------------------------------------
--=============================================================================================
create table RUBROS(
	ID_Rubro    int identity not null,
	Descripcion varchar(255) not null,
)
ALTER TABLE RUBROS ADD PRIMARY KEY(ID_Rubro)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA RUBROS.'
GO
--=============================================================================================
------------------------------------ TABLE ARTICULOS ------------------------------------------
--=============================================================================================
create table ARTICULOS(
	ID_Articulo  numeric(20)   not null, 
	Descripcion  varchar(255)  not null,
	Precio_Venta numeric(10,2) not null,
	Rubro        int           not null,
	Fecha        datetime      not null,
	Hora         varchar(8)	   not null
)
GO
ALTER TABLE ARTICULOS ADD PRIMARY KEY(ID_Articulo)
ALTER TABLE ARTICULOS ADD CONSTRAINT FK_RUBRO_ARTICULOS 
	FOREIGN KEY(Rubro) REFERENCES RUBROS(ID_Rubro)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ARTICULOS.'
GO
--=============================================================================================
------------------------------------ TABLE TMP_ARTICULOS_VENTAS -------------------------------
--=============================================================================================
create table TMP_ARTICULOS_VENTAS(
	ID_Item_Venta	  numeric(30) identity  not null,
	ID_Articulo       numeric(20)           not null, 
	Cantidad	      numeric(10)           not null
)
GO
ALTER TABLE TMP_ARTICULOS_VENTAS ADD CONSTRAINT FK_ID_Articulo_TMP_ARTICULOS_VENTAS
	FOREIGN KEY(ID_Articulo) REFERENCES ARTICULOS(ID_Articulo)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA TMP_ARTICULOS_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE ESTADOS_VENTAS -------------------------------------
--=============================================================================================
create table ESTADOS_VENTAS(
	Estado            numeric(1)		not null, 
	Descripcion		  varchar(255)		not null
)
GO
ALTER TABLE ESTADOS_VENTAS ADD PRIMARY KEY(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ESTADOS_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE VENTAS ---------------------------------------------
--=============================================================================================
create table VENTAS(
	ID_Venta      numeric(30) identity not null,
	Cantidad      numeric(10)          not null,
	Importe       numeric(10,2)        not null, 
	Estado		  numeric(1)           not null, 
	Fecha         datetime             not null,
	Hora          varchar(8)           not null
)
GO
ALTER TABLE VENTAS ADD PRIMARY KEY(ID_Venta)
ALTER TABLE VENTAS ADD CONSTRAINT FK_Estado_VENTAS
	FOREIGN KEY(Estado) REFERENCES ESTADOS_VENTAS(Estado)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE ARTICULOS_VENTAS -------------------------------
--=============================================================================================
create table ARTICULOS_VENTAS(
	ID_Venta          numeric(30)	not null, 
	ID_Item_Venta	  numeric(20)	not null,
	ID_Articulo       numeric(20)	not null, 
	Cantidad	      numeric(10)	not null,
	Precio_Venta      numeric(10,2)	not null  --Agrego el precio para que quede registrado a que precio se vendió el articulo ese día, ya que mañana ese artículo puede cambiar.
)
GO
ALTER TABLE ARTICULOS_VENTAS ADD PRIMARY KEY(ID_Venta,ID_Item_Venta)
ALTER TABLE ARTICULOS_VENTAS ADD CONSTRAINT FK_ID_Item_Venta_ARTICULOS_VENTAS
	FOREIGN KEY(ID_Venta) REFERENCES VENTAS(ID_Venta)
ALTER TABLE ARTICULOS_VENTAS ADD CONSTRAINT FK_ID_Articulo_VENTAS
	FOREIGN KEY(ID_Articulo) REFERENCES ARTICULOS(ID_Articulo)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ARTICULOS_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE PROVEEDORES ----------------------------------------
--=============================================================================================
create table PROVEEDORES(
	ID_Proveedor int identity not null,
	Rubro        int		  not null,
	Nombre       varchar(255) null    ,
	Contacto     varchar(255) null    ,
	Direccion    varchar(255) null    ,
	Localidad    varchar(255) null    ,
	Provincia    varchar(255) null    ,
	Telefono     numeric(20)  null    ,
	Cuit         numeric(11)  null	  
)
GO
ALTER TABLE PROVEEDORES ADD PRIMARY KEY(ID_Proveedor)
ALTER TABLE PROVEEDORES ADD CONSTRAINT FK_RUBRO_PROVEEDORES 
	FOREIGN KEY(Rubro) REFERENCES RUBROS(ID_Rubro)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA PROVEEDORES.'
GO
--=============================================================================================
------------------------------------ TABLE MOVIMIENTOS_CAJA -----------------------------------
--=============================================================================================
create table MOVIMIENTOS_CAJA(
	ID_Movimiento  numeric(30) identity	not null,
	Ingreso_Salida numeric(1)    		not null, -- 0:Ingreso 1:Salida.
	Descripcion    varchar(255)  		not null,	
	Valor          numeric(10,2) 		not null,
	Fecha          DATETIME      		not null,
	Hora           varchar(8)    		not null, 						 
)
GO
ALTER TABLE MOVIMIENTOS_CAJA ADD PRIMARY KEY(ID_Movimiento)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA MOVIMIENTOS_CAJA.'
GO
--=============================================================================================
------------------------------------ TABLE CAJA -----------------------------------------------
--=============================================================================================
create table CAJA(
	Fecha		    datetime      not null,
	Caja_Inicial    numeric(10,2) not null,
	Caja_Final	    numeric(10,2) not null,
	Importe_Total   numeric(10,2) not null,
)
GO
ALTER TABLE CAJA ADD PRIMARY KEY(Fecha)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA CAJA.'
GO
--=============================================================================================
------------------------------------ TABLE PARAMETROS_GENERALES -------------------------------
--=============================================================================================
create table PARAMETROS_GENERALES(
	Estado_Caja	numeric(1) not null
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA PARAMETROS_GENERALES.'
GO
-- =====================================================================================
-- ============================== Administrador General ================================
-- =============== Password: w23e (encriptada con el algoritmo SHA256) =================
-- =====================================================================================
DELETE FROM USUARIOS WHERE USERNAME = 'ADMIN'
INSERT INTO USUARIOS(Username,Pass,Descripcion,sino_bloqueado)
	VALUES ('admin', 'E6-B8-70-50-BF-CB-81-43-FC-B8-DB-01-70-A4-DC-9E-D0-0D-90-4D-DD-3E-2A-4A-D1-B1-E8-DC-0F-DC-9B-E7','Administrador General','0')
PRINT 'SE CREÓ CORRECTAMENTE EL USUARIO ADMIN.'
GO

COMMIT

PRINT REPLICATE('=',60)
PRINT 'FIN DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',60)
