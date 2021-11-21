using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Models
{
    public class MyMedia
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int AlbumCategoryId { get; set; }
        public AlbumCategory AlbumCategory { get; set; } = new AlbumCategory();
    }
}
