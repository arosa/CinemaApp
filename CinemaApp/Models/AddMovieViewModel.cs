using CinemaApp.Models.Domain;

namespace CinemaApp.Models
{
    public class AddMovieViewModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Theater Theater { get; set; }
        public DateTime PremiereDate { get; set; }
        public DateTime FinalDate { get; set; }
    }


}