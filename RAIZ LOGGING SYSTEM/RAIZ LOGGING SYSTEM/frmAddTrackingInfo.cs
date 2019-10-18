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
    public partial class frmAddTrackingInfo : Form
    {
        public frmAddTrackingInfo()
        {
            InitializeComponent();
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddTrackingInfo_Load(object sender, EventArgs e)
        {
            getlastid();
        }
        public void clear()
        {
            txtTo.Text = "";
            txtFrom.Text = "";
            txtThru.Text = "";
            txtSubject.Text = "";
        }
        public void getlastid()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select (Max(ID)+1) as ID from information Order by ID DESC", conn);
            MySqlDataReader dRead;
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    dRead = cmd.ExecuteReader();
                    if (dRead.Read())
                    {


                        txttransid.Text = dRead["ID"].ToString(); //if variable nTL does not contain value above
                        var nTL = txttransid.TextLength; ///getting the length of the characters inside textbx
                        //MessageBox.Show(nTL.ToString());
                        if (nTL == 3) //ibig sabihin 100  so add xa 1 zero (0)  (0)+100
                        {
                            txttransid.Text = "0" + dRead["ID"].ToString();
                        }
                        else if (nTL == 2)  //ibig sabihin 18 so add xa 2 zer (00)+18
                        {

                            txttransid.Text = "00" + dRead["ID"].ToString();
                        }
                        else if (nTL == 1)  // 125= (0)+125
                        {
                            txttransid.Text = "00" + dRead["ID"].ToString();
                        }
                        else if (nTL == 0) // if empty pa db and ala pa retrieve na value sa textbox from db
                        {
                            txttransid.Text = "001";
                        }
                        else
                        {
                            //txtSubCode.Text = "SID-";
                            txttransid.Text = dRead["ID"].ToString(); //if variable nTL does not contain value above
                        }

                        //meaning if more thank 4 characters na 9999 --->  10000 na get nya lng ung 10001 using txtfirst = dread[]
                        //just insert autonum field in the db: name it id--->
                        //add txtbox named it txtAutoNum.Text
                    }
                    dRead.Close();



                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void save()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from information where ID ='" + txttransid.Text + "'", conn);
            MySqlDataReader dRead;
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    dRead = cmd.ExecuteReader();
                    if (!dRead.Read())
                    {
                        dRead.Close();
                        cmd.CommandText = "Insert Into information(ID,date,too,thru,froom,subject)Values('" + txttransid.Text.ToUpper() + "','" + dtpdate.Text.ToUpper() + "','" + txtTo.Text.ToUpper() + "','" + txtThru.Text.ToUpper() + "','" + txtFrom.Text.ToUpper() + "','" + txtSubject.Text.ToUpper() + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Information Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getlastid();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Information Already Exist!", "Save Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cmdsave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmViewInformations();
            f.ShowDialog();
        }
    }
}
