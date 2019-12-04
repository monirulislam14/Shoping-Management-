using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopInfomation.Models
{
    public class ShopViewModel
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public string Contact { get; set; }
        public int Count { get; set; }
        public int LevelId { get; set; }
        public string LevelNo { get; set; }
        public int BlockId { get; set; }
        public string BlockName { get; set; }
    }
}