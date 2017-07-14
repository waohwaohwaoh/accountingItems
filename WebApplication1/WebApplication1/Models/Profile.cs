using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DTO;
using WebApplication1.DAL;

namespace WebApplication1.Models
{
    public class Profile
    {
        public int profileId { get; set; }
        public string profileName { get; set; }
        public List<Profile> GetAllProfiles()
        {
            List<ProfileDTO> profilesDTOList = new ProfileRepository().SelectAllProfiles();
            if (profilesDTOList == null)
                return null;
            List<Profile> profilesModelsList = new List<Profile>();
            foreach (var i in profilesDTOList)
            {
                profilesModelsList.Add(new Profile
                {
                    profileId = i.profileId,
                    profileName = i.profileName
                });
            }
            return profilesModelsList;
        }
    }
}