using Domains;
using MediCare.Core.Enums;

namespace MediCare.Core.Entities
{
    public class Appointment : BaseTable
    {
        public Guid DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public Guid PatientId { get; set; }
        public Patient? Patient { get; set; }
        public Guid TimeSlotId { get; set; }
        public TimeSlot? TimeSlot { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    
}
