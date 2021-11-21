using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Models
{
    public class AlbumCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<MyMedia> MyMedia { get; set; } = new List<MyMedia>();
    }
}
