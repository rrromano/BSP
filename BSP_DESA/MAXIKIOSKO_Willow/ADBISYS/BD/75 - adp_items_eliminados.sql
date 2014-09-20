Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_items_eliminados')
  Drop Procedure adp_items_eliminados
Go 

-- SP QUE OBTIENE LOS DIFERENTES ITEMS ELIMINADOS.
Create procedure adp_items_eliminados (@Fecha datetime,
																			 @Tabla varchar(255) = null)
as


BEGIN TRY

	SET NOCOUNT ON

--==============================================================
		SELECT 'RUBROS' AS 'ITEM',
					 UPPER(convert(varchar,ID_RUBRO))	AS 'CÓDIGO',
 					 UPPER(DESCRIPCION)		AS 'DESCRIPCIÓN',
					 convert(varchar,FECHA_MODIF,120) AS 'FECHA_MODIF',
					 UPPER(LOGIN_MODIF)		AS 'LOGIN_MODIF',
					 UPPER(TERM_MODIF)		AS 'TERM_MODIF'
			FROM RUBROS
			WHERE 1=1
				AND ESTADO = 0
				AND @FECHA = CONVERT(VARCHAR,FECHA_MODIF,112)
				AND 1 = CASE WHEN @TABLA IS NULL THEN 1
										 ELSE CASE WHEN @TABLA = 'RUBROS' THEN 1
															 ELSE 0
													END
								END
----------------------------------------------------------------
		UNION
----------------------------------------------------------------
		SELECT 'PROVEEDORES' AS 'ITEM',
					 UPPER(convert(varchar,ID_Proveedor))	AS 'CÓDIGO',
 					 UPPER(Nombre)				AS 'DESCRIPCIÓN',
					 convert(varchar,FECHA_MODIF,120) AS 'FECHA_MODIF',
					 UPPER(LOGIN_MODIF)		AS 'LOGIN_MODIF',
					 UPPER(TERM_MODIF)		AS 'TERM_MODIF'
			FROM PROVEEDORES
			WHERE 1=1
				AND ESTADO = 0
				AND @FECHA = CONVERT(VARCHAR,FECHA_MODIF,112)
				AND 1 = CASE WHEN @Tabla IS NULL THEN 1
										 ELSE CASE WHEN @Tabla = 'PROVEEDORES' THEN 1
															 ELSE 0
													END
								END
----------------------------------------------------------------
		UNION
----------------------------------------------------------------
		SELECT 'MOVIMIENTOS DE CAJA' AS 'ITEM',
					 UPPER(convert(varchar,ID_TipoMovimiento))	AS 'CÓDIGO',
 					 UPPER(Descripcion)				AS 'DESCRIPCIÓN',
					 convert(varchar,FECHA_MODIF,120) AS 'FECHA_MODIF',
					 UPPER(LOGIN_MODIF)				AS 'LOGIN_MODIF',
					 UPPER(TERM_MODIF)				AS 'TERM_MODIF'
			FROM TIPOMOVIMIENTO_CAJA
			WHERE 1=1
				AND ESTADO = 0
				AND @FECHA = CONVERT(VARCHAR,FECHA_MODIF,112)
				AND 1 = CASE WHEN @Tabla IS NULL THEN 1
										 ELSE CASE WHEN @Tabla = 'MOVIMIENTOS DE CAJA' THEN 1
															 ELSE 0
													END
								END
----------------------------------------------------------------
		UNION
----------------------------------------------------------------								
		SELECT 'ARTÍCULOS' AS 'ITEM',
					 UPPER(convert(varchar,ID_Articulo))	AS 'CÓDIGO',
 					 UPPER(Descripcion)	AS 'DESCRIPCIÓN',
					 convert(varchar,FECHA_MODIF,120) AS 'FECHA_MODIF',
					 UPPER(LOGIN_MODIF)	AS 'LOGIN_MODIF',
					 UPPER(TERM_MODIF)	AS 'TERM_MODIF'
			FROM ARTICULOS_ELIMINADOS
			WHERE 1=1
				AND @FECHA = CONVERT(VARCHAR,FECHA_MODIF,112)
				AND 1 = CASE WHEN @Tabla IS NULL THEN 1
										 ELSE CASE WHEN @Tabla = 'ARTICULOS' THEN 1
															 ELSE 0
													END
								END
----------------------------------------------------------------
		UNION
----------------------------------------------------------------								
		SELECT 'COMPRAS' AS 'ITEM',
					 UPPER(convert(varchar,Id_Compra))	AS 'CÓDIGO',
 					 UPPER(B.Nombre) + ' - $' + convert(varchar(11),Importe)	AS 'DESCRIPCIÓN',
					 convert(varchar,A.FECHA_MODIF,120) AS 'FECHA_MODIF',
					 UPPER(A.LOGIN_MODIF)	AS 'LOGIN_MODIF',
					 UPPER(A.TERM_MODIF)	AS 'TERM_MODIF'
			FROM COMPRAS A
			INNER JOIN PROVEEDORES B ON (A.Id_Proveedor = B.ID_Proveedor)
			WHERE 1=1
				AND A.ESTADO = 0
				AND @FECHA = CONVERT(VARCHAR,A.fecha_modif,112)
				AND 1 = CASE WHEN @Tabla IS NULL THEN 1
										 ELSE CASE WHEN @Tabla = 'COMPRAS' THEN 1
															 ELSE 0
													END
								END
----------------------------------------------------------------
		UNION
----------------------------------------------------------------								
		SELECT 'VENTAS' AS 'ITEM',
					 UPPER(ID_Venta)		AS 'CÓDIGO',
 					 'Cant. Art: ' + CONVERT(VARCHAR(10),Cantidad_Articulos) + ' - $' + CONVERT(VARCHAR(11),Importe) AS 'DESCRIPCIÓN',
					 convert(varchar,FECHA_MODIF,120) AS 'FECHA_MODIF',
					 UPPER(LOGIN_MODIF)	AS 'LOGIN_MODIF',
					 UPPER(TERM_MODIF)	AS 'TERM_MODIF'
			FROM VENTAS A
			WHERE 1=1
				AND A.ESTADO = 0
				AND @FECHA = CONVERT(VARCHAR,A.fecha_modif,112)
				AND 1 = CASE WHEN @Tabla IS NULL THEN 1
										 ELSE CASE WHEN @Tabla = 'VENTAS' THEN 1
															 ELSE 0
													END
								END								
--==============================================================

SET NOCOUNT OFF
	
END TRY

BEGIN CATCH
  SET NOCOUNT OFF
  PRINT 'ACTUALIZACION CANCELADA POR ERROR'
  SELECT ERROR_NUMBER()     'ERROR_NUMBER' , 
         ERROR_MESSAGE()    'ERROR_MESSAGE', 
         ERROR_LINE()       'ERROR_LINE', 
         ERROR_PROCEDURE()  'ERROR_PROCEDURE', 
         ERROR_SEVERITY ()  'ERROR_SEVERITY',   
         ERROR_STATE()      'ERROR_STATE'
END CATCH
GO