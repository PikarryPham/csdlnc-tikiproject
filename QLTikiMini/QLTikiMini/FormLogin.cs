using DataAccess;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUsername.Text))
            {
                lblStatus.Text = "Vui lòng nhập đầy đủ thông tin đăng nhập";
                return;
            }
            if (!radioKH.Checked && !radioNBH.Checked && !radioNV.Checked)
            {
                lblStatus.Text = "Vui lòng chọn loại tài khoản đăng nhập";
                return;
            }
            if (radioKH.Checked)
            {
                LoginDataAccess da = new LoginDataAccess();
                DataTable tbl = da.LoginKH(txtUsername.Text, txtPassword.Text);
                if (da.ReturnCode == 0)
                {
                    UserInfo.TenKH = tbl.Rows[0]["TEN_KH"].ToString();
                    UserInfo.IDKH = Convert.ToInt32(tbl.Rows[0]["ID_KH"]);
                    Form form = new FormSearch();
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                    this.Close();
                }
                else
                    lblStatus.Text = da.ReturnMess;
                return;
            }
            if (radioNBH.Checked)
            {
                
                lblStatus.Text = "NBH Login successfully";
            }
            if (radioNV.Checked)
            {
                lblStatus.Text = "NV Login successfully";
            }
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Form form = new FormCreateAccount();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
            this.Close();
        }

        private void LblStatus_Click(object sender, EventArgs e)
        {
            //dnthing...
        }
    }
}
