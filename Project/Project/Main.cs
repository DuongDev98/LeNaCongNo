using Project.Forms;
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
            mnuQuanLyThanhToan.Click += MnuQuanLyThanhToan_Click;
            mnuTongHopCongNo.Click += MnuTongHopCongNo_Click;
            mnuChiTietCongNo.Click += MnuChiTietCongNo_Click;
            mnuQuery.Click += MnuQuery_Click;
        }

        private void MnuQuery_Click(object sender, EventArgs e)
        {
            OpenTapMain(new Query());
        }

        private void MnuQuanLyThanhToan_Click(object sender, EventArgs e)
        {
            OpenTapMain(new QuanLyThanhToan());
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
            foreach (TabPage page in tabControl.TabPages)
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
                tabControl.TabPages.Add(tabPage);

                form.FormBorderStyle = FormBorderStyle.None;
                form.MdiParent = this;
                form.Parent = tabPage;
                form.Dock = DockStyle.Fill;

                form.Show();
            }

            tabControl.SelectedTab = tabPage;
        }
        private void tabControl_MouseDown(object sender, MouseEventArgs e)
        {
            Rectangle r = tabControl.GetTabRect(this.tabControl.SelectedIndex);
            Rectangle closeButton = new Rectangle(r.Right - 20, r.Top + (r.Height - 20) / 2, 25, 25);
            if (closeButton.Contains(e.Location))
            {
                tabControl.TabPages.Remove(tabControl.SelectedTab);
            }
        }
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool selectedPage = tabControl.SelectedTab == tabControl.TabPages[e.Index];

            //reset title
            e.Graphics.FillRectangle(new SolidBrush(selectedPage ? Color.White : Color.WhiteSmoke), e.Bounds);

            //vẽ nút close
            int btnCloseWidth = 20, btnCloseHeight = 20, leftBtnClose = e.Bounds.Right - btnCloseWidth - 5, topBtnClose = e.Bounds.Top + (e.Bounds.Height - btnCloseHeight) / 2;
            Rectangle btnClose = new Rectangle(leftBtnClose, topBtnClose, 20, 20);
            e.Graphics.FillRectangle(new SolidBrush(Color.OrangeRed), btnClose);

            SizeF size = CalculateSizeText(e.Font, "X");
            e.Graphics.DrawString("X", e.Font, Brushes.White, btnClose.Left + (btnClose.Width - size.Width) / 2, btnClose.Top + (btnClose.Height - size.Height) / 2);

            //Title page
            //Lấy dữ liệu tối đa có thể hiển thị
            string pageTitle = tabControl.TabPages[e.Index].Text;

            string lastTile = "";
            bool oversizeText = CalculateSizeText(e.Font, pageTitle).Width > e.Bounds.Width - btnCloseWidth - 5;
            for (int i = 0; i < pageTitle.Length; i++)
            {
                //hiển thị thêm ... khi dữ liệu dài hơn vùng hiển thị
                string temp = pageTitle.Substring(0, i + 1) + (oversizeText ? "..." : "");
                if (CalculateSizeText(e.Font, temp).Width < e.Bounds.Width - btnCloseWidth - 5)
                {
                    lastTile = temp;
                    size = CalculateSizeText(e.Font, temp);
                }
                else break;
            }
            RectangleF rectangleF = new RectangleF(e.Bounds.Left + 5, e.Bounds.Top + (e.Bounds.Height - size.Height) / 2, leftBtnClose, e.Bounds.Height);
            e.Graphics.DrawString(lastTile, e.Font, Brushes.Black, rectangleF);

            Rectangle customSize = e.Bounds;
            customSize.Width = (int)CalculateSizeText(e.Font, pageTitle).Width + btnCloseWidth + 5;

            e.DrawFocusRectangle();
        }

        private SizeF CalculateSizeText(Font font, string text)
        {
            Image fakeImage = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(fakeImage);
            return graphics.MeasureString(text, font);
        }
    }
}
