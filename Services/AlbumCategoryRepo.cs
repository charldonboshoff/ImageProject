using ImageProject.Infrastructure;
using ImageProject.Models;
using ImageProject.Models.ImageProjectDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Services
{
    public class AlbumCategoryRepo : IAlbumCategoryRepo
    {
        private readonly MyContext _context;

        public AlbumCategoryRepo(MyContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var albumCategory = GetById(id);
            _context.AlbumCategories.Remove(albumCategory);
        }
        public List<AlbumCategory> GetAll()
        {
            return _context.AlbumCategories.ToList();
        }
        public AlbumCategory GetById(int Id)
        {
            return _context.AlbumCategories.Where(i => i.Id == Id).FirstOrDefault();
        }
        public void Insert(AlbumCategory albumCategory)
        {
            _context.AlbumCategories.Add(albumCategory);
        }
        public void Update(AlbumCategory albumCategory)
        {
            _context.AlbumCategories.Update(albumCategory);
        }
    }
}
