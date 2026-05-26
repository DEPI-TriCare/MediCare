using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.DTOs
{
    public class SpecializationDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
    }

    public class CreateSpecializationDto
    {
        public required string Name { get; set; }
    }

    public class UpdateSpecializationDto
    {
        public required string Name { get; set; }
    }
}
