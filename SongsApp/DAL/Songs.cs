using System;
using System.Collections.Generic;
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
        public AspNetUsers user { get; set; }
    }
}
