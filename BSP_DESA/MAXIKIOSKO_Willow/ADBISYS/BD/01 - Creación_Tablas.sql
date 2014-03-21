Use ADBISYS
go

-- RR 2014-03-21: CREACIÓN DE LAS DIFERENTES TABLAS QUE UTILIZARÁ EL SISTEMA ADBISYS.

SET NOCOUNT ON
BEGIN TRAN

PRINT REPLICATE('=',50)
PRINT 'INICIO DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',50)
GO


If Exists ( Select 1 From sysobjects Where Name = 'USUARIOS' )
  Drop Table USUARIOS
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
If Exists ( Select 1 From sysobjects Where Name = 'VENTAS' )
  Drop Table VENTAS
Go
If Exists ( Select 1 From sysobjects Where Name = 'VENTAS_HIST' )
  Drop Table VENTAS_HIST
Go
If Exists ( Select 1 From sysobjects Where Name = 'MOVIMIENTOS_CAJA' )
  Drop Table MOVIMIENTOS_CAJA
Go
If Exists ( Select 1 From sysobjects Where Name = 'MOVIMIENTOS_CAJA_HIST' )
  Drop Table MOVIMIENTOS_CAJA_HIST
Go

--=============================================================================================
------------------------------------ TABLE USUARIOS -------------------------------------------
--=============================================================================================
create table USUARIOS(
	ID_User  int identity not null,
	Username varchar(255) not null,
	Pass	 varchar(255) not null,
	primary key(ID_User)
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA USUARIOS.'
GO
--=============================================================================================
------------------------------------ TABLE RUBROS ---------------------------------------------
--=============================================================================================
create table RUBROS(
	ID_Rubro	int identity not null,
	Descripcion varchar(255) not null,
	primary key(ID_Rubro)
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA RUBROS.'
GO
--=============================================================================================
------------------------------------ TABLE ARTICULOS ------------------------------------------
--=============================================================================================
create table ARTICULOS(
	ID_Articulo  varchar(100)  not null,
	Codigo		 varchar(100)  null	   ,	
	Descripcion  varchar(255)  not null,
	Precio_Venta numeric(10,2) not null,
	Rubro		 int		   not null,
	Fecha		 datetime      not null,
	Hora		 varchar(8)	   not null,
	primary key  (ID_Articulo),
	constraint   FK_RUBRO_ARTICULOS
	foreign key  (Rubro)
	references   RUBROS(ID_Rubro)
	
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA ARTICULOS.'
GO
--=============================================================================================
------------------------------------ TABLE VENTAS ---------------------------------------------
--=============================================================================================
create table VENTAS(
	ID_Venta	  numeric(20)  identity not null,
	Codigo	      varchar(100)		   not null,
	Cantidad	  numeric(10)		   not null,
	sino_correcta numeric(1)			   not null, -- 0:Incorrecta 1:Correcta.	
	Fecha		  datetime			   not null,
	Hora		  varchar(8)			   not null,
	primary key   (ID_Venta)
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE VENTAS_HIST ----------------------------------------
--=============================================================================================
create table VENTAS_HIST(
	ID_Venta	  numeric(20)  identity not null,
	Codigo	      varchar(100)		   not null,
	Cantidad	  numeric(10)		   not null,
	sino_correcta numeric(1)			   not null, -- 0:Incorrecta 1:Correcta.	
	Fecha		  datetime			   not null,
	Hora		  varchar(8)			   not null,
	primary key   (ID_Venta)
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA VENTAS_HIST.'
GO
--=============================================================================================
------------------------------------ TABLE PROVEEDORES ----------------------------------------
--=============================================================================================
create table PROVEEDORES(
	ID_Proveedor int identity not null,
	Rubro		 int		  not null,
	Nombre		 varchar(255) null	  ,
	Contacto	 varchar(255) null	  ,
	Direccion	 varchar(255) null	  ,
	Localidad	 varchar(255) null	  ,
	Provincia	 varchar(255) null	  ,
	Telefono	 numeric(20)  null	  ,
	Cuit		 numeric(11)  null	  ,
	primary key  (ID_Proveedor),
	constraint   FK_RUBRO_PROVEEDORES
	foreign key  (Rubro)
	references   RUBROS(ID_Rubro)
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA PROVEEDORES.'
GO
--=============================================================================================
------------------------------------ TABLE MOVIMIENTOS_CAJA -----------------------------------
--=============================================================================================
create table MOVIMIENTOS_CAJA(
	ID_Movimiento  int identity  not null,
	Ingreso_Salida numeric(1)    not null, -- 0:Ingreso 1:Salida
	Descripcion	   varchar(255)  not null,	
	Valor		   numeric(10,2) not null,
	Valor_Actual   numeric(10,2) not null,
	Fecha		   DATETIME      not null,
	Hora		   varchar(8)	 not null, 						 
	primary key    (ID_Movimiento),
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA MOVIMIENTOS_CAJA.'
GO
--=============================================================================================
------------------------------------ TABLE MOVIMIENTOS_CAJA_HIST ------------------------------
--=============================================================================================
create table MOVIMIENTOS_CAJA_HIST(
	ID_Movimiento  int identity  not null,
	Ingreso_Salida numeric(1)    not null, -- 0:Ingreso 1:Salida.
	Descripcion	   varchar(255)  not null,	
	Valor		   numeric(10,2) not null,
	Valor_Actual   numeric(10,2) not null,
	Fecha		   DATETIME      not null,
	Hora		   varchar(8)	 not null, 						 
	primary key    (ID_Movimiento),
)
GO
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA MOVIMIENTOS_CAJA_HIST.'
GO

COMMIT

PRINT REPLICATE('=',50)
PRINT 'FIN DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',50)
