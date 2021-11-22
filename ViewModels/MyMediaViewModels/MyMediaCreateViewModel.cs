using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.ViewModels.MyMediaViewModels
{
    public class MyMediaCreateViewModel
    {
        public List<IFormFile> Files { get; set; }
        public int AlbumCategoryId { get; set; }
    }
}
