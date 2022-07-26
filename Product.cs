using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTKEntityFrameworkDemo
{
    //bu sınıfı tablonun karşılığı olarak oluşturduk isimleri hemen hemen aynı olacak şekilde
    public class Product
    {
        [RequiredProperty]//altında yer alan veri için kısıt içeren bir attribute oluşturabilirsin yani bu Id için geçerli olacak bir özniteliktir.
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockAmount { get; set; }

    }

   
}
