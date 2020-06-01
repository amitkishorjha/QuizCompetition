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
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController()
        {
            this._testimonialService = new TestimonialService(new TestimonialRepository<EFDbContext>());
        }

        // GET: Gallery
        public ActionResult Index()
        {
            var list = _testimonialService.GetAll();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Testimonial model)
        {
            try
            {
                UploadFile(HttpContext.Request, model);
                model.IsActive = false;
                _testimonialService.Add(model);
                _testimonialService.Save();

                //if (file.ContentLength > 0)
                //{
                //    var model = new Testimonial();

                //    string _FileName = Path.GetFileName(file.FileName);
                //    string _path = Path.Combine(Server.MapPath("~/GalleryPhotos"), _FileName);
                //    file.SaveAs(_path);
                //    model.ImageUrl = _path;

                //    _testimonialService.Add(model);
                //    _testimonialService.Save();
                //}
                //ViewBag.Message = "File Uploaded Successfully!!";

                return View("ThankYou");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult Gallery()
        {
            ViewBag.Gallery = "active";
            var photos = _testimonialService.GetAll().OrderByDescending(x => x.CreatedDate);
            return View(photos);
        }


        public ActionResult Publish(Guid id)
        {
            var eventEntity = _testimonialService.FindBy(x => x.Id == id).Single();

            return View(eventEntity);
        }

        [HttpPost]
        [ActionName("Publish")]
        public ActionResult PublishPost(Guid id)
        {
            try
            {
                var oldEntity = _testimonialService.FindBy(x => x.Id == id).Single();
                
                oldEntity.UpdatedDate = DateTime.Now;
                oldEntity.UpdatedBy = Request.IsAuthenticated ? User.Identity.Name : "System";
                oldEntity.IsActive = true;

                _testimonialService.Edit(oldEntity);
                _testimonialService.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult Edit(Guid id)
        {
            var eventEntity = _testimonialService.FindBy(x => x.Id == id).Single();

            return View(eventEntity);
        }

        [HttpPost]
        public ActionResult Edit(Guid id, Testimonial model)
        {
            try
            {
                var oldEntity = _testimonialService.FindBy(x => x.Id == id).Single();

                oldEntity.Name = model.Name;
                oldEntity.Email = model.Email;
                oldEntity.Telephone = model.Telephone;
                oldEntity.Message = model.Message;
                oldEntity.Year = model.Year;
                oldEntity.UpdatedDate = DateTime.Now;
                oldEntity.UpdatedBy = Request.IsAuthenticated ? User.Identity.Name : "System";
                oldEntity.IsActive = model.IsActive;

                _testimonialService.Edit(oldEntity);
                _testimonialService.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var eventEntity = _testimonialService.FindBy(x => x.Id == id).Single();

            return View(eventEntity);

        }

        // POST: Event/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(Guid id)
        {
            try
            {
                var eventEntity = _testimonialService.FindBy(x => x.Id == id).Single();
                _testimonialService.Delete(eventEntity);
                _testimonialService.Save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private void UploadFile(HttpRequestBase request, Testimonial model)
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
                    var fileSavePath = (HttpContext.Server.MapPath("~/TestimonialPhotos/") + model.Id + fileName.Substring(fileName.LastIndexOf('.')));

                    // Save the uploaded file to "UploadedFiles" folder
                    httpPostedFile.SaveAs(fileSavePath);
                    model.ImageUrl = fileSavePath;
                }
            }
        }
    }
}