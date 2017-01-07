using SportStoreAngular1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStoreAngular1.data
{
    public class ProductRepository : IRepository<Product>
    {
        private DataContext context = new DataContext();

        public IEnumerable<Product> GetAll()
        {
            return context.Products;
        }

        public async Task<int> Save(Product product)
        {
            if(product.Id == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbEntry = context.Products.Find(product.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Price = product.Price;
                    dbEntry.Category = product.Category;
                }
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Product> Delete(int id)
        {
            Product dbEntry = context.Products.Find(id);
            if(dbEntry != null)
            {
                context.Products.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }
    }
}
