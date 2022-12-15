using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Screens
{
    public partial class QuanLyBanHang : Form
    {
        public QuanLyBanHang()
        {
            InitializeComponent();

            button1.Click += Button1_Click;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            TaiHoaDon("");
        }

        private void QuanLyBanHang_Load(object sender, EventArgs e)
        {
            TaiHoaDon("");
        }

        private void TaiHoaDon(string TDONHANGID)
        {
            splitMain.Panel2.Controls.Clear();
            HoaDonBanHang hoaDonBanHangForm = new HoaDonBanHang(TDONHANGID);
            hoaDonBanHangForm.TopLevel = false;
            hoaDonBanHangForm.AutoScroll = true;
            hoaDonBanHangForm.FormBorderStyle = FormBorderStyle.None;
            hoaDonBanHangForm.Dock = DockStyle.Fill;
            foreach (Control ctrl in hoaDonBanHangForm.Controls)
            {
                if (ctrl.Name == "splitMain1")
                {
                    (ctrl as SplitContainer).SplitterDistance = 100;
                }
            }
            splitMain.Panel2.Controls.Add(hoaDonBanHangForm);
            hoaDonBanHangForm.Show();
        }
    }
}
