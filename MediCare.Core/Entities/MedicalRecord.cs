using Domains;

namespace MediCare.Core.Entities
{
    public class MedicalRecord : BaseTable
    {
        public Guid PatientId { get; set; }
        public Patient? Patient { get; set; }
        public DateTime DateCreated { get; set; }
        public string? AttachedFileUrl { get; set;}
        public string Diagnosis { get; set; } = string.Empty;
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();

    }
}
