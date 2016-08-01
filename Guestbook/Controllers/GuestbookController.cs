using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        private IGuestbookRepository _repository;

        public GuestbookController() { // costruttore di default invocato dal framework quando l'applicazione viene eseguita
            _repository = new GuestbookRepository();
        }

        public GuestbookController(IGuestbookRepository repository) // costruttore utilizzato nei test per iniettare un'implementazione fake del repository
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            //ViewBag.Entries = _repository.GetMostRecentEntries(); // passa il risultato della query alla view
            int i = 5;
            return View(_repository.GetMostRecentEntries());
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            if(ModelState.IsValid)
            {
                _repository.AddEntry(entry);
                return RedirectToAction("Index"); // redirect all'azione Index()
            }
            return View(entry); // se la validazione dei dati inseriti fallisce torna alla vista di inserimento dove l'utente può correggerli            
        }
       
        public ActionResult Show(int id)
        {
            var entry =_repository.FindById(id); // recupero l'oggetto con l'id specificato
            bool hasPermission = User.Identity.Name == "alex.ruzzante@yahoo.it";//entry.Name;
            ViewBag.HasPermission = hasPermission;
            return View(entry); // lo passo alla View
        }
        public ActionResult CommentSummary()
        {
            return View(_repository.GetCommentSummary());
        }
        public ActionResult Tablesorter()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            var entry = _repository.FindById(id);
            return View(entry);
        }
        [HttpPost]
        public ActionResult Edit(GuestbookEntry entry)
        {
            var entryToUpdate = _repository.FindById(entry.Id);
            entryToUpdate.DateAdded = DateTime.Now;
            if (TryUpdateModel(entryToUpdate,
               new string[] { "Name", "Message", "DateAdded" }))
            {
                    _repository.UpdateEntry();
                    return RedirectToAction("Index");
            }
            else
            {
                return View(entryToUpdate);
            }
             // se la validazione dei dati inseriti fallisce torna alla vista di inserimento dove l'utente può correggerli            
        }
    }
}