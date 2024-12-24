using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
using WebApplication1.Models;

namespace FiscalCalendarApi.Tests
{
    [TestFixture]
    public class FiscalCalendarControllerTests
    {
        private FiscalCalendarController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller
            _controller = new FiscalCalendarController();
        }

        [Test]
        public void GetFiscalCalendars_ReturnsAllCalendars()
        {
            // Act
            var result = _controller.GetFiscalCalendars();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var calendars = okResult.Value as List<FiscalCalendar>;
            Assert.AreEqual(3, calendars.Count); // Assuming there are 3 hardcoded calendars
        }

        [Test]
        public void GetFiscalCalendarsByCompany_ValidCompany_ReturnsCalendars()
        {
            // Act
            var result = _controller.GetFiscalCalendarsByCompany("CompanyA");

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var calendars = okResult.Value as List<FiscalCalendar>;
            Assert.AreEqual(2, calendars.Count); // Assuming CompanyA has 2 calendars
        }

        [Test]
        public void GetFiscalCalendarByCompanyAndDateRange_ValidCompanyAndDateRange_ReturnsCalendars()
        {
            // Act
            var result = _controller.GetFiscalCalendarByCompanyAndDateRange("CompanyA", new DateTime(2023, 01, 01), new DateTime(2023, 12, 31));

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var calendars = okResult.Value as List<FiscalCalendar>;
            Assert.AreEqual(1, calendars.Count); // Assuming CompanyA has 1 calendar in this date range
        }

        [Test]
        public void GetFiscalCalendarsByCompany_InvalidCompany_ReturnsEmpty()
        {
            // Act
            var result = _controller.GetFiscalCalendarsByCompany("InvalidCompany");

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result.Result);
            var okResult = result.Result as OkObjectResult;
            var calendars = okResult.Value as List<FiscalCalendar>;
            Assert.IsEmpty(calendars); // Should return an empty list
        }
    }
}
