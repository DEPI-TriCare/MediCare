using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.ProtocalDTOs
{
    public class PrescriptionProtocalDTO : BaseDTO
    {
        public PrescriptionProtocalDTO()
        {
            MedicineProtocal = new List<MedicineProtocalDTO>();
        }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [Required]
        [MaxLength(200)]
        public string Disease { get; set; }

        [MaxLength(50)]
        public string? Code { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public Guid DoctorId { get; set; }

        public virtual List<MedicineProtocalDTO> MedicineProtocal { get; set; }
    }
}
