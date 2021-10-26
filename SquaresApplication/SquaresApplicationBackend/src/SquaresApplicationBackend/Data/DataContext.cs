using Microsoft.EntityFrameworkCore;
using SquaresApplicationBackend.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresApplicationBackend.Api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PointEntity> Points { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
