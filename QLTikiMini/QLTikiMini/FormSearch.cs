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
    public partial class FormSearch : Form
    {
        public FormSearch()
        {
            InitializeComponent();
            lblUserInfo.Text = "Hello " + UserInfo.TenKH;
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            Form form = new FormSearchProducts();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void btnVoucher_Click(object sender, EventArgs e)
        {
            Form form = new FormSearchVoucher();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Form form = new FormLogin();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }
    }
}
