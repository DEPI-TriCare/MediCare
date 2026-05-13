using Domains;
using MediCare.Core.Enums;

namespace MediCare.Core.Entities
{
    public class AppointmentLog : BaseTable
    {
        public Guid AppointmentId { get; set; }
        public required Appointment Appointment { get; set; }
        public string Reason { get; set; } = string.Empty;
        public AppointmentChangeType ChangeType { get; set; }
    }
}
