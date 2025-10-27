using System.ComponentModel.DataAnnotations;

namespace HospitalManagement.Models
{
    public class Doctor
    {
        public string? DoctorId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Specialization is required")]
        public string Specialization { get; set; } = string.Empty;

        [Required(ErrorMessage = "Experience is required")]
        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years")]
        public int Experience { get; set; }

        [Required(ErrorMessage = "Qualification is required")]
        public string Qualification { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public string Contact { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Consultation fee is required")]
        [Range(0, 100000, ErrorMessage = "Fee must be a valid amount")]
        public decimal ConsultationFee { get; set; }

        public string? AvailableDays { get; set; }

        public string? ConsultationTime { get; set; }

        public DateTime JoinedDate { get; set; } = DateTime.Now;
    }
}