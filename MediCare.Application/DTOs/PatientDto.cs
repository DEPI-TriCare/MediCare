using MediCare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.DTOs
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }
        public string Allergies { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }

    public class CreatePatientDto
    {
        public string UserId { get; set; } = string.Empty;
        public string Allergies { get; set; }
    }

    public class UpdatePatientDto
    {
        public string Allergies { get; set; }
    }
}
