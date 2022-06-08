using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u18279547_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Home(HttpPostedFileBase file, FormCollection whichType)
        {
            
            if(file != null && file.ContentLength > 0)
            {
                var radioSelected = whichType["option"].ToString();

            var FileName = Path.GetFileName(file.FileName);
            string path = "";

            if(radioSelected == "document")
            {
                 path = Path.Combine(Server.MapPath("~/Media/Documents/"), FileName);
            }
            else if(radioSelected == "image")
            {
                 path = Path.Combine(Server.MapPath("~/Media/Images/"), FileName);
            }
            else if(radioSelected == "video")
            {
                 path = Path.Combine(Server.MapPath("~/Media/Videos/"), FileName);
            }

                file.SaveAs(path);
            }
            
            return RedirectToAction("Home");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Videos()
        {
            return View();
        }

        public ActionResult Images()
        {
            return View();
        }

    }
}