using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using TaechIdeas.Alessiodisalvo.Models;

namespace TaechIdeas.Alessiodisalvo.Controllers
{
    public class GalleryController : BaseController
    {
        //
        // GET: /Gallery/
        public ActionResult Index()
        {
            var gallery = GetGallery();

            return View(gallery);
        }

        private Gallery GetGallery()
        {
            var gallery = new Gallery
            {
                Name = ConfigurationManager.AppSettings["GalleryMainName"]
            };

            var mainFolder = ConfigurationManager.AppSettings["GalleryMainFolder"];

            var directories = new DirectoryInfo(Server.MapPath(mainFolder + "/1280")).GetDirectories();

            if (!directories.Any())
                return null;

            var rooms = new List<Room>();

            foreach (var directory in directories)
            {
                var room = new Room
                {
                    Name = directory.Name
                };

                var pictureList = new List<Picture>();

                var files = directory.GetFiles("*.jpg");

                if (!files.Any())
                    break;

                foreach (var f in files)
                {
                    var picture = new Picture
                    {
                        Name = f.Name,
                        RelativePath1280 = mainFolder + "/1280/" + directory + "/" + f.Name,
                        RelativePath480 = mainFolder + "/480/" + directory + "/" + f.Name,
                        RelativePath90 = mainFolder + "/90/" + directory + "/" + f.Name
                    };

                    pictureList.Add(picture);
                }

                room.CoverRelativePath = pictureList.First().RelativePath1280;
                room.Pictures = pictureList;

                rooms.Add(room);
            }

            gallery.Rooms = rooms;

            return gallery;
        }
    }
}