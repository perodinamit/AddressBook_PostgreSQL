using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook_PostgreSQL.ViewModels
{
    public class PhoneViewModel
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public int? ContactId { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
