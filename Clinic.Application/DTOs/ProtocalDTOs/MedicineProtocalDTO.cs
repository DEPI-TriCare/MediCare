using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.ProtocalDTOs
{
    public class MedicineProtocalDTO : BaseDTO
    {
        [Required]
        [MaxLength(300)]
        public string MedicineName { get; set; }

        [Required]
        [MaxLength(30)]
        public string Dosage { get; set; }

        [Required]
        [MaxLength(30)]
        public string Frequency { get; set; }

        [Required]
        [MaxLength(30)]
        public string Duration { get; set; }

        [MaxLength(500)]
        public string? Instructions { get; set; }

        [Required]
        public Guid ProtocalId { get; set; }
    }
}
