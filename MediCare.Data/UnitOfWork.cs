using MediCare.Core.Entities;
using MediCare.Core.Interfaces;
using MediCare.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Appointment, int> Appointments { get; }
        public IGenericRepository<AppointmentLog, int> AppointmentLogs { get; }
        public IGenericRepository<Doctor, int> Doctors { get; }
        public IGenericRepository<MedicalRecord, int> MedicalRecords { get; }
        public IGenericRepository<Patient, int> Patients { get; }
        public IGenericRepository<Prescription, int> Prescriptions { get; }
        public IGenericRepository<Specialization, int> Specializations { get; }
        public IGenericRepository<TimeSlot, int> TimeSlots { get; }

        private AppDbContext _context { get;}

        public UnitOfWork(AppDbContext context)
        {
            Appointments = new GenericRepository<Appointment, int>(context);
            AppointmentLogs = new GenericRepository<AppointmentLog, int>(context);
            Doctors = new GenericRepository<Doctor, int>(context);  
            MedicalRecords = new GenericRepository<MedicalRecord, int>(context);
            Patients = new GenericRepository<Patient, int>(context);
            Prescriptions = new GenericRepository<Prescription, int>(context);
            Specializations = new GenericRepository<Specialization, int>(context);
            TimeSlots = new GenericRepository<TimeSlot, int>(context);
            
            _context = context;
        }
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
