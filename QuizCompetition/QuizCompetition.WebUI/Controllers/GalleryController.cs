using School.BusinessLogic.Impl;
using School.BusinessLogic.Interface;
using School.DomainModel;
using School.Repository.Common;
using School.Repository.Impl;
using School.WebUI.SMHS.Common.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.WebUI.SMHS.Controllers
{
   
    public class GalleryController : Controller
    {
        private readonly IPhotoDetailsService _photoDetailsService;

        public GalleryController()
        {
            this._photoDetailsService = new PhotoDetailsService(new PhotoDetailsRepository<EFDbContext>());
        }

        [SessionExpire]
        [Authorize]
        // GET: Gallery
        public ActionResult Index()
        {
            var list = _photoDetailsService.GetAll();

            return View(list);
        }

        [SessionExpire]
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        [SessionExpire]
        [Authorize]
        [HttpPost]
        public ActionResult Create(PhotoDetails model)
        {
            try
            {
                UploadFile(HttpContext.Request,model);

                _photoDetailsService.Add(model);
                _photoDetailsService.Save();
                
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var photoModel = _photoDetailsService.GetAll().Where(x => x.Id == id).SingleOrDefault();
            return View(photoModel);
        }

        [SessionExpire]
        [Authorize]
        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Guid id, PhotoDetails model)
        {
            try
            {
                var photoModel = _photoDetailsService.GetAll().Where(x => x.Id == id).SingleOrDefault();
                photoModel.Title = model.Title;
                photoModel.Description = model.Description;
                photoModel.IsActive = model.IsActive;

                _photoDetailsService.Edit(photoModel);
                _photoDetailsService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult Gallery()
        {
            ViewBag.Gallery = "active";
            var photos = _photoDetailsService.FindBy(x=>x.IsActive==true).OrderByDescending(x=>x.CreatedDate);
            return View(photos);
        }

        [SessionExpire]
        [Authorize]
        public ActionResult Delete(Guid id)
        {
            var photoModel = _photoDetailsService.GetAll().Where(x => x.Id == id).SingleOrDefault();
            return View(photoModel);
        }

        [SessionExpire]
        [Authorize]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(Guid id)
        {
            var photoModel = _photoDetailsService.GetAll().Where(x => x.Id == id).SingleOrDefault();
            try
            {
                _photoDetailsService.Delete(photoModel);
                _photoDetailsService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View(photoModel);
            }
        }

        [SessionExpire]
        [Authorize]
        public ActionResult Details(Guid id)
        {
            var photo = _photoDetailsService.FindBy(x => x.Id == id).SingleOrDefault();

            return View(photo);
        }

        private void UploadFile(HttpRequestBase request,PhotoDetails model)
        {
            if (request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = request.Files[0];

                var fileName = httpPostedFile.FileName;

                if (httpPostedFile != null)
                {
                    // Validate the uploaded image(optional)

                    // Get the complete file path
                    var fileSavePath = (HttpContext.Server.MapPath("~/GalleryPhotos/") + model.Id+fileName.Substring(fileName.LastIndexOf('.')));

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    model.ImageUrl = fileSavePath;
                }
            }
        }
    }
}