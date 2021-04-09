using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Blog.Models;


namespace Blog.Controllers
{
    public class PostController : Controller
    {
         public IActionResult Cadastro()
        {
            return View();
        }
        
        [HttpPost]
         public IActionResult Cadastro(Post novoPost)
        {
            PostService service = new PostService();

            int novoId = service.CreatePost(novoPost);

            if(novoId != 0){
                @ViewData["Mensagem"] = "Cadastro realizado com sucesso";
            }

            else {

                @ViewData["Mensagem"] = "Falha no cadastro";
            } 

            return View();
        }

          public IActionResult Lista()
        {   
            PostService servico = new PostService();
            ICollection<Post> lista = servico.GetPosts("", "");
            
            return View(lista);
        }


        [HttpGet]
          public IActionResult Lista(string q, string ordem)
        {   
            PostService service = new PostService();

            if(q == null)
            q = String.Empty;

            if(ordem == null)
            ordem = "t";
            
            return View(service.GetPosts(q, ordem));
        }


          [HttpGet]
        public IActionResult Editar(int id){
            
            PostService servico = new PostService();
            Post registro = servico.GetPostDetail(id);

            return View(registro);
        }

        [HttpPost]
        public IActionResult Editar(Post post){

            PostService s = new PostService();
            
            s.UpdatePost(post);

            return RedirectToAction("Lista");
        }

         public IActionResult Excluir(int id){

            PostService s = new PostService();
            
          Post registro = s.GetPostDetail(id);

           s.RemovePost(registro);

            return RedirectToAction("Lista");
        }
        
    }
}