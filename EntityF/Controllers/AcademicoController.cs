using EntityF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityF.Controllers
{
    public class AcademicoController : Controller
    {
        // GET: Academico

        facear_2019Entities db = new facear_2019Entities();

        //BUSCAS
        public ActionResult Index()
        {
            //Busca tudo
            var listagem = db.Academico.ToList();

            //Primeiro registro com exceção
            //var listagem = db.Academico.First();

            //Primeiro registro sem exceção (traz vazio se for o caso)
            //var listagem = db.Academico.FirstOrDefault();

            //Quantos registros quer que o comando busque
            //var listagem = db.Academico.Take(2);

            //Lista em ordem crescente de... (pelo nome)
            //var listagem = db.Academico.OrderBy(x=>x.Nome);

            //Lista em ordem decrescente de... (pelo nome)
            //var listagem = db.Academico.OrderByDescending(x => x.Nome);

            //Busca por filtro de palavra
            //var listagem = db.Academico.Where(x => x.Nome.Contains("le"));
            //var listagem = db.Academico.Where(x => x.Nome.StartsWith("a"));

            //Busca por filtro com mais de um campo
            //var listagem = db.Academico.Where(x => x.Nome.Contains("le") && x.Sexo=="M");

            //Conta quantos registros tem
            //int qtd = db.Academico.Count();

            //condicional (quantas mulheres tem...)
            //int qtd = db.Academico.Where(x => x.Sexo == "F").Count();

            //Soma de campos int, float, double, decimal...
            //int somaDeID = db.Academico.Sum(x => x.Id_Academico);

            return View(listagem);
        }

        [HttpPost]
        public ActionResult Index(string txtNome, string txtSexo, string txtOrd, int txtTake)
        {
            var listagem = db.Academico.Take(txtTake);
            return View(listagem);
        }

        //BUSCAS
        public ActionResult Create()
        {
            //ComboBox de Materias
            ViewBag.Materias = new SelectList(db.Materia.ToList().OrderBy(x => x.Descricao), "Id_Materia", "Descricao");

            return View();
        }

        //Vem por parâmetro o objeto, e as notas por formcollection
        [HttpPost]
        public ActionResult Create(Academico academico, FormCollection form)
        {
            //Verifica se já existe o Academico no banco
            //Create com relacionamento de tabelas
            //Any = existe, abandona a query no primeiro registro que bata com o parâmetro
            //if (db.Academico.Any(x => x.Nome == "Fabiano"))
            //{
            //    //ALTERAR
            //    //Pega o primeiro fabiano que existe
            //    var ac = db.Academico.FirstOrDefault(x => x.Nome == "Fabiano");
            //    //altera o nome
            //    ac.Nome = "Fabiano Nezello";

            //    //Alterar nota
            //    //Pega a primeira nota do fabiano
            //    var nota = ac.Nota.First();
            //    //altera nota 1
            //    nota.Nota_I = 10;
            //    nota.Nome_Materia = "PHP";

            //    //Altera
            //    db.Entry(ac).State = EntityState.Modified;
            //    db.SaveChanges();

            //}
            //else
            //{
            //    //CADASTRAR
            //    Academico ac = new Academico();
            //    ac.Nome = "Fabiano";
            //    ac.Sexo = "M";

            //    Nota nota = new Nota();
            //    nota.Nota_I = 2;
            //    nota.Nota_II = 3.6m;
            //    nota.Nota_III = 4.0m;
            //    nota.Nota_IV = 4.5m;
            //    nota.Nome_Materia = "POO";
            //    ac.Nota.Add(nota);

            //    Nota nota_ = new Nota();
            //    nota_.Nota_I = 3;
            //    nota_.Nota_II = 7.6m;
            //    nota_.Nota_III = 9.0m;
            //    nota_.Nota_IV = 4.5m;
            //    nota_.Nome_Materia = "JAVA";
            //    ac.Nota.Add(nota_);

            //    db.Academico.Add(ac);
            //    db.SaveChanges();
            //}
            
            return View();
        }

        
    }
}