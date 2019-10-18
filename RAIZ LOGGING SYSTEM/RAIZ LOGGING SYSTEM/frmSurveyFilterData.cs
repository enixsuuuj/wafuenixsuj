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
    public partial class frmSurveyFilterData : Form
    {
        public frmSurveyFilterData()
        {
            InitializeComponent();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void count()
        {
   
        }
        private void FilterData_Load(object sender, EventArgs e)
        {
            dataview();
            count();
        }
        public void dataview()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging", conn);
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
                        lvi.Text = dRead["surveyno"].ToString();
                        lvi.SubItems.Add(dRead["date"].ToString());
                        lvi.SubItems.Add(dRead["nameofinterviewee"].ToString());
                        lvi.SubItems.Add(dRead["age"].ToString());
                        lvi.SubItems.Add(dRead["presentadd"].ToString());
                        lvi.SubItems.Add(dRead["homeadd"].ToString());
                        lvi.SubItems.Add(dRead["datebirth"].ToString());
                        lvi.SubItems.Add(dRead["placebirth"].ToString());
                        lvi.SubItems.Add(dRead["status"].ToString());
                        lvi.SubItems.Add(dRead["occupation"].ToString());
                        lvi.SubItems.Add(dRead["cropplanted"].ToString());
                        lvi.SubItems.Add(dRead["farmedstat"].ToString());
                        lvi.SubItems.Add(dRead["workstat"].ToString());
                        lvi.SubItems.Add(dRead["monthlyincome"].ToString());
                        lvi.SubItems.Add(dRead["prob1"].ToString());
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

        private void txtname_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void cmboccupation_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging where occupation LIKE '%" + cmboccupation.Text + "%' AND workstat LIKE'%" + cmbworkstat.Text + "%'AND monthlyincome LIKE'%" + cmbmonthlyincome.Text + "%'AND farmedstat LIKE'%" + cmblandfarmstat.Text + "%'AND prob1 LIKE'%" + cmbproblems.Text + "%'", conn);
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
                        lvi.Text = dRead["surveyno"].ToString();
                        lvi.SubItems.Add(dRead["date"].ToString());
                        lvi.SubItems.Add(dRead["nameofinterviewee"].ToString());
                        lvi.SubItems.Add(dRead["age"].ToString());
                        lvi.SubItems.Add(dRead["presentadd"].ToString());
                        lvi.SubItems.Add(dRead["homeadd"].ToString());
                        lvi.SubItems.Add(dRead["datebirth"].ToString());
                        lvi.SubItems.Add(dRead["placebirth"].ToString());
                        lvi.SubItems.Add(dRead["status"].ToString());
                        lvi.SubItems.Add(dRead["occupation"].ToString());
                        lvi.SubItems.Add(dRead["cropplanted"].ToString());
                        lvi.SubItems.Add(dRead["farmedstat"].ToString());
                        lvi.SubItems.Add(dRead["workstat"].ToString());
                        lvi.SubItems.Add(dRead["monthlyincome"].ToString());
                        lvi.SubItems.Add(dRead["prob1"].ToString());
                        lvSAY.Items.Add(lvi);
                    }
                    dRead.Close();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Record Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbworkstat_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging where occupation LIKE '%" + cmboccupation.Text + "%' AND workstat LIKE'%" + cmbworkstat.Text + "%'AND monthlyincome LIKE'%" + cmbmonthlyincome.Text + "%'AND farmedstat LIKE'%" + cmblandfarmstat.Text + "%'AND prob1 LIKE'%" + cmbproblems.Text + "%'", conn);
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
                        lvi.Text = dRead["surveyno"].ToString();
                        lvi.SubItems.Add(dRead["date"].ToString());
                        lvi.SubItems.Add(dRead["nameofinterviewee"].ToString());
                        lvi.SubItems.Add(dRead["age"].ToString());
                        lvi.SubItems.Add(dRead["presentadd"].ToString());
                        lvi.SubItems.Add(dRead["homeadd"].ToString());
                        lvi.SubItems.Add(dRead["datebirth"].ToString());
                        lvi.SubItems.Add(dRead["placebirth"].ToString());
                        lvi.SubItems.Add(dRead["status"].ToString());
                        lvi.SubItems.Add(dRead["occupation"].ToString());
                        lvi.SubItems.Add(dRead["cropplanted"].ToString());
                        lvi.SubItems.Add(dRead["farmedstat"].ToString());
                        lvi.SubItems.Add(dRead["workstat"].ToString());
                        lvi.SubItems.Add(dRead["monthlyincome"].ToString());
                        lvi.SubItems.Add(dRead["prob1"].ToString());
                        lvSAY.Items.Add(lvi);
                    }
                    dRead.Close();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Record Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbmonthlyincome_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbmonthlyincome_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging where occupation LIKE '%" + cmboccupation.Text + "%' AND workstat LIKE'%" + cmbworkstat.Text + "%'AND monthlyincome LIKE'%" + cmbmonthlyincome.Text + "%'AND farmedstat LIKE'%" + cmblandfarmstat.Text + "%'AND prob1 LIKE'%" + cmbproblems.Text + "%'", conn);
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
                        lvi.Text = dRead["surveyno"].ToString();
                        lvi.SubItems.Add(dRead["date"].ToString());
                        lvi.SubItems.Add(dRead["nameofinterviewee"].ToString());
                        lvi.SubItems.Add(dRead["age"].ToString());
                        lvi.SubItems.Add(dRead["presentadd"].ToString());
                        lvi.SubItems.Add(dRead["homeadd"].ToString());
                        lvi.SubItems.Add(dRead["datebirth"].ToString());
                        lvi.SubItems.Add(dRead["placebirth"].ToString());
                        lvi.SubItems.Add(dRead["status"].ToString());
                        lvi.SubItems.Add(dRead["occupation"].ToString());
                        lvi.SubItems.Add(dRead["cropplanted"].ToString());
                        lvi.SubItems.Add(dRead["farmedstat"].ToString());
                        lvi.SubItems.Add(dRead["workstat"].ToString());
                        lvi.SubItems.Add(dRead["monthlyincome"].ToString());
                        lvi.SubItems.Add(dRead["prob1"].ToString());
                        lvSAY.Items.Add(lvi);
                    }
                    dRead.Close();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Record Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmblandfarmstat_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging where occupation LIKE '%" + cmboccupation.Text + "%' AND workstat LIKE'%" + cmbworkstat.Text + "%'AND monthlyincome LIKE'%" + cmbmonthlyincome.Text + "%'AND farmedstat LIKE'%" + cmblandfarmstat.Text + "%'AND prob1 LIKE'%" + cmbproblems.Text + "%'", conn);
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
                        lvi.Text = dRead["surveyno"].ToString();
                        lvi.SubItems.Add(dRead["date"].ToString());
                        lvi.SubItems.Add(dRead["nameofinterviewee"].ToString());
                        lvi.SubItems.Add(dRead["age"].ToString());
                        lvi.SubItems.Add(dRead["presentadd"].ToString());
                        lvi.SubItems.Add(dRead["homeadd"].ToString());
                        lvi.SubItems.Add(dRead["datebirth"].ToString());
                        lvi.SubItems.Add(dRead["placebirth"].ToString());
                        lvi.SubItems.Add(dRead["status"].ToString());
                        lvi.SubItems.Add(dRead["occupation"].ToString());
                        lvi.SubItems.Add(dRead["cropplanted"].ToString());
                        lvi.SubItems.Add(dRead["farmedstat"].ToString());
                        lvi.SubItems.Add(dRead["workstat"].ToString());
                        lvi.SubItems.Add(dRead["monthlyincome"].ToString());
                        lvi.SubItems.Add(dRead["prob1"].ToString());
                        lvSAY.Items.Add(lvi);
                    }
                    dRead.Close();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Record Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbproblems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbproblems_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging where occupation LIKE '%" + cmboccupation.Text + "%' AND workstat LIKE'%" + cmbworkstat.Text + "%'AND monthlyincome LIKE'%" + cmbmonthlyincome.Text + "%'AND farmedstat LIKE'%" + cmblandfarmstat.Text + "%'AND prob1 LIKE'%" + cmbproblems.Text + "%'", conn);
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
                        lvi.Text = dRead["surveyno"].ToString();
                        lvi.SubItems.Add(dRead["date"].ToString());
                        lvi.SubItems.Add(dRead["nameofinterviewee"].ToString());
                        lvi.SubItems.Add(dRead["age"].ToString());
                        lvi.SubItems.Add(dRead["presentadd"].ToString());
                        lvi.SubItems.Add(dRead["homeadd"].ToString());
                        lvi.SubItems.Add(dRead["datebirth"].ToString());
                        lvi.SubItems.Add(dRead["placebirth"].ToString());
                        lvi.SubItems.Add(dRead["status"].ToString());
                        lvi.SubItems.Add(dRead["occupation"].ToString());
                        lvi.SubItems.Add(dRead["cropplanted"].ToString());
                        lvi.SubItems.Add(dRead["farmedstat"].ToString());
                        lvi.SubItems.Add(dRead["workstat"].ToString());
                        lvi.SubItems.Add(dRead["monthlyincome"].ToString());
                        lvi.SubItems.Add(dRead["prob1"].ToString());
                        lvSAY.Items.Add(lvi);
                    }
                    dRead.Close();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No Record Found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
