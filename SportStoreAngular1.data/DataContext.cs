using SportStoreAngular1.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportStoreAngular1.data
{
    public class DataContext : DbContext
    {

        public DataContext() : base("SportsStoreAngular1"){ }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
    }
}
