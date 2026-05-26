using MediCare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.DTOs
{
    public class MedicalRecordDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public DateTime DateCreated { get; set; }
        public string AttachedFileUrl { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public ICollection<PrescriptionDto> Prescriptions { get; set; } = new List<PrescriptionDto>();
    }

    public class CreateMedicalRecordDto
    {
        public int PatientId { get; set; }
        public DateTime DateCreated { get; set; }
        public string AttachedFileUrl { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public ICollection<CreatePrescriptionDto> Prescriptions { get; set; } = new List<CreatePrescriptionDto>();
    }

    public class UpdateMedicalRecordDto
    {
        public string AttachedFileUrl { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public ICollection<UpdatePrescriptionDto> Prescriptions { get; set; } = new List<UpdatePrescriptionDto>();
    }
}
