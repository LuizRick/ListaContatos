using Contatos.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contatos.Controllers
{
    public class ContatoEmailController : Controller
    {
        // GET: ContatoEmail
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContatoEmail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContatoEmail/Create
        public ActionResult Create(int id)
        {
            return View(new Models.Email()
            {
                Contato = new Models.Contato() { Id = id }
            });
        }

        // POST: ContatoEmail/Create
        [HttpPost]
        public ActionResult Create(Models.Email email)
        {
            try
            {
                // TODO: Add insert logic here
                EmailDAL emailDAL = new EmailDAL();
                emailDAL.Salvar(email);
                return View("Ok", email);
            }
            catch
            {
                return View("Error", email);
            }
        }

        // GET: ContatoEmail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContatoEmail/Edit/5
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

        // GET: ContatoEmail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContatoEmail/Delete/5
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
