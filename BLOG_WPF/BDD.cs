using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOG_WPF
{
    class BDD
    {
        private ApplicationContext _db;
        public BDD()
        {
        }

        public ApplicationContext DB
        {
            get { return _db; }
            set { _db = value; }
        }
    }
}
