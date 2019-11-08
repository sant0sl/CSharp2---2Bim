using EntityF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //EXERCÍCIO PARA FIXAÇÃO (BOSTA)----------------------------------------------
        public ActionResult Academicos()
        {
            //DropdownList MATERIAS
            ViewBag.Materias = new SelectList(db.Materia.ToList().OrderBy(x => x.Descricao), "Id_Materia", "Descricao");
            return View();
        }

        public JsonResult salvarNota(string Id_Materia, string nota1, string nota2, string nota3, string nota4)
        {
            IList<Nota> listaDeNotas = new List<Nota>();
            if (Session["ListaNotas"] != null)
            {
                listaDeNotas = (IList<Nota>)Session["ListaNotas"];
            }
            Nota n = new Nota();
            n.Nome_Materia = Id_Materia;
            n.Nota_I = Convert.ToDecimal(nota1);
            n.Nota_II = Convert.ToDecimal(nota2);
            n.Nota_III = Convert.ToDecimal(nota3);
            n.Nota_IV = Convert.ToDecimal(nota4);
            listaDeNotas.Add(n);
            Session["ListaNotas"] = listaDeNotas;

            return Json(new
            {
                listaDeNotas
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Academicos(FormCollection frm)
        {
            Academico ac = new Academico();
            ac.Nome = frm["txtNome"];
            ac.Sexo = frm["txtSexo"];
            ac.Idade = frm["txtIdade"];
            ac.Excluido = false;
            ac.Ativo = true;

            IList<Nota> listaDeNotas = new List<Nota>();
            if (Session["ListaNotas"] != null)
            {
                listaDeNotas = (IList<Nota>)Session["ListaNotas"];
            }

            //ac.Nota = listaDeNotas;
            db.Academico.Add(ac);
            db.SaveChanges();

            return View();
        }

        //----------------------------------------------------------------------------

        public JsonResult fitrarAcademicos(string nome)
        {
            var lista = db.Academico.ToList().Where(x => x.Nome.Contains(nome));
            IList<Academico> listaAcademico = new List<Academico>();

            //StringBuilder str = new StringBuilder();

            //str.Append("<table>");
            foreach (var item in lista)
            {
                Academico a = new Academico();
                a.Nome = item.Nome;
                a.Sexo = item.Sexo;
                listaAcademico.Add(a);
                //str.Append("<tr><td>"+ item.Nome + "</td><td>" + item.Sexo + "</td></tr>");
            }
            //str.Append("</table>");

            return Json(new
            {
                //tabelaAcademicos = str.ToString(),
                //lista,
                listaAcademico
            }, JsonRequestBehavior.AllowGet);
        }

        //----------------------------------------------------------------------------

        //enviando hora atual para o javascript
        public JsonResult RetornaHora()
        {
            DateTime horaAtual = DateTime.Now;

            return Json(new
            {
                hora = horaAtual.ToString("dd/MM/yyyy")
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RetornaQtdLetras(string nome, string sobrenome)
        {
            int qtd = nome.Length;
            qtd += sobrenome.Length;

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