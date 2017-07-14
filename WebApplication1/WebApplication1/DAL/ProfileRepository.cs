using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.DTO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.DAL
{
    public class ProfileRepository
    {
        string sqlExpressionSelect = "select * from T_Profile";
        public List<ProfileDTO> SelectAllProfiles()
        {
            List<ProfileDTO> profilesList = null;
            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlExpressionSelect, connect))
                {
                    connect.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            profilesList = new List<ProfileDTO>();
                            while (reader.Read())
                            {
                                profilesList.Add(new ProfileDTO()
                                {
                                    profileId = reader.GetInt32(0),
                                    profileName = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
                connect.Close();
            }
            return profilesList;
        }
    }
}