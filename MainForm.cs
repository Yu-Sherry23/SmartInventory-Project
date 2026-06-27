namespace SmartInventory
{
    public partial class MainForm : Form
    {
        // 畫面（Designer）已備好下列控件，直接照投影片使用即可：
        //   dgv（清單）、txtSearch、cmbCategory、txtName/txtCategory/txtQuantity/txtPrice、
        //   btnAdd/btnUpdate/btnDelete、btnCheck、lblTotal
        //
        // TODO（13-1）：宣告全部商品清單
        //   private List<Product> all = new List<Product>();

        public MainForm()
        {
            InitializeComponent();

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
