using ContactBook_PostgreSQL.Models;
using ContactBook_PostgreSQL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook_PostgreSQL.Repository
{
    public interface IPhoneRepository
    {
        Task<List<Contact>> GetContacts();

        Task<List<PhoneViewModel>> GetPhones();

        Task<PhoneViewModel> GetPhone(int? phoneId);

        Task<int> AddPhone(Phone phone);

        Task<int> DeletePhone(int? phoneId);

        Task UpdatePhone(Phone phone);
    }
}
