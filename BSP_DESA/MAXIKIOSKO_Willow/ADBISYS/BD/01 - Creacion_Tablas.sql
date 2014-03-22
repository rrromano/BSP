Use ADBISYS
go

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
	ID_Rubro	int identity not null,
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
	ID_Articulo  varchar(100)  not null,
	Codigo		 varchar(100)  null	   ,	
	Descripcion  varchar(255)  not null,
	Precio_Venta numeric(10,2) not null,
	Rubro		 int		   not null,
	Fecha		 datetime      not null,
	Hora		 varchar(8)	   not null
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
	ID_Venta	  numeric(20) identity not null,
	Codigo	      varchar(100)		   not null,
	Cantidad	  numeric(10)		   not null,
	sino_correcta numeric(1)		   not null, -- 0:Incorrecta 1:Correcta.	
	Fecha		  datetime			   not null,
	Hora		  varchar(8)		   not null
)
GO
ALTER TABLE TMP_VENTAS ADD PRIMARY KEY(ID_Venta)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA TMP_VENTAS.'
GO
--=============================================================================================
------------------------------------ TABLE VENTAS ---------------------------------------------
--=============================================================================================
create table VENTAS(
	ID_Venta	  numeric(20) identity not null,
	Codigo	      varchar(100)		   not null,
	Cantidad	  numeric(10)		   not null,
	sino_correcta numeric(1)		   not null, -- 0:Incorrecta 1:Correcta.	
	Fecha		  datetime			   not null,
	Hora		  varchar(8)		   not null
)
GO
ALTER TABLE VENTAS ADD PRIMARY KEY(ID_Venta)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA VENTAS.'
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
	Cuit		 numeric(11)  null	  
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
	Hora		   varchar(8)	 not null, 						 
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
	Descripcion	   varchar(255)  not null,	
	Valor		   numeric(10,2) not null,
	Valor_Actual   numeric(10,2) not null,
	Fecha		   DATETIME      not null,
	Hora		   varchar(8)	 not null, 						 
)
GO
ALTER TABLE MOVIMIENTOS_CAJA ADD PRIMARY KEY(ID_Movimiento)
PRINT 'SE CREÓ CORRECTAMENTE LA TABLA MOVIMIENTOS_CAJA.'
GO

COMMIT

PRINT REPLICATE('=',60)
PRINT 'FIN DE CREACIÓN DE TABLAS.'
PRINT REPLICATE('=',60)
