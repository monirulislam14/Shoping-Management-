using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopInfomation.BLL;
using ShopInfomation.Models;

namespace ShopInfomation.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult GetAllShopInfo()
        {
            ShopInfoManager manager = new ShopInfoManager();
            return View(manager.GetAllShopInfo());
        }
        public ActionResult Create()
        {
            BlockManager bManager = new BlockManager();
            LevelManager lManager = new LevelManager();
            ViewBag.AllBlock = bManager.GetAllBlock();
            ViewBag.AllLevel = lManager.GetAllLevel();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Shop shop)
        {
            ShopInfoManager manager = new ShopInfoManager();
            if (manager.SaveShop(shop))
            {
                return RedirectToAction("ShopAndBlockView", "Shop");
            }
            return RedirectToAction("Create", "Shop");

        
        }
        public ActionResult ShopAndBlockView()
        {
            ShopInfoManager manager = new ShopInfoManager();


            return View(manager.GetShopAndBlockView());
        }
        [HttpPost]
        public ActionResult ShopAndBlockView(ViewBySearch search)
        {
            ShopInfoManager manager = new ShopInfoManager();
            ShopViewModel vShop = new ShopViewModel();
            ViewBag.Count = vShop.Count;
            return View(manager.GetShopAndBlockViewBySearch(search));
        }

        public ActionResult EditShop()
        {
            BlockManager bManager = new BlockManager();
            LevelManager lManager = new LevelManager();
            ShopInfoManager manager = new ShopInfoManager();
            int id = Convert.ToInt32(Request.QueryString["shopId"]);
            ViewBag.AllBlock = bManager.GetAllBlock();
            ViewBag.AllLevel = lManager.GetAllLevel();
            return View(manager.ShopAndBlockViewEdit(id));
        }
        [HttpPost]
        public ActionResult EditShop(ShopViewModel shop)
        {
            int id = Convert.ToInt32(Request.QueryString["shopId"]);
            ShopInfoManager manager = new ShopInfoManager();
            ViewBag.Message = manager.SaveUpdatedShop(shop, id);
            return RedirectToAction("ShopAndBlockView", "Shop");
        }

        public ActionResult DeleteShop()
        {
            int id = Convert.ToInt32(Request.QueryString["shopId"]);
            ShopInfoManager manager = new ShopInfoManager();
            bool isDelete = manager.ShopAndBlockViewDelete(id);
            return RedirectToAction("ShopAndBlockView", "Shop");
        }
    }
}