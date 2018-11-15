using BLL;
using DAL;
using SongsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace SongsApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public SongLogic songsLogic;
        public HomeController()
        {
            songsLogic = new SongLogic();
        }
        public ActionResult Index()
        {
            SongViewModels model = new SongViewModels();
            model.songs = new List<Songs>();
            model.songs = songsLogic.getUserSongs(User.Identity.GetUserId<string>()).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}