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
        /// <summary>
        /// get song from db 
        /// </summary> 
        /// <param name="id">Song ID</param>
        /// <returns></returns>
        public Songs getSong(string id)
        {
            return dBContext.songs.FirstOrDefault(s => s.ID.ToString() == id);
        }

        /// <summary>
        /// add song to db 
        /// </summary> 
        /// <param name="song">Song object</param>
        public void add(Songs song)
        {
            dBContext.songs.Add(song);
            dBContext.SaveChanges();
        }
        /// <summary>
        /// delete song from db 
        /// </summary> 
        /// <param name="id">Song ID</param>
        public void delete(string id)
        {
            Songs song = getSong(id);
            dBContext.songs.Remove(song);
            dBContext.SaveChanges();
        }
        /// <summary>
        /// update song in db 
        /// </summary> 
        /// <param name="song">song</param>
        public void update(Songs song)
        {
            dBContext.songs.Attach(song);
            dBContext.Entry(song).State = System.Data.Entity.EntityState.Modified;
            dBContext.SaveChanges();
        }
        /// <summary>
        /// get all song from db 
        /// </summary> 
        /// <returns></returns>
        public List<Songs> getAllSongs()
        {
            return dBContext.songs.ToList();
        }
        /// <summary>
        /// get songs belonged to user from db 
        /// </summary> 
        /// <param name="id">user ID</param>
        /// <returns></returns>
        public List<Songs> getUserSongs(string usrId)
        {
            return dBContext.songs.Where(s => s.user_Id.ToString() == usrId).ToList();
        }
    }
}
