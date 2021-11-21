using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Infrastructure
{
    public interface IUnitOfWork
    {
        IAlbumCategoryRepo AlbumCategoryRepo {get;}
        IMyMediaRepo MyMediaRepo { get; }
        void Save();
        void UploadFile(List<IFormFile> files);
    }
}
