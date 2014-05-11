Use WIADBISYS
Go 
If Exists ( Select 1 From SysObjects Where Name = 'adp_nuevo_TipoMovCaja')
  Drop Procedure adp_nuevo_TipoMovCaja
Go 

-- SP QUE INSERTA UN NUEVO PROVEEDOR.
Create procedure adp_nuevo_TipoMovCaja (@TIPOMOVCAJA_ID			NUMERIC(2),
																				@TIPOMOVCAJA_DESC		VARCHAR(255),
																				@TIPOMOVCAJA_ES			NUMERIC(1),
																				@TIPOMOVCAJA_FECHA	DATETIME,
																				@TIPOMOVCAJA_HORA		VARCHAR(8),	
																				@TIPOMOVCAJA_LOGIN	VARCHAR(255) = null)
as


BEGIN TRY

	SET NOCOUNT ON

	INSERT INTO TIPOMOVIMIENTO_CAJA (	ID_TIPOMOVIMIENTO,
																		DESCRIPCION,
																		INGRESO_SALIDA,
																		ESTADO,
																		FECHA_MODIF,
																		LOGIN_MODIF,
																		TERM_MODIF	)
													 
	VALUES (@TIPOMOVCAJA_ID						,	--ID TIPO MOVIMIENTO
					UPPER(@TIPOMOVCAJA_DESC)	,	--DESCRIPCION
					@TIPOMOVCAJA_ES						, --ENTRADA/SALIDA
					1													, --ESTADO
					GETDATE(), --FECHA_MODIF
					@TIPOMOVCAJA_LOGIN				,	--LOGIN_MODIF
					HOST_NAME()								)	--TERM_MODIF
					
					
	INSERT	INTO MOVIMIENTOS_CAJA	(ID_TIPOMOVIMIENTO,
																 VALOR,
																 ESTADO,
																 FECHA,
																 HORA)
	VALUES (@TIPOMOVCAJA_ID,
					'0.00',
					1,
					CONVERT(VARCHAR,@TIPOMOVCAJA_FECHA,112),
					@TIPOMOVCAJA_HORA)

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
go
