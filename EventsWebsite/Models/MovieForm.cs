using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsWebsite.Models
{
    public class MovieForm
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
       
        public string MovieTitle { get; set; }

        [Required]
        
        public string MovieCertificate { get; set; }

        [Required]
        
        public string MovieDescription { get; set; }

        
        
        public string MovieImage { get; set; }

       
        public decimal MoviePrice { get; set; }

        
        public decimal IMDbRating { get; set; }

        
        public DateTime ReleaseDate { get; set; }

        
        public int RunTime { get; set; }

        [Required]
        
        public DateTime Created { get; set; }

        [Required]
        
        public DateTime Modified { get; set; }

        
        public int Year { get; set; }

        [Required]
        
        public string Genres { get; set; }

       
        public int NumVotesIMDb { get; set; }

        
        public string Directors { get; set; }

       
        public string URL { get; set; }

    }
}
