using ShopInfomation.DAL;
using ShopInfomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopInfomation.BLL
{
    public class BlockManager
    {
        BlockGateway gateway = new BlockGateway();
        public List<Block> GetAllBlock()
        {
            return gateway.GetAllBlock();
        }
    }
}