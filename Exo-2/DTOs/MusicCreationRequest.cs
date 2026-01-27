using System.ComponentModel.DataAnnotations;

namespace Exo_2.DTOs
{
    public class MusicCreationRequest
    {
        public string Titre { get; set; }

        public string Interpretre { get; set; }
        public string DateDeSortie { get; set; }
        public string GenreMusic { get; set; }
        public string TempDeMusic { get; set; }
        public string Note { get; set; }
    }
}
