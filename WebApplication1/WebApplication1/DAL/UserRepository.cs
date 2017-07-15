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
    public class UserRepository
    {
        //sqlExp
        string sqlExpressionSelect = 
            "select T_Person.*, T_Authentication.password, T_Authentication.login from T_Authentication inner join T_Person on T_Authentication.personId = T_Person.personId";
        public List<UserDTO> SelectAll()
        {
            List<UserDTO> usersList = null;
            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlExpressionSelect, connect))
                {
                    connect.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            usersList = new List<UserDTO>();
                            while (reader.Read())
                            {
                                usersList.Add(new UserDTO()
                                {
                                    personId = reader.GetGuid(0),
                                    name = reader.GetString(1),
                                    surname = reader.GetString(2),
                                    patronymic = reader.GetString(3),
                                    mobile = reader.GetString(4),
                                    password = reader.GetString(5),
                                    login = reader.GetString(6),
                                    position = new PositionRepository().SelectByUserId(reader.GetGuid(0)),
                                    profile = new ProfileRepository().SelectByUserId(reader.GetGuid(0))
                                });
                            }
                        }
                    }
                }
                connect.Close();
            }
            return usersList;
        }
    }
}