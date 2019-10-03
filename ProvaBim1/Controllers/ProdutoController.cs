using ProvaBim1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProvaBim1.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            return View(listaProdutos);
        }
        //Menus
        [HttpGet]
        public ActionResult IndexTipo(int id)
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            List<Produto> listaProdutosCategoria = new List<Produto>();
            foreach (var item in listaProdutos)
            {
                if (item.categoria == id)
                {
                    listaProdutosCategoria.Add(item);
                }
            }

            return View(listaProdutosCategoria);
        }

        //Login admin
        public ActionResult LoginAdmin()
        {
            Session["Admin"] = 0;
            return View();
        }

        //Efetuar login
        [HttpPost]
        public ActionResult LoginAdmin(Usuario u)
        {
            if (u.login.Equals("adm") && u.senha.Equals("123"))
            {
                Session["Admin"] = 1;
                return RedirectToAction("Logado");
            }
            else if (!u.login.Equals("adm") || !u.senha.Equals("123"))
            {
                ModelState.AddModelError("", "Login incorreto!");
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Login incorreto!");
                return View();
            }
        }

        //Logado
        public ActionResult Logado()
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            return View(listaProdutos);
        }

        //Crud------------------------
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Produto p)
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            //validação backend das strings
            if (string.IsNullOrEmpty(p.nome))
            {
                ModelState.AddModelError("", "O campo nome é obrigatório!");
            }
            if (string.IsNullOrEmpty(p.descricao))
            {
                ModelState.AddModelError("", "O campo descricao é obrigatório!");
            }
            if (string.IsNullOrEmpty(p.marca))
            {
                ModelState.AddModelError("", "O campo marca é obrigatório!");
            }
            if (string.IsNullOrEmpty(p.modelo))
            {
                ModelState.AddModelError("", "O campo modelo é obrigatório!");
            }

            listaProdutos.Add(p);
            Session["Produtos"] = listaProdutos;

            return RedirectToAction("Index");
        }

        //Redireciona para a página de alteração com as info
        public ActionResult Update(int id)
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            var p1 = listaProdutos.Find(x => x.idProduto == id);
            return View(p1);
        }

        [HttpPost]
        public ActionResult Update(Produto p)
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            var p1 = listaProdutos.Find(x => x.idProduto == p.idProduto);

            //validação backend das strings
            if (string.IsNullOrEmpty(p.nome))
            {
                ModelState.AddModelError("", "O campo nome é obrigatório!");
            }
            if (string.IsNullOrEmpty(p.descricao))
            {
                ModelState.AddModelError("", "O campo descricao é obrigatório!");
            }
            if (string.IsNullOrEmpty(p.marca))
            {
                ModelState.AddModelError("", "O campo marca é obrigatório!");
            }
            if (string.IsNullOrEmpty(p.modelo))
            {
                ModelState.AddModelError("", "O campo modelo é obrigatório!");
            }

            listaProdutos.Remove(p1);
            listaProdutos.Add(p);
            Session["Produtos"] = listaProdutos;

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            var p1 = listaProdutos.Find(x => x.idProduto == id);

            listaProdutos.Remove(p1);
            Session["Produtos"] = listaProdutos;

            return RedirectToAction("Index");
        }
        //---------------------------

        public ActionResult DadosProduto(int id)
        {
            List<Produto> listaProdutos = new List<Produto>();
            if (Session["Produtos"] != null)
            {
                listaProdutos = (List<Produto>)Session["Produtos"];
            }

            var p1 = listaProdutos.Find(x => x.idProduto == id);
            return View(p1);
        }
    }
}