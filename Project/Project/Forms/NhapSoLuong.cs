using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Forms
{
    public partial class NhapSoLuong : Form
    {
        public NhapSoLuong()
        {
            InitializeComponent();
        }

        private void txtValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnOK.PerformClick();
            }
            else if (char.IsDigit((char)e.KeyCode))
            {
                e.Handled = true;
            }
        }

        public int Value
        {
            get
            {
                string text = txtValue.Text.Trim();
                text = text.Length == 0 ? "0" : text;
                return int.Parse(text);
            }
        }
    }
}
