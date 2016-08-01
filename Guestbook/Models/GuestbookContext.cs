using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Guestbook.Models
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext() : base("Guestbook") // definisce il nome del database
        {
        }
        public DbSet<GuestbookEntry> Entries { get; set; } // fornisce l'accesso ai dati della tabella
    }
}