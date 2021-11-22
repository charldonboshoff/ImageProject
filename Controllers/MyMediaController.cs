using AutoMapper;
using ImageProject.Infrastructure;
using ImageProject.Models;
using ImageProject.ViewModels.AlbumCategoryViewModels;
using ImageProject.ViewModels.MyMediaViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Controllers
{
    public class MyMediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MyMediaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            var myMedia = _unitOfWork.MyMediaRepo.GetAll();
            var mediaVM = _mapper.Map<List<MyMediaViewModel>>(myMedia);

            return View(mediaVM);
        }
        //Get the details(meta data) of the media manager
        public ActionResult Details(int id)
        {
            var myMedia = _unitOfWork.MyMediaRepo.GetById(id);
            var mediaVM = _mapper.Map<MyMediaViewModel>(myMedia);

            return View(mediaVM);
        }
        public ActionResult Create()
        {
            ViewBag.AlbumCategories = _unitOfWork.AlbumCategoryRepo.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MyMediaCreateViewModel mediaCVM)
        {
            try
            {
                var albumCategory = _unitOfWork.AlbumCategoryRepo.GetById(mediaCVM.AlbumCategoryId);

                List<MyMedia> myMedia = new List<MyMedia>();
                foreach (var file in mediaCVM.Files)
                {
                    myMedia.Add(new MyMedia()
                    {
                        ImagePath = file.FileName,
                        AlbumCategory = albumCategory
                    });
                }

                _unitOfWork.UploadFile(mediaCVM.Files);
                _unitOfWork.MyMediaRepo.AddRange(myMedia);
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.AlbumCategories = _unitOfWork.AlbumCategoryRepo.GetAll();
            var myMedia = _unitOfWork.MyMediaRepo.GetById(id);
            var mappedMedia = _mapper.Map<MyMediaEditViewModel>(myMedia);

            return View(mappedMedia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MyMediaEditViewModel mediaEVM)
        {
            try
            {
                if (mediaEVM.File == null && _unitOfWork.MyMediaRepo.GetById(mediaEVM.AlbumCategoryId).AlbumCategoryId == mediaEVM.AlbumCategoryId)
                {
                    RedirectToAction(nameof(Index));
                }
                else if (mediaEVM.File != null)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(mediaEVM.File);
                    var updateMyMedia = _unitOfWork.MyMediaRepo.GetById(mediaEVM.AlbumCategoryId);
                    updateMyMedia.AlbumCategoryId = mediaEVM.AlbumCategoryId;
                    updateMyMedia.ImagePath = mediaEVM.File.FileName;

                    _unitOfWork.UploadFile(files);
                    _unitOfWork.MyMediaRepo.Update(updateMyMedia);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
                else if (_unitOfWork.MyMediaRepo.GetById(mediaEVM.AlbumCategoryId).AlbumCategoryId != mediaEVM.AlbumCategoryId)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(mediaEVM.File);
                    var updateMyMedia = _unitOfWork.MyMediaRepo.GetById(mediaEVM.AlbumCategoryId);
                    updateMyMedia.AlbumCategoryId = mediaEVM.AlbumCategoryId;
                    updateMyMedia.ImagePath = _unitOfWork.MyMediaRepo.GetById(mediaEVM.AlbumCategoryId).ImagePath;

                    //_unitOfWork.UploadFile(files);
                    _unitOfWork.MyMediaRepo.Update(updateMyMedia);
                    _unitOfWork.Save();

                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var model = _unitOfWork.MyMediaRepo.GetById(id);
            var viewModel = _mapper.Map<MyMediaViewModel>(model);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection iFormCollection)
        {
            try
            {
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
