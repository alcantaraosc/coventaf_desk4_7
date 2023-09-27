﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Model.Modelos
{
    public class Facturas
    {
        //factura de super: 1060010
        public Facturas()
        {
            //PEDIDO_AUTORIZA = new HashSet<PEDIDO_AUTORIZA>();
            //FACTURA_LINEA = new HashSet<FACTURA_LINEA>();
            //FACTURA_RETENCION = new HashSet<FACTURA_RETENCION>();
            //FACTURA_ADUANA = new HashSet<FACTURA_ADUANA>();
            //FACTURA_CANCELA = new HashSet<FACTURA_CANCELA>();
            //FIADORES_DOC_FA = new HashSet<FIADORES_DOC_FA>();
            //GARANTIAS_DOC_FA = new HashSet<GARANTIAS_DOC_FA>();
            //PLAN_PAGO_DOC = new HashSet<PLAN_PAGO_DOC>();
        }


        [Required]
        [StringLength(1)]
        public string Tipo_Documento { get; set; }
        [Required]
        [StringLength(50)]
        public string Factura { get; set; }

        [StringLength(6)]
        public string Caja { get; set; }

        [StringLength(20)]
        public string Num_Cierre { get; set; }

        public int? Audit_Trans_Inv { get; set; }

        [Required]
        [StringLength(1)]
        public string Esta_Despachado { get; set; }

        [Required]
        [StringLength(1)]
        public string En_Investigacion { get; set; }

        [Required]
        [StringLength(1)]
        public string Trans_Adicionales { get; set; }

        [Required]
        [StringLength(1)]
        public string Estado_Remision { get; set; }

        [StringLength(10)]
        public string Asiento_Documento { get; set; }
        [Required]

        public decimal Descuento_Volumen { get; set; }

        [Required]
        [StringLength(1)]
        public string Moneda_Factura { get; set; }

        [StringLength(40)]
        public string Comentario_Cxc { get; set; }
        [Required]
        public DateTime Fecha_Despacho { get; set; }

        [Required]
        [StringLength(1)]
        public string Clase_Documento { get; set; }

        [Required]
        public DateTime Fecha_Recibido { get; set; }

        [StringLength(50)]
        public string Pedido { get; set; }


        [StringLength(50)]
        public string Factura_Original { get; set; }

        [StringLength(1)]
        public string Tipo_Original { get; set; }

        [Required]

        public decimal Comision_Cobrador { get; set; }

        [StringLength(20)]
        public string Tarjeta_Credito { get; set; }

        [Required]

        public decimal Total_Volumen { get; set; }

        [StringLength(10)]
        public string Numero_Autoriza { get; set; }

        [Required]

        public decimal Total_Peso { get; set; }
        [Required]

        public decimal Monto_Cobrado { get; set; }
        [Required]

        public decimal Total_Impuesto1 { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public DateTime Fecha_Entrega { get; set; }
        [Required]

        public decimal Total_Impuesto2 { get; set; }
        [Required]

        public decimal Porc_Descuento2 { get; set; }
        [Required]

        public decimal Monto_Flete { get; set; }
        [Required]

        public decimal Monto_Seguro { get; set; }
        [Required]

        public decimal Monto_Documentacio { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo_Descuento1 { get; set; }

        [Required]
        [StringLength(1)]
        public string Tipo_Descuento2 { get; set; }
        [Required]

        //investigando en softland: Monto  del descuento General
        public decimal Monto_Descuento1 { get; set; }
        [Required]

        public decimal Monto_Descuento2 { get; set; }
        [Required]
        //investigando en softland: PorCentaje Descuento General        
        public decimal Porc_Descuento1 { get; set; }
        [Required]

        public decimal Total_Factura { get; set; }
        [Required]
        public DateTime Fecha_Pedido { get; set; }
        public DateTime? Fecha_Hora_Anula { get; set; }

        public DateTime? Fecha_Orden { get; set; }
        [Required]

        public decimal Total_Mercaderia { get; set; }
        [Required]

        public decimal Comision_Vendedor { get; set; }

        [StringLength(30)]
        public string Orden_Compra { get; set; }
        [Required]
        public DateTime Fecha_Hora { get; set; }
        [Required]

        public decimal Total_Unidades { get; set; }
        [Required]
        public short Numero_Paginas { get; set; }
        [Required]

        public decimal Tipo_Cambio { get; set; }

        [Required]
        [StringLength(1)]
        public string Anulada { get; set; }

        [Required]
        [StringLength(4)]
        public string Modulo { get; set; }

        [Required]
        [StringLength(1)]
        public string Cargado_Cg { get; set; }

        [Required]
        [StringLength(1)]
        public string Cargado_Cxc { get; set; }

        [Required]
        [StringLength(160)]
        public string Embarcar_A { get; set; }

        [StringLength(8)]
        public string Direc_Embarque { get; set; }

        [StringLength(4000)]
        public string Direccion_Factura { get; set; }
        [Required]
        public short Multiplicador_Ev { get; set; }

        [Column(TypeName = "Text")]
        public string Observaciones { get; set; }

        [StringLength(50)]
        public string Rubro1 { get; set; }

        [StringLength(50)]
        public string Rubro2 { get; set; }

        [StringLength(50)]
        public string Rubro3 { get; set; }

        [StringLength(50)]
        public string Rubro4 { get; set; }

        [StringLength(50)]
        public string Rubro5 { get; set; }
        [Required]
        public int Version_Np { get; set; }

        [Required]
        [StringLength(1)]
        public string Moneda { get; set; }

        [Required]
        [StringLength(12)]
        public string Nivel_Precio { get; set; }

        [Required]
        [StringLength(4)]
        public string Cobrador { get; set; }

        [Required]
        [StringLength(4)]
        public string Ruta { get; set; }

        [Required]
        [StringLength(25)]
        public string Usuario { get; set; }

        [StringLength(25)]
        public string Usuario_Anula { get; set; }

        [Required]
        [StringLength(4)]
        public string Condicion_Pago { get; set; }

        [Required]
        [StringLength(4)]
        public string Zona { get; set; }

        [Required]
        [StringLength(4)]
        public string Vendedor { get; set; }

        [StringLength(50)]
        public string Doc_Credito_Cxc { get; set; }

        [Required]
        [StringLength(20)]
        public string Cliente_Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string Cliente_Corporac { get; set; }

        [Required]
        [StringLength(20)]
        public string Cliente_Origen { get; set; }

        [Required]
        [StringLength(20)]
        public string Cliente { get; set; }

        [Required]
        [StringLength(4)]
        public string Pais { get; set; }

        public short? Subtipo_Doc_Cxc { get; set; }

        [StringLength(3)]
        public string Tipo_Credito_Cxc { get; set; }

        [StringLength(3)]
        public string Tipo_Doc_Cxc { get; set; }

        //tambien se utiliza cuando el cliente paga una factura al credito y credito a Corto Plazo(Super). ahi pone el saldo
        public decimal? Monto_Anticipo { get; set; }

        public decimal? Total_Peso_Neto { get; set; }
        [Required]
        public DateTime Fecha_Rige { get; set; }

        [StringLength(20)]
        public string Contrato { get; set; }

        public decimal? Porc_Intcte { get; set; }

        [Required]
        [StringLength(1)]
        public string Usa_Despachos { get; set; }

        [Required]
        [StringLength(1)]

        public string Cobrada { get; set; }

        [Required]
        [StringLength(1)]
        public string Descuento_Cascada { get; set; }

        [StringLength(250)]
        public string Direccion_Embarque { get; set; }

        [StringLength(10)]
        public string Consecutivo { get; set; }
        [Required]
        public int Reimpreso { get; set; }

        [StringLength(12)]
        public string Division_Geografica1 { get; set; }

        [StringLength(12)]
        public string Division_Geografica2 { get; set; }

        public decimal? Base_Impuesto1 { get; set; }

        public decimal? Base_Impuesto2 { get; set; }

        [StringLength(150)]
        public string Nombre_Cliente { get; set; }

        [StringLength(50)]
        public string Doc_Fiscal { get; set; }

        [StringLength(20)]
        public string Nombremaquina { get; set; }

        [StringLength(20)]
        public string Serie_Resolucion { get; set; }

        public int? Consec_Resolucion { get; set; }

        [Required]
        [StringLength(1)]
        public string Genera_Doc_Fe { get; set; }
        [StringLength(4)]
        public string Tasa_Impositiva { get; set; }

        public decimal? Tasa_Impositiva_Porc { get; set; }

        [StringLength(4)]
        public string Tasa_Cree1 { get; set; }

        public decimal? Tasa_Cree1_Porc { get; set; }

        [StringLength(4)]
        public string Tasa_Cree2 { get; set; }

        public decimal? Tasa_Cree2_Porc { get; set; }

        public decimal? Tasa_Gan_Ocasional_Porc { get; set; }

        [StringLength(10)]
        public string Contrato_Ac { get; set; }

        public decimal? Ajuste_Redondeo { get; set; }

        [StringLength(3)]
        public string Uso_Cfdi { get; set; }

        [StringLength(4)]
        public string Forma_Pago { get; set; }

        [StringLength(50)]
        public string Clave_Referencia_De { get; set; }

        public DateTime? Fecha_Referencia_De { get; set; }

        [StringLength(2)]
        public string Justi_Dev_Haciend { get; set; }

        [StringLength(3)]
        public string Incoterms { get; set; }

        [StringLength(9)]
        public string U_Ad_Wm_Numero_Vendedor { get; set; }

        [StringLength(13)]
        public string U_Ad_Wm_Enviar_Gln { get; set; }

        [StringLength(8)]
        public string U_Ad_Wm_Numero_Recepcion { get; set; }

        [StringLength(10)]
        public string U_Ad_Wm_Numero_Reclamo { get; set; }

        [StringLength(8)]
        public string U_Ad_Wm_Fecha_Reclamo { get; set; }

        [StringLength(12)]
        public string U_Ad_Pc_Numero_Vendedor { get; set; }

        [StringLength(13)]
        public string U_Ad_Pc_Enviar_Gln { get; set; }

        [StringLength(12)]
        public string U_Ad_Gs_Numero_Vendedor { get; set; }

        [StringLength(13)]
        public string U_Ad_Gs_Enviar_Gln { get; set; }

        [StringLength(8)]
        public string U_Ad_Gs_Numero_Recepcion { get; set; }

        [StringLength(8)]
        public string U_Ad_Gs_Fecha_Recepcion { get; set; }

        [StringLength(12)]
        public string U_Ad_Am_Numero_Proveedor { get; set; }

        [StringLength(13)]
        public string U_Ad_Am_Enviar_Gln { get; set; }

        [StringLength(8)]
        public string U_Ad_Am_Numero_Recepcion { get; set; }

        [StringLength(10)]
        public string U_Ad_Am_Numero_Reclamo { get; set; }

        [StringLength(8)]
        public string U_Ad_Am_Fecha_Reclamo { get; set; }

        [StringLength(8)]
        public string U_Ad_Am_Fecha_Recepcion { get; set; }

        [StringLength(4)]
        public string Tipo_Operacion { get; set; }
        [Required]
        public byte NoteExistsFlag { get; set; }
        [Required]
        public DateTime RecordDate { get; set; }
        [Required]
        public Guid RowPointer { get; set; }
        [Required]
        [StringLength(30)]
        public string CreatedBy { get; set; }
        [Required]
        [StringLength(30)]
        public string UpdatedBy { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string Clave_De { get; set; }

        [StringLength(10)]
        public string Actividad_Comercial { get; set; }

        public decimal? Monto_Otro_Cargo { get; set; }

        public decimal? Monto_Total_Iva_Devuelto { get; set; }

        [StringLength(2)]
        public string Codigo_Referencia_De { get; set; }

        [StringLength(4)]
        public string Tipo_Referencia_De { get; set; }

        [StringLength(2)]
        public string Cancelacion { get; set; }

        [StringLength(20)]
        public string Estado_Cancelacion { get; set; }

        [StringLength(1)]
        public string Tiene_Relacionados { get; set; }

        [StringLength(25)]
        public string Prefijo { get; set; }

        public DateTime? Fecha_Inicio_Resolucion { get; set; }

        public DateTime? Fecha_Final_Resolucion { get; set; }

        [StringLength(80)]
        public string Clave_Tecnica { get; set; }

        public int? Matricula_Mercantil { get; set; }

        [StringLength(1)]
        public string Es_Factura_Reemplazo { get; set; }

        [StringLength(50)]
        public string Factura_Original_Reemplazo { get; set; }

        [StringLength(10)]
        public string Consecutivo_Ftc { get; set; }

        [StringLength(50)]
        public string Numero_Ftc { get; set; }

        [StringLength(20)]
        public string Nit_Transportador { get; set; }

        [StringLength(50)]
        public string Ncf_Modificado { get; set; }

        [StringLength(100)]
        public string Num_Oc_Exenta { get; set; }

        [StringLength(100)]
        public string Num_Cons_Reg_Exo { get; set; }

        [StringLength(100)]
        public string Num_Irsede_Agr_Gan { get; set; }

        [StringLength(30)]
        public string U_Ad_Wm_Tipo_Nc { get; set; }

        [StringLength(1)]
        public string Cuenta_Asiento { get; set; }

        [StringLength(10)]
        public string Tipo_Pago { get; set; }

        [StringLength(2)]
        public string Tipo_Descuento_Global { get; set; }

        [StringLength(10)]
        public string Tipo_Factura { get; set; }

        [StringLength(2)]
        public string Tipo_Nc { get; set; }

        [StringLength(4)]
        public string Tipo_Detrac { get; set; }

        [StringLength(4)]
        public string Act_Detrac { get; set; }
        public decimal? Porc_Detrac { get; set; }
        [StringLength(20)]
        public string Cierre_Anulacion { get; set; }
        [StringLength(20)]
        public string Tienda_Enviado { get; set; }

        //select SALDO, SALDO_REPORTE, ESTADO_COBRO, * from TIENDA.DOCUMENTO_POS where DOCUMENTO='T1C02-DEV-0000002' --DOCUMENTO='0369671'
        //este saldo es cuando haces una devolucion aqui se carga mientre se cobra, o mejor dicho mientra se paga con el vale.
        //tambien se utiliza cuando el cliente paga una factura al credito. ahi pone el saldo
        public decimal? Saldo { get; set; } = 0.00M;
        /*saldo reporte es dolares*/
        public decimal? Saldo_Reporte { get; set; }
        //se refiere si es TIENDA O SUPER, esto con el fin de poder identificar el consecutivo de la factura ya que la factura de super y tienda son diferente
        [StringLength(6)]
        public string UnidadNegocio { get; set; }
        //Este campo es para la devolucion el cual tiene una fecha de vencimiento, para el resto de factura es la fecha que se registra la factura
        public DateTime? Fecha_Vence { get; set; }
        [NotMapped]
        [StringLength(100)]
        public string NombreCajero { get; set; }                
        [StringLength(4)]
        public string Bodega { get; set; }
        [NotMapped]
        [StringLength(100)]
        public string NombreBodega { get; set; }
        [NotMapped]
        [StringLength(200)]
        public string Procedencia { get; set; }
    }
}

