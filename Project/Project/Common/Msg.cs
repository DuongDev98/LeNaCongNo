using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project.Common
{
    public class Msg
    {
        public static void ShowInfo(string msg)
        {
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void ShowWarning(string msg)
        {
            MessageBox.Show(msg, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static DialogResult ShowYesNo(string msg)
        {
            return MessageBox.Show(msg, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
