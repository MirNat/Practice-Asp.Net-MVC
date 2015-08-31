using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbum.PL.Controllers
{
    public class PhotoController : Controller
    {
        // GET: Photo
        public ActionResult GetFullSizePhotoById()
        {
            return View("FullSizePhoto");
        }
    }
}