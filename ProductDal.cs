using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BTKEntityFrameworkDemo
{
    public class ProductDal
    {
        
        public List<Product> GetAll()
        {
            //bu alttaki "using" Garbage Collector'ı yani çöp toplayıcıyı beklemeden nesnemizi zorla bellekten atmamıza yarıyo. bellek önemli da onu mu bekliyek 
            using (BTKETradeDBContext context = new BTKETradeDBContext())
            {
                return context.Products.ToList();//sadece bunun için adonette bir sürü kod yazmıştık getall metodu ile
                                                 //sonrasında appconfig e connectionstring ile alakalı kodları yazıyoruz korkma bişe değil
            }
        }
        public List<Product> GetByName(string key)//DİKKAT LİNQ SORGULARI İÇERİR
        {
            //burada search işlemini direk veritabanına sorgu atarak yaptık.
            using (BTKETradeDBContext context = new BTKETradeDBContext())
            {
                return context.Products.Where(p=>p.ProductName.Contains(key)).ToList();
            }
            //çok verimiz olduğu zaman bu şekil daha avantajlı neden
            //çünkü SADECE ihtiyacımız olan veriyi veritabanından çekmemizi sağlar
            //bunu da search textboxının textchanged kısmında çalıştırmamız lazım orada yazıyo.
        }
        public List<Product> GetByUnitPrice(decimal price)//DİKKAT LİNQ SORGULARI İÇERİR
        {            
            using (BTKETradeDBContext context = new BTKETradeDBContext())
            {
                return context.Products.Where(p => p.UnitPrice>=price).ToList();//girilen değere eşit veya ondan büyük değerleri getirmek
            }            
        }
        public List<Product> GetByUnitPrice(decimal min, decimal max)//DİKKAT LİNQ SORGULARI İÇERİR
        {
            using (BTKETradeDBContext context = new BTKETradeDBContext())
            {
                return context.Products.Where(p => p.UnitPrice >= min &&p.UnitPrice<max ).ToList();//girilen iki değer arası 
            }
        }

        public void Add(Product product)
        {
            using (BTKETradeDBContext context = new BTKETradeDBContext())
            {
                //context.Products.Add(product); alttaki iki satırın yerine bunu da kullanabilirsin 
                var entity = context.Entry(product);
                entity.State = EntityState.Added;
                context.SaveChanges();
            }

        }

        public void Update(Product product)
        {
            using (BTKETradeDBContext context = new BTKETradeDBContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }

        }
        public void Delete(Product product)
        {
            using (BTKETradeDBContext context = new BTKETradeDBContext())
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }

        }


    }
}
