using Clinic.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.ScheduleDTOs
{
    public class ScheduleDTO : BaseDTO
    {
        public ScheduleDTO()
        {
            DoctorSchedules = new List<DoctorScheduleDTO>();
        }

        [Required]
        public Day Day { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }

        [Required]
        public TimeSpan EndTime { get; set; }

        public List<DoctorScheduleDTO> DoctorSchedules { get; set; }
    }
}
