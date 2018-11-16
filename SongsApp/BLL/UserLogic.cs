using DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserLogic
    {
        public DBContext dBContext;
        public UserLogic()
        {
            dBContext = new DBContext();
        }
        /// <summary>
        /// check if mail exixts in db 
        /// </summary> 
        /// <param name="email">email</param>
        /// <returns></returns>
        public bool IsEmailExists(string email)
        {
            return dBContext.users.Any(user => user.Email == email);
        }
        /// <summary>
        /// get user from db 
        /// </summary> 
        /// <param name="id">user ID</param>
        /// <returns></returns>
        public AspNetUsers getUser(string id)
        {
            return dBContext.users.Where(u => u.Id.ToString() == id).FirstOrDefault();
        }
    }
}
