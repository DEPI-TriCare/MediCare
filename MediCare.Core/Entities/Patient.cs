
using Domains;

namespace MediCare.Core.Entities
{
    public class Patient : BaseTable
    {
        public string UserId { get; set; } = string.Empty;
        public string Allergies { get; set; } = string.Empty;
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
