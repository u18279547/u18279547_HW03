using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace u18279547_HW03.Models
{
    public class FileModel
    {
        public string FileName { get; set; }

        public HttpPostedFileBase Files { get; set; }
        
    }
}