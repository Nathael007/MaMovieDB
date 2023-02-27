using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaMovieDB.Models.EntityFramework
{
    public partial class Film
    {
        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }
        [Column("flm_titre")]
        [StringLength(100)]
        public string? Titre { get; set; }
        [Column("flm_resume")]
        public string? Resume { get; set; }
        [Column("flm_datesortie")]
        public DateTime DateSortie { get; set; }
        [Column("flm_duree")]
        public decimal Duree { get; set; }
        [Column("flm_genre")]
        public string? Genre { get; set; }
    }
}