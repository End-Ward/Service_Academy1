﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Service_Academy1.Models
{
    public class ProgramManagementModel
    {
        [Key]
        public int ProgramManagementId { get; set; }

        [ForeignKey("ProgramsModel")]
        public int ProgramId { get; set; } // Foreign key for ProgramsModel

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsArchived { get; set; } = false;

        public virtual ProgramsModel? ProgramsModel { get; set; } // Navigation property
    }
}
