using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class Cierre_Pos
    {
        [Required]
        [StringLength(20)]
        public string Num_Cierre { get; set; }
        [Required]
        [StringLength(25)]
        public string Cajero { get; set; }
        [Required]
        [StringLength(6)]
        public string Caja { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo_Cierre { get; set; }
        [Required]
        [StringLength(40)]
        public string Nombre_Vendedor { get; set; }
        [Required]
        public DateTime Fecha_Hora { get; set; }
        [Required]
        public decimal Tipo_Cambio { get; set; }
        [Required]
        public decimal Monto_Apertura { get; set; }
        [Required]
        public decimal Total_Diferencia { get; set; }
        [StringLength(50)]
        public string Documento_Ajuste { get; set; }
        //TOTAL_LOCAL= [es la suma de todo lo q se recibió en cordoba incluyendo efectivo, tarjeta, cheque, etc pero qque solo sea córdobas]
        [Required]
        public decimal Total_Local { get; set; }
        //--TOTAL_DOLAR=[es la suma de todo el dinero q se recibió en dolares incluyendo efectivo, tarjeta cheque, pero que solo sea dólar     
        [Required]
        public decimal Total_Dolar { get; set; }
        //VENTAS_EFECTIVO= [es la suma solo en efectivo en cordoba y nada mas]
        [Required]
        public decimal Ventas_Efectivo { get; set; }
        //Indica si el cierre esta abierto(A); cerrado(C) o anulado(N)
        [Required]
        [StringLength(1)]        
        public string Estado { get; set; }
        public DateTime? Fecha_Hora_Inicio { get; set; }
        [StringLength(4000)]
        public string Notas { get; set; }

        //es la suma solo en efectivo en dolares y nada mas
        [Required]
        public decimal Cobro_Efectivo_Rep { get; set; }
        [StringLength(20)]
        public string Num_Cierre_Caja { get; set; }
        [StringLength(50)]
        public string Doc_Fiscal { get; set; }
        [StringLength(50)]
        public string Documento { get; set; }
        [StringLength(10)]
        public string Correlativo { get; set; }
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


    }
}
