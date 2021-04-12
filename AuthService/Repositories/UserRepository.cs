using AuthService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Repositories
{
    public class UserRepository : IUserRepository
    {
        
        private static readonly List<UserDto> Users = new List<UserDto>()
        {
            new UserDto(){UserID = 1,UserName = "Ramesh",Password = "ramesh@123"},
            new UserDto(){UserID = 2,UserName = "Suresh",Password = "suresh@123"}
        };
        public UserDto GetUser(User user)
        {
            try
            {
                UserDto  userDto =  Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                return userDto;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }
    }
}
