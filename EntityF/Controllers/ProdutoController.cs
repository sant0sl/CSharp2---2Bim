using EntityF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityF.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto

        facear_2019Entities db = new facear_2019Entities();

        //READ
        public ActionResult Index()
        {
            var listagem = db.Produto.ToList();

            return View(listagem);
        }

        public ActionResult Create()
        {
            return View();
        }

        //CREATE
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Produto.Add(produto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(produto);
                }
            }
            else
            {
                ModelState.AddModelError("", "Existem campos que estão incorretos.");
                return View(produto);
            }
        }

        //FIND BY ID
        public ActionResult Update(int ID)
        {
            var produto = db.Produto.Find(ID);
            return View(produto);
        }

        //UPDATE
        [HttpPost]
        public ActionResult Update(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.Entry(produto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message.ToString());
                    return View(produto);
                }
            }
            else
            {
                ModelState.AddModelError("", "Existem campos que estão incorretos.");
                return View(produto);
            }
        }

        public ActionResult Delete(int ID)
        {
            var produto = db.Produto.Find(ID);
            return View(produto);
        }

        //DELETE
        [HttpPost]
        public ActionResult Delete(Produto produto)
        {
            try
            {
                var p = db.Produto.Find(produto.Id_Produto);
                db.Produto.Remove(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.ToString());
                return View(produto);
            }
        }

    }
}