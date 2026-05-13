using MediCare.Core.Entities;
using MediCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.DTOs
{
    public class TimeSlotDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public AvailabilityStatus Status { get; set; }
    }

    public class CreateTimeSlotDto
    {
        public int DoctorId { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public AvailabilityStatus Status { get; set; } = AvailabilityStatus.Available;
    }

    public class UpdateTimeSlotDto
    {
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public AvailabilityStatus Status { get; set; }
    }
}
