using MediCare.Core.Enums;

namespace MediCare.Core.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int TimeSlotId { get; set; }
        public TimeSlot TimeSlot { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    
}
