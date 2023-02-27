using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MaMovieDB.Models.EntityFramework
{
    public partial class Utilisateur
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }
        [Column("utl_nom")]
        [StringLength(50)]
        public string? Nom { get; set; }
        [Column("utl_prenom")]
        [StringLength(50)]
        public string? Prenom { get; set; }
        [Column("utl_mobile", TypeName = "char(10)")]
        public string? Mobile { get; set; }
        [Column("utl_mail")]
        [StringLength(100)]
        public string? Mail { get; set; }
        [Column("utl_pwd")]
        [StringLength(64)]
        public string? Pwd { get; set; }
        [Column("utl_rue")]
        [StringLength(200)]
        public string? Rue { get; set; }
    }
}
