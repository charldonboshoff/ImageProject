using ImageProject.Infrastructure;
using ImageProject.Models;
using ImageProject.Models.ImageProjectDBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Services
{
    public class MyMediaRepo : IMyMediaRepo
    {
        private readonly MyContext _context;

        public MyMediaRepo(MyContext context)
        {
            _context = context;
        }
        public void AddRange(List<MyMedia> model)
        {
            _context.MyMedia.AddRange(model);
        }
        public void Delete(int id)
        {
            var myMediaManager = GetById(id);
            _context.MyMedia.Remove(myMediaManager);
        }
        public List<MyMedia> GetAll()
        {
            var data = _context.MyMedia.Include(i => i.AlbumCategory).ToList();
            return data;
        }
        public MyMedia GetById(int Id)
        {
            return _context.MyMedia.Where(i => i.Id == Id).Include(i => i.AlbumCategory).FirstOrDefault();
        }
        public void Insert(MyMedia myMediaManager)
        {
            _context.MyMedia.Add(myMediaManager);
        }
        public void Update(MyMedia myMediaManager)
        {
            _context.MyMedia.Update(myMediaManager);
        }
    }
}
