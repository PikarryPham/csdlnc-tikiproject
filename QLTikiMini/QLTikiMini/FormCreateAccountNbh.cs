using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;

namespace QLTikiMini
{
    public partial class FormCreateAccountNbh : Form
    {
        public FormCreateAccountNbh()
        {
            InitializeComponent();
        }

        private void BtnCreateAccount_Click(object sender, EventArgs e)
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
            CreateAccountNbhDataAccess da = new CreateAccountNbhDataAccess();
            da.CREATE_ACCOUNT_NBH(txtTen.Text, txtUsername.Text, txtpass.Text, txtVat.Text, txtSDT.Text, txtmail.Text,txtMDKKD.Text, txtcuahang.Text, txtdchich.Text, txtDMN.Text, txtMHVH.Text);
            MessageBox.Show(da.ReturnMess);
            if (da.ReturnCode == 0)
            {
                Form form = new FormLogin();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.Show();
                this.Close();
            }
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
