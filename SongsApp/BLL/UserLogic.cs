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
        public bool IsEmailExists(string email)
        {
            return dBContext.users.Any(citizen => citizen.Email == email);
        }
        public AspNetUsers getUser(string id)
        {
            return dBContext.users.Where(u => u.Id.ToString() == id).FirstOrDefault();
        }
    }
}
