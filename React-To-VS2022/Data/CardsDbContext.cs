using Microsoft.EntityFrameworkCore;
using React_To_VS2022.Models;
using System.Collections.Generic;

namespace React_To_VS2022.Data
{
    public class CardsDbContext : DbContext
    {
        public CardsDbContext(DbContextOptions<CardsDbContext> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }
    }
}
