using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guestbook.Models;

/* GuestbookRepository è la classe concreta che implementa l'interfaccia IGuestbookRepository ed è responsabile di effettuare data access */

namespace Guestbook.Controllers
{
    public class GuestbookRepository : IGuestbookRepository
    {
        private GuestbookContext _db = new GuestbookContext();
        public IList<GuestbookEntry> GetMostRecentEntries()
        {
            return (from entry in _db.Entries
                    orderby entry.DateAdded descending
                    select entry).Take(20).ToList();
        }
        public GuestbookEntry FindById(int id)
        {
            var entry = _db.Entries.Find(id); // recupero l'oggetto con l'id specificato
            return entry;
        }
        public IList<CommentSummary> GetCommentSummary()
        {
            var entries = from entry in _db.Entries // query in definita in LINQ
                          group entry by entry.Name
                          into groupedByName
                          orderby groupedByName.Count() descending
                          select new CommentSummary
                          {
                              NumberOfComments = groupedByName.Count(),
                              UserName = groupedByName.Key
                          };
            return entries.ToList();
        }
        public void AddEntry(GuestbookEntry entry)
        {
            entry.DateAdded = DateTime.Now; // setta il campo mancante

            _db.Entries.Add(entry); // aggiunge l'oggetto all'EntriesDbSet del GuestbookContext
            _db.SaveChanges(); // scrive sul database la nuova entry            
        }
        public void UpdateEntry()
        {
            _db.SaveChanges(); // scrive sul database la entry modificata  
        }
    }
}