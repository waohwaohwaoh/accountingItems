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
    }
}