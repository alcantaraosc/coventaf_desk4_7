using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Order_Compras
    {
        [Required]
        [StringLength(10)]
        public string Orden_Compra { get; set; }
        [StringLength(25)]
        public string Usuario { get; set; }
        [Required]
        [StringLength(20)]
        public string Proveedor { get; set; }
        [Required]
        [StringLength(4)]
        public string Bodega { get; set; }
        [Required]
        [StringLength(4)]
        public string Condicion_Pago { get; set; }
        [Required]
        [StringLength(4)]
        public string Moneda { get; set; }
        [Required]
        [StringLength(4)]        
        public string Pais { get; set; }
        [StringLength(10)]
        public string Respon_Seguimiento { get; set; }
        [Required]
        [StringLength(4)]
        public string Modulo_Origen { get; set; }
        [Required]
        public DateTime? Fecha { get; set; }
        public DateTime? Fecha_Cotizacion { get; set; }
        public DateTime? Fecha_Ofrecida { get; set; }
        public DateTime? Fecha_Emision { get; set; }
        public DateTime? Fecha_Req_Embarque { get; set; }
        [Required]
        public DateTime Fecha_Requerida { get; set; }
        [StringLength(250)]
        public string Direccion_Embarque { get; set; }
        [StringLength(250)]
        public string Direccion_Cobro { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo_Descuento { get; set; }
        [Required]
        public decimal Porc_Descuento { get; set; }
        public decimal? Monto_Descuento { get; set; }
        [Required]
        public decimal Total_Mercaderia { get; set; }
        [Required]
        public decimal Total_Impuesto1 { get; set; }
        [Required]
        public decimal Total_Impuesto2 { get; set; }
        [Required]
        public decimal Monto_Flete { get; set; }
        [Required]
        public decimal Monto_Seguro { get; set; }
        [Required]
        public decimal Monto_Documentacio { get; set; }
        [Required]
        public decimal Monto_Anticipo { get; set; }
        [Required]
        public decimal Total_A_Comprar { get; set; }
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
        [StringLength(1)]
        public string Prioridad { get; set; }
        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
        [Required]
        [StringLength(1)]
        public string Impresa { get; set; }
        [StringLength(10)]
        public string Num_Formulario { get; set; }
        [StringLength(250)]
        public string Instrucciones { get; set; }
        [StringLength(40)]
        public string Comentario_Cxp { get; set; }
        [Required]
        public DateTime Fecha_Hora { get; set; }
        [Column(TypeName = "Text")]
        public string Observaciones { get; set; }
        [StringLength(1)]
        public string Requiere_Confirma { get; set; }
        [StringLength(1)]
        public string Confirmada { get; set; }
        [StringLength(25)]
        public string Usuario_Confirma { get; set; }
        public DateTime? Fecha_Hora_Confir { get; set; }
        [StringLength(25)]
        public string Usuario_Cierre { get; set; }
        public DateTime? Fecha_Hora_Cierre { get; set; }
        [StringLength(10)]
        public string Asiento_Cierre { get; set; }
        [Required]
        [StringLength(1)]
        public string Orden_Programada { get; set; }
        [Required]
        [StringLength(1)]
        public string Recibido_De_Mas { get; set; }
        public DateTime? Fecha_Hora_Cancela { get; set; }
        [StringLength(25)]
        public string Usuario_Cancela { get; set; }
        [StringLength(2)]
        public string Tipo_Prorrateo_Oc { get; set; }
        [StringLength(20)]
        public string Presupuesto_Cr { get; set; }
        [StringLength(4)]
        public string Cod_Direc_Emb { get; set; }
        [StringLength(250)]
        public string Notas_Noaprobar { get; set; }
        [StringLength(10)]
        public string Departamento { get; set; }
        public DateTime? Fecha_Ult_Notif { get; set; }
        public decimal? Base_Impuesto1 { get; set; }
        public decimal? Base_Impuesto2 { get; set; }
        public decimal? Tot_Imp1_Asum_Desc { get; set; }
        public decimal? Tot_Imp1_Asum_Nodesc { get; set; }
        public decimal? Tot_Imp1_Rete_Desc { get; set; }
        public decimal? Tot_Imp1_Rete_Nodesc { get; set; }
        public DateTime? Fecha_No_Aprueba { get; set; }
        [StringLength(25)]
        public string Usuario_No_Aprueba { get; set; }
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

        public decimal? Monto_Isc { get; set; } = 0.00M;
    }
}
