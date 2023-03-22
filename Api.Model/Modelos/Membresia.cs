﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Model.Modelos
{
    public class Membresia
    {
        [Required]
        [StringLength(25)]
        public string Grupo { get; set; }
        [Required]
        [StringLength(25)]
        public string Usuario { get; set; }
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
