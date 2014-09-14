USE WIAdbisys


--TRY CATCH

  --TESTS VENTAS

  --SELECT * FROM ARTICULOS_VENTAS

  IF EXISTS(SELECT 1 FROM VENTAS)
    DELETE VENTAS
    
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


EXEC dbo.adp_obtener_ventas @d_16_fecha = '20140914'
EXEC dbo.adp_obtener_ventas @d_16_fecha = '20140914'


--END TRY

--BEGIN CATCH


--END CATCH