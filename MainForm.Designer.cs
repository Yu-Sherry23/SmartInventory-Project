namespace SmartInventory
{
partial class MainForm
{
    /// <summary>Required designer variable.</summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>Clean up any resources being used.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        flowLayoutPanel1 = new FlowLayoutPanel();
        label1 = new Label();
        txtSearch = new TextBox();
        label2 = new Label();
        cmbCategory = new ComboBox();
        btnCheck = new Button();
        tableLayoutPanel2 = new TableLayoutPanel();
        label6 = new Label();
        txtPrice = new TextBox();
        label5 = new Label();
        txtQuantity = new TextBox();
        label4 = new Label();
        txtCategory = new TextBox();
        label3 = new Label();
        txtName = new TextBox();
        flowLayoutPanel2 = new FlowLayoutPanel();
        btnAdd = new Button();
        btnUpdate = new Button();
        btnDelete = new Button();
        dgv = new DataGridView();
        flowLayoutPanel3 = new FlowLayoutPanel();
        lblTotal = new Label();
        flowLayoutPanel1.SuspendLayout();
        tableLayoutPanel2.SuspendLayout();
        flowLayoutPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
        flowLayoutPanel3.SuspendLayout();
        SuspendLayout();
        //
        // flowLayoutPanel1（頂部：搜尋 / 分類 / 庫存警示）
        //
        flowLayoutPanel1.AutoSize = true;
        flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowLayoutPanel1.Controls.Add(label1);
        flowLayoutPanel1.Controls.Add(txtSearch);
        flowLayoutPanel1.Controls.Add(label2);
        flowLayoutPanel1.Controls.Add(cmbCategory);
        flowLayoutPanel1.Controls.Add(btnCheck);
        flowLayoutPanel1.Dock = DockStyle.Top;
        flowLayoutPanel1.Location = new Point(0, 0);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        flowLayoutPanel1.Padding = new Padding(10, 5, 10, 5);
        flowLayoutPanel1.Size = new Size(984, 39);
        flowLayoutPanel1.TabIndex = 0;
        //
        // label1
        //
        label1.Anchor = AnchorStyles.None;
        label1.AutoSize = true;
        label1.Location = new Point(13, 12);
        label1.Name = "label1";
        label1.Size = new Size(43, 15);
        label1.TabIndex = 0;
        label1.Text = "搜尋：";
        //
        // txtSearch
        //
        txtSearch.Anchor = AnchorStyles.None;
        txtSearch.Location = new Point(62, 8);
        txtSearch.Name = "txtSearch";
        txtSearch.Size = new Size(180, 23);
        txtSearch.TabIndex = 1;
        //
        // label2
        //
        label2.Anchor = AnchorStyles.None;
        label2.AutoSize = true;
        label2.Location = new Point(248, 12);
        label2.Name = "label2";
        label2.Size = new Size(43, 15);
        label2.TabIndex = 2;
        label2.Text = "分類：";
        //
        // cmbCategory
        //
        cmbCategory.Anchor = AnchorStyles.None;
        cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbCategory.FormattingEnabled = true;
        cmbCategory.Location = new Point(297, 8);
        cmbCategory.Name = "cmbCategory";
        cmbCategory.Size = new Size(121, 23);
        cmbCategory.TabIndex = 3;
        //
        // btnCheck
        //
        btnCheck.Anchor = AnchorStyles.None;
        btnCheck.Location = new Point(424, 8);
        btnCheck.Name = "btnCheck";
        btnCheck.Size = new Size(75, 23);
        btnCheck.TabIndex = 4;
        btnCheck.Text = "庫存警示";
        btnCheck.UseVisualStyleBackColor = true;
        //
        // tableLayoutPanel2（左側：輸入欄）
        //
        tableLayoutPanel2.ColumnCount = 2;
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
        tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tableLayoutPanel2.Controls.Add(label6, 0, 3);
        tableLayoutPanel2.Controls.Add(txtPrice, 1, 3);
        tableLayoutPanel2.Controls.Add(label5, 0, 2);
        tableLayoutPanel2.Controls.Add(txtQuantity, 1, 2);
        tableLayoutPanel2.Controls.Add(label4, 0, 1);
        tableLayoutPanel2.Controls.Add(txtCategory, 1, 1);
        tableLayoutPanel2.Controls.Add(label3, 0, 0);
        tableLayoutPanel2.Controls.Add(txtName, 1, 0);
        tableLayoutPanel2.Controls.Add(flowLayoutPanel2, 1, 4);
        tableLayoutPanel2.Dock = DockStyle.Left;
        tableLayoutPanel2.Location = new Point(0, 39);
        tableLayoutPanel2.Name = "tableLayoutPanel2";
        tableLayoutPanel2.RowCount = 5;
        tableLayoutPanel2.RowStyles.Add(new RowStyle());
        tableLayoutPanel2.RowStyles.Add(new RowStyle());
        tableLayoutPanel2.RowStyles.Add(new RowStyle());
        tableLayoutPanel2.RowStyles.Add(new RowStyle());
        tableLayoutPanel2.RowStyles.Add(new RowStyle());
        tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        tableLayoutPanel2.Size = new Size(200, 562);
        tableLayoutPanel2.TabIndex = 1;
        //
        // label6
        //
        label6.Anchor = AnchorStyles.None;
        label6.AutoSize = true;
        label6.Location = new Point(3, 94);
        label6.Name = "label6";
        label6.Size = new Size(31, 15);
        label6.TabIndex = 6;
        label6.Text = "單價";
        //
        // txtPrice
        //
        txtPrice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtPrice.Location = new Point(40, 90);
        txtPrice.Name = "txtPrice";
        txtPrice.Size = new Size(157, 23);
        txtPrice.TabIndex = 7;
        //
        // label5
        //
        label5.Anchor = AnchorStyles.None;
        label5.AutoSize = true;
        label5.Location = new Point(3, 65);
        label5.Name = "label5";
        label5.Size = new Size(31, 15);
        label5.TabIndex = 4;
        label5.Text = "數量";
        //
        // txtQuantity
        //
        txtQuantity.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtQuantity.Location = new Point(40, 61);
        txtQuantity.Name = "txtQuantity";
        txtQuantity.Size = new Size(157, 23);
        txtQuantity.TabIndex = 5;
        //
        // label4
        //
        label4.Anchor = AnchorStyles.None;
        label4.AutoSize = true;
        label4.Location = new Point(3, 36);
        label4.Name = "label4";
        label4.Size = new Size(31, 15);
        label4.TabIndex = 2;
        label4.Text = "分類";
        //
        // txtCategory
        //
        txtCategory.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtCategory.Location = new Point(40, 32);
        txtCategory.Name = "txtCategory";
        txtCategory.Size = new Size(157, 23);
        txtCategory.TabIndex = 3;
        //
        // label3
        //
        label3.Anchor = AnchorStyles.None;
        label3.AutoSize = true;
        label3.Location = new Point(3, 7);
        label3.Name = "label3";
        label3.Size = new Size(31, 15);
        label3.TabIndex = 0;
        label3.Text = "名稱";
        //
        // txtName
        //
        txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
        txtName.Location = new Point(40, 3);
        txtName.Name = "txtName";
        txtName.Size = new Size(157, 23);
        txtName.TabIndex = 1;
        //
        // flowLayoutPanel2（新增 / 更新 / 刪除）
        //
        tableLayoutPanel2.SetColumnSpan(flowLayoutPanel2, 2);
        flowLayoutPanel2.Controls.Add(btnAdd);
        flowLayoutPanel2.Controls.Add(btnUpdate);
        flowLayoutPanel2.Controls.Add(btnDelete);
        flowLayoutPanel2.Dock = DockStyle.Fill;
        flowLayoutPanel2.Location = new Point(3, 119);
        flowLayoutPanel2.Name = "flowLayoutPanel2";
        flowLayoutPanel2.Size = new Size(194, 440);
        flowLayoutPanel2.TabIndex = 8;
        //
        // btnAdd
        //
        btnAdd.Location = new Point(3, 3);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new Size(75, 23);
        btnAdd.TabIndex = 0;
        btnAdd.Text = "新增";
        btnAdd.UseVisualStyleBackColor = true;
        //
        // btnUpdate
        //
        btnUpdate.Location = new Point(84, 3);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new Size(75, 23);
        btnUpdate.TabIndex = 1;
        btnUpdate.Text = "更新";
        btnUpdate.UseVisualStyleBackColor = true;
        //
        // btnDelete
        //
        btnDelete.Location = new Point(3, 32);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new Size(75, 23);
        btnDelete.TabIndex = 2;
        btnDelete.Text = "刪除";
        btnDelete.UseVisualStyleBackColor = true;
        //
        // dgv（右側：商品清單）
        //
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgv.Dock = DockStyle.Fill;
        dgv.Location = new Point(200, 39);
        dgv.Name = "dgv";
        dgv.ReadOnly = true;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.Size = new Size(784, 562);
        dgv.TabIndex = 2;
        //
        // flowLayoutPanel3（底部：總價值）
        //
        flowLayoutPanel3.AutoSize = true;
        flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        flowLayoutPanel3.BorderStyle = BorderStyle.FixedSingle;
        flowLayoutPanel3.Controls.Add(lblTotal);
        flowLayoutPanel3.Dock = DockStyle.Bottom;
        flowLayoutPanel3.Location = new Point(200, 558);
        flowLayoutPanel3.Name = "flowLayoutPanel3";
        flowLayoutPanel3.Padding = new Padding(6);
        flowLayoutPanel3.Size = new Size(784, 43);
        flowLayoutPanel3.TabIndex = 3;
        //
        // lblTotal
        //
        lblTotal.Anchor = AnchorStyles.None;
        lblTotal.AutoSize = true;
        lblTotal.Font = new Font("Microsoft JhengHei UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 136);
        lblTotal.ForeColor = Color.FromArgb(0, 192, 0);
        lblTotal.Location = new Point(9, 13);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(105, 17);
        lblTotal.TabIndex = 0;
        lblTotal.Text = "總庫存價值：$ 0";
        //
        // MainForm
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(984, 601);
        Controls.Add(flowLayoutPanel3);
        Controls.Add(dgv);
        Controls.Add(tableLayoutPanel2);
        Controls.Add(flowLayoutPanel1);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SmartInventory 智能庫存管理系統";
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        tableLayoutPanel2.ResumeLayout(false);
        tableLayoutPanel2.PerformLayout();
        flowLayoutPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
        flowLayoutPanel3.ResumeLayout(false);
        flowLayoutPanel3.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private FlowLayoutPanel flowLayoutPanel1;
    private Label label1;
    private TextBox txtSearch;
    private Label label2;
    private ComboBox cmbCategory;
    private Button btnCheck;
    private TableLayoutPanel tableLayoutPanel2;
    private Label label6;
    private Label label5;
    private Label label4;
    private Label label3;
    private TextBox txtPrice;
    private TextBox txtQuantity;
    private TextBox txtCategory;
    private TextBox txtName;
    private FlowLayoutPanel flowLayoutPanel2;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private DataGridView dgv;
    private FlowLayoutPanel flowLayoutPanel3;
    private Label lblTotal;
}
}
