
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sensus.GUI.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sensus.GUI.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Statistic> Statistics { get; set; }

        public DataBaseContext()
        {

            Database.EnsureCreated();
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=C:\\WPF\\Проекты\\Sensus\\Sensus.GUI\\statistica.db");
        }

        public DataBaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }



        

    }
        
}
