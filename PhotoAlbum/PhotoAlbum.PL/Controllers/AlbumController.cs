using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoAlbum.PL.Controllers
{
    [Authorize]
    public class AlbumController : Controller
    {
        public ActionResult LatestPublications()
        {
            return View("ShowAllAlbums");
        }

        public ActionResult AllPublications()
        {
            return View("ShowAllAlbums");
        }

        public ActionResult GetUserAlbums()
        {
            return View("ShowAllAlbums");
        }

        public ActionResult GetAlbumInfoById()
        {
            return View("AlbumInfo");
        }
        public ActionResult GetAlbumPhotosById()
        {
            return View("ShowAlbumData");
        }

    }
}
