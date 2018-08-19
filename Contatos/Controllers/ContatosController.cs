using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contatos.Models.DAL;
using Contatos.Models.BLL;

/**
 * Geralmente faço todas a requisições via ajax porém para simplificar farei tudo sem usar ajax
 * usarei javascript apenas para validar algumas coisas
 */
namespace Contatos.Views
{
    public class ContatosController : Controller
    {
        private Dictionary<string, List<IStrategy>> validacoes = new Dictionary<string, List<IStrategy>>();

        public ContatosController()
        {
            List<IStrategy> salvarContatos = new List<IStrategy>
            {
                new ValidarNomeUnico()
            };
            validacoes.Add("SALVAR", salvarContatos);
        }

        // GET: Contatos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int id)
        {
            ContatoDAL contatoDAL = new ContatoDAL();
            var model = contatoDAL.Consultar(new Models.Contato()
            {
                Id = id
            });
            return View(model.FirstOrDefault());
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            ViewBag.ErrorMsg = null;
            return View();
        }

        // POST: Contatos/Create
        [HttpPost]
        public ActionResult Create(Models.Contato contato)
        {
            try
            {
                string msg = ExecutaRegrasNegocio("SALVAR", contato);
                if (msg != null)
                {
                    ViewBag.ErrorMsg = msg;
                    return View(contato);
                }
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
        public ActionResult Edit(Models.Contato contato)
        {
            try
            {
                // TODO: Add update logic here
                ContatoDAL contatoDAL = new ContatoDAL();
                
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


        private string ExecutaRegrasNegocio(string acao, Contatos.Models.Entidade entidade)
        {
            string msg = null;
            foreach (var list in this.validacoes[acao])
            {
                msg = list.Processar(entidade);
                if (msg != null)
                    return msg;
            }

            return msg;
        }
    }
}
