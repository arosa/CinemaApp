namespace CinemaApp.Models
{
    public class UpdateTheaterViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public double TicketPrice { get; set; }
        public TimeOnly OpenHoursFrom { get; set; }
        public TimeOnly OpenHoursTo { get; set; }
    }
}
