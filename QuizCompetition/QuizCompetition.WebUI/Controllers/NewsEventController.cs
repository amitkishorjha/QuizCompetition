using School.BusinessLogic.Impl;
using School.BusinessLogic.Interface;
using School.DomainModel;
using School.Repository.Common;
using School.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace School.WebUI.SMHS.Controllers
{
    public class NewsEventController : Controller
    {
        private readonly INewsEventService _newsEventService;

        public NewsEventController()
        {
            this._newsEventService = new NewsEventService(new NewsEventRepository<EFDbContext>());
        }

        // GET: NewsEvent
        public ActionResult NewsAndEvents()
        {
            var newsList = _newsEventService.GetAll().OrderByDescending(x => x.DateOfNews);

            return View(newsList);
        }

        public ActionResult Index()
        {
            var news = _newsEventService.GetAll();
            return View(news);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsEvent model)
        {
            try
            {
                UploadFile(HttpContext.Request, model);

                _newsEventService.Add(model);
                _newsEventService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult Edit(Guid id)
        {
            var photoModel = _newsEventService.GetAll().Where(x => x.Id == id).SingleOrDefault();
            return View(photoModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult EditPost(Guid id, NewsEvent model)
        {
            try
            {
                var photoModel = _newsEventService.GetAll().Where(x => x.Id == id).SingleOrDefault();
                photoModel.Title = model.Title;
                photoModel.DateOfNews = model.DateOfNews;
                photoModel.FullDescription = model.FullDescription;
                photoModel.IsActive = model.IsActive;

                _newsEventService.Edit(photoModel);
                _newsEventService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View();
            }
        }


        public ActionResult Delete(Guid id)
        {
            var photoModel = _newsEventService.GetAll().Where(x => x.Id == id).SingleOrDefault();
            return View(photoModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(Guid id)
        {
            var photoModel = _newsEventService.GetAll().Where(x => x.Id == id).SingleOrDefault();
            try
            {
                _newsEventService.Delete(photoModel);
                _newsEventService.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View(photoModel);
            }
        }

        public ActionResult Details(Guid id)
        {
            var photo = _newsEventService.FindBy(x => x.Id == id).SingleOrDefault();

            return View(photo);
        }

        private void UploadFile(HttpRequestBase request, NewsEvent model)
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
                    var fileSavePath = (HttpContext.Server.MapPath("~/NewsEventPhotos/") + model.Id + fileName.Substring(fileName.LastIndexOf('.')));

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    model.ImageUrl = fileSavePath;
                }
            }
        }
    }
}