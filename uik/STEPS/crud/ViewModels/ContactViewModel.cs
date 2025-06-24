using crud.Models;
using System.Collections.Generic;

namespace crud.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; } = new Contact();
        public IEnumerable<Contact> ContactList { get; set; } = new List<Contact>();
    }
}
