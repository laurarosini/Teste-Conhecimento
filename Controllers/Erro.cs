using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Teste_K2iP.Controllers
{
    public class Erro : Controller
    {
        public IActionResult Index()
        {
            throw new Exception("Erro proposital!");
            return View();
        }
    }
}
