namespace WebApplication1.Models
{
    public class FiscalCalendar
    {
        public int Id { get; set; }
        public string Company { get; set; } // New property to identify the company
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }
}
