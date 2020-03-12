using ContactBook_PostgreSQL.Models;
using ContactBook_PostgreSQL.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactBook_PostgreSQL.Repository
{
    public class PhoneRepository : IPhoneRepository
    {
        MyWebApiContext db;
        public PhoneRepository(MyWebApiContext _db)
        {
            db = _db;
        }

        public async Task<int> AddPhone(Phone phone)
        {
            if (db != null)
            {
                await db.Phones.AddAsync(phone);
                await db.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> DeletePhone(int? phoneId)
        {
            int result = 0;

            if (db != null)
            {
                var phone = await db.Phones.FirstOrDefaultAsync(x => x.Id == phoneId);

                if (phone != null)
                {
                    db.Phones.Remove(phone);

                    result = await db.SaveChangesAsync();
                }
                return result;
            }

            return result;
        }

        public async Task<List<Contact>> GetContacts()
        {
            if (db != null)
            {
                return await db.Contacts.ToListAsync();
            }

            return null;
        }

        public async Task<PhoneViewModel> GetPhone(int? phoneId)
        {
            if (db != null)
            {
                return await (from p in db.Phones
                              join c in db.Contacts on p.ContactId equals c.Id
                              where p.Id == phoneId
                              select new PhoneViewModel
                              {
                                  PhoneId = p.Id,
                                  ContactId = p.ContactId,
                                  DateCreated = p.DateCreated,
                                  Number = p.Number
                              }).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<List<PhoneViewModel>> GetPhones()
        {
            if (db != null)
            {
                return await (from p in db.Phones
                              join c in db.Contacts on p.ContactId equals c.Id
                              select new PhoneViewModel
                              {
                                  PhoneId = p.Id,
                                  ContactId = p.ContactId,
                                  DateCreated = p.DateCreated,
                                  Number = p.Number
                              }).ToListAsync();
            }

            return null;
        }

        public async Task UpdatePhone(Phone phone)
        {
            if (db != null)
            {
                db.Phones.Update(phone);

                await db.SaveChangesAsync();
            }
        }
    }
}
