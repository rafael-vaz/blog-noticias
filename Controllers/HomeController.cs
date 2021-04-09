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
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int p = 1)
        {   
            int quantidadePorPagina = 2;

            PostService service = new PostService();
            ICollection<Post> lista = service.GetPostsFull(p, quantidadePorPagina);

            int quantidadeRegistros = service.CountPosts();

            ViewData["Paginas"] = (int)Math.Ceiling((double)quantidadeRegistros / quantidadePorPagina);
            return View(lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
