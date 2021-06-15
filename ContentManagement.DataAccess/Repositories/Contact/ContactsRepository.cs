using ContactManagement.DataAccess.Entities;
using ContactManagement.DataAccess.Factory;
using ContactManagement.DataAccess.Interfaces.Contact;
using System.Collections.Generic;
using System.Linq;

namespace ContactManagement.DataAccess.Repositories.Contact
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly RepositoryFactory _repositoryFactory;
        private static List<Contacts> contactsList = new List<Contacts>();
        public ContactsRepository(RepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        public Contacts AddContact(Contacts item)
        {
            _repositoryFactory.Contacts.Add(item);
            _repositoryFactory.SaveChanges();
            return item;
        }
        public Contacts UpdateContact(Contacts item)
        {
            var itemToUpdate = contactsList.SingleOrDefault(r => r.Id == item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.FirstName = item.FirstName;
                itemToUpdate.LastName = item.LastName;

            }
            return itemToUpdate;
        }
        public void DeleteContact(int Id)
        {
            var itemToRemove = contactsList.SingleOrDefault(r => r.Id == Id);
            if (itemToRemove != null)
                contactsList.Remove(itemToRemove);
        }
        public IEnumerable<Contacts> GetAllContacts()
        {
            contactsList = _repositoryFactory.Contacts.ToList<Contacts>();
            return contactsList;
        }
        public Contacts FindContact(int Id)
        {
            var contactItem = contactsList.Find(e => e.Id == Id);
            return contactItem;
        }

    }
}
