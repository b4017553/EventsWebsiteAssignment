using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsWebsite.Models
{
    public class Movie
    {
        [Key]
        public int MovieID { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string MovieTitle { get; set; }

        [Required]
        [Column(TypeName = "varchar(5)")]
        public string MovieCertificate { get; set; }

        [Column(TypeName = "text")]
        public string MovieDescription { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string MovieImage { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal MoviePrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal IMDbRating { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "int")]
        public int RunTime { get; set; }

        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [DataType(DataType.Date)]
        public DateTime Modified { get; set; }

        [Column(TypeName = "int")]
        public int Year { get; set; }

        [Column(TypeName = "text")]
        public string Genres { get; set; }

        [Column(TypeName = "int")]
        public int NumVotesIMDb { get; set; }

        [Column(TypeName = "text")]
        public string Directors { get; set; }

        [Column(TypeName = "text")]
        public string URL { get; set; }

    }
}
