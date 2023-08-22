using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Model.Modelos
{
    public class Orden_Compra_Lineas
    {
        [NotMapped]
        public bool Nuevo { get; set; }

        [Required]
        [StringLength(10)]
        public string Orden_Compra { get; set; }
        [Required]
        public short Orden_Compra_Linea { get; set; }
        [Required]
        [StringLength(20)]
        public string Articulo { get; set; }
        [Required]
        [StringLength(4)]
        public string Bodega { get; set; }
        [Required]
        public short Linea_Usuario { get; set; }
        [Column(TypeName = "Text")]
        public string Descripcion { get; set; }
        [Required]
        public decimal Cantidad_Ordenada { get; set; }
        [Required]
        public decimal Cantidad_Embarcada { get; set; }
        [Required]
        public decimal Cantidad_Recibida { get; set; }
        [Required]
        public decimal Cantidad_Rechazada { get; set; }
        [Required]
        public decimal Precio_Unitario { get; set; }
        [Required]
        public decimal Impuesto1 { get; set; }
        [Required]
        public decimal Impuesto2 { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo_Descuento { get; set; }
        [Required]
        public decimal Porc_Descuento { get; set; }
        [Required]
        public decimal Monto_Descuento { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(1)]
        public string Estado { get; set; }
        [StringLength(250)]
        public string Comentario { get; set; }
        public decimal? Factor_Conversion { get; set; }
        [Required]
        public DateTime Fecha_Requerida { get; set; }
        public DateTime? Fec_Embarque_Prov { get; set; }
        public short? Dias_Para_Entrega { get; set; }
        [StringLength(50)]
        public string Factura { get; set; }
        [StringLength(6)]
        public string Unidad_Distribucio { get; set; }
        [StringLength(25)]
        public string Usuario_Cancela { get; set; }
        public DateTime? Fecha_Hora_Cancela { get; set; }
        public DateTime? Fecha_Hora_Cierre { get; set; }
        [StringLength(25)]
        public string Usuario_Cierre { get; set; }
        [StringLength(25)]
        public string Centro_Costo { get; set; }
        [StringLength(25)]
        public string Cuenta_Contable { get; set; }
        [StringLength(250)]
        public string E_Mail { get; set; }
        public decimal Cantidad_Aceptada { get; set; }
        [StringLength(8)]
        public string Localizacion { get; set; }
        [StringLength(15)]
        public string Lote { get; set; }
        [StringLength(1)]
        public string Imp2_Por_Cantidad { get; set; }
        [StringLength(25)]
        public string Fase { get; set; }
        [StringLength(25)]
        public string Proyecto { get; set; }
        public int? Serie_Cadena { get; set; }
        [Required]
        [StringLength(1)]
        public string Imp1_Afecta_Costo { get; set; }
        public decimal Imp1_Asumido_Desc { get; set; }
        public decimal Imp1_Asumido_Nodesc { get; set; }
        public decimal Imp1_Retenido_Desc { get; set; }
        public decimal Imp1_Retenido_Nodesc { get; set; }
        public int? Orden_Cambio { get; set; }
        [Required]
        public decimal Precio_Art_Prov { get; set; }
        [StringLength(4)]
        public string Concepto_Me { get; set; }
        public decimal? Monto_Aplicado { get; set; }
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
        [StringLength(4)]
        public string Tipo_Impuesto1 { get; set; }
        [StringLength(2)]
        public string Tipo_Tarifa1 { get; set; }
        [StringLength(4)]
        public string Tipo_Impuesto2 { get; set; }
        [StringLength(2)]
        public string Tipo_Tarifa2 { get; set; }
        public decimal? Porc_Exoneracion { get; set; }
        public decimal? Monto_Exoneracion { get; set; }
        [Required]
        [StringLength(1)]
        public string Es_Canasta_Basica { get; set; }
        public decimal? Montototalimpuestoacreditar { get; set; }
        public decimal? Montototaldegastoaplicable { get; set; }
        public decimal? Montoproporcionalidad { get; set; }
        public decimal? Subtotal_Bienes { get; set; }
        public decimal? Subtotal_Servicios { get; set; }
        public decimal? Porcentaje_Isc { get; set; }
        public decimal? Monto_Isc { get; set; }
    }
}
