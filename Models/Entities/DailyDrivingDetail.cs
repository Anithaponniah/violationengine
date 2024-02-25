using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckDrivingDetails.Models.Entities
{
    public class DailyDrivingDetail
    {
        [Key]
        public int Id { get; set; } 
        public int DriverId { get; set; }
        public string? DriverName { get; set; }
        public double DrivingTime { get; set; }
        public double BreakingTime { get; set; }
        public string? BreakState
        {
            get; set;
        }
        
    }
}
