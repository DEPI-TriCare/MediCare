using MediCare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.Interfaces
{
    public interface IPatientService
    {
        public Task<IEnumerable<PatientDto>> GetAllAsync();

        public Task<PatientDto> GetByIdAsync(int id);

        public Task<PatientDto> CreateAsync(CreatePatientDto dto);

        public Task<PatientDto> UpdateAsync(int id, UpdatePatientDto dto);

        public Task DeleteByIdAsync(int id);

        public Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int patientId);

        public Task<IEnumerable<MedicalRecordDto>> GetMedicalrecordsAsync(int patientId);

        // only prescriptions where they still need to take
        public Task<IEnumerable<PrescriptionDto>> GetActivePrescription(int patientId);
    }
}
