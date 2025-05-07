using System.ComponentModel.DataAnnotations;

namespace event_ease
{
    public class Attendance
    {
        [Required(ErrorMessage = "Event ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Event ID must be a positive number.")]
        public int EventId { get; set; }

        [Required(ErrorMessage = "User name is required.")]
        [StringLength(100, ErrorMessage = "User name cannot exceed 100 characters.")]
        public string UserName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;
    }
}