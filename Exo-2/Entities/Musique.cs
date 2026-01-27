using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exo_2.Entities
{
    [Table("Musique")]
    public class Musique
    {
        [Column("MusicId")]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Titre { get; set; }
        [MaxLength(50)]
        public string Interpretre { get; set; }
        public DateOnly DateDeSortie { get; set; }
        [MaxLength(50)]
        public string GenreMusic { get; set; }
        public TimeSpan TempDeMusic { get; set; }
        public int Note { get; set; }

    }
}
