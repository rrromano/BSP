Use WIAdbisys
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_modificarVenta')
  Drop Procedure adp_modificarVenta
Go 

-- SP PARA MODIFICAR VENTA 
Create procedure dbo.adp_modificarVenta ( @ID_VENTA NUMERIC(30),
                                          @USUARIO_VENTA VARCHAR(255) = NULL)
as

BEGIN TRY

  BEGIN TRAN
    
	  SET NOCOUNT ON
	  
	  
    --RAISERROR (N'This is message %s %d.', -- Message text.
    --       10, -- Severity,
    --       1, -- State,
    --       N'number', -- First argument.
    --       5); -- Second argument.

	  
	  DECLARE @CANTIDAD_ARTICULOS NUMERIC(10)
	  DECLARE @IMPORTE_VENTA NUMERIC(10,2)
	  DECLARE @MENSAJE_ERROR VARCHAR(500)
	  
	  IF NOT EXISTS (SELECT 1 FROM TMP_ARTICULOS_VENTAS)
	  BEGIN
	      SET @MENSAJE_ERROR = 'NO SE HAN IMPORTADO REGISTROS EN LA TABLA TMP_ARTICULOS_VENTAS'
	      RAISERROR (N'%s', 16, 1, @MENSAJE_ERROR);
	    END
	  
	  IF NOT EXISTS (SELECT 1 FROM VENTAS WHERE ID_VENTA = @ID_VENTA)
	    BEGIN
	      SET @MENSAJE_ERROR = 'NO EXISTE VENTA CON UN ID_VENTA = ' + ISNULL(CONVERT(VARCHAR,@ID_VENTA),'NULL')
	      RAISERROR (N'%s', 16, 1, @MENSAJE_ERROR);
	    END
	  
	  
	  IF EXISTS (SELECT 1 FROM ARTICULOS_VENTAS WHERE ID_VENTA = @ID_VENTA)
	    DELETE ARTICULOS_VENTAS WHERE ID_VENTA = @ID_VENTA
	  
	  INSERT INTO ARTICULOS_VENTAS (ID_VENTA, ID_ITEM_VENTA, ID_ARTICULO, CANTIDAD, PRECIO_VENTA)
	  SELECT @ID_VENTA, A.ID_ITEM_VENTA, A.ID_ARTICULO, A.CANTIDAD, B.PRECIO_VENTA
	  FROM TMP_ARTICULOS_VENTAS A
	  INNER JOIN ARTICULOS B ON (A.ID_Articulo = B.ID_Articulo)
	  
	  SELECT  @CANTIDAD_ARTICULOS = COUNT(1),
	          @IMPORTE_VENTA = SUM(PRECIO_VENTA * CANTIDAD)
	  FROM ARTICULOS_VENTAS
	  WHERE ID_VENTA = @ID_VENTA
	  
	  UPDATE A 
	  SET   A.CANTIDAD_ARTICULOS = @CANTIDAD_ARTICULOS,
	        A.IMPORTE = @IMPORTE_VENTA,
	        A.FECHA_MODIF = GETDATE(),
	        A.LOGIN_MODIF = @USUARIO_VENTA,
	        A.TERM_MODIF = HOST_NAME()
	  FROM VENTAS A
	  WHERE ID_VENTA = @ID_VENTA
	  
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
