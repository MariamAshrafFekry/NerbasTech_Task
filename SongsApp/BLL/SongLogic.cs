using DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class SongLogic
    {
        public DBContext dBContext;
        public SongLogic()
        {
            dBContext = new DBContext();
        }
        public Songs getSong(string id)
        {
            return dBContext.songs.FirstOrDefault(s => s.ID.ToString() == id);
        }
        public void add(Songs song)
        {
            dBContext.songs.Add(song);
            dBContext.SaveChanges();
        }
        public void delete(string id)
        {
            Songs song = getSong(id);
            dBContext.songs.Remove(song);
            dBContext.SaveChanges();
        }
        public void update(Songs song)
        {
            dBContext.songs.Attach(song);
            dBContext.Entry(song).State = System.Data.Entity.EntityState.Modified;
            dBContext.SaveChanges();
        }
        public List<Songs> getAllSongs()
        {
            return dBContext.songs.ToList();
        }
        public List<Songs> getUserSongs(string usrId)
        {
            return dBContext.songs.Where(s => s.user.Id.ToString() == usrId).ToList();
        }
    }
}
