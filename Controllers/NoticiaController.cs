using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using E_Players_Asp_Net_Core.Models;
using Microsoft.AspNetCore.Http;

        namespace E_Players_Asp_Net_Core.Controllers
    {
        public class NoticiaController : Controller
        {
        Noticias noticiaModel = new Noticias();

        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll(); 
            return View();
        }
        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia = new Noticias();
            novaNoticia.IdNoticias =  Int32.Parse( form ["IdNoticias"] ) ;
            novaNoticia.Titulo = form ["Titulo"];
            novaNoticia.Texto = form["Texto"];
            

             // Upload Início
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Noticias");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaNoticia.Imagem   = file.FileName;
            }
            else
            {
                novaNoticia.Imagem   = "padrao.png";
            }
            // Upload Final

            novaNoticia.Create(novaNoticia);
            ViewBag.Noticias = novaNoticia.ReadAll();
            return LocalRedirect("~/Noticias");
        }
        [Route("{Id}")]
        public IActionResult ExcluirN(int Id)
        {
            noticiaModel.DeleteN(Id);
            return LocalRedirect("~/Noticias");

        }

    }
}
