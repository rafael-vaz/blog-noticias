using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Comentario
    {
         public int Id { get; set; }

         [StringLength(100)]
          public string Autor { get; set; }

          [Column(TypeName = "TEXT")]
          public string Conteudo { get; set; }
          public DateTime Data {get; set;}
          public int PostId { get; set; }
          public Post Post {get; set;}
    }
}