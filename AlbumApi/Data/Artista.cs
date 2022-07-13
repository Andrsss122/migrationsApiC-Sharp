using System.ComponentModel.DataAnnotations;

namespace AlbumApi.Data
{
    public class Artista
    {
        [Key]
        public int IdArtista { get; set; }

        [Required(ErrorMessage = "Escibi algo men")]
        public string Nombre { get; set; }

    }
}
