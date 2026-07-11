using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.PrescriptionDTOs
{
    public class PrescriptionDTO : BaseDTO
    {
        public PrescriptionDTO()
        {
            Medicines = new List<PrescriptionMedicineDTO>();
        }

        [Required]
        public DateTime PrescriptionDate { get; set; }

        [Required]
        public Guid AppointmentId { get; set; }

        public virtual List<PrescriptionMedicineDTO> Medicines { get; set; }
    }
}
