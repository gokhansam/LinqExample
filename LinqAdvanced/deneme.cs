using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAdvanced
{
    public class deneme
    {
        private readonly List<Product> _productlar = new List<Product>()
        {
            new Product() {Id=1, CategoryId =1, Name="gogo", Price = 122},
            new Product() {Id=2, CategoryId =2, Name="boko", Price = 125},
        };

        private readonly List<Category> _categoriler = new List<Category>()
        {
            new Category() {Id=1, Name ="moko"},
            new Category() {Id=2, Name = "mokkoko"},
            new Category() {Id=3, Name = "bokoko"}
        };
        
        private void ciko()
        {
            var result01 = (from producttt in _productlar
                            where producttt.Id == 1
                            select producttt);

            var result02 = (from producttt in _categoriler
                            where producttt.Name.StartsWith("asd",StringComparison.OrdinalIgnoreCase)
                            select producttt
                            ).ToList();

            var result03 = (from cato in _categoriler
                            group cato by cato.Id into catoGroup 
                            select catoGroup
                ).ToList();

            IGrouping<int, Category> catooGroup = result03[0];
            var catoId = catooGroup.Key;
            foreach (var item in catooGroup)
            {

            }

            var result04 = ( from popo in _productlar
                             select new Product()
                             {
                                 
                             }
                ).ToList();
        }
    }
}
