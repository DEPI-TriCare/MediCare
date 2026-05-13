using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs
{
    public class RefreshTokenDTO : BaseDTO
    {
        public string Token { get; set; }
        public string UserId { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
