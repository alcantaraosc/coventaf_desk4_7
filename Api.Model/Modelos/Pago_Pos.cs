using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    //En esta tabla se agrega la devolucion al momento de hacer dicha devoucion por el supervisor
    //al momento de pagar con la devolucion tampoco hace nada.
    public class Pago_Pos
    {
        [Required]
        [StringLength(50)]
        public string Documento { get; set; }
        [Required]
        [StringLength(4)]
        public string Pago { get; set; }  /*el campo pago es consecutivo e inicia  desde : 0,1,2 .... n  el codigo -1, es para identificar que el registro es un vuelto del cliente, este codigo (-1) ya esta definido en softland  */
        [Required]
        [StringLength(6)]
        public string Caja { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo { get; set; }  /*F es factura*/
        [StringLength(4)]
        public string Condicion_Pago { get; set; }
        [StringLength(8)]
        public string Entidad_Financiera { get; set; }
        [StringLength(12)]
        public string Tipo_Tarjeta { get; set; }
        [Required]
        [StringLength(4)]
        public string Forma_Pago { get; set; }
        [StringLength(80)]
        public string Numero { get; set; }
        [Required]

        public decimal Monto_Local { get; set; }
        [Required]

        public decimal Monto_Dolar { get; set; }
        [StringLength(80)]
        public string Autorizacion { get; set; }
        [StringLength(5)]
        public string Fecha_Expiracion { get; set; }
        public int? Cobro { get; set; }
        [StringLength(20)]
        public string Cliente_Liquidador { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo_Cobro { get; set; }
        [StringLength(80)]
        public string Referencia { get; set; }
        [StringLength(80)]
        public string Num_Seguimiento { get; set; }
        [StringLength(50)]
        public string Num_Transac_Tarjeta { get; set; }
        [StringLength(30)]
        public string Campo1 { get; set; }
        [StringLength(50)]
        public string Valor1 { get; set; }
        [StringLength(30)]
        public string Campo2 { get; set; }
        [StringLength(50)]
        public string Valor2 { get; set; }
        [StringLength(30)]
        public string Campo3 { get; set; }
        [StringLength(50)]
        public string Valor3 { get; set; }
        [StringLength(30)]
        public string Campo4 { get; set; }
        [StringLength(50)]
        public string Valor4 { get; set; }
        [StringLength(30)]
        public string Campo5 { get; set; }
        [StringLength(50)]
        public string Valor5 { get; set; }
        [StringLength(30)]
        public string Campo6 { get; set; }
        [StringLength(50)]
        public string Valor6 { get; set; }
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
