﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Visitation
    {
        public int VisitationId { get; set; }

        [Required]
        public DateTime Date { get; set; }

       
        [MaxLength(250)]
        public string Comments { get; set; }

        public Patient Patient { get; set; }

        // [ForeignKey(nameof(Patient))] // ??
        public int PatientId { get; set; } // nav prop

        // [ForeignKey(nameof(Doctor))] // ??
        public int DoctorId { get; set; } // nav prop
        public Doctor Doctor { get; set; }


    }
}
