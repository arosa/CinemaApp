namespace CinemaApp.Models.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TheaterID { get; set; }
        public DateTime PremiereDate { get; set; }
        public DateTime FinalDate { get; set; }

    }
}
