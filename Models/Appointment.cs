using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Appointment
    {
        public string? AppointmentId { get; set; }

        [Required(ErrorMessage = "Patient is required")]
        public string PatientId { get; set; } = string.Empty;

        public string? PatientName { get; set; }

        [Required(ErrorMessage = "Doctor is required")]
        public string DoctorId { get; set; } = string.Empty;

        public string? DoctorName { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required(ErrorMessage = "Appointment time is required")]
        public string AppointmentTime { get; set; } = string.Empty;

        [Required(ErrorMessage = "Reason is required")]
        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = "Scheduled"; // Scheduled, Completed, Cancelled

        public string? Notes { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}