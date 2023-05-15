using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Documento_Pos
    {
        [Required]
        [StringLength(50)]
        public string Documento { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }
        [Required]
        [StringLength(6)]
        public string Caja { get; set; }
        [StringLength(6)]
        public string Caja_Cobro { get; set; }
        [Required]
        [StringLength(10)]
        public string Correlativo { get; set; }
        [StringLength(4)]
        public string Perfil { get; set; }
        [StringLength(4)]
        public string Vendedor { get; set; }
        [Required]
        [StringLength(20)]
        public string Cliente { get; set; }
        [StringLength(150)]
        public  string Nombre_Cliente { get; set; }
        [Required]
        [StringLength(25)]
        public string Cajero { get; set; }
        [Required]
        public decimal  Impuesto1 { get; set; }
        [Required]
        public decimal  Impuesto2 { get; set; }
        [Required]
        public decimal  Descuento { get; set; }
        [Required]
        public decimal  Total_Pagar { get; set; }
        [Required]
        public decimal  Total { get; set; }
        [Required]
        public DateTime Fch_Hora_Creacion { get; set; }
        public DateTime? Fch_Hora_Cobro { get; set; }
        public DateTime? Fch_Hora_Anula { get; set; }
        [Required]
        [StringLength(1)]
        public string Exportado { get; set; }
        [Required]
        [StringLength(1)]        
        public string Estado_Cobro { get; set; }
        [Required]
        public decimal Saldo { get; set; }
        [Required]
        public decimal Saldo_Reporte { get; set; }
        [Required]
        [StringLength(1)]
        public string Moneda_Doc { get; set; }
        [Required]
        public DateTime  Fecha_Vence { get; set; }
        [Required]
        [StringLength(1)]
        public string Listo_Inventario { get; set; }
        [StringLength(12)]
        public string Nivel_Precio { get; set; }
        [StringLength(1)]
        public string Moneda_Nivel { get; set; }
        public int Version { get; set; }
        public DateTime? FechaNac_Cliente { get; set; }
        [StringLength(50)]
        public string Telefono_Cliente { get; set; }
        [StringLength(20)]
        public string Nit_Cliente { get; set; }
        [Column(TypeName = "Text")]
        public string Notas { get; set; }
        [StringLength(4)]
        public string Pais { get; set; }
        [StringLength(1)]
        public string Clase_Documento { get; set; }
        [StringLength(4000)]
        public string Direccion { get; set; }
        [StringLength(1)]
        public string Exportado_Tienda { get; set; }
        [StringLength(4)]
        public string Condicion_Pago_Apa { get; set; }
        [StringLength(50)]
        public string Doc_Cc { get; set; }
        [StringLength(3)]
        public string Tipo_Doc_Cc { get; set; }
        [Required]
        [StringLength(1)]
        public string Cargado_Cc { get; set; }
        [Required]
        [StringLength(1)]
        public string Cargado_Cg { get; set; }
        [StringLength(1)]
        public string Devuelve_Dinero { get; set; }
        [StringLength(50)]
        public string Doc_Cc_Anul { get; set; }
        [StringLength(3)]
        public string Tipo_Doc_Cc_Anul { get; set; }
        [StringLength(1)]
        public string Genero_Factura_Inicio { get; set; }
        [StringLength(1)]
        public string Afecta_Contabil { get; set; }
        public decimal? Efectivo_Devuelto { get; set; }        
        [Required]
        public decimal Tipo_Cambio { get; set; }
        [StringLength(254)]
        public string Beneficiario { get; set; }
        [StringLength(1)]
        public string Moneda { get; set; }
        [StringLength(1)]
        public string Subtipo { get; set; }
        [StringLength(20)]
        public string Id_Beneficiario { get; set; }
        [StringLength(25)]
        public string Usuario_Ult_Impre { get; set; }
        public DateTime? Fch_Hora_Ult_Impre { get; set; }
        [StringLength(25)]
        public string Usuario_Aplicacion { get; set; }
        public DateTime? Fch_Hora_Aplicacio { get; set; }
        [StringLength(25)]
        public string Usuario_Anulacion { get; set; }
        [StringLength(1)]
        public string Estado_Impresion { get; set; }
        [StringLength(50)]
        public string Telefono_Beneficia { get; set; }
        [StringLength(20)]
        public string Ncf { get; set; }
        [StringLength(6)]
        public string Tipo_Ncf { get; set; }
        [StringLength(20)]
        public string Num_Cierre { get; set; }
        [StringLength(150)]
        public string Recibido_De { get; set; }
        [StringLength(20)]
        public string Resolucion { get; set; }
        [StringLength(10)]
        public string Cod_Clase_Doc { get; set; }
        [Required]
        [StringLength(1)]
        public string Doc_Express { get; set; }
        [StringLength(10)]
        public string Mensajero { get; set; }
        [StringLength(20)]
        public string Cliente_Express { get; set; }
        [StringLength(80)]
        public string Entrega_Exprss_A { get; set; }
        [Required]
        [StringLength(1)]
        public string Estado_Express { get; set; }
        public decimal? Monto_Entregado { get; set; }
        public decimal? Monto_Devuelto { get; set; }
        public DateTime? Fch_Envio { get; set; }
        public DateTime? Fch_Entrega { get; set; }
        [StringLength(10)]
        public string Motiv_Cancela_Expr { get; set; }
        [StringLength(1000)]
        public string Nota_Express { get; set; }
        public decimal? Base_Impuesto1 { get; set; }
        public decimal? Base_Impuesto2 { get; set; }
        [StringLength(50)]
        public string Doc_Fiscal { get; set; }
        [StringLength(50)]
        public string Prefijo { get; set; }
        [StringLength(50)]
        public string Pedido_Autorizado { get; set; }
        [StringLength(50)]
        public string Doc_Cc_Anticipo { get; set; }
        [StringLength(20)]
        public string Nombremaquina { get; set; }
        [StringLength(20)]
        public string Cierre_Anulacion { get; set; }
        [Required]
        [StringLength(1)]
        public string Doc_Sincronizado { get; set; }
        [Required]
        public decimal Monto_Bonificado { get; set; }
        [Required]
        [StringLength(1)]
        public string Es_Doc_Externo { get; set; }
        [StringLength(4000)]
        public string Tienda_Enviado { get; set; }
        [Required]
        [StringLength(1)]
        public string Usa_Despachos { get; set; }
        [StringLength(50)]
        public string Clave_Referencia_De { get; set; }
        public DateTime? Fecha_Referencia_De { get; set; }
        [StringLength(4)]
        public string Forma_Pago { get; set; }
        [StringLength(3)]
        public string Uso_Cfdi { get; set; }
        [StringLength(2)]
        public string Justi_Dev_Haciend { get; set; }
        [StringLength(50)]
        public string Clave_De { get; set; }
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
        [StringLength(10)]
        public string Actividad_Comercial { get; set; }
        public decimal? Monto_Otro_Cargo { get; set; }
        public decimal? Monto_Total_Iva_Devuelto { get; set; }
        [StringLength(50)]
        public string Ncf_Modificado { get; set; }
    }
}
