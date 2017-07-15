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
    public class PositionRepository
    {
        string sqlExpressionSelect = "select * from T_Position";
        string sqlExpressionSelectByUserId = 
            "select * from T_Position inner join T_User on T_Position.positionId = T_User.positionId where personId = @personId";
        public List<PositionDTO> SelectAll()
        {
            List<PositionDTO> positionsList = null;
            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlExpressionSelect, connect))
                {
                    connect.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            positionsList = new List<PositionDTO>();
                            while (reader.Read())
                            {
                                positionsList.Add(new PositionDTO()
                                {
                                    positionId = reader.GetInt32(0),
                                    positionName = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
                connect.Close();
            }
            return positionsList;
        }
        public List<PositionDTO> SelectByUserId(Guid _id)
        {
            List<PositionDTO> positionsList = null;
            using (SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["conStr"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlExpressionSelectByUserId, connect))
                {
                    command.Parameters.Add("@personId", SqlDbType.UniqueIdentifier).Value = _id;
                    connect.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            positionsList = new List<PositionDTO>();
                            while (reader.Read())
                            {
                                positionsList.Add(new PositionDTO()
                                {
                                    positionId = reader.GetInt32(0),
                                    positionName = reader.GetString(1)
                                });
                            }
                        }
                    }
                }
                connect.Close();
            }
            return positionsList;
        }
    }
}