using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ContactBook_PostgreSQL.Models
{
    public class MyWebApiContext:DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options)
        {
            
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }


    }
}
