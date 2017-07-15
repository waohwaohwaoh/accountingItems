using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DTO;
using WebApplication1.DAL;

namespace WebApplication1.Models
{
    public class User
    {
        public Guid personId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string patronymic { get; set; }
        public string mobile { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public List<Position> position { get; set; }
        public List<Profile> profile { get; set; }
        public List<User> GetAll()
        {
            List<UserDTO> usersDTOList = new UserRepository().SelectAll();
            if (usersDTOList == null)
                return null;
            List<User> usersModelsList = new List<User>();
            foreach (var i in usersDTOList)
            {
                usersModelsList.Add(new User
                {
                    password = i.password,
                    login = i.login,
                    personId = i.personId,
                    name = i.name,
                    surname = i.surname,
                    patronymic = i.patronymic,
                    mobile = i.mobile,
                    position = new Position().GetByUserId(i.personId),
                    profile = new Profile().GetByUserId(i.personId)
                });
            }
            return usersModelsList;
        }
    }
}