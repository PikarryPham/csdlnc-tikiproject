using DataAccess;
using QLTikiMini.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTikiMini
{
    public partial class FormSearchProducts : Form
    {
        public FormSearchProducts()
        {
            InitializeComponent();
            lblUserInfo.Text = "Hello " + UserInfo.TenKH;
            LoadData();
        }

        private void btnBuy_Click(object sender, EventArgs e, int id)
        {
            MessageBox.Show("Click chọn sản phẩm " + id);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form form = new FormSearch();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            panelProductList.Controls.Clear();
            DataTable tbl = new SearchProductsDataAccess().KICHBAN1_GIAKHUYENMAIGIAMDAN(txtSearch.Text);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                UC_Product uc = new UC_Product();
                uc.IdSanPham = Convert.ToInt32(tbl.Rows[i]["ID_SP"].ToString());
                StringBuilder sb = new StringBuilder();
                sb.Append("Thông tin sản phẩm " + tbl.Rows[i]["TEN_SPHAM"] + Environment.NewLine);
                sb.Append("Giá niêm yết: " + Convert.ToInt32(tbl.Rows[i]["GIANIEMYET"]).ToString("#,##") + Environment.NewLine);
                sb.Append("Giá khuyến mại: " + Convert.ToInt32(tbl.Rows[i]["GIAKHUYENMAI"]).ToString("#,##") + Environment.NewLine);
                sb.Append("Hạn sử dụng sản phẩm: " + Convert.ToDateTime(tbl.Rows[i]["HANSUDUNGSP"]) + Environment.NewLine);
                sb.Append("Thời gian khuyến mãi: " + Convert.ToInt32(tbl.Rows[i]["THOIGIANKM"]).ToString("#,##") + Environment.NewLine);
                uc.SetInfo(sb.ToString());
                /*Nhấn nút mua sản phẩm thì .....*/
                uc.GetButton().Click += (_sender, EventArgs) => { btnBuy_Click(_sender, EventArgs, uc.IdSanPham); };
                panelProductList.Controls.Add(uc);
            }
        }
    }
}
