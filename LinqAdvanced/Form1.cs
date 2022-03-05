using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqAdvanced
{
    public partial class Form1 : Form
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product() { Id =1,  CategoryId = 1, Name = "Apple iMac", Price = 2000 },
            new Product() { Id =2,  CategoryId = 1, Name = "Apple iBook Pro", Price = 2500 },
            new Product() { Id =3,  CategoryId = 2, Name = "Vestel Buzdolabı", Price = 2700 },
            new Product() { Id =4,  CategoryId = 2, Name = "Bosch Bulaşık Mak.", Price = 2800 },
            new Product() { Id =5,  CategoryId = 2, Name = "Arçelik Fırın", Price = 3000 },
            new Product() { Id =6,  CategoryId = 3, Name = "narenciye Sıkacagı", Price = 3000 },
            new Product() { Id =7,  CategoryId = 4, Name = "Tekli Koltuk", Price = 3100 },
            new Product() { Id =8,  CategoryId = 4, Name = "Zigon Sehpa", Price = 3500 },
            new Product() { Id =9,  CategoryId = 4, Name = "Köşe Koltu kTakımı", Price = 4000 },
            new Product() { Id =10, CategoryId = 5, Name = "Avize", Price = 1500 },
        };

        private readonly List<Category> _categories = new List<Category>()
        {
            new Category() { Id =1, Name = "Elektronik"},
            new Category() { Id =1, Name = "Beyaz Eşya"},
            new Category() { Id =1, Name = "Küçük ev aletleri"},
            new Category() { Id =1, Name = "Oturma grubu"},
            new Category() { Id =1, Name = "Isıklandırma"}
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var result01 = (from cat in _categories
                            where cat.Id == 3
                            select cat).SingleOrDefault();

            var result02 = from cat in _categories
                           where cat.Name.Contains('e', StringComparison.OrdinalIgnoreCase)
                           select cat;

            var result03 = (from cat in _categories
                            where cat.Id >= 3
                            select cat.Name).ToArray();

            var result04 = (from cat in _categories
                            where cat.Name.EndsWith("a", StringComparison.OrdinalIgnoreCase)
                            select $"{cat.Id} - {cat.Name}").ToList();

            var result05 = (from prod in _products
                            group prod by prod.CategoryId into prodGrouped
                            select prodGrouped
                            ).ToList();
            IGrouping<int, Product> productGrouping = result05[0];
            var categoryId = productGrouping.Key;
            foreach (var productt in productGrouping)
            {

            }

            var result06 = (from prod in _products
                            group prod by prod.CategoryId into productGroup
                            select new ProductCountByCategory() //sonucunu böyle class olarak da dönderebiliriz.
                            {
                                CategoryId = productGroup.Key,
                                ProductCount = productGroup.Count()
                            }
                            );

            var joinResult = (from prod in _products
                              join cat in _categories on prod.CategoryId equals cat.Id
                              select new
                              {
                                  Id = prod.Id,
                                  Name = prod.Name,
                                  CategoryId = prod.CategoryId,
                                  CategoryName = cat.Name
                              });
        }
    }
}