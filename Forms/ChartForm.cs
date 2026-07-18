using SmartInventory.Models;
using SmartInventory.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SmartInventory.Forms
{
    public partial class ChartForm : Form
    {
        private List<Product> _all;

        public ChartForm(List<Product> all)
        {
            InitializeComponent();
            _all = all;

            //初始化繪圖區域
            chart.ChartAreas.Clear();
            chart.Legends.Clear();
            // --- 1. 左邊：數量直條圖區域 ---
            var areaQty = new ChartArea("AreaQuantity");
            areaQty.AxisX.MajorGrid.Enabled = false;
            areaQty.AxisY.MajorGrid.Enabled = false;
            chart.ChartAreas.Add(areaQty);

            // --- 2. 右邊：金額環形圖區域 ---
            var areaValue = new ChartArea("AreaValue");
            chart.ChartAreas.Add(areaValue);

            // 圖例統一設定於下方置中
            var legend = new Legend("L")
            {
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center
            };
            chart.Legends.Add(legend);


            var stat = ProductService.Statistics(_all); // 統計各分類
            DrawChart(stat);//繪製圖表

        }


        private void DrawChart(Dictionary<string, decimal[]> stat)
        {
            chart.Series.Clear();
            chart.Legends["L"].CustomItems.Clear();

            var areaQty = chart.ChartAreas["AreaQuantity"];

            // 針對左側直條圖的 X 軸防重疊處理
            areaQty.AxisX.Interval = stat.Count > 15 ? 0 : 1;
            areaQty.AxisX.LabelStyle.Interval = stat.Count > 15 ? 0 : 1;
            areaQty.AxisX.LabelStyle.Angle = stat.Count > 5 ? -45 : 0;

            // --- 數列 1：數量直條圖 ---
            var sQty = new Series("庫存量")
            {
                ChartType = SeriesChartType.Column,
                ChartArea = "AreaQuantity",
                IsValueShownAsLabel = true,
                LabelForeColor = Color.Black,
                IsVisibleInLegend = false
            };

            // --- 數列 2：金額環形圖 ---
            var sValue = new Series("總金額")
            {
                ChartType = SeriesChartType.Doughnut, // 【變更】改為具現代感的環形圖
                ChartArea = "AreaValue",
                IsValueShownAsLabel = true,
                LabelForeColor = Color.Black,
                Label = "#VALX \n #VAL{C0}"
            };

            // 【關鍵優化】強制將標籤放置於圓環外部，自動啟動牽引線機制防止文字重疊
            sValue["PieLabelStyle"] = "Outside";

            int n = stat.Count, xi = 1, ci = 0;
            foreach (var kv in stat)
            {
                var color = GetColor(ci, n);

                decimal qtyAmount = (kv.Value != null && kv.Value.Length > 0) ? kv.Value[0] : 0;
                decimal totalValue = (kv.Value != null && kv.Value.Length > 1) ? kv.Value[1] : 0;

                // 1. 左側直條圖綁定
                int ptQtyIdx = sQty.Points.AddXY(xi, (double)qtyAmount);
                sQty.Points[ptQtyIdx].AxisLabel = kv.Key;
                sQty.Points[ptQtyIdx].Color = color;

                // 2. 右側環形圖綁定
                int ptValIdx = sValue.Points.AddXY(kv.Key, (double)totalValue);
                sValue.Points[ptValIdx].Color = color;
                sValue.Points[ptValIdx].LegendText = kv.Key;

                xi++;
                ci++;
            }

            chart.Series.Add(sQty);
            chart.Series.Add(sValue);
        }



        private static Color GetColor(int index, int total) =>
           ColorFromHsl(360f * index / Math.Max(total, 1), 0.65f, 0.52f);


        private static Color ColorFromHsl(float h, float s, float l)
        {
            float c = (1 - Math.Abs(2 * l - 1)) * s;
            float x = c * (1 - Math.Abs(h / 60 % 2 - 1));
            float m = l - c / 2;

            (float r, float g, float b) = h switch
            {
                < 60 => (c, x, 0f),
                < 120 => (x, c, 0f),
                < 180 => (0f, c, x),
                < 240 => (0f, x, c),
                < 300 => (x, 0f, c),
                _ => (c, 0f, x)
            };

            int R = Math.Clamp((int)((r + m) * 255), 0, 255);
            int G = Math.Clamp((int)((g + m) * 255), 0, 255);
            int B = Math.Clamp((int)((b + m) * 255), 0, 255);

            return Color.FromArgb(R, G, B);
        }


        }
}
