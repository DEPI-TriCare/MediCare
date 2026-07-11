using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Application.DTOs.UserDTOs
{
    public class RoleDTO : BaseDTO
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}
