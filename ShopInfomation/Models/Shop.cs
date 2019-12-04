using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopInfomation.Models
{
    public class Shop
    {
        public int ShopId { get; set; }
      
        public string ShopName { get; set; }
        public string Contact { get; set; }

        public int LevelId { get; set; }

        public int BlockId { get; set; }
            
        
    
    }
}