using Contatos.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contatos.Controllers
{
    public class ContatoTelefoneController : Controller
    {
        // GET: ContatoTelefone
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContatoTelefone/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContatoTelefone/Create
        public ActionResult Create(int id)
        {
            return View(new Models.Telefone()
            {
                Contato = new Models.Contato() { Id = id }
            });
        }

        // POST: ContatoTelefone/Create
        [HttpPost]
        public ActionResult Create(Models.Telefone telefone)
        {
            try
            {
                // TODO: Add insert logic here
                TelefoneDAL telefoneDAL = new TelefoneDAL();
                telefoneDAL.Salvar(telefone);
                return View("Ok", telefone);
            }
            catch(Exception ex)
            {
                ViewBag.Ex = ex;
                return View("Error" , telefone);
            }
        }

        // GET: ContatoTelefone/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContatoTelefone/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: ContatoTelefone/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoTelefone/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
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
    }
}
