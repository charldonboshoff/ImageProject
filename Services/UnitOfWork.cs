using ImageProject.Data;
using ImageProject.Infrastructure;
using ImageProject.Models.ImageProjectDBContext;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        private IAlbumCategoryRepo _albumCategoryRepo;
        private IMyMediaRepo _myMediaRepo;
        [Obsolete]
        private readonly IHostingEnvironment hostingEnvironment;

        [Obsolete]
        public UnitOfWork(MyContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IAlbumCategoryRepo AlbumCategoryRepo
        {
            get
            {
                return _albumCategoryRepo = _albumCategoryRepo ?? new AlbumCategoryRepo(_context);
            }
        }
        public IMyMediaRepo MyMediaRepo
        {
            get
            {
                return _myMediaRepo = _myMediaRepo ?? new MyMediaRepo(_context);
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        /*
        public CloudBlobContainer BlobContainer(string azureStorageConnectionString, string containerName)
        {
            var azureStorageAccount = CloudStorageAccount.Parse(azureStorageConnectionString);
            var cloudBlobClient = azureStorageAccount.CreateCloudBlobClient();
            return cloudBlobClient.GetContainerReference(containerName);
        }

        public async Task<IActionResult> UploadNewImage(IFormFile aFile, string title)
        {
            var container = anImageService.BlobContainer(AzureStorageConnectionString, "images");
            var content = ContentDispositionHeaderValue.Parse(aFile.ContentDisposition);
            var fileName = content.FileName.Trim('"');

            //Get a reference to a block blob
            var blockBlob = container.GetBlockBlobReference(fileName);

            await blockBlob.UploadFromStreamAsync(aFile.OpenReadStream());
            await anImageService.SetImage(title, blockBlob.Uri);

            return RedirectToAction("Index");
        }
        */
        [Obsolete]
        public async void UploadFile(List<IFormFile> files)
        {
            foreach (IFormFile item in files)
            {
                long ttlBytes = files.Sum(file => file.Length);
                string fileName = item.FileName.Trim('"');
                fileName = EnsureFileName(fileName);
                byte[] buffer = new byte[16 * 1024];
                using (FileStream output = File.Create(GetPathAndFileName(fileName)))
                {
                    using (Stream input = item.OpenReadStream())
                    {
                        int readBytes;
                        while ((readBytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            ttlBytes += readBytes;
                        }
                    }
                }
            }
        }
        private string EnsureFileName(string fileName)
        {
            if (fileName.Contains("\\"))
            {
                fileName = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            }
            return fileName;
        }

        [Obsolete]
        private string GetPathAndFileName(string fileName)
        {
            string path = hostingEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path + fileName;
        }
    }
}
