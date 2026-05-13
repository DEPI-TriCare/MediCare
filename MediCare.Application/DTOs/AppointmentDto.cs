using MediCare.Core.Entities;
using MediCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.DTOs
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int TimeSlotId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public class CreateAppointmentDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int TimeSlotId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public class UpdateAppointmentDto
    {
        public int TimeSlotId { get; set; }
        public DateOnly AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
