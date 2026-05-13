namespace MediCare.Core.Enums
{
    public class NotificationResult
    {
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime SentAt { get; set; }
    }

}
