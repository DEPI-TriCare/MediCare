using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Core.Enums
{
    public class NotificationResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime SentAt { get; set; }
    }

}
