using MediCare.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.Interfaces
{
    public interface IDoctorService
    {
        public Task<IEnumerable<DoctorDto>> GetAllAsync();

        public Task<DoctorDto> GetByIdAsync(int id);

        public Task<DoctorDto> CreateAsync(CreateDoctorDto dto);

        public Task<DoctorDto> UpdateAsync(int id, UpdateDoctorDto dto);

        public Task DeleteByIdAsync(int id);

        public Task<IEnumerable<AppointmentDto>> GetAppointmentsAsync(int doctorId);

        public Task<IEnumerable<TimeSlotDto>> GetTimeSlotsAsync(int doctorId);

    }
}
