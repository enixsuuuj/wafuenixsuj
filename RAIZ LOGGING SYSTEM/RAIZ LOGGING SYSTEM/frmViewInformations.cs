using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace RAIZ_LOGGING_SYSTEM
{
    public partial class frmViewInformations : Form
    {
        public frmViewInformations()
        {
            InitializeComponent();
        }

        private void frmViewInformations_Load(object sender, EventArgs e)
        {
            dataview();
        }
        public void dataview()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from information", conn);
            MySqlDataReader dRead;

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    dRead = cmd.ExecuteReader();
                    lvSAY.Items.Clear();

                    while (dRead.Read())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = dRead["ID"].ToString();
                        lvi.SubItems.Add(dRead["date"].ToString());
                        lvi.SubItems.Add(dRead["too"].ToString());
                        lvi.SubItems.Add(dRead["thru"].ToString());
                        lvi.SubItems.Add(dRead["froom"].ToString());
                        lvi.SubItems.Add(dRead["subject"].ToString());
                        lvSAY.Items.Add(lvi);
                    }
                    dRead.Close();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    //int sum = 0;
                    //foreach (ListViewItem l in lvSAY.Items)
                    //{
                    //    sum += int.Parse(l.SubItems[6].Text);
                    //}
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Record Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
