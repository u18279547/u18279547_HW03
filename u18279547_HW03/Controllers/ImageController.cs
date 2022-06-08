using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u18279547_HW03.Models;

namespace u18279547_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Image()
        {

            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Media/Images/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Server.MapPath("~/Media/Images/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteFile(string fileName)
        {
            //Build the File Path.
            string path = Server.MapPath("~/Media/Images/") + fileName;

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction("Image");
        }
    }
}