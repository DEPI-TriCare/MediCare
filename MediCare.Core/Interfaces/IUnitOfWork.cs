using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediCare.Core.Entities;

namespace MediCare.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IGenericRepository<Appointment, int> Appointments { get; }
        public IGenericRepository<AppointmentLog, int> AppointmentLogs { get; }
        public IGenericRepository<Doctor, int> Doctors { get; }
        public IGenericRepository<MedicalRecord, int> MedicalRecords { get; }
        public IGenericRepository<Patient, int> Patients { get; }
        public IGenericRepository<Prescription, int> Prescriptions { get; }
        public IGenericRepository<Specialization, int> Specializations { get; }
        public IGenericRepository<TimeSlot, int> TimeSlots { get; }
    
       public Task SaveChanges();
    }
}
