using Clinic.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.ScheduleDTOs
{
    public class DoctorScheduleDTO : BaseDTO
    {
        [Required]
        public Guid DoctorId { get; set; }

        [Required]
        public Guid ScheduleId { get; set; }
    }
}
