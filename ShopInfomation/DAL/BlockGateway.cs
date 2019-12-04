using ShopInfomation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;


namespace ShopInfomation.DAL
{
    public class BlockGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["ShopInfoDb"].ConnectionString;


        public List<Block> GetAllBlock()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "select * from Block";
            SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Block> blockList = new List<Block>();
            while (reader.Read())
            {
               Block block=new Block();

                block.BlockId = Convert.ToInt32(reader["BlockId"]);
                block.BlockName = reader["BlockName"].ToString();

                blockList.Add(block);
            }
            reader.Close();
            connection.Close();
            return blockList;
        }
    }
}