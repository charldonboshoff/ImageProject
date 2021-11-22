using AutoMapper;
using ImageProject.Infrastructure;
using ImageProject.Models;
using ImageProject.ViewModels.AlbumCategoryViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageProject.Controllers
{
    public class AlbumCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlbumCategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //Get the album category
        public ActionResult Index()
        {
            var albumCategories = _unitOfWork.AlbumCategoryRepo.GetAll();
            var mappedAlbumCategories = _mapper.Map<List<AlbumCategoryViewModel>>(albumCategories);

            return View(mappedAlbumCategories);
        }
        //Get the details(meta data) of the album category
        public ActionResult Details(int id)
        {
            var albumCategory = _unitOfWork.AlbumCategoryRepo.GetById(id);
            var mappedAlbumCategory = _mapper.Map<AlbumCategoryViewModel>(albumCategory);

            return View(mappedAlbumCategory);
        }
        public ActionResult Create(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateAlbumCategoryViewModel albumCategory)
        {
            try
            {
                var mappedAlbumCategory = _mapper.Map<AlbumCategory>(albumCategory);
                _unitOfWork.AlbumCategoryRepo.Insert(mappedAlbumCategory);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var albumCategory = _unitOfWork.AlbumCategoryRepo.GetById(id);
            var mappedAlbumCategory = _mapper.Map<EditAlbumCategoryViewModel>(albumCategory);

            return View(mappedAlbumCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditAlbumCategoryViewModel evm)
        {
            try
            {
                var albumCategory = _mapper.Map<AlbumCategory>(evm);
                _unitOfWork.AlbumCategoryRepo.Update(albumCategory);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            var albumCategory = _unitOfWork.AlbumCategoryRepo.GetById(id);
            var mappedAlbumCategory = _mapper.Map<AlbumCategoryViewModel>(albumCategory);

            return View(mappedAlbumCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, AlbumCategoryViewModel albumCategory)
        {
            try
            {
                _unitOfWork.AlbumCategoryRepo.Delete(Id);
                _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
