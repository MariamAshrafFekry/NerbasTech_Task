using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SongsApp.Models
{
    public class SongViewModels
    {
        public SongViewModel songModel { get; set; }
        public string id { get; set; }
        public List<Songs> songs { get; set; }
    }
    public class SongViewModel
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Song Name is Required")]
        [RegularExpression("^[a-zA-Z\u0621-\u064A]*$", ErrorMessage = "Song Name must contain alphabetical characters only!")]
        public string SongName { get; set; }

        [Required(ErrorMessage = "Singer Name is Required")]
        [RegularExpression("^[a-zA-Z\u0621-\u064A]*$", ErrorMessage = "Singer Name must contain alphabetical characters only!")]
        public string SingerName { get; set; }

        [Required(ErrorMessage = "Album Name is Required")]
        [RegularExpression("^[a-zA-Z\u0621-\u064A]*$", ErrorMessage = "Album Name must contain alphabetical characters only!")]
        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Image")]
        [RegularExpression(".*\\.jpg", ErrorMessage = "Song Image must be .jpg file")]
        public HttpPostedFileWrapper image { get; set; }

        [Required]
        [Display(Name = "Song")]
        [RegularExpression(".*\\.mp3", ErrorMessage = "Song  must be .mp3 file")]
        public HttpPostedFileWrapper song { get; set; }

        [Required]
        [Display(Name = "National ID")]
        [RegularExpression(".*\\.jpg", ErrorMessage = "National ID must be .jpg file")]
        public HttpPostedFileWrapper NationalID { get; set; }


    }
}