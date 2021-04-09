using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Post
    {
         public int Id {get; set;}

         [StringLength(100)]
          public string Titulo { get; set; }

          [Column(TypeName = "TEXT")]
          public string Texto { get; set; }
          public DateTime Data {get; set;}
          public ICollection<Comentario> Comentarios {get; set;}
    }
}