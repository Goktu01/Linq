using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp58
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product { ProductPrice=1000,Name="Abra"}
            };
            List<Category> categories = new List<Category>
            {
                new Category {CategoryId=1,CategoryName="Laptop",CategoryPrice=1000},
                new Category {CategoryId=2,CategoryName="Dizüstü",CategoryPrice=100},
                new Category {CategoryId=3,CategoryName="Tablet",CategoryPrice=10}
            };
            foreach (var c in categories)
            {
                if(c.CategoryPrice==10)
                Console.WriteLine(c.CategoryName);
            }

            Console.WriteLine("---Linq---");
            var result = categories.Where(c=>c.CategoryId==1);
            foreach (var item in result)
            {
              Console.WriteLine(item.CategoryName);
            }
            static List<Category> FilteredWithLinq(List<Category> category)
            {
                return category.Where(category => category.CategoryId == 1).ToList();
            }
            var check = categories.Any(c=>c.CategoryName=="Tulpar");
            Console.WriteLine(check);

            var check2 = categories.Find(c => c.CategoryName == "Tablet");
            Console.WriteLine(check2.CategoryPrice+" "+check2.CategoryName);
            Console.WriteLine("---------------------------");

            var test = from c in categories
                         where c.CategoryPrice > 0
                         orderby c.CategoryPrice descending
                         select c;
            foreach (var item in test)
            {
                Console.WriteLine(item.CategoryName);
            }
            var variable = from c in categories
                           where c.CategoryPrice > 0
                           orderby c.CategoryPrice
                           select new ProductDto { CategoryId=c.CategoryId , CategoryName =c.CategoryName};

        }

        class ProductDto
        {
            public int CategoryId{ get; set; }
            public string CategoryName { get; set; }
        }

        class Product
        {
            public int ProductPrice{ get; set; }
            public string Name{ get; set; }
        }
        class Category
        {
            public int CategoryId{ get; set; }
            public string  CategoryName{ get; set; }
            public int CategoryPrice { get; set; }
        }

        
    }
}
