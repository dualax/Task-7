using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Task7.Model
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext()
        {
        }
        #region Конструктор
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        #endregion

        #region Public свойства
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Методы
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(GetProducts());
            base.OnModelCreating(modelBuilder);
        }

        private Product[] GetProducts() => new Product[]
        {
            new Product{ProductID = 1,
                        ProductName = "Булочка с корицей",
                        ProductDescription = "Когда то его посыпали перцем, но его поломанный отец смог сотварить из этого корицу",
                        ProductPrice = 52,
                        ProductUnit = 20},
            new Product{ProductID = 2,
                        ProductName = "Булочка с маком",
                        ProductDescription = "Вкуснейший ребенок главного Батона",
                        ProductPrice = 69,
                        ProductUnit = 18},
            new Product{ProductID = 3,
                        ProductName = "Куколд",
                        ProductDescription = "Великая булочка, можно смотреть, но не трогать!",
                        ProductPrice = 72,
                        ProductUnit = 20},
            new Product{ProductID = 4,
                        ProductName = "Каравай",
                        ProductDescription = "Батон переживший нашествие голодных людей, покрывшийся легендарной пылью и слезами жалких людишек",
                        ProductPrice = 99999,
                        ProductUnit = 1}
        };
        #endregion

    }
}