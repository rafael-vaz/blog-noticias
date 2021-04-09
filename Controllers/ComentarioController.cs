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
    public class ComentarioController : Controller
    {

        public IActionResult Cadastrar(Comentario c)
        {

            ComentarioService servico = new ComentarioService();

            servico.CreateComentario(c);
            c.Data = DateTime.Now;
            return RedirectToAction("Index", "Home");
        }

    }
}