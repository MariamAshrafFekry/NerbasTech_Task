using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace DAL
{
    public class DBContext:DbContext
    {
        public DbSet<AspNetUsers> users { get; set; }
        public DbSet<Songs> songs { get; set; }
    }
}
