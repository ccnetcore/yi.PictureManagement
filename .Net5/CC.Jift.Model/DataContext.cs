using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Jift.Model
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<student> student { get; set; }
        public DbSet<admin> admin { get; set; }
        public DbSet<mail> mail { get; set; }
        public DbSet<myclass> myclass { get; set; }
        public DbSet<myfile> myfile { get; set; }
        public DbSet<note> note { get; set; }
        public DbSet<comment> comment { get; set; }
    }
}
