using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KisiselWebSitesi.Models.Siniflar
{
    public class Context : DbContext
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<AnaSayfa> AnaSayfa { get; set; }
        public DbSet<İkonlar> ikonlar { get; set; }
    }
}