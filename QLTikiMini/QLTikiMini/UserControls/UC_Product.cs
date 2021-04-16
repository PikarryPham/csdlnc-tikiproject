using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTikiMini.UserControls
{
    public partial class UC_Product : UserControl
    {
        public int IdSanPham;
        public UC_Product()
        {
            InitializeComponent();
        }

        public void SetInfo(string info)
        {
            lblProductInfo.Text = info;
        }

        public Button GetButton()
        {
            return btnBuy;
        }
    }
}
