using AgendaVirtual.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgendaVirtual.Controllers
{
    public class AgendaVirtualController : Controller
    {

        AgendaVirtualEntities2 db = new AgendaVirtualEntities2();

        // GET: AgendaVirtual
        public ActionResult Index()
        {
            return View();
        }

        //mostra todos os registros
        public JsonResult MostrarTudo()
        {
            IList<Agenda> listaAnotacoes = new List<Agenda>();
            listaAnotacoes = db.Agenda.ToList();

            return Json(new
            {
                listaAnotacoes
            }, JsonRequestBehavior.AllowGet);
        }

        //salvar (novo e altera)
        public JsonResult Salvar(string id, string anotacao, string data)
        {
            Agenda agenda = new Agenda();
            agenda.Id_Anotacao = Convert.ToInt32(id);
            agenda.Anotacao = anotacao;
            agenda.DataAnotacao = data;

            string msgRetorno = null;

            if (agenda.Id_Anotacao.Equals(null) || agenda.Id_Anotacao.Equals(0))
            {
                db.Agenda.Add(agenda);
                db.SaveChanges();
                msgRetorno = "Nova anotação feita";
            }
            else
            {
                db.Entry(agenda).State = EntityState.Modified;
                db.SaveChanges();
                msgRetorno = "Anotação alterada";
            }

            IList<Agenda> listaAnotacoes = new List<Agenda>();
            listaAnotacoes = db.Agenda.ToList();

            return Json(new
            {
                msgRetorno,
                listaAnotacoes
            }, JsonRequestBehavior.AllowGet);
        }

        //excluir (exclui)
        public JsonResult Excluir(string id)
        {
            Agenda agenda = new Agenda();
            agenda.Id_Anotacao = Convert.ToInt32(id);

            db.Agenda.Remove(agenda);
            db.SaveChanges();

            string msgRetorno = "Anotação removida";

            IList<Agenda> listaAnotacoes = new List<Agenda>();
            listaAnotacoes = db.Agenda.ToList();

            return Json(new
            {
                msgRetorno,
                listaAnotacoes
            }, JsonRequestBehavior.AllowGet);
        }

        //alterar (joga os dados nos campos)
        public JsonResult Alterar(string id)
        {
            var a = db.Agenda.ToList().Find(x=>x.Id_Anotacao == Convert.ToInt32(id));

            string idAnotacao = Convert.ToString(a.Id_Anotacao);
            string Anotacao = a.Anotacao;
            string dataAnotacao = a.DataAnotacao;

            return Json(new
            {
                idAnotacao,
                Anotacao,
                dataAnotacao
            }, JsonRequestBehavior.AllowGet);
        }

    }
}