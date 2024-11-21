using System.ComponentModel.DataAnnotations;

namespace Bibliotec.Models
{
    public class Curso
    {
        [Key]
       public int CursoID {get; set;}

       public string? Nome {get; set;}

       public char Periodo {get; set;}

     
    }
}