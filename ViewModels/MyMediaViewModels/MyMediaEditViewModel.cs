using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.ViewModels.MyMediaViewModels
{
    public class MyMediaEditViewModel
    {
        public int Title { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
        public int AlbumCategoryId { get; set; }
    }
}
