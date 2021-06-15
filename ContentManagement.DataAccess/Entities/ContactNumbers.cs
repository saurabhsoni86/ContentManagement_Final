using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManagement.DataAccess.Entities
{
    public class ContactNumbers
    {
        public int Id { get; set; }
        public int? ContactId { get; set; }
        public string ContactNumber { get; set; }
        public bool IsPrimary { get; set; }
        public ContactType Type { get; set; }
    }

    public enum ContactType
    {
        Home,
        Mobile,
        Emergency,
        Alternate
    }
}
