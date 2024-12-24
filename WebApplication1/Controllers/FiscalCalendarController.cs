using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FiscalCalendarController : ControllerBase
    {
        private static readonly List<FiscalCalendar> FiscalCalendars = new List<FiscalCalendar>
        {
            new FiscalCalendar { Id = 1, Company = "CompanyA", StartDate = new DateTime(2023, 01, 01), EndDate = new DateTime(2023, 12, 31), Description = "Fiscal Year 2023" },
            new FiscalCalendar { Id = 2, Company = "CompanyB", StartDate = new DateTime(2024, 01, 01), EndDate = new DateTime(2024, 12, 31), Description = "Fiscal Year 2024" },
            new FiscalCalendar { Id = 3, Company = "CompanyA", StartDate = new DateTime(2024, 01, 01), EndDate = new DateTime(2024, 12, 31), Description = "Fiscal Year 2024" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<FiscalCalendar>> GetFiscalCalendars()
        {
            return Ok(FiscalCalendars);
        }

        [HttpGet("{company}")]
        public ActionResult<IEnumerable<FiscalCalendar>> GetFiscalCalendarsByCompany(string company)
        {
            var result = FiscalCalendars.Where(fc => fc.Company == company).ToList();
            return Ok(result);
        }

        [HttpGet("{company}/{startDate}/{endDate}")]
        public ActionResult<IEnumerable<FiscalCalendar>> GetFiscalCalendarByCompanyAndDateRange(string company, DateTime startDate, DateTime endDate)
        {
            var result = FiscalCalendars.Where(fc => fc.Company == company && fc.StartDate >= startDate && fc.EndDate <= endDate).ToList();
            return Ok(result);
        }
    }
}
