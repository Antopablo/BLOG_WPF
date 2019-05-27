using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLOG_WPF
{
   public class ApplicationContext : DbContext
    {
        public DbSet <User> User { get; set; }

        public DbSet <Article> Article { get; set; }
    }
}
