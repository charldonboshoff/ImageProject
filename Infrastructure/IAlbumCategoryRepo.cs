using ImageProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Infrastructure
{
    public interface IAlbumCategoryRepo
    {
        List<AlbumCategory> GetAll();
        AlbumCategory GetById(int Id);
        void Insert(AlbumCategory albumCategory);
        void Update(AlbumCategory albumCategory);
        void Delete(int id);
    }
}
