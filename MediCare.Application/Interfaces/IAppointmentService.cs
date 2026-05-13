using MediCare.Application.DTOs;
using MediCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.Interfaces
{
    public interface IAppointmentService
    {
        public Task<IEnumerable<AppointmentDto>> GetAllAsync();

        public Task<AppointmentDto> GetByIdAsync(int id);

        public Task<AppointmentDto> CreateAsync(CreateAppointmentDto dto);

        public Task<AppointmentDto> ChangeStatusAsync(int id, AppointmentStatus newStatus);

        public Task<AppointmentDto> ChangeTimeSlotAsync(int id, int newTimeSlotId);

        public Task<AppointmentDto> ChangeDateAsync(int id, DateTime newDate);

    }
}
