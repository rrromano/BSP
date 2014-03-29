USE ADBISYS
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
If Exists ( Select 1 From sysobjects Where Name = 'TMP_MOVIMIENTOS_CAJA' )
  Drop Table TMP_MOVIMIENTOS_CAJA
Go
If Exists ( Select 1 From sysobjects Where Name = 'MOVIMIENTOS_CAJA' )
  Drop Table MOVIMIENTOS_CAJA
Go

--=============================================================================================
------------------------------------ TABLE USUARIOS -------------------------------------------
--=============================================================================================
create table USUARIOS(
	ID_User  int identity not null,
	Username varchar(255) not null,
	Pass	 varchar(255) not null,
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
	ID_Articulo  varchar(100)  not null, --¿Por qué varchar(100)?
	Codigo       varchar(100)  null	   , --¿Qué es el código? ¿Es distinto al Id_Venta?
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
------------------------------------ TABLE TMP_VENTAS -----------------------------------------
--=============================================================================================
create table TMP_VENTAS(
	ID_Venta	    numeric(20) identity  not null,
	Codigo			varchar(100)          not null, --¿Qué es el código? ¿Es distinto al Id_Venta?
	Cantidad	    numeric(10)           not null,
	Importe			numeric(14,2)         not null, 
	sino_correcta	numeric(1)            not null, -- 0:Incorrecta 1:Correcta.	
	Fecha		    datetime              not null,
	Hora		    varchar(8)            not null
)
GO
ALTER TABLE TMP_VENTAS ADD PRIMARY KEY(ID_Venta)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA TMP_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE TMP_ARTICULOS_VENTAS -------------------------------
--=============================================================================================
create table TMP_ARTICULOS_VENTAS(
	ID_Item_Venta	    numeric(20) identity  not null,
	ID_Venta            numeric(20)           not null, --¿Qué es el código? ¿Es distinto al Id_Venta?
	ID_Articulo         varchar(100)          not null, --¿Por qué varchar(100)?  
	Cantidad	        numeric(10)           not null,
	Precio_Venta        numeric(10,2)         not null  --Agrego el precio para que quede registrado a que precio se vendió el articulo ese día, ya que mañana ese artículo puede cambiar.
)
GO
ALTER TABLE TMP_ARTICULOS_VENTAS ADD PRIMARY KEY(ID_Item_Venta)
ALTER TABLE TMP_ARTICULOS_VENTAS ADD CONSTRAINT FK_TMP_ITEM_VENTAS
	FOREIGN KEY(ID_Venta) REFERENCES TMP_VENTAS(ID_Venta)
ALTER TABLE TMP_ARTICULOS_VENTAS ADD CONSTRAINT FK_TMP_ITEM_ARTICULOS
	FOREIGN KEY(ID_Articulo) REFERENCES ARTICULOS(ID_Articulo)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA TMP_ARTICULOS_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE VENTAS ---------------------------------------------
--=============================================================================================
create table VENTAS(
	ID_Venta      numeric(20) identity not null,
	Codigo        varchar(100)         not null, --¿Qué es el código? ¿Es distinto al Id_Venta?
	Cantidad      numeric(10)          not null,
	Importe       numeric(14,2)        not null, 
	sino_correcta numeric(1)           not null, -- 0:Incorrecta 1:Correcta.	
	Fecha         datetime             not null,
	Hora          varchar(8)           not null
)
GO
ALTER TABLE VENTAS ADD PRIMARY KEY(ID_Venta)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE ARTICULOS_VENTAS -------------------------------
--=============================================================================================
create table ARTICULOS_VENTAS(
	ID_Item_Venta	    numeric(20) identity  not null,
	ID_Venta            numeric(20)           not null, --¿Qué es el código? ¿Es distinto al Id_Venta?
	ID_Articulo         varchar(100)          not null, --¿Por qué varchar(100)?  
	Cantidad	        numeric(10)           not null
)
GO
ALTER TABLE ARTICULOS_VENTAS ADD PRIMARY KEY(ID_Item_Venta)
ALTER TABLE ARTICULOS_VENTAS ADD CONSTRAINT FK_ITEM_VENTAS
	FOREIGN KEY(ID_Venta) REFERENCES VENTAS(ID_Venta)
ALTER TABLE ARTICULOS_VENTAS ADD CONSTRAINT FK_ITEM_ARTICULOS
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
------------------------------------ TABLE TMP_MOVIMIENTOS_CAJA -------------------------------
--=============================================================================================
create table TMP_MOVIMIENTOS_CAJA(
	ID_Movimiento  int identity  not null,
	Ingreso_Salida numeric(1)    not null, -- 0:Ingreso 1:Salida
	Descripcion	   varchar(255)  not null,	
	Valor		   numeric(10,2) not null,
	Valor_Actual   numeric(10,2) not null,
	Fecha		   DATETIME      not null,
	Hora		   varchar(8)    not null, 						 
)
GO
ALTER TABLE TMP_MOVIMIENTOS_CAJA ADD PRIMARY KEY(ID_Movimiento)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA TMP_MOVIMIENTOS_CAJA.'
GO
--=============================================================================================
------------------------------------ TABLE MOVIMIENTOS_CAJA -----------------------------------
--=============================================================================================
create table MOVIMIENTOS_CAJA(
	ID_Movimiento  int identity  not null,
	Ingreso_Salida numeric(1)    not null, -- 0:Ingreso 1:Salida.
	Descripcion    varchar(255)  not null,	
	Valor          numeric(10,2) not null,
	Valor_Actual   numeric(10,2) not null,
	Fecha          DATETIME      not null,
	Hora           varchar(8)    not null, 						 
)
GO
ALTER TABLE MOVIMIENTOS_CAJA ADD PRIMARY KEY(ID_Movimiento)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA MOVIMIENTOS_CAJA.'
GO

COMMIT

PRINT REPLICATE('=',60)
PRINT 'FIN DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',60)
