using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.MedicalRecordDTOs
{
    public class MedicalRecordDTO : BaseDTO
    {
        [MaxLength(1000)]
        public string? Allergy { get; set; }

        [MaxLength(1000)]
        public string? Notes { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Diagnosis { get; set; }

        [MaxLength(1000)]
        public string? ChronicDisease { get; set; }

        [MaxLength(1000)]
        public string? CurrentMedications { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        [Required]
        public Guid DoctorId { get; set; }
    }
}
