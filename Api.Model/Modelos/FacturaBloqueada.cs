﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class FacturaBloqueada
    {
        [Required]
        [StringLength(50)]
        public string NoFactura { get; set; }

        [StringLength(50)]
        public string Cajero { get; set; }

        [StringLength(15)]
        public string Caja { get; set; }
        [Required]
        [StringLength(50)]
        public string NumCierreCT { get; set; }

        [Required]
        [StringLength(4)]
        public string TipoDocumento { get; set; }

        [Required]
        [StringLength(6)]
        public string UnidadNegocio { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        [StringLength(50)]
        public string EstadoFactura { get; set; }

    }
}
