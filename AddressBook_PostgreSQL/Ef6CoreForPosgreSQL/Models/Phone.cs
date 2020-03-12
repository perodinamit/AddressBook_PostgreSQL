using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook_PostgreSQL.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
    }
}
