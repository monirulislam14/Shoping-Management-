using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopInfomation.DAL;
using ShopInfomation.Models;

namespace ShopInfomation.BLL
{
    public class ShopInfoManager
    {   
        ShopGateway gateway=new ShopGateway();
        public List<Shop> GetAllShopInfo()
        {
            return gateway.GetAllShopInfo();
        }

        public bool SaveShop(Shop shop)
        {
         
                if (IsShopExist(shop))
                {
                    return false;
                }
                else
                {

                    return gateway.SaveShop(shop);
                }

        }
        public bool IsShopExist(Shop shop)
        {

            var shopList = GetAllShopInfo();

            return shopList.Any(emp => emp.ShopName == shop.ShopName);
        }

        public List<ShopViewModel> GetShopAndBlockView()
        {
           
            return gateway.GetShopAndBlockView();
        }
        public List<ShopViewModel> GetShopAndBlockViewBySearch(ViewBySearch search)
        {
            return gateway.GetShopAndBlockViewBySearch(search);
        }

        public ShopViewModel ShopAndBlockViewEdit(int id)
        {
            return gateway.ShopAndBlockViewEdit(id);
        }
        public bool ShopAndBlockViewDelete(int id)
        {   
             ShopGateway gateway=new ShopGateway();

            return gateway.ShopAndBlockViewDelete(id);
        }

        public bool SaveUpdatedShop(ShopViewModel shop,int id)
        {
            ShopGateway gateway = new ShopGateway();
            if (gateway.SaveUpdatedShop( shop, id))
            {
                return true;
            }
            return false;
        }

    }
}