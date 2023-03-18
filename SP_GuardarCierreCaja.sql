USE [TIENDA]
-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE SP_GuardarCierreCaja
	@Caja VARCHAR(6), @Cajero VARCHAR(25), @NumCierre VARCHAR(20),	
	--@TotalDiferencia estoy investigando.
	@TotalDiferencia AS DECIMAL(24,8),
	@Total_Local AS DECIMAL(24,8), @Total_Dolar AS DECIMAL(24,8), 
	@Ventas_Efectivo AS DECIMAL(24,8), @CobroEfectivoRep AS DECIMAL(24,8), 
	@Notas VARCHAR(4000), 
	@ListDetallePago AS DatosCierreDetallePago READONLY
AS
BEGIN TRY  	
	BEGIN TRANSACTION

	DECLARE @ConsCierreCajero VARCHAR(50), @NumCierreCaja VARCHAR(50), @DocumCierreCaja VARCHAR(50)


	--obtener el consecutivo para el cierre del cajero
	 SELECT @ConsCierreCajero=VALOR FROM TIENDA.CONSEC_CAJA_POS WHERE CAJA=@Caja and CODIGO='CCAJERO'
	 --obtener el numero de cierre de la caja
	 SELECT @NumCierreCaja=NUM_CIERRE_CAJA FROM TIENDA.CIERRE_POS WHERE  NUM_CIERRE=@NumCierre AND CAJA=@Caja
	
	--la tabla CIERRE_POS se refiere al cierre de cajero
	UPDATE  TIENDA.CIERRE_POS 
			--fecha y hora de cierre del cajero.
		SET   FECHA_HORA = GETDATE(),-- '20230211 12:44:47',   
				
			--TIPO_CAMBIO =@TipoCambio,-- 36.2924,        
			TOTAL_DIFERENCIA = @TotalDiferencia,        
			DOCUMENTO_AJUSTE = '', 
			--TOTAL_LOCAL= [es la suma de todo lo q se recibió en cordoba incluyendo efectivo, tarjeta para que se córdobas]
			TOTAL_LOCAL =@Total_Local, --941.37, 
			
			--TOTAL_DOLAR=[es la suma de todo el dinero q se recibió en dolares incluyendo efectivo, tarjeta cheque, pero que solo sea dólar      
			TOTAL_DOLAR = @Total_Dolar,--27.16,    
			
			--VENTAS_EFECTIVO= [es la suma  solo en efectivo en cordoba y nada mas]
			VENTAS_EFECTIVO =@Ventas_Efectivo,
			
			--DOCUMENTO= cierre de cajero(T1C02-CCO-0000295) SELECT VALOR,* FROM TIENDA.CONSEC_CAJA_POS  WHERE CAJA='T1C2'
			DOCUMENTO = @ConsCierreCajero, --'T1C02-CCO-0000295',        
			CORRELATIVO = 'CCAJERO',     
			--COBRO_EFECTIVO_REP= [es la suma  solo en efectivo en dolares y nada mas]
			COBRO_EFECTIVO_REP = @CobroEfectivoRep, --Monto en efectivo en moneda reporte  
			ESTADO = 'C',    
			NOTAS = @Notas
	WHERE CAJA =@Caja AND CAJERO =@Cajero AND  NUM_CIERRE = @NumCierre
	
	---actualizar el consecutivo del cajero
	UPDATE  TIENDA.CONSEC_CAJA_POS SET VALOR= (SELECT TIENDA.NextStrCodigo(@ConsCierreCajero, LEN(@ConsCierreCajero)))  WHERE CAJA=@Caja and CODIGO='CCAJERO'
	
	/*   Nota importante: aunque en caja no se reciba efectivo en córdobas y en dólares se tiene que reflejar cero (0)*/

	--guardar el detalle de pago. 
	INSERT INTO  TIENDA.CIERRE_DET_PAGO (NUM_CIERRE, CAJERO, CAJA, TIPO_PAGO, TOTAL_SISTEMA, TOTAL_USUARIO, DIFERENCIA, ORDEN)
	SELECT NumCierre, Cajero, Caja, TipoPago, TotalSistema, TotalUsuario, Diferencia, Orden FROM @ListDetallePago
		
	---SOLO TARJETA =(0003)
	INSERT INTO  TIENDA.CIERRE_DESG_TARJ ( CONSECUTIVO, CAJA, TIPO_TARJETA, DOCUMENTO, TIPO, AUTORIZACION, MONTO, NUM_CIERRE, CAJERO ) 		
	SELECT ROW_NUMBER() OVER(ORDER BY PAGO_POS.FORMA_PAGO) AS CONSECUTIVO, 
															FACTURA.CAJA, 
												PAGO_POS.TIPO_TARJETA,
												PAGO_POS.DOCUMENTO, 
												PAGO_POS.TIPO, 
												PAGO_POS.AUTORIZACION,
												PAGO_POS.MONTO_LOCAL,
												FACTURA.NUM_CIERRE,
												FACTURA.USUARIO																			
	FROM TIENDA.PAGO_POS 
			INNER JOIN TIENDA.FACTURA ON TIENDA.PAGO_POS.DOCUMENTO = TIENDA.FACTURA.FACTURA AND TIENDA.PAGO_POS.TIPO = TIENDA.FACTURA.TIPO_DOCUMENTO AND TIENDA.PAGO_POS.CAJA = TIENDA.FACTURA.CAJA
	WHERE        (TIENDA.PAGO_POS.FORMA_PAGO = '0003') AND (FACTURA.NUM_CIERRE=@NumCierre) AND (PAGO_POS.CAJA=@Caja) AND (FACTURA.USUARIO=@Cajero)

	/*****************************cierre de caja **************************************************************************************************************************/	
	 --obtener el consecutivo para el cierre de caja
	 SELECT @DocumCierreCaja=VALOR FROM TIENDA.CONSEC_CAJA_POS WHERE CAJA=@Caja and CODIGO='CCAJA';

	--cierre de caja
	UPDATE  TIENDA.CIERRE_CAJA SET CAJERO_CIERRE = @Cajero,
								   FECHA_CIERRE =  GETDATE(),
								   ESTADO = 'C', 
								   --'T1C02-CCA-0000226'
								   DOCUMENTO = @DocumCierreCaja, 
								   CORRELATIVO = 'CCAJA' 
	WHERE NUM_CIERRE_CAJA = @NumCierreCaja AND CAJA = @Caja AND ESTADO='A'

	--Actualizar el consecutivo de la caja de cierre
	UPDATE TIENDA.CONSEC_CAJA_POS SET VALOR=(SELECT TIENDA.NextStrCodigo(@DocumCierreCaja, LEN(@DocumCierreCaja))) WHERE  CODIGO = 'CCAJA' AND CAJA=@Caja 
	
	/**************************************************************************************************************************************************************/

	COMMIT TRANSACTION; 

END TRY  
BEGIN CATCH  
	ROLLBACK	
	RETURN	ERROR_MESSAGE();    
END CATCH