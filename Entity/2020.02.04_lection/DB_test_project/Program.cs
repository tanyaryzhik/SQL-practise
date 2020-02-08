using DB_test_project.Models;
using System;

namespace DB_test_project
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new BikeStoresContext())
            {
                foreach (var item in dbContext.Brands)
                {
                    Console.WriteLine(item.BrandName);
                }
            }
        }
    }
}