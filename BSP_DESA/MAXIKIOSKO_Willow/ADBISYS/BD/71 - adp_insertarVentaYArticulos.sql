Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_insertarVentaYArticulos')
  Drop Procedure adp_insertarVentaYArticulos
Go 

-- SP PARA INSERTAR TODOS LOS REGISTROS DE TMP_ARTICULOS_VENTAS EN LA TABLA ARTICULOS_VENTAS Y LUEGO INSERTAR EN LA TABLA VENTAS
Create procedure dbo.adp_insertarVentaYArticulos (@FECHA_VENTA DATETIME, 
                                                  @HORA_VENTA VARCHAR(8), 
                                                  @USUARIO_VENTA VARCHAR(255) = NULL)
as

BEGIN TRY

  BEGIN TRAN
    
	  SET NOCOUNT ON
  	
	  DECLARE @CANTIDAD_ARTICULOS NUMERIC(10)
	  DECLARE @IMPORTE NUMERIC(10,2)
	  DECLARE @ID_MAX_VENTA NUMERIC(30)
  	
	  --SET @FECHA_VENTA = CONVERT(DATETIME,CONVERT(VARCHAR,@FECHA_VENTA,112))

    --=============================================================================
    --SE OBTIENE LA CANTIDAD DE ARTICULOS - SE OBTIENE EL IMPORTE TOTAL DE LA VENTA	
    --=============================================================================
	  SELECT  @CANTIDAD_ARTICULOS = COUNT(1),  
	          @IMPORTE = SUM(A.CANTIDAD * B.PRECIO_VENTA)
	  FROM TMP_ARTICULOS_VENTAS A
	  INNER JOIN ARTICULOS B ON (A.ID_Articulo = B.ID_Articulo)
	  WHERE B.Estado = 1 
    --=============================================================================
  	
    
    --=============================================================================
    --GUARDO LA VENTA *************************************************************
    --=============================================================================
	  INSERT INTO VENTAS (CANTIDAD_ARTICULOS, 
	                      IMPORTE, 
	                      ESTADO, 
	                      FECHA_VENTA, 
	                      HORA_VENTA, 
	                      FECHA_MODIF, 
	                      LOGIN_MODIF, 
	                      TERM_MODIF)
	  VALUES (@CANTIDAD_ARTICULOS, 
	          @IMPORTE, 
	          1, 
	          @FECHA_VENTA, 
	          @HORA_VENTA, 
	          GETDATE(), 
	          @USUARIO_VENTA, 
	          HOST_NAME())
    --=============================================================================
    
    --=============================================================================
    --OBTENGO EL ID DE LA VENTA QUE SE ACABA DE GUARDAR ***************************
    --=============================================================================
    SELECT @ID_MAX_VENTA = MAX(ID_Venta) FROM VENTAS
    --=============================================================================

    --=============================================================================
    --GUARDO LOS ARTICULOS QUE COMPONEN LA VENTA **********************************
    --=============================================================================
	  INSERT INTO ARTICULOS_VENTAS (ID_Venta, 
	                                ID_Item_Venta, 
	                                ID_Articulo, 
	                                Cantidad,
	                                Precio_Venta)
  	
	  SELECT  @ID_MAX_VENTA, 
	          B.ID_Item_Venta,
	          B.ID_Articulo,
	          B.Cantidad,
	          A.Precio_Venta
	  FROM ARTICULOS A
		  INNER JOIN TMP_ARTICULOS_VENTAS B ON (A.ID_Articulo = B.ID_Articulo)
    WHERE A.ESTADO = 1
    --=============================================================================
    
    
    --=============================================================================
    --BORRO LA TABLA TMP_ARTICULOS_VENTAS *****************************************
    --=============================================================================
    IF EXISTS(SELECT 1 FROM TMP_ARTICULOS_VENTAS)
      DELETE TMP_ARTICULOS_VENTAS
    --=============================================================================

    --=============================================================================
    --REINICIÓ EL CONTADOR DE LA TABLA TMP_ARTICULOS_VENTAS ***********************
    --=============================================================================
    DBCC CHECKIDENT ('TMP_ARTICULOS_VENTAS', RESEED,0)
    --=============================================================================
    
	  SET NOCOUNT OFF

  COMMIT
  	
END TRY

BEGIN CATCH
  SET NOCOUNT OFF
  ROLLBACK
  PRINT 'ACTUALIZACION CANCELADA POR ERROR'
  SELECT ERROR_NUMBER()     'ERROR_NUMBER' , 
         ERROR_MESSAGE()    'ERROR_MESSAGE', 
         ERROR_LINE()       'ERROR_LINE', 
         ERROR_PROCEDURE()  'ERROR_PROCEDURE', 
         ERROR_SEVERITY ()  'ERROR_SEVERITY',   
         ERROR_STATE()      'ERROR_STATE'
END CATCH	

go
