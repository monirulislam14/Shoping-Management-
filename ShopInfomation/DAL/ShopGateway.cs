using ShopInfomation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ShopInfomation.DAL
{
    public class ShopGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["ShopInfoDb"].ConnectionString;
        public List<Shop> GetAllShopInfo()
        {

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("sPGetAllShop", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Shop> shopList = new List<Shop>();
            while (reader.Read())
            {
                Shop shop = new Shop();

                shop.ShopId = Convert.ToInt32(reader["ShopId"]);
                shop.ShopName = reader["ShopName"].ToString();
                shop.Contact = reader["Contact"].ToString();
                shop.LevelId = Convert.ToInt32(reader["LevelId"]);
                shop.BlockId = Convert.ToInt32(reader["BlockId"]);
                shopList.Add(shop);
            }
            reader.Close();
            connection.Close();
            return shopList;
        }

        public bool SaveShop(Shop shop)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SaveShop", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ShopName", shop.ShopName);
            cmd.Parameters.AddWithValue("@Contact", shop.Contact);
            cmd.Parameters.AddWithValue("@LevelId", shop.LevelId);
            cmd.Parameters.AddWithValue("@BlockId", shop.BlockId);


            connection.Open();
            int rowEffect = cmd.ExecuteNonQuery();
            connection.Close();
            if (rowEffect > 0)
            {
                return true;
            }
            return false;
        }

        public List<ShopViewModel> GetShopAndBlockView()
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("SpShopViewModel", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ShopViewModel> EmpDeptList = new List<ShopViewModel>();

            while (reader.Read())
            {
                ShopViewModel spBlock = new ShopViewModel();
                spBlock.ShopId = Convert.ToInt32(reader["ShopId"]);
                spBlock.ShopName = reader["ShopName"].ToString();
                spBlock.Contact = reader["Contact"].ToString();
                spBlock.LevelNo = reader["LevelNo"].ToString();
                spBlock.BlockName = reader["BlockName"].ToString();

                EmpDeptList.Add(spBlock);
            }
            reader.Close();
            connection.Close();
            return EmpDeptList;

        }
        public List<ShopViewModel> GetShopAndBlockViewBySearch(ViewBySearch search)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("sPViewModelWithSearch", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Search", search.SearchShopName);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<ShopViewModel> EmpDeptList = new List<ShopViewModel>();
            int count = 0;
            while (reader.Read())
            {
                ShopViewModel spBlock = new ShopViewModel();
                spBlock.Count = ++count;
              
                spBlock.ShopName = reader["ShopName"].ToString();
                spBlock.Contact = reader["Contact"].ToString();
                spBlock.LevelNo = reader["LevelNo"].ToString();
                spBlock.BlockName = reader["BlockName"].ToString();

                EmpDeptList.Add(spBlock);
            }
            reader.Close();
            connection.Close();
            return EmpDeptList;
        }
        public ShopViewModel ShopAndBlockViewEdit(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("EditShopViewModel", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
         
            ShopViewModel spBlock = new ShopViewModel();
            while (reader.Read())
            {
               
                spBlock.ShopId = Convert.ToInt32(reader["ShopId"]);
                spBlock.ShopName = reader["ShopName"].ToString();
                spBlock.Contact = reader["Contact"].ToString();
                spBlock.LevelNo = reader["LevelNo"].ToString();
                spBlock.BlockName = reader["BlockName"].ToString();

       
            }
            reader.Close();
            connection.Close();
            return spBlock;
        }

        public bool ShopAndBlockViewDelete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("DeleteShopViewModel", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();

            int rowEffect = cmd.ExecuteNonQuery();
            connection.Close();
            if (rowEffect > 0)
            {
                return true;
            }
            return false;
        }
        public bool SaveUpdatedShop(ShopViewModel shop ,int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("sPSaveUpdatedShopViewModel", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ShopId", id);
            cmd.Parameters.AddWithValue("@ShopName", shop.ShopName);
            cmd.Parameters.AddWithValue("@Contact", shop.Contact);
            cmd.Parameters.AddWithValue("@LevelId", shop.LevelId);
            cmd.Parameters.AddWithValue("@BlockId", shop.BlockId);

            connection.Open();
            int rowEffect = cmd.ExecuteNonQuery();
            connection.Close();
            if (rowEffect > 0)
            {
                return true;
            }
            return false;
        }
    }
}