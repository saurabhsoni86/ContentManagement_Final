using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagement.DataAccess.Entities
{
    public class Contacts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public IEnumerable<ContactNumbers> PhoneNumbers { get; set; }
        public bool Status { get; set; }
    }
}
