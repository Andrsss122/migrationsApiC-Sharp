using System.ComponentModel.DataAnnotations;

namespace AlbumApi.Data
{
    public class Artista
    {
        [Key]
        public int IdArtista { get; set; }

        public string Nombre { get; set; }
    }
}
