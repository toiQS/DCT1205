using DCT1205.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT1205.Presistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<PaymentRecord> PaymentRecord { get; set; }
        public DbSet<TaxYear> TaxYear { get; set; }
    }
}
