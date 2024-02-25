using System.ComponentModel.DataAnnotations;

namespace CheckDrivingDetails.Models
{
    public class DailyDrivingViewModel
    {
        [Key]
        public int Id { get; set; }
        public string? DriverName { get; set; }
        public double DrivingTime { get; set; }
        public double TimeBreak { set; get; }
        public string? BreakState { get; set; }
    }
}
