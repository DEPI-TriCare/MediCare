
using Domains;

namespace MediCare.Core.Entities
{
    public class Prescription : BaseTable
    {
        public Guid MedicalRecordId { get; set; }
        public MedicalRecord? MedicalRecord { get; set; }
        public string MedicationName { get; set; } = string.Empty;
        public string Dosage { get; set; } = string.Empty;
        public string Frequency { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
    }
}
