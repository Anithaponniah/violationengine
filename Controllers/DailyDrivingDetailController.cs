using Microsoft.AspNetCore.Mvc;
using CheckDrivingDetails.Models;
using CheckDrivingDetails.Data;
using CheckDrivingDetails.Models.Entities;

using System.Xml;
using Microsoft.IdentityModel.Tokens;

namespace CheckDrivingDetails.Controllers
{
    public enum BreakState
    {
        NotStarted,
        FirstPartTaken,
        Completed
    }
    public class DailyDrivingDetailController : Controller
    {
        public  CDRViolationContext objdbContext;

        //public CDRulesViolation CDRulesViolations { get; private set; }

        public DailyDrivingDetailController(CDRViolationContext dbContext)
        {
            objdbContext = dbContext;

        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public  IActionResult Add(DailyDrivingViewModel viewModel)
        {

            var DailyDrivingDetail = new DailyDrivingDetail();
            {
                DailyDrivingDetail.DriverId = viewModel.Id;
                DailyDrivingDetail.DriverName = viewModel.DriverName;
                DailyDrivingDetail.DrivingTime = viewModel.DrivingTime;
                DailyDrivingDetail.BreakingTime = viewModel.TimeBreak;
                DailyDrivingDetail.BreakState = viewModel.BreakState;
                 objdbContext.DailyDrivingDetails.Add(DailyDrivingDetail);
                //await objdbContext.SaveChangesAsync();
                //objdbContext.SaveChanges();

            };
            if (viewModel.DriverName != null && viewModel.BreakState != null)
            {
                DailyDrivingDetail.DriverId = viewModel.Id;
                string str = CheckDrivingRules(viewModel.DrivingTime, viewModel.TimeBreak);
                ViewBag.result = str;
                Drive(viewModel.DrivingTime, viewModel.TimeBreak, viewModel.BreakState,viewModel.Id);
                
            }

            //await dbContext.CDRulesViolations.AddAsync(CDRulesViolation);
            //await dbContext.SaveChangesAsync();
             
            return View();
        }


        private void Drive(double drivingTime, double breakTime, string breakState,int Id)
        {
            string str = CheckDrivingRules(drivingTime, breakTime);
            if (!string.IsNullOrEmpty(str))
            {
                //DailyDrivingViewModel viewModel = new DailyDrivingViewModel();
                CDRulesViolation crdModel = new CDRulesViolation();
                crdModel.DriverId = Id;
                crdModel.ViolationType = str;
                crdModel.Timestamp = DateTime.Now;

                objdbContext.CDRulesViolations.Add(crdModel);
                objdbContext.SaveChanges();

                //var x=   objdbContext.CDRulesViolations.ToList().Where(g => g.Id == Id);
                Console.WriteLine("Violation detected!");
                return;
            }
            else {
                switch (breakState)
                {
                    case "NotStarted":
                        if (drivingTime == 4.5)
                        {
                            Console.WriteLine("Taking a 45-minute break.");
                            Drive(drivingTime + 0.5, breakTime + 0.75, "Completed", Id);
                        }
                        else
                        {
                            Drive(drivingTime + 0.5, breakTime, "NotStarted", Id);
                        }
                        break;
                    case "FirstPartTaken":
                        Console.WriteLine("Taking the second part of the break (30 minutes).");
                        if (drivingTime == 4.5)
                        {
                            Drive(drivingTime + 0.5, breakTime + 0.5, "Completed", Id);
                        }
                        else
                        {
                            Drive(drivingTime + 0.5, breakTime, "FirstPartTaken", Id);
                        }

                        break;
                    case "Completed":
                        if (drivingTime >= 4.5)
                        {
                            Console.WriteLine("Taking a 45-minute break.");
                            Drive(drivingTime + 0.5, breakTime, "Completed", Id);
                        }
                        else
                        {
                            Drive(drivingTime + 0.5, breakTime, "NotStarted", Id);
                        }
                        break;
                }
            }
            
        }

        private string CheckDrivingRules(double drivingTime, double breakTime)
        {
            //double drivingTime = viewModel.DrivingTime;
            //    double breakTime=viewModel.BreakingTime;
            string result = string.Empty;
            Console.WriteLine("inside checkdriving" + drivingTime);
            // Rule: Daily driving time cannot exceed nine hours, extended to ten hours up to twice a week
            if (drivingTime > 10)

                result = "Violation detected as the daily driving time cannot exceed nine hours, extended to ten hours up to twice a week";
            //else if (drivingTime > 9 )
                //result = "Violation detected!";

            
            // Rule: After 4.5 hours of driving, a 45-minute break is required
            else if (drivingTime > 4.5 && breakTime == 0)
                result = "Violation detected as after 4.5 hours of driving, a 45-minute break is required ";

            // Rule: Break time cannot exceed 45 minutes
            if (breakTime > 0.75)
                result = "Break time cannot exceed 45 minutes so violation detected!";

            return result;
        }



    }
}
