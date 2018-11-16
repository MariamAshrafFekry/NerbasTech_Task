using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Songs
    {
        public Guid ID { get; set; }
        public string SongName { get; set; }
        public string SingerName { get; set; }
        public string AlbumName { get; set; }
        public byte[] image { get; set; }
        public byte[] song { get; set; }
        public byte[] nationalID { get; set; }
        public virtual AspNetUsers user { get; set; }
        public string user_Id { get; set; }
    }
}
