namespace CinemaApp.Models.Domain
{
    public class Session
    {
        public Guid Id { get; set; }
        public Guid TheaterID { get; set; }
        public Guid MovieID { get; set; }
        public TimeOnly SessionTime {  get; set; }
    }
}
