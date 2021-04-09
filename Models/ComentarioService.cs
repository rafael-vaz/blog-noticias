using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Models
{
    public class ComentarioService
    {


    public int CreateComentario(Comentario comentario){

        using(var context = new BlogContext()){

            context.Comentarios.Add(comentario);
            context.SaveChanges();
            return comentario.Id;
        }
    }

    public List<Comentario> GetComentarios(int idPost){

        using(var context = new BlogContext()){
            
            
            return context.Comentarios.Where(c => c.PostId == idPost).ToList();

        }
    }


        
    }
}