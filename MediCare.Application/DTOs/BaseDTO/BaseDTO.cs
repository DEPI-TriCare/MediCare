using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public int CurrentState { get; set; }
    }
}
