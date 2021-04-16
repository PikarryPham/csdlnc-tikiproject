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
    public partial class FormCreateAccountKh : Form
    {
        public FormCreateAccountKh()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {
                    if (string.IsNullOrEmpty(((TextBox)x).Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản");
                        return;
                    }
                }
            }
            CreateAccountKhDataAccess da = new CreateAccountKhDataAccess();
            da.CREATE_ACCOUNT_KH(txtTen.Text, txtDiaChi.Text, txtEmail.Text, txtSdt.Text, txtUsername.Text, txtPassword.Text);
            MessageBox.Show(da.ReturnMess);
            if (da.ReturnCode == 0)
            {
                Form form = new FormLogin();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                this.Close();
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            //dsthing....
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
