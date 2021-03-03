﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
      
        public int DiagnoseId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Comments { get; set; }

        public Patient Patient { get; set; }

        // [ForeignKey(nameof(Patient))] // ??
        public int PatientId { get; set; } // nav prop

       


    }
}
