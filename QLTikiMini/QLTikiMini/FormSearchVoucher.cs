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
    public partial class FormSearchVoucher : Form
    {
        public FormSearchVoucher()
        {
            InitializeComponent();
            lblUserInfo.Text = "Hello " + UserInfo.TenKH;
            LoadData();
        }

        private void btnBuy_Click(object sender, EventArgs e, int voucherId, string thongTinVoucher)
        {
            FormCollection fc = Application.OpenForms;
            foreach (Form frm in fc)
            {
                if (frm.Name == "FormInformationVoucher")
                {
                    frm.Close();
                    break;
                }
            }

            FormInformationVoucher form = new FormInformationVoucher();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.SetVoucherData(voucherId, thongTinVoucher);
            form.Show();
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
            DataTable tbl = new SearchVoucherDataAccess().KICHBAN1_RATEGIAMGIA(txtSearch.Text);
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                UC_Product uc = new UC_Product();
                uc.IdSanPham = Convert.ToInt32(tbl.Rows[i]["ID_VOUCHER"].ToString());
                StringBuilder sb = new StringBuilder();
                sb.Append("Thông tin voucher " + tbl.Rows[i]["TENVOUCHER"] + Environment.NewLine);
                sb.Append("Giá tiền: " + Convert.ToInt32(tbl.Rows[i]["GIATIEN"]).ToString("#,##") + Environment.NewLine);
                sb.Append("Giá khuyến mại: " + Convert.ToInt32(tbl.Rows[i]["GIAKHUYENMAI"]).ToString("#,##") + Environment.NewLine);
                sb.Append("Thời hạn sử dụng: " + DateTime.Parse(tbl.Rows[i]["THOIHANSUDUNG"].ToString()).ToString("dd/MM/yyyy") + Environment.NewLine);
                uc.SetInfo(sb.ToString());
                uc.GetButton().Click += (_sender, EventArgs) => { btnBuy_Click(_sender, EventArgs, uc.IdSanPham, sb.ToString()); };
                panelProductList.Controls.Add(uc);
            }
        }
    }
}
