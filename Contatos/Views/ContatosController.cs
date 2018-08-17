using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contatos.Models.DAL;

/**
 * Geralmente faço todas a requisições via ajax porém para simplificar farei tudo sem usar ajax
 * usarei javascript apenas para validar algumas coisas
 */
namespace Contatos.Views
{
    public class ContatosController : Controller
    {
        // GET: Contatos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        [HttpPost]
        public ActionResult Create(Models.Contato contato)
        {
            try
            {
                // TODO: Add insert logic here
                ContatoDAL dal = new ContatoDAL();
                dal.Salvar(contato);
                return RedirectToAction("Ok");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contatos/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Contato collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contatos/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.Contato contato)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Listar(Models.Contato contato)
        {
            var letter = Request.QueryString["letter"];
            if (!string.IsNullOrEmpty(letter))
            {
                contato = new Models.Contato()
                {
                    Nome = letter
                };
            }
            ContatoDAL contatoDAL = new ContatoDAL();
            return View(contatoDAL.Consultar(contato).ToList());
        }

        public ActionResult Ok()
        {
            return View();
        }
    }
}
