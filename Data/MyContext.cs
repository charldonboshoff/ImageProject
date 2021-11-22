using ImageProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageProject.ViewModels.AlbumCategoryViewModels;
using ImageProject.ViewModels.MyMediaViewModels;

namespace ImageProject.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<AlbumCategory> AlbumCategories { get; set; }
        public DbSet<MyMedia> MyMedia { get; set; }
        public DbSet<ImageProject.ViewModels.AlbumCategoryViewModels.AlbumCategoryViewModel> AlbumCategoryViewModel { get; set; }
        public DbSet<ImageProject.ViewModels.MyMediaViewModels.MyMediaViewModel> MyMediaViewModel { get; set; }
        public DbSet<ImageProject.ViewModels.AlbumCategoryViewModels.CreateAlbumCategoryViewModel> CreateAlbumCategoryViewModel { get; set; }
        public DbSet<ImageProject.ViewModels.AlbumCategoryViewModels.EditAlbumCategoryViewModel> EditAlbumCategoryViewModel { get; set; }
    }
}
