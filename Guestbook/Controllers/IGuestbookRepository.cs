using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Interfaccia per effettuare data access */

namespace Guestbook.Controllers
{
    public interface IGuestbookRepository
    {
        IList<GuestbookEntry> GetMostRecentEntries();
        GuestbookEntry FindById(int id);
        IList<CommentSummary> GetCommentSummary();
        void AddEntry(GuestbookEntry entry);
        void UpdateEntry();
    }
}
