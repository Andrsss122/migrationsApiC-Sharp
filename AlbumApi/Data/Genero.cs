using System.ComponentModel.DataAnnotations;

namespace AlbumApi.Data
{
    public class Genero
    {
        [Key]
       public int IdGenero { get; set; }
       public string Nombre { get; set; }



    }
}
