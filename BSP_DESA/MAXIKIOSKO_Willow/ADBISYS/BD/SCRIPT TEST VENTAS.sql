USE WIAdbisys


--TRY CATCH

  --TESTS VENTAS

  --SELECT * FROM ARTICULOS_VENTAS

  IF EXISTS(SELECT 1 FROM VENTAS)
    DELETE VENTAS
  IF EXISTS(SELECT 1 FROM ARTICULOS)
    DELETE ARTICULOS
  IF EXISTS(SELECT 1 FROM RUBROS)
    DELETE RUBROS
  
  DBCC CHECKIDENT ('VENTAS', RESEED,0)
  DBCC CHECKIDENT ('RUBROS', RESEED,0)
    
  INSERT INTO VENTAS (Cantidad_Articulos,Importe,Estado,Fecha_Venta,Hora_Venta,fecha_modif,login_modif,term_modif)
  VALUES (3, '501.12', 1, CONVERT(VARCHAR,CONVERT(VARCHAR,GETDATE(),112)), '00:00:01', GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO VENTAS (Cantidad_Articulos,Importe,Estado,Fecha_Venta,Hora_Venta,fecha_modif,login_modif,term_modif)
  VALUES (1, '100', 1, CONVERT(VARCHAR,CONVERT(VARCHAR,GETDATE(),112)), '00:00:02', GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO VENTAS (Cantidad_Articulos,Importe,Estado,Fecha_Venta,Hora_Venta,fecha_modif,login_modif,term_modif)
  VALUES (5, '200.14', 1, CONVERT(VARCHAR,CONVERT(VARCHAR,GETDATE(),112)), '00:00:03', GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO VENTAS (Cantidad_Articulos,Importe,Estado,Fecha_Venta,Hora_Venta,fecha_modif,login_modif,term_modif)
  VALUES (6, '150.17', 1, CONVERT(VARCHAR,CONVERT(VARCHAR,GETDATE(),112)), '00:00:04', GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO VENTAS (Cantidad_Articulos,Importe,Estado,Fecha_Venta,Hora_Venta,fecha_modif,login_modif,term_modif)
  VALUES (1, '15.15', 1, CONVERT(VARCHAR,CONVERT(VARCHAR,GETDATE(),112)), '00:00:05', GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO VENTAS (Cantidad_Articulos,Importe,Estado,Fecha_Venta,Hora_Venta,fecha_modif,login_modif,term_modif)
  VALUES (2, '14.3', 1, CONVERT(VARCHAR,CONVERT(VARCHAR,GETDATE(),112)), '00:00:06', GETDATE(), 'BSP', HOST_NAME() )

  INSERT INTO RUBROS (Descripcion, Estado, fecha_modif, login_modif, term_modif)
  VALUES ('DESODORANTES', 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO RUBROS (Descripcion, Estado, fecha_modif, login_modif, term_modif)
  VALUES ('CALCULADORAS', 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO RUBROS (Descripcion, Estado, fecha_modif, login_modif, term_modif)
  VALUES ('CREMAS', 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO RUBROS (Descripcion, Estado, fecha_modif, login_modif, term_modif)
  VALUES ('DISCOS EXTERNOS', 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO RUBROS (Descripcion, Estado, fecha_modif, login_modif, term_modif)
  VALUES ( 'PERFUMES', 1, GETDATE(), 'BSP', HOST_NAME() )

  INSERT INTO ARTICULOS (ID_Articulo, Descripcion, Precio_Venta, Rubro, Estado, fecha_modif, login_modif, term_modif)
  VALUES (7791293022628,'DESODORANTE REXONA MEN AQUASHIELD', '22.5', 1, 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO ARTICULOS (ID_Articulo, Descripcion, Precio_Venta, Rubro, Estado, fecha_modif, login_modif, term_modif)
  VALUES (4971850900726,'CALCULADORA CASIO FX-991ES PLUS', '650.50', 2, 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO ARTICULOS (ID_Articulo, Descripcion, Precio_Venta, Rubro, Estado, fecha_modif, login_modif, term_modif)
  VALUES (7791909104632,'CREMA FACTOR DERMICO 20G', '75.00', 3, 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO ARTICULOS (ID_Articulo, Descripcion, Precio_Venta, Rubro, Estado, fecha_modif, login_modif, term_modif)
  VALUES (7636490041488,'DISCO EXTERNO SAMSUNG 1 TB', '800.00', 4, 1, GETDATE(), 'BSP', HOST_NAME() )
  INSERT INTO ARTICULOS (ID_Articulo, Descripcion, Precio_Venta, Rubro, Estado, fecha_modif, login_modif, term_modif)
  VALUES (8411061723784,'PERFUME 212 VIP', '1250', 5, 1, GETDATE(), 'BSP', HOST_NAME() )

--END TRY

--BEGIN CATCH


--END CATCH