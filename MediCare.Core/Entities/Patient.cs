
namespace MediCare.Core.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Allergies { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
