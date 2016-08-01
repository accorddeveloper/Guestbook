using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// View Model = un oggetto model creato allo scopo esclusivo di mostrare dati su schermo

namespace Guestbook.Models
{
    public class CommentSummary
    {
        public string UserName { get; set; }
        public int NumberOfComments { get; set; }
    }
}