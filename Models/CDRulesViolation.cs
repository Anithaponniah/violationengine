using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckDrivingDetails.Models
{
    public class CDRulesViolation
    {
        [Key]
        public int Id { get; set; } 
        public int DriverId { get; set; }
        
        public string? ViolationType { get; set; }
        public DateTime Timestamp { get; set; }
        public string? AdditionalInfo { get; set; }

        public string? BreakState { get; set; }
        
        [ForeignKey("DriverId")]
        public DailyDrivingViewModel? Driver { get; set; }

    }
}
