using SmartInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Services
{
    internal class ProductService
    {
        public static readonly string[] Categories =
            { "電子", "生活", "文具", "食品" };


        public static (decimal,int) GetTotalValue(List<Product> all)
        {
            //decimal qty,total = 0; 本來可以寫在一起，但是qty是int要另外寫

            decimal total = 0;
            int qty = 0;

            foreach (Product product in all)
            {
                total += product.TotalValue;
                qty += product.Quantity;
            }

            return (total,qty);

        }



        
        
       public static List<Product> GetLowStock(List<Product> all,int lowStock=10)//外部輸入=>參數給預設值，不給預設值也可以public static List<Product> GetLowStock(List<Product> all,int lowStock)
        {
            
            var result = new List<Product>();
            foreach(var p in all)
            {
                if (p.Quantity < lowStock)
                {
                    result.Add(p);
                    //Console.WriteLine($"{p.Name} {p.Quantity}");
                }
            }
            return result;
        }

        public static List<Product> Search(List<Product> all, string keyword, string category)
        {
            //1. 判斷是否都為空字串 (「如果沒有輸入關鍵字 + 選全部分類，就直接回傳全部資料」)
            if (keyword == string.Empty && category == string.Empty) return all;

            //2. 是否是搜尋關鍵字(資料沒有含關鍵字，不符合skip（continue)往下一筆，每一筆都沒關鍵字就不往下Category篩選，關鍵字搜尋結果為空(空就是result這個List裡面沒被Add任何東西，List空filtered空就無任何資料view顯示)/符合才往下篩選Category)
            //3. 是否是搜尋分類
            var result = new List<Product>(); //建立一個「空的清單」，用來裝篩選後的結果
            foreach (var p in all)
            {
                if (!p.Name.Contains(keyword)) continue;
                if (category == "全部" || p.Category.Contains(category))
                {
                    result.Add(p); //不管商品分類是什麼，全部或任何分類，全部都會進 result
                }
            }

            //4.回傳篩選後的商品集合
            return result;
        }
    }


}

