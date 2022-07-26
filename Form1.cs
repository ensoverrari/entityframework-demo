using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTKEntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal = new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadProduct();
        }

        private void LoadProduct()
        {
            dgwProducts.DataSource = _productDal.GetAll();// bu kodu extract method diyerek metot haline getiriyoruz
        }

        private void SearchProduct(string key)//arama yapmamızı sağlayan olay
        {
            //var results = _productDal.GetAll().Where(p=>p.ProductName.Contains(key)).ToList();//büyük küçük harf duyarlılığı olablir diğerinde yok
            //küçükbüyük duyarlılığını kaldırabiliyomuşuz :) Where(p=>p.ProductName.ToLower().Contains(key.ToLower())
            var results = _productDal.GetByName(key);//direk veri tabanı sorgusu sonucunda productdaldaki metodumuzu burda çalıştırıyoruz.
            //where ile başlayan kısım bizim sorgumuz p herbir eleman için anlamında her bir elemanın nameini al key i içerenleri listele anlamında yani
            dgwProducts.DataSource = results;
            //bu işlemi productdal sınıfında yaparak direk veritabanına sorgu atabiliriz oraya da bak getall gibi bir metot yazdık
            //bu kısımdaki sorgu işlemi getallda biter. sorgu sonucu gelen verileri programda süzdük sadece
            //KÜÇÜK BÜYÜK DUYARLILIK KONUSU ŞUNDAN KAYNAKLI CSHARP BÜYÜK KÜÇÜK DUYARLILIĞINA SAHİPKEN SQL SORGULARI SAHİP DEĞİL
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                ProductName = tbProductName.Text,
                UnitPrice = Convert.ToDecimal(tbUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbStockAmount.Text)
            });
            MessageBox.Show("Product added!");
            LoadProduct(); 
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbProductName.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbUnitPrice.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbStockAmount.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),//bunu gridden alabiliriz çünkü textboxlarımızda yok
                ProductName = tbProductName.Text,
                UnitPrice = Convert.ToDecimal(tbUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbStockAmount.Text)
            });
            MessageBox.Show("Product updated");
            LoadProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product
            {
                Id = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),//bunu gridden alabiliriz çünkü textboxlarımızda yok
            });
            MessageBox.Show("Product deleted");
            LoadProduct();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProduct(tbSearch.Text);
        }
    }
}
