using ShopInfomation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ShopInfomation.DAL
{
    public class LevelGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["ShopInfoDb"].ConnectionString;


        public List<Level> GetAllLevel()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Level";
            SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Level> levelList = new List<Level>();
            while (reader.Read())
            {
                Level level=new Level();
                level.LevelId = Convert.ToInt32(reader["LevelNo"]);

                level.LevelNo = reader["LevelNo"].ToString();
              
                levelList.Add(level);
            }
            reader.Close();
            connection.Close();
            return levelList;
        }
    }
}