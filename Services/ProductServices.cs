using SmartInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Services
{
    internal class ProductServices
    {
        public class ProductSerivices
        {
            public static List<Product> Search(List<Product> all, string keyword, string category)
            {
                //1. 判斷是否都為空字串
                if (keyword == string.Empty && category == string.Empty) return all;

                //2. 是否是搜尋關鍵字
                //3. 是否是搜尋分類
                var result = new List<Product>(); //建立一個「空的清單」，用來裝篩選後的結果
                foreach (var p in all)
                {
                    if (!p.Name.Contains(keyword)) continue;
                    if (category == "全部" || p.Category.Contains(category))
                    {
                        result.Add(p);
                    }
                }

                //4.回傳篩選後的商品集合
                return result;
            }
        }


    }
}
