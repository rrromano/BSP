USE WIADBISYS
GO

--EXEC descr ARTICULOS
DELETE ARTICULOS
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif) VALUES (1,'ALFAJOR CACHAFAZ', 10, 2, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif) VALUES (2,'MARLBORO 10', 10, 3, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif) VALUES (3,'MARLBORO 20', 20, 3, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif) VALUES (4,'COCA COLA 600 ML', 12, 4, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif)VALUES (5,'SPRITE 600 ML', 12, 4, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif) VALUES (6,'FANTA 1 Lt', 16, 4, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif) VALUES (7,'SUGUS MAX', 2, 5, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif)VALUES (8,'SUGUS', 1, 5, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif)VALUES (9,'BELDENT MENTA', 5, 6, 1, '', GETDATE(), 'BSP', HOST_NAME())
INSERT INTO ARTICULOS (ID_Articulo,Descripcion,Precio_Venta,Rubro,Estado,Hora_modif,fecha_modif,login_modif,term_modif)VALUES (10,'BELDENT FRUTA', 5, 6, 1, '', GETDATE(), 'BSP', HOST_NAME())


--exec adp_actualizacionMasiva_Articulo  @Articulo_IdRubro = 2 , @Articulo_TipoAct = 0 , @Articulo_SumaResta = 0 , @Articulo_Valor = 1
