using Clinic.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Application.DTOs.PatientDTOs
{
    public class PatientDTO : BaseDTO
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(14)]
        public string NationalNumber { get; set; }

        public string? UserId { get; set; }

        [Required]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(150)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public BloodType BloodType { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
