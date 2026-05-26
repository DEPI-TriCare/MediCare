using MediCare.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.DTOs
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public required SpecializationDto Specialization { get; set; }
        public decimal ConsultationFee { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }

    public class CreateDoctorDto
    {
        public string UserId { get; set; } = string.Empty;
        public int SpecializationId { get; set; }
        public decimal ConsultationFee { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }

    public class UpdateDoctorDto
    {
        public int SpecializationId { get; set; }
        public decimal ConsultationFee { get; set; }
        public string? ProfilePictureUrl { get; set; }
    }
}
