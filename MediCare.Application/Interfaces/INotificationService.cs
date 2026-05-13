using MediCare.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediCare.Application.Interfaces
{
    public interface INotificationService
    {
        // --- Appointment notifications ---

        /// <summary>
        /// Sends a reminder to the patient before their upcoming appointment.
        /// </summary>
        Task<NotificationResult> SendAppointmentReminderAsync(int appointmentId);

        /// <summary>
        /// Notifies the patient that their appointment has been confirmed.
        /// </summary>
        Task<NotificationResult> SendAppointmentConfirmationAsync(int appointmentId);

        /// <summary>
        /// Notifies the patient that their appointment has been cancelled, with an optional reason.
        /// </summary>
        Task<NotificationResult> SendAppointmentCancellationAsync(int appointmentId, string? reason);

        /// <summary>
        /// Notifies the patient that their appointment has been rescheduled to a new time.
        /// </summary>
        Task<NotificationResult> SendAppointmentRescheduledAsync(int appointmentId, DateTime newDateTime);

        // --- Staff / internal notifications ---

        /// <summary>
        /// Notifies a doctor that a new appointment has been assigned to them.
        /// </summary>
        Task<NotificationResult> NotifyDoctorOfNewAppointmentAsync(int doctorId, int appointmentId);

        /// <summary>
        /// Broadcasts a message to all staff members (e.g. schedule change, emergency alert).
        /// </summary>
        Task<IEnumerable<NotificationResult>> BroadcastToStaffAsync(string subject, string message);

        // --- General / custom ---

        /// <summary>
        /// Sends a custom ad-hoc notification to any user by their ID.
        /// </summary>
        Task<NotificationResult> SendCustomNotificationAsync(string userId, string subject, string message);

    }

}
