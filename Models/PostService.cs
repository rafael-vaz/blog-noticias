using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Blog.Models
{
    public class PostService
    {
        //[MÉTODO DE REGISTRO]
        public int CreatePost(Post novoPost)
        {

            using (var context = new BlogContext())
            {

                context.Add(novoPost);
                context.SaveChanges();
                return novoPost.Id;
            }
        }

        

//[MÉTODO PARA RETORNO DE UM ÚNICO REGISTRO]  
  
        public Post GetPostDetail(int id)
  {
      using (var context = new BlogContext())
      {
          Post registro = context.Posts.Where(p => p.Id == id).SingleOrDefault();
          return registro;
      }
  }

 /* 
O método SingleOrDefault() seleciona o único elemento filtrado na consulta e, caso haja mais de um registro no retorno,
lança uma exceção. Uma versão semelhante a esse método é FirstOrDefault(), que, em vez de emitir erro, quando a consulta
resulta em mais de um registro, recupera o primeiro deles. 
*/

        //[MÉTODO DE LISTAGEM]
        public ICollection<Post> GetPosts(string termo, string ordem)
        {

            using (var context = new BlogContext())
            {

                IQueryable<Post> consulta = context.Posts.Where(/*Post*/p => p.Titulo.Contains(termo, StringComparison.OrdinalIgnoreCase));

                if (ordem == "t")
                    consulta = consulta.OrderBy(p => p.Titulo);

                else
                    consulta = consulta.OrderBy(p => p.Data);

                return consulta.ToList();
            }
        }

//[MÉTODO DE LISTAGEM COM COMENTÁRIO]
        public ICollection<Post> GetPostsFull(int page,  int size)
  {
      using (var context = new BlogContext())
      {
          int pular = (page - 1) * size;

          IQueryable<Post> consulta =
              context.Posts.Include(p => p.Comentarios).OrderByDescending(p => p.Data);
  
          return consulta.Skip(pular).Take(size).ToList();
      } 
  }

//[MÉTODO DE EDIÇÃO]
        public void UpdatePost(Post post)
        {

            using (var context = new BlogContext())
            {

                Post registro = context.Posts.Find(post.Id);

                if (registro != null)
                {
                    registro.Texto = post.Texto;
                    registro.Titulo = post.Titulo;
                    registro.Data = post.Data;

                    context.SaveChanges();
                    

                }

            }
        }

        public void RemovePost(Post p){

            using(var context = new BlogContext()){

                context.Posts.Remove(p);
                context.SaveChanges();
            }
        }

        public int CountPosts(){

            using(var context = new BlogContext()){

                return context.Posts.Count();
            }
        }
    }
}