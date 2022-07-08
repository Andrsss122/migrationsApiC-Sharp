using System.ComponentModel.DataAnnotations;

namespace AlbumApi.Data
{
    public class Album
    {
        [Key]
        public int IdAlbum { get; set; }
        [StringLength(150)]
        [Required (ErrorMessage = "Escibi algo men")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Escibi algo men")]
        public Artista artista { get; set; }
        [Required(ErrorMessage = "Escibi algo men")]
        public Genero genero { get; set; }


    }
}
