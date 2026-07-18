using SmartInventory.Data;
using SmartInventory.Models;
using SmartInventory.Services;
using System.ComponentModel;
using System.Diagnostics;

namespace SmartInventory
{
    public partial class MainForm : Form
    {
        // 畫面（Designer）已備好下列控件，直接照投影片使用即可：
        //   dgv（清單）、txtSearch、cmbCategory、txtName/txtCategory/txtQuantity/txtPrice、
        //   btnAdd/btnUpdate/btnDelete、btnCheck、lblTotal
        //
        // TODO（13-1）：宣告全部商品清單
        private List<Product> all = new List<Product>();
        //綁定畫面用
        private BindingList<Product> view = new BindingList<Product>();

        public MainForm()
        {
            InitializeComponent();
            dgv.DataSource = view;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;

            //和屬性比，系統會先以這裡(建構式裡的)為準
            nudStockNum.Minimum = 0;
            nudStockNum.Maximum = 10000;


            //設定ComboBox
            cmbCategory.Items.Add("全部");
            cmbCategory.Items.AddRange(ProductService.Categories);
            cmbCategory.SelectedIndex = 0;

            cmbInputCategory.Items.AddRange(ProductService.Categories);
            cmbInputCategory.SelectedIndex = 0;


            DBHelper.InitDb();
            all = DBHelper.GetAllProducts();

            foreach (var p in all)
            {
                Debug.WriteLine(p);
            }

            RefreshView();


            // TODO（13-1）：啟動就讀資料庫
            //   DbHelper.InitDb();
            //   all = DbHelper.GetAllProducts();

            // TODO（13-2）：接上畫面
            //   宣告 BindingList<Product> view，dgv.DataSource = view;
            //   cmbCategory 加入「全部/電子/生活/文具/食品」並 SelectedIndex = 0;
            //   掛事件：txtSearch.TextChanged、cmbCategory.SelectedIndexChanged、dgv.CellClick → RefreshView/帶入欄位;
            //   呼叫 RefreshView();

            // TODO（13-3）：動態加「統計圖表」按鈕
            //   var btnChart = new Button { Text = "統計圖表", AutoSize = true };
            //   btnChart.Click += (_, _) => new ChartForm(all).ShowDialog();
            //   flowLayoutPanel1.Controls.Add(btnChart);
        }

        public void RefreshView()
        {
            //篩選機制 filtered=清單result
            var filtered = ProductService.Search(all, txtSearch.Text.Trim(), cmbCategory.Text);
            view.Clear();
            foreach (var p in filtered) //p in filtered(清單result)
            {
                view.Add(p);
            }

            var (total, qty) = ProductService.GetTotalValue(all);
            lblTotal.Text = $"總庫存價值:${total} | 庫存總數量:{qty}";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ReadInput(out Product p)) return; //先檢查輸入，如果不正確 → 直接停止（return）

            //插入資料庫
            DBHelper.InsertProduct(p);
            all = DBHelper.GetAllProducts();
            //all=DBHelper.GetAllProducts(); 也可以這樣寫all.Add(p);

            //更新資料庫
            RefreshView();
            //輸入區變空白
            ClearInput();
        }

        private void ClearInput()
        {
            TextBox[] boxs = { txtName, txtQuantity, txtPrice };
            //cmbInputCategory.SelectedIndex=0;
            foreach (var b in boxs) b.Text = string.Empty;

        }



        private bool ReadInput(out Product product) //回傳true和false 並由輸入端組裝product也就是p
        {
            product = new Product();//需宣告product，因為prodcut是物件需new它

            if (txtName.Text.Trim() == "" || cmbInputCategory.Text == "")
            {
                MessageBox.Show("商品名稱或分類不能為空!");
                return false;
            }

            if (!int.TryParse(txtQuantity.Text, out int q) || q <= 0)
            {
                MessageBox.Show("數量輸入不正確!");
                return false;
            }
            if (!decimal.TryParse(txtPrice.Text, out decimal p) || p <= 0)
            {
                MessageBox.Show("金額輸入不正確!");
                return false;
            }

            product.Name = txtName.Text;
            product.Category = cmbInputCategory.Text;
            product.Quantity = q;
            product.Price = p;

            return true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= view.Count) return;
            var p = view[e.RowIndex];
            txtName.Text = p.Name;
            cmbInputCategory.Text = p.Category;
            txtQuantity.Text = p.Quantity.ToString();
            txtPrice.Text = p.Price.ToString();

        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            //CellClick有綁定事件所以可以用e寫，這裡沒有綁定事件所以不能用e寫
            if (dgv.CurrentRow == null) return;

            int index = dgv.CurrentRow.Index;
            var p = view[index]; //從Binding畫面清單(view)拿出 DataGridView 目前選到index那一列的整個物件 Product

            if (MessageBox.Show($"是否刪除Id:{p.Id}-{p.Name}", "確認",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;


            DBHelper.DeleteProduct(p);
            all = DBHelper.GetAllProducts();
            RefreshView();

            //如果你原本選的位置已經不存在了就改選「最後一筆」
            if (view.Count > 0)
            {
                if (index >= view.Count) index = view.Count - 1;
            }

            //維持當下位置
            dgv.Rows[index].Selected = true;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null) return;

            if (!ReadInput(out Product p)) return;

            int index = dgv.CurrentRow.Index;
            //取得對應商品的實際Id
            p.Id = view[index].Id;

            if (MessageBox.Show($"是否更新Id:{p.Id}-{p.Name}", "確認",
                MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            //更新商品
            DBHelper.UpdateProduct(p);
            all = DBHelper.GetAllProducts();
            RefreshView();
            //維持當下位置
            dgv.Rows[index].Selected = true;

        }

        //當 cmbCategory 「有任何變化」就觸發RefreshView()更新畫面;不用按按鈕，下拉選單選項改變就觸發

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshView();
        }

        //當 txtSearch 裡面的文字「有任何變化」就觸發RefreshView()更新畫面;不用按按鈕，系統「邊打字邊幫你搜尋」
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int lowStock = (int)nudStockNum.Value; //強制犧牲一下，decimal轉int
            var result=ProductService.GetLowStock(all, lowStock);
            if (result.Count == 0)
            {
                MessageBox.Show("庫存狀況良好!");
                return;
            }

            string lowStockStr = $"低庫存警告:少於{lowStock}數量\n\n";
            foreach(var p in result)
            {
                lowStockStr += $"{p.Name} 數量:{p.Quantity}\n";
            }
            MessageBox.Show(lowStockStr);

        }




        // ───── 以下方法 13-2 才會寫（按鈕事件可在 Designer 雙擊自動產生）─────
        // 13-2：RefreshView()             刷新清單與總價值（用 ProductService.Search 過濾）
        // 13-2：ReadInput(out Product p)  讀輸入＋TryParse 驗證
        // 13-2：ClearInput()              清空輸入框
        // 13-2：btnAdd_Click             新增 → InsertProduct → 重讀 → RefreshView → ClearInput
        // 13-2：dgv_CellClick            點選列帶回輸入欄
        // 13-2：btnUpdate_Click          修改（p.Id 沿用主鍵）→ UpdateProduct → 重讀 → RefreshView
        // 13-2：btnDelete_Click          確認後 DeleteProduct → 重讀 → RefreshView
        // 13-2：btnCheck_Click           ProductService.GetLowStock → MessageBox 列出
    }
}
