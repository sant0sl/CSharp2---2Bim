using EntityF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityF.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia

        facear_2019Entities db = new facear_2019Entities();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult OutrosComandosJQuery()
        {
            return View();
        }

        //enviando hora atual para o javascript
        public JsonResult RetornaHora()
        {
            DateTime horaAtual = DateTime.Now;

            return Json(new
            {
                hora = horaAtual.ToString("dd/MM/yyyy")
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RetornaQtdLetras(string nome)
        {
            int qtd = nome.Length;

            return Json(new
            {
                qtd
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            //DropdownList
            ViewBag.Academicos = new SelectList(db.Academico.ToList().OrderBy(x => x.Nome), "Id_Academico", "Nome", 2);
            return View();
        }

        public ActionResult Update()
        {
            var materia = db.Materia.FirstOrDefault();
            //DropdownList
            ViewBag.Academicos = new SelectList(db.Academico.ToList().OrderBy(x => x.Nome), "Id_Academico", "Nome", 2);
            return View(materia);
        }
    }
}