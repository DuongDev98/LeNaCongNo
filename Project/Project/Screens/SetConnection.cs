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
    public partial class SetConnection : Form
    {
        public SetConnection()
        {
            InitializeComponent();
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            Connection.server = txtServer.Text.Trim();
            Connection.database = txtDatabase.Text.Trim();
            string error;
            DataTable dt = DatabaseSql.GetTable(@"SELECT a.RDB$RELATION_NAME FROM RDB$RELATIONS a WHERE COALESCE(RDB$SYSTEM_FLAG, 0) = 0 AND RDB$RELATION_TYPE = 0", null, out error);
            if (error.Length > 0)
            {
                Msg.ShowWarning(error);
            }
            else
            {
                Hide();
                Main fMain = new Main();
                fMain.Show();
            }
        }
    }
}
