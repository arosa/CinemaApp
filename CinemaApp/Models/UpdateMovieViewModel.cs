﻿using CinemaApp.Models.Domain;

namespace CinemaApp.Models
{
    public class UpdateMovieViewModel
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid TheaterID { get; set; }
        public DateTime PremiereDate { get; set; }
        public DateTime FinalDate { get; set; }

        public string TheaterName { get; set; }

    }
}
