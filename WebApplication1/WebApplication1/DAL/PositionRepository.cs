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
        public List<PositionDTO> SelectAllPositions()
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
    }
}