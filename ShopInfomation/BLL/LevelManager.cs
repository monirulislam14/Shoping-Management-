using ShopInfomation.DAL;
using ShopInfomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopInfomation.BLL
{
    public class LevelManager
    {
        LevelGateway gateway = new LevelGateway();
        public List<Level> GetAllLevel()
        {
            return gateway.GetAllLevel();
        }

    }
}