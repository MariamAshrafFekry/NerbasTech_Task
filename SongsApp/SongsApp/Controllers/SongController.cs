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

namespace SongsApp.Controllers
{
    public class SongController : Controller
    {
        public SongLogic songsLogic;
        public SongController()
        {
            songsLogic = new SongLogic();
        }
        // GET: Song
        public ActionResult Index()
        {
            return View("View");
        }
        [HttpPost]
        public ActionResult AddSong(SongViewModels model)
        {
            Debug.Write(User.Identity.GetUserId<string>() + " LLL");
            DAL.Songs song = new DAL.Songs();
            song.user.Id = User.Identity.GetUserId();
            song.AlbumName = model.AlbumName;
            song.SingerName = model.SingerName;
            song.SongName = model.SongName;
            using (var binaryReader = new BinaryReader(model.image.InputStream))
            {
                song.image = binaryReader.ReadBytes(model.image.ContentLength);
            }

            using (var binaryReader = new BinaryReader(model.song.InputStream))
            {
                song.song = binaryReader.ReadBytes(model.song.ContentLength);
            }

            using (var binaryReader = new BinaryReader(model.NationalID.InputStream))
            {
                song.nationalID = binaryReader.ReadBytes(model.NationalID.ContentLength);
            }
            Debug.WriteLine(song.SingerName + " " + song.SongName + " " + song.AlbumName);
            Debug.WriteLine(song.image + "  " + song.nationalID + "  " + song.song);
            songsLogic.add(song);
            return View("Index", "Home");
        }
    }
}