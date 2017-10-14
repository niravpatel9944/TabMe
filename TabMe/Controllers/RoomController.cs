using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabMe.BAL;
using TabMe.DAL;
using TabMe.ViewModel;
using TabMe.ViewModel.Enum;

namespace TabMe.Controllers
{
    public class RoomController : BaseController
    {
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            var item = RoomBAL.GetAll();
            return PartialView("List", item.ReturnObject);
        }
        public ActionResult Create()
        {
            RoomModel model = new RoomModel();
            model.Room = new RoomViewModel();
            model.Picture = new PictureViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(RoomModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            string[] pictureIds = "".Split(',');
            if (model.Room.PictureIds != null)
                pictureIds = model.Room.PictureIds.Split(',');

            var room = RoomBAL.Insert(model.Room);
            model.Room = (RoomViewModel)room.ReturnObject;

            for (int i = 0; i < pictureIds.Length; i++)
            {
                if (pictureIds[i].Trim().Length == 0) continue;
                PictureViewModel picture = new PictureViewModel();
                picture.Id = Convert.ToInt64(pictureIds[i]);
                picture.Entity = Entity.Room;
                picture.EntityId = model.Room.Id;
                ReturnResult returnResult = PictureBAL.Update(Convert.ToInt64(pictureIds[i]), picture);
                picture = (PictureViewModel)returnResult.ReturnObject;
                System.IO.File.Move(Server.MapPath("~/") + "uploadTemp/" + picture.Id + picture.FileExtension, Server.MapPath("~/") + "Images/" + picture.Id + picture.FileExtension);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            RoomModel model = new RoomModel();
            var room = RoomBAL.GetById(Id);
            model.Room = (RoomViewModel)room.ReturnObject;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(RoomModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            string[] pictureIds = "".Split(',');
            if (model.Room.PictureIds != null)
                pictureIds = model.Room.PictureIds.Split(',');

            var room = RoomBAL.Update(model.Room.Id, model.Room);
            model.Room = (RoomViewModel)room.ReturnObject;
            
            for (int i = 0; i < pictureIds.Length; i++)
            {
                if (pictureIds[i].Trim().Length == 0) continue;
                PictureViewModel picture = new PictureViewModel();
                picture.Id = Convert.ToInt64(pictureIds[i]);
                picture.Entity = Entity.Room;
                picture.EntityId = model.Room.Id;
                ReturnResult returnResult = PictureBAL.Update(Convert.ToInt64(pictureIds[i]), picture);
                picture = (PictureViewModel)returnResult.ReturnObject;
                System.IO.File.Move(Server.MapPath("~/") + "uploadTemp/" + picture.Id + picture.FileExtension, Server.MapPath("~/") + "Images/" + picture.Id + picture.FileExtension);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        //do not validate request token (XSRF)
        public ActionResult AsyncUpload()
        {
            //find more info here http://stackoverflow.com/questions/4884920/mvc3-valums-ajax-file-upload
            Stream stream = null;
            var fileName = "";
            var contentType = "";
            if (String.IsNullOrEmpty(Request["qqfile"]))
            {
                // IE
                HttpPostedFileBase httpPostedFile = Request.Files[0];
                if (httpPostedFile == null)
                    throw new ArgumentException("No file uploaded");
                stream = httpPostedFile.InputStream;
                fileName = Path.GetFileName(httpPostedFile.FileName);
                contentType = httpPostedFile.ContentType;
            }
            else
            {
                //Webkit, Mozilla
                stream = Request.InputStream;
                fileName = Request["qqfile"];
            }

            var fileBinary = new byte[stream.Length];
            stream.Read(fileBinary, 0, fileBinary.Length);

            var fileExtension = Path.GetExtension(fileName);
            if (!String.IsNullOrEmpty(fileExtension))
                fileExtension = fileExtension.ToLowerInvariant();
            
            string FilePath = Server.MapPath("~/") + "uploadTemp/";
            if (!Directory.Exists(FilePath))
                Directory.CreateDirectory(FilePath);
            if(!Directory.Exists(Server.MapPath("~/") + "Images/"))
                Directory.CreateDirectory(Server.MapPath("~/") + "Images/");

            PictureViewModel picture = new PictureViewModel();
            picture.Id = 0;
            picture.Entity = Entity.Room;
            picture.EntityId = 0;
            picture.FileExtension = fileExtension;
            ReturnResult returnResult = PictureBAL.Insert(picture);
            picture = (PictureViewModel)returnResult.ReturnObject;
            
            FileStream fs = new FileStream(FilePath + picture.Id + fileExtension, FileMode.CreateNew);
            BinaryWriter w = new BinaryWriter(fs);
            w.Write(fileBinary);
            w.Close();
            fs.Close();
            
            return Json(new
            {
                success = true,
                pictureId = picture.Id,
                fileExtension = fileExtension
            },
                "text/plain");
        }
    }
}