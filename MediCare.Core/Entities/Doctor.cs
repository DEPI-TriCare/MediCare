using Domains;
using System.ComponentModel;

namespace MediCare.Core.Entities
{
    public class Doctor : BaseTable
    {
        public string UserId { get; set; } = string.Empty;
        public Guid SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
        public decimal ConsultationFee { get; set; }
        public string ProfilePictureUrl { get; set; }
        public ICollection<TimeSlot> TimeSlots { get; set; } = new List<TimeSlot>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();


    }
}
