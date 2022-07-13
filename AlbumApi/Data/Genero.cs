using System.ComponentModel.DataAnnotations;

namespace AlbumApi.Data
{
    public class Genero
    {
        [Key]
       public int IdGenero { get; set; }

        [Required(ErrorMessage = "Escibi algo men")]
        public string Nombre { get; set; }




    }
}
