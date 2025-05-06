using System.ComponentModel.DataAnnotations;

namespace event_ease
{
    public class Event
    {
        [Required(ErrorMessage = "Event Name is required.")]
        [StringLength(100, ErrorMessage = "Event Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Event Date is required.")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "01/01/2025", "12/31/2025", ErrorMessage = "Event Date must be within the current year.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Event Location is required.")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email Address is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;
        
        public bool IsCompleted { get; set; } = false; 
    }
}