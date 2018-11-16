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

namespace SongsApp.Controllers
{
    public class SongController : Controller
    {
        public SongLogic songsLogic;
        public UserLogic usersLogic;
        public SongController()
        {
            songsLogic = new SongLogic();
            usersLogic = new UserLogic();
        }
        // GET: Song
        public ActionResult Index()
        {
            return View("View");
        }
        [HttpPost]
        public ActionResult AddSong(SongViewModels model)
        {
            DAL.Songs song = new DAL.Songs();
            AspNetUsers u = new AspNetUsers();
            song.ID = Guid.NewGuid();
            u = usersLogic.getUser(User.Identity.GetUserId<string>());
            song.user = new AspNetUsers();
            song.user = u;
            song.user_Id = User.Identity.GetUserId<string>();
            song.AlbumName = model.songModel.AlbumName;
            song.SingerName = model.songModel.SingerName;
            song.SongName = model.songModel.SongName;
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
            songsLogic.add(song);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult DeleteSong(string id)
        {
            songsLogic.delete(id);
            return RedirectToAction("Index", "Home");
        }
    }
}