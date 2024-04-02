namespace CinemaApp.Models
{
    public class IndexMovieViewModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required Guid TheaterID { get; set; }
        public DateTime PremiereDate { get; set; }
        public DateTime FinalDate { get; set; }
        public string TheaterName { get; set; }
    }
}
