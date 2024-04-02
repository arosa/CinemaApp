using CinemaApp.Models.Domain;

namespace CinemaApp.Models
{
    public class AddMovieViewModel
    {

        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required Guid TheaterID { get; set; }
        public DateTime PremiereDate { get; set; }
        public DateTime FinalDate { get; set; }
    }


}