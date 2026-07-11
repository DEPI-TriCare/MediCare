using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.MedicalRecordDTOs
{
    public class TestDTO : BaseDTO
    {
        public string? File { get; set; }

        [MaxLength(1000)]
        public string? Description { get; set; }

        [Required]
        public Guid MedicalRecordId { get; set; }
    }
}
