using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using SongsApp.Models;
using Microsoft.AspNet.Identity;
using System.IO;
using System.Diagnostics;
using DAL;
using System.Web.Script.Serialization;

namespace SongsApp.Controllers
{
    public class SongController : Controller
    {
        private SongLogic _songsLogic;
        private UserLogic _usersLogic;
        public SongController()
        {
        }

        public UserLogic UserLogic
        {
            get
            {
                return _usersLogic ?? new UserLogic();
            }
            private set
            {
                _usersLogic = value;
            }
        }

        public SongLogic SongLogic
        {
            get
            {
                return _songsLogic ?? new SongLogic();
            }
            private set
            {
                _songsLogic = value;
            }
        }
        // GET: Song
        public ActionResult Index()
        {
            return View("View");
        }
        // Add Song to Database
        [HttpPost]
        public ActionResult AddSong(SongViewModels model)
        {
            DAL.Songs song = new DAL.Songs();
            AspNetUsers u = new AspNetUsers();
            song.ID = Guid.NewGuid();
            u = UserLogic.getUser(User.Identity.GetUserId<string>());
            song.user = new AspNetUsers();
            song.user = u;
            song.user_Id = User.Identity.GetUserId<string>();
            song.AlbumName = model.songModel.AlbumName;
            song.SingerName = model.songModel.SingerName;
            song.SongName = model.songModel.SongName;
            // convert image httpPostedFileWrapper to byte[]
            using (var binaryReader = new BinaryReader(model.songModel.image.InputStream))
            {
                song.image = binaryReader.ReadBytes(model.songModel.image.ContentLength);
            }

            using (var binaryReader = new BinaryReader(model.songModel.song.InputStream))
            {
                song.song = binaryReader.ReadBytes(model.songModel.song.ContentLength);
            }

            using (var binaryReader = new BinaryReader(model.songModel.NationalID.InputStream))
            {
                song.nationalID = binaryReader.ReadBytes(model.songModel.NationalID.ContentLength);
            }
            SongLogic.add(song);
            return RedirectToAction("Index", "Home");
        }
        // delete song
        public ActionResult DeleteSong(string id)
        {
            SongLogic.delete(id);
            return RedirectToAction("Index", "Home");
        }
        // get all songs
        public JsonResult GetAllSongs()
        {
            List<Songs> allsongs = SongLogic.getAllSongs();
            var songs = allsongs.Select(s => new { Name=s.SongName, song= string.Format("data:audio/mp3;base64,{0}", Convert.ToBase64String(s.song))});
            int count = allsongs.Count();
            return Json(new { songs, count});
        }
    }
}