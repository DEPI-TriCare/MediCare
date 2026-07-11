using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.MedicalRecordDTOs
{
    public class MedicalRecordPagination
    {
        [Range(1, int.MaxValue, ErrorMessage = "Page number must be at least 1.")]
        public int TestPageNumber { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int TestPageSize { get; set; } = 5;

        [Range(1, int.MaxValue, ErrorMessage = "Page number must be at least 1.")]
        public int MedicalRadilogyPageNumber { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int MedicalRadilogyPageSize { get; set; } = 5;

        [Range(1, int.MaxValue, ErrorMessage = "Page number must be at least 1.")]
        public int AppointmentPageNumber { get; set; } = 1;

        [Range(1, 100, ErrorMessage = "Page size must be between 1 and 100.")]
        public int AppointmentPageSize { get; set; } = 5;
    }
}
