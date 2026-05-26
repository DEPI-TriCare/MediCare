using Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> entity)
        {
            entity.HasKey(a => a.Id);
            entity.Property(a => a.CurrentState).HasDefaultValue(1);

            // --------------------------------------------------------------- //

            entity.HasOne(a => a.Prescription).WithOne(a => a.Appointment).HasForeignKey<Prescription>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.TimeSlot).WithMany(a => a.Appointments).HasForeignKey(a => a.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.RecordDiagnosis).WithOne(a => a.Appointment).HasForeignKey<RecordDiagnosis>(a => a.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(a => a.Doctor).WithMany(a => a.Appointments).HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasOne(a => a.Patient).WithMany(a => a.Appointments).HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}