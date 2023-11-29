using Domain_Layer.Data;
using Domain_Layer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service_Layer.IService;
using System.Globalization;

namespace AttendenceReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendenceController : ControllerBase
    {

        private readonly IAttService<Attendences> _AttendenceServices;

        private readonly AppDBContext _appDbContext;
        private readonly Attendences Attendence;
        public AttendenceController(IAttService<Attendences> AttendenceServices, AppDBContext appDbContext)
        {
            _AttendenceServices = AttendenceServices;
            _appDbContext = appDbContext;
        }
        [HttpGet(nameof(GetAttendenceById))]
        public IActionResult GetAttendenceById(int EmpId)
        {
            var obj = _AttendenceServices.Get(EmpId);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        private object GetAttendenceById()
        {
            throw new NotImplementedException();
        }

        [HttpGet("ByMonth")]
        public IActionResult GetAttendanceReportByMonth(string month)
        {
            try
            {
                // Parse the month name to a DateTime object
                DateTime parsedDate = DateTime.ParseExact(month, "MMMM", CultureInfo.CurrentCulture);

                var attendancesForMonth = _appDbContext.Attendence
                    .Where(a => a.Date != null && a.Date.Value.Month == parsedDate.Month)
                    .ToList();

                return Ok(attendancesForMonth);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid month format. Please provide a valid month name.");
            }
        }
        [HttpGet("all-months")]
        public async Task<IActionResult> GetAllMonthsAsync()
        {
            try
            {
                var allMonths = await _AttendenceServices.GetAllMonthsAsync();

                return Ok(allMonths);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your needs
                return BadRequest("Error retrieving months. Please try again later.");
            }
        }
        [HttpGet("ByEmployeeName")]
        public IActionResult GetAttendanceReportByEmployeeName(string employeeName)
        {
            try
            {
                var attendancesForEmployee = _AttendenceServices.GetAttendanceByEmployeeName(employeeName);

                return Ok(attendancesForEmployee);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your needs
                return BadRequest("Error retrieving attendance records. Please try again later.");
            }
        }
        [HttpGet("all-Employeenames")]
        public async Task<IActionResult> GetAllEmployeeNames()
        {
            try
            {
                var allEmployeeNames = await _AttendenceServices.GetAllEmployeeNames();

                return Ok(allEmployeeNames);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it according to your needs
                return BadRequest("Error retrieving employee names. Please try again later.");
            }
        }


        [HttpGet(nameof(GetAllAttendence))]
        public IActionResult GetAllAttendence()
        {
            var obj = _AttendenceServices.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateAttendence))]
        public IActionResult CreateAttendence(Attendences Attendence)
        {
            if (Attendence != null)
            {
                _AttendenceServices.Insert(Attendence);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        
        }
        [HttpPut(nameof(UpdateAttendence))]
        public IActionResult UpdateAttendence(Attendences Attendence)
        {
            if (Attendence != null)
            {
                _AttendenceServices.Update(Attendence);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteAttendence))]
        public IActionResult DeleteAttendence(Attendences Attendence)
        {
            if (Attendence != null)
            {
                _AttendenceServices.Delete(Attendence);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
