using Project.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            mnuHoaDonBanHang.Click += MnuHoaDonBanHang_Click;
            mnuDanhMucMatHang.Click += MnuDanhMucMatHang_Click;
            mnuDanhMucKhachHang.Click += MnuDanhMucKhachHang_Click;
            mnuDanhMucBangGia.Click += MnuDanhMucBangGia_Click;
            mnuQuanLyBanHang.Click += MnuQuanLyBanHang_Click;
            mnuTongHopCongNo.Click += MnuTongHopCongNo_Click;
            mnuChiTietCongNo.Click += MnuChiTietCongNo_Click;

            MnuHoaDonBanHang_Click(null, null);
        }

        private void MnuChiTietCongNo_Click(object sender, EventArgs e)
        {
            OpenTapMain(new ChiTietCongNo());
        }

        private void MnuTongHopCongNo_Click(object sender, EventArgs e)
        {
            OpenTapMain(new TongHopCongNo());
        }

        private void MnuQuanLyBanHang_Click(object sender, EventArgs e)
        {
            OpenTapMain(new QuanLyBanHang());
        }

        private void MnuDanhMucBangGia_Click(object sender, EventArgs e)
        {
            OpenTapMain(new DanhSachBangGia());
        }

        private void MnuDanhMucKhachHang_Click(object sender, EventArgs e)
        {
            OpenTapMain(new DanhSachKhachHang());
        }

        private void MnuDanhMucMatHang_Click(object sender, EventArgs e)
        {
            OpenTapMain(new DanhSachMatHang());
        }

        private void MnuHoaDonBanHang_Click(object sender, EventArgs e)
        {
            OpenTapMain(new HoaDonBanHang(""));
        }

        private void OpenTapMain(Form form)
        {
            //kiểm tra xem tabmain có chưa
            TabPage tabPage = null;
            foreach (TabPage page in tabMain.TabPages)
            {
                if (page.Text == form.Text)
                {
                    tabPage = page;
                    break;
                }
            }

            if (tabPage == null)
            {
                //thêm tab
                tabPage = new TabPage();
                tabPage.Text = form.Text;
                tabMain.TabPages.Add(tabPage);

                form.FormBorderStyle = FormBorderStyle.None;
                form.MdiParent = this;
                form.Parent = tabPage;
                form.Dock = DockStyle.Fill;

                form.Show();
            }

            tabMain.SelectedTab = tabPage;
        }
    }
}
