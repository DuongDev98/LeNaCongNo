using Project.Common;
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
    public partial class Query : Form
    {
        public Query()
        {
            InitializeComponent();
        }

        private void tsbTruyVan_Click(object sender, EventArgs e)
        {
            string query = txtQuery.Text.Trim();
            if (query.Length == 0)
            {
                Msg.ShowWarning("Query trống");
                return;
            }
            string error;
            if (DatabaseSql.ExcuteQuery(query, null, out error))
            {
                Msg.ShowInfo("Thực hiện xong");
            }
            else
            {
                Msg.ShowWarning(error);
            }
        }
    }
}
