﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }
        public int DoctorId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(80)]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

    }
}
