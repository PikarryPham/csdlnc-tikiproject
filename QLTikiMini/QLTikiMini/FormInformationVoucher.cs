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
    public partial class FormInformationVoucher : Form
    {
        private int maVoucher;
        public FormInformationVoucher()
        {
            InitializeComponent();
            lblUserInfo.Text = "Hello " + UserInfo.TenKH;
        }

        public void SetVoucherData(int id, string thongTinVoucher)
        {
            maVoucher = id;
            lblVoucherInfo.Text = thongTinVoucher;
        }

        private void btnBuy_Click(object sender, EventArgs e)
        {
            InformationVoucherDataAccess da = new InformationVoucherDataAccess();
            da.KICHBAN1_MUAVOUCHER(UserInfo.IDKH, maVoucher, Convert.ToInt32(txtAmount.Text), txtPhone.Text);
            MessageBox.Show(da.ReturnMess);
            if (da.ReturnCode == 0)
                this.Close();
        }
        private void BtnBack_Click_1(object sender, EventArgs e)
        {
            Form form = new FormSearchVoucher();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }
    }
}
