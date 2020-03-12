using ContactBook_PostgreSQL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_PostgreSQL.Validations
{
    public class AddressUniqueAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var _context = (MyWebApiContext)validationContext.GetService(typeof(MyWebApiContext));
            var entity = _context.Contacts.SingleOrDefault(x => x.Address == value.ToString());

            if (entity != null)
            {
                return new ValidationResult(GetErrorMessage(value.ToString()));
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage(string address)
        {
            return $"Address {address} is already in use.";
        }
    }
}
