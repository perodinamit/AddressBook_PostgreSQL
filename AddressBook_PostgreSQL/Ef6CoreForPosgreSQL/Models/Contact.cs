using ContactBook_PostgreSQL.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook_PostgreSQL.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [AddressUnique]
        public string Address { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
        public ICollection<Phone> Phones { get; set; }

    }
}
