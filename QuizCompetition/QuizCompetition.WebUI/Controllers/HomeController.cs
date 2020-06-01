using School.BusinessLogic.Common;
using School.BusinessLogic.Impl;
using School.BusinessLogic.Interface;
using School.Repository.Common;
using School.Repository.Impl;
using School.WebUI.SMHS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace School.WebUI.SMHS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public HomeController()
        {
            this._testimonialService = new TestimonialService(new TestimonialRepository<EFDbContext>());

        }
        public ActionResult Index()
        {
            ViewBag.Index = "active";

            var list = _testimonialService.FindBy(x => x.IsActive == true).OrderByDescending(x => x.CreatedDate);

            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.About = "active";

            ViewBag.UrduHighSchoolStaffList = GetStaffList(@"\TextFiles\URDU_HIGH_SCHOOL_STAFF.txt");
            ViewBag.UrduJrCollegeStaffList = GetStaffList(@"\TextFiles\URDU_JR_COLLEGE_STAFF.txt");
            ViewBag.ComputerUrduJrCollegeStaffList = GetStaffList(@"\TextFiles\Computer_URDU_JR_COLLEGE_STAFF.txt");
            ViewBag.DiniyatUrduJrCollegeStaffList = GetStaffList(@"\TextFiles\Diniyat_URDU_JR_COLLEGE_STAFF.txt");
            ViewBag.NonTeachingUrduJrCollegeStaffList = GetStaffList(@"\TextFiles\Non_Teaching_URDU_JR_COLLEGE_STAFF.txt");
            ViewBag.UrduPrimarySchoolStaffList = GetStaffList(@"\TextFiles\URDU_PRIMARY_SCHOOL_STAFF.txt");

            return View();
        }

        public ActionResult WeOffer(string boxNumber,string ServiceName)
        {
            var pathString = $@"\WeOffer\{boxNumber}.txt";
            var path = Server.MapPath(pathString);

            TextReader rs = new TextReader(path);

            StringBuilder paraTextBuilder = new StringBuilder();

            foreach(var line in rs.GetLines())
            {
                paraTextBuilder.Append(line);
            }

            ViewBag.ParaText = paraTextBuilder.ToString();

            ViewBag.ServiceName = ServiceName;

            return View();

        }

        private IEnumerable<StaffDetails> GetStaffList(string filePath)
        {
            TextReader reader = new TextReader(Server.MapPath(filePath));
            List<StaffDetails> staffList = new List<StaffDetails>();
            foreach(var line in  reader.GetLines())
            {
                var items = line.Split('|');
                var staff = new StaffDetails()
                {
                    Name = items[0],
                    Qualification = items[1],
                    Designation = items[2]
                };
                staffList.Add(staff);
            }

            return staffList;
        }

        public ActionResult Contact()
        {
            ViewBag.Contact = "active";
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

       
    }
}