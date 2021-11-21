using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Models.ImageProjectDBContext
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            
        }
        public DbSet<AlbumCategory> AlbumCategories { get; set; }
        public DbSet<MyMedia> MyMedia { get; set; }
    }
}
