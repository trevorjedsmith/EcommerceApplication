using SportStoreAngular1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStoreAngular1.data
{
    public class OrderRepository : IRepository<Order>
    {
        private DataContext context = new DataContext();
 
        public IEnumerable<Order> GetAll()
        {
            return context.Orders.Include("Lines").Include("Lines.Product");
        }

        public async Task<int> Save(Order order)
        {
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            return await context.SaveChangesAsync();
        }

        public async Task<Order> Delete(int id)
        {
            Order dbEntry = context.Orders.Find(id);

            if(dbEntry != null)
            {
                context.Orders.Remove(dbEntry);
            }
            await context.SaveChangesAsync();
            return dbEntry;
        }

    }
}
