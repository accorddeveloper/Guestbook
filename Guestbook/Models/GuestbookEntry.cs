using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
    public class GuestbookEntry
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)] // in questo modo l'editor visualizzera una text area invece di una semplice text box per stringhe
        public string Message { get; set; }
        public DateTime DateAdded { get; set; }
    }
}