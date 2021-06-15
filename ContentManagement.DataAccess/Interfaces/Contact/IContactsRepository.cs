using System;
using System.Collections.Generic;
using System.Text;
using ContactManagement.DataAccess.Entities;

namespace ContactManagement.DataAccess.Interfaces.Contact
{
    public interface IContactsRepository
    {
        Contacts AddContact(Contacts item);
        Contacts UpdateContact(Contacts item);
        void DeleteContact(int Id);
        IEnumerable<Contacts> GetAllContacts();
        Contacts FindContact(int id);
    }
}
