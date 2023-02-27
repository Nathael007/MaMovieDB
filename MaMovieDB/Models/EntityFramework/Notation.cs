using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaMovieDB.Models.EntityFramework
{
    public partial class Notation
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }
        [Key]
        [Column("flm_id")]
        public string? FilmId { get; set; }
        [Column("not_note")]
        [StringLength(50)]
        public int Note { get; set; }

        [ForeignKey("UtilisateurId")]

        [InverseProperty("Notation")]
        public virtual Utilisateur UtilisateurFilmNavigation { get; set; } = null!;

        [ForeignKey("FilmId")]
        [InverseProperty("Notation")]
        public virtual Film NotesFilmNavigation { get; set; } = null!;


    }
}
