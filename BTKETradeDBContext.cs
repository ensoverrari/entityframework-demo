using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BTKEntityFrameworkDemo
{
    public class BTKETradeDBContext: DbContext
    {
        public DbSet<Product> Products { get; set; }//dbset denilen generic yapıyı kullanıcaz
        //benim bir product nesnem için dbset generic yapım var onu Products tablosu yerine kullanıcam demek

        
    }
}
