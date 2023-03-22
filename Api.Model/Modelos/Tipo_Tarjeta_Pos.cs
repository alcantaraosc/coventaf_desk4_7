﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class Tipo_Tarjeta_Pos
    {
        [Required]
        [StringLength(12)]
        public string Tipo_Tarjeta { get; set; }
        [Required]
        [StringLength(20)]
        public string Cliente { get; set; }
        [Required]
        public decimal Comision { get; set; }
        [StringLength(25)]
        public string Ctr_Autorizador { get; set; }
        [StringLength(25)]
        public string Cta_Autorizador { get; set; }
        [StringLength(25)]
        public string Ctr_Comision { get; set; }
        [StringLength(25)]
        public string Cta_Comision { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo_Cobro { get; set; }
        [Required]
        [StringLength(1)]
        public string Configuracion_Pago { get; set; }
        public decimal? Porcentaje_Pago { get; set; }
        [Required]
        [StringLength(1)]
        public string Porcentaje_Fijo { get; set; }
        [StringLength(20)]
        public string Ncf_Factura { get; set; }
        [StringLength(20)]
        public string Ncf_Devolucion { get; set; }
        [Required]
        [StringLength(1)]
        public string Configuracion_Cobro { get; set; }
        [Required]
        [StringLength(1)]
        public string Tipo_Conf_Cobro_Cliente { get; set; }
        [Required]
        [StringLength(1)]
        public string Generar_Cobro { get; set; }
        [StringLength(3)]
        public string Tipo_Doc_Cxc { get; set; }
        public short? Subtipo_Doc_Cxc { get; set; }
        [StringLength(3)]
        public string Tipo_Doc_Comision { get; set; }
        public short? Subtipo_Doc_Comision { get; set; }
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
