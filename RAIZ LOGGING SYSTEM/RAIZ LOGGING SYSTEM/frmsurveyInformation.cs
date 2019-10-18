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
    public partial class frmsurveyInformation : Form
    {
        string problems;
        string problem;
        public frmsurveyInformation()
        {
            InitializeComponent();
        }
        MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
        string yesno;
        public void save()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging where nameofinterviewee ='" + txtname.Text + "'", conn);
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
                        cmd.CommandText = "Insert Into raiz_logging(surveyno,date,nameofinterviewee,age,presentadd,homeadd,datebirth,placebirth,status,occupation,cropplanted,farmedstat,workstat,monthlyincome,nameofhusband_wife,noofchildren,comments,quest)Values('" + txtsurveyno.Text.ToUpper() + "','" + dtpdate.Text.ToUpper() + "','" + txtname.Text.ToUpper() + "','" + txtage.Text.ToUpper() + "','" + txtpresentadd.Text.ToUpper() + "','" + txthomeadd.Text.ToUpper() + "','"+txtdateofbirth.Text+"','"+txtplacebirth.Text.ToUpper()+"','"+cmbstat.Text+"','"+cmboccupation.Text.ToUpper()+"','"+txtcropplant.Text.ToUpper()+"','"+cmblandfarmstat.Text.ToUpper()+"','"+cmbworkstat.Text.ToUpper()+"','"+cmbmonthlyincome.Text+"','"+txtnameofhusbandwife.Text.ToUpper()+"','"+txtnoofchildren.Text+"','"+textBox1.Text+"','"+yesno+"')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        savechildren();
                        MessageBox.Show("Information Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cleartext();
                    }
                    else
                    {
                        MessageBox.Show("Information Already Exist!", "Save Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var role = txtname.Text;
                        myvar.name = role.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void cmboccupation_TextChanged(object sender, EventArgs e)
        {
            if (cmboccupation.Text == "Others")
            {
                lblspec1.Visible = true;
                txtspec1.Visible = true;
            }
            else if (cmboccupation.Text == "Farmer")
            {
                lblspec1.Visible = false;
                txtspec1.Visible = false;
            }
            else if (cmboccupation.Text == "Farm Worker")
            {
                lblspec1.Visible = false;
                txtspec1.Visible = false;
            }
            else if (cmboccupation.Text == "Driver")
            {
                lblspec1.Visible = false;
                txtspec1.Visible = false;
            }
            else if (cmboccupation.Text == "Laborer")
            {
                lblspec1.Visible = false;
                txtspec1.Visible = false;
            }
        }
        private void cmblandfarmstat_TextChanged(object sender, EventArgs e)
        {
            if (cmblandfarmstat.Text == "Owned")
            {
                lblspec2.Visible = false;
                txtspec2.Visible = false;
            }
            else if (cmblandfarmstat.Text == "Rented")
            {
                lblspec2.Visible = false;
                txtspec2.Visible = false;
            }
            else if (cmblandfarmstat.Text == "Occupied")
            {
                lblspec2.Visible = false;
                txtspec2.Visible = false;
            }
            else if (cmblandfarmstat.Text == "Public Land (IFMA)")
            {
                lblspec2.Visible = false;
                txtspec2.Visible = false;
            }
            else if (cmblandfarmstat.Text == "Applied for free Patent")
            {
                lblspec2.Visible = false;
                txtspec2.Visible = false;
            }
            else if (cmblandfarmstat.Text == "Do not Know")
            {
                lblspec2.Visible = false;
                txtspec2.Visible = false;
            }
            else if (cmblandfarmstat.Text == "Others")
            {
                lblspec2.Visible = true;
                txtspec2.Visible = true;
            }
        }
        private void cmbworkstat_TextChanged(object sender, EventArgs e)
        {
            if (cmbworkstat.Text == "Employed")
            {
                lblspec3.Visible = false;
                txtspec3.Visible = false;
            }
            else if (cmbworkstat.Text == "Self Employed")
            {
                lblspec3.Visible = false;
                txtspec3.Visible = false;
            }
            else if (cmbworkstat.Text == "Unemployed")
            {
                lblspec3.Visible = false;
                txtspec3.Visible = false;
            }
            else if (cmbworkstat.Text == "Permanent")
            {
                lblspec3.Visible = false;
                txtspec3.Visible = false;
            }
            else if (cmbworkstat.Text == "Part Time")
            {
                lblspec3.Visible = false;
                txtspec3.Visible = false;
            }
            else if (cmbworkstat.Text == "Seasonal")
            {
                lblspec3.Visible = false;
                txtspec3.Visible = false;
            }
            else if (cmbworkstat.Text == "Others")
            {
                lblspec3.Visible = true;
                txtspec3.Visible = true;
            }
        }
        private void cmbyear_TextChanged(object sender, EventArgs e)
        {
            if (cmbyear.Text == "")
            {
                cmbyear.Text = "0";
            }
            decimal a = Convert.ToDecimal(txtyearnow.Text);

            decimal b = Convert.ToDecimal(cmbyear.Text);


            decimal c = a - b;
            txtage.Text = Convert.ToString(c);
            txtdateofbirth.Text = cmbmonth.Text + "/" + cmbday.Text + "/" + cmbyear.Text;
        }
        public void year()
        {
            var LastYear = DateTime.Now.AddYears(0).ToString("yyyy"); //"2011"
            txtyearnow.Text = LastYear;
        }
        private void frmtransaction_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = (1000); //1sec
            timer.Tick += new EventHandler(refresh_Tick);
            timer.Start();

            year();
            getlastid();
        }
        private void cmbmonth_TextChanged(object sender, EventArgs e)
        {
            txtdateofbirth.Text = cmbmonth.Text + "/" + cmbday.Text + "/" + cmbyear.Text;
        }
        private void cmbday_TextChanged(object sender, EventArgs e)
        {
            txtdateofbirth.Text = cmbmonth.Text + "/" + cmbday.Text + "/" + cmbyear.Text;
        }
        public void getlastid()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select (Max(surveyno)+1) as surveyno from raiz_logging Order by surveyno DESC", conn);
            MySqlDataReader dRead;
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    dRead = cmd.ExecuteReader();
                    if (dRead.Read())
                    {


                        txtsurveyno.Text = dRead["surveyno"].ToString(); //if variable nTL does not contain value above
                        var nTL = txtsurveyno.TextLength; ///getting the length of the characters inside textbx
                        //MessageBox.Show(nTL.ToString());
                        if (nTL == 3) //ibig sabihin 100  so add xa 1 zero (0)  (0)+100
                        {
                            txtsurveyno.Text = "0" + dRead["surveyno"].ToString();
                        }
                        else if (nTL == 2)  //ibig sabihin 18 so add xa 2 zer (00)+18
                        {

                            txtsurveyno.Text = "00" + dRead["surveyno"].ToString();
                        }
                        else if (nTL == 1)  // 125= (0)+125
                        {
                            txtsurveyno.Text = "00" + dRead["surveyno"].ToString();
                        }
                        else if (nTL == 0) // if empty pa db and ala pa retrieve na value sa textbox from db
                        {
                            txtsurveyno.Text = "001";
                        }
                        else
                        {
                            //txtSubCode.Text = "SID-";
                            txtsurveyno.Text = dRead["surveyno"].ToString(); //if variable nTL does not contain value above
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
        private void txtlname_TextChanged(object sender, EventArgs e)
        {
            txtname.Text = txtfname.Text + " " + txtmi.Text + ". " + txtlname.Text;
        }
        private void txtfname_TextChanged(object sender, EventArgs e)
        {
            txtname.Text = txtfname.Text + " " + txtmi.Text + ". " + txtlname.Text;
        }
        private void txtmi_TextChanged(object sender, EventArgs e)
        {
            txtname.Text = txtfname.Text + " " + txtmi.Text + ". " + txtlname.Text;
        }
        private void txtmun1_TextChanged(object sender, EventArgs e)
        {
            txtpresentadd.Text = txtbar1.Text + ", " + txtsit1.Text + ", " + txtmun1.Text;
        }
        private void txtbar1_TextChanged(object sender, EventArgs e)
        {
            txtpresentadd.Text = txtbar1.Text + ", " + txtsit1.Text + ", " + txtmun1.Text;
        }
        private void txtsit1_TextChanged(object sender, EventArgs e)
        {
            txtpresentadd.Text = txtbar1.Text + ", " + txtsit1.Text + ", " + txtmun1.Text;
        }
        private void txtmun2_TextChanged(object sender, EventArgs e)
        {
            txthomeadd.Text = txtbar2.Text + ", " + txtsit2.Text + ", " + txtmun2.Text;
        }
        private void txtbar2_TextChanged(object sender, EventArgs e)
        {
            txthomeadd.Text = txtbar2.Text + ", " + txtsit2.Text + ", " + txtmun2.Text;
        }
        private void txtsit2_TextChanged(object sender, EventArgs e)
        {
            txthomeadd.Text = txtbar2.Text + ", " + txtsit2.Text + ", " + txtmun2.Text;
        }
        public void Single()
        {
            if (txtlname.Text.ToString() == "" || txtfname.Text.ToString() == "" || txtmi.Text.ToString() == "" || txtage.Text.ToString() == "" || txtmun1.Text.ToString() == "" || txtbar1.Text.ToString() == "" || txtsit1.Text.ToString() == "" || txtmun2.Text.ToString() == "" || txtbar2.Text.ToString() == "" || txtbar2.Text.ToString() == "" || cmbmonth.Text.ToString() == "" || cmbday.Text.ToString() == "" || cmbyear.Text.ToString() == "" || txtplacebirth.Text.ToString() == "" || cmbstat.Text.ToString() == "" || cmboccupation.Text.ToString() == "" || txtcropplant.Text.ToString() == "" || cmblandfarmstat.Text.ToString() == "" || cmbworkstat.Text.ToString() == "" || cmbmonthlyincome.Text.ToString() == "")
            {
                MessageBox.Show("Please Fill in Data!", "Fill in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                updateinformation();
            }  
        }
        public void Married()
        {
            if (txtlname.Text.ToString() == "" || txtfname.Text.ToString() == "" || txtmi.Text.ToString() == "" || txtage.Text.ToString() == "" || txtmun1.Text.ToString() == "" || txtbar1.Text.ToString() == "" || txtsit1.Text.ToString() == "" || txtmun2.Text.ToString() == "" || txtbar2.Text.ToString() == "" || txtbar2.Text.ToString() == "" || cmbmonth.Text.ToString() == "" || cmbday.Text.ToString() == "" || cmbyear.Text.ToString() == "" || txtplacebirth.Text.ToString() == "" || cmbstat.Text.ToString() == "" || cmboccupation.Text.ToString() == "" || txtcropplant.Text.ToString() == "" || cmblandfarmstat.Text.ToString() == "" || cmbworkstat.Text.ToString() == "" || cmbmonthlyincome.Text.ToString() == ""  || txtnameofhusbandwife.Text.ToString() == "" || txtnoofchildren.Text.ToString() == "")
            {
                MessageBox.Show("Name of Husband/Wife Required!", "Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                updateinformation();
            }  
        }
        public void fillindata()
        {
            if (txtlname.Text.ToString() == "" || txtfname.Text.ToString() == "" || txtmi.Text.ToString() == "" || txtage.Text.ToString() == "" || txtmun1.Text.ToString() == "" || txtbar1.Text.ToString() == "" || txtsit1.Text.ToString() == "" || txtmun2.Text.ToString() == "" || txtbar2.Text.ToString() == "" || txtbar2.Text.ToString() == "" || cmbmonth.Text.ToString() == "" || cmbday.Text.ToString() == "" || cmbyear.Text.ToString() == "" || txtplacebirth.Text.ToString() == "" || cmbstat.Text.ToString() == "" || cmboccupation.Text.ToString() == "" || txtcropplant.Text.ToString() == "" || cmblandfarmstat.Text.ToString() == "" || cmbworkstat.Text.ToString() == "" || cmbmonthlyincome.Text.ToString() == "")
            {
                MessageBox.Show("Please Fill in Data!", "Fill in Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                status();
            }  
        }
        public void updateinformation()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select* from raiz_logging where nameofinterviewee= '" + txtname.Text + "'", conn);
            MySqlDataReader dRead;

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    dRead = cmd.ExecuteReader();
                    if (dRead.Read())
                    {
                        dRead.Close();
                        cmd.CommandText = "Update raiz_logging Set surveyno='" + txtsurveyno.Text.ToUpper() + "', date='" + dtpdate.Text.ToUpper() + "', age='" + txtage.Text.ToUpper() + "', presentadd='" + txtpresentadd.Text.ToUpper() + "', homeadd='" + txthomeadd.Text.ToUpper() + "', datebirth='" + txtdateofbirth.Text.ToUpper() + "',placebirth='" + txtplacebirth.Text.ToUpper() + "', status='" + cmbstat.Text.ToUpper() + "', occupation='" + cmboccupation.Text.ToUpper() + "', cropplanted='" + txtcropplant.Text.ToUpper() + "', farmedstat='" + cmblandfarmstat.Text.ToUpper() + "', workstat='" + cmbworkstat.Text.ToUpper() + "', monthlyincome='" + cmbmonthlyincome.Text.ToUpper() + "', nameofhusband_wife='" + txtnameofhusbandwife.Text.ToUpper() + "', noofchildren='" + txtnoofchildren.Text.ToUpper() + "', comments='" + textBox1.Text.ToUpper() + "', quest='" + yesno.ToUpper() + "' Where nameofinterviewee='" + txtname.Text.ToUpper() + "'";
                        cmd.ExecuteNonQuery();
                        savechildren();
                        MessageBox.Show("Information Saved!", "Save!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cleartext();
                    }
                }
            }
            catch (MySqlException Ex)
            {

                MessageBox.Show(Ex.Message, "Try Again!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void saveproblem()
        {
            string s = "";
            foreach (Control cc in this.Controls)
            {
                if (cc is CheckBox)
                {
                    CheckBox b = (CheckBox)cc;
                    if (b.Checked)
                    {
                        s = b.Text + " " + s;
                    }
                }
            }
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("Insert into raiz_logging(nameofinterviewee,prob1)values('" + txtname.Text + "','" + s + "')", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            fillindata();
            //MessageBox.Show("Successfully Saved!");
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //save();

            saveproblem();
            getlastid();
        }
        public void prob1()
        {
            //try
            //{
            //    string str = "";
            //    if (checkedListBox1.CheckedItems.Count > 0)
            //    {
            //        for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            //        {
            //            if (str == "")
            //            {
            //                str = checkedListBox1.CheckedItems[i].ToString();
            //            }
            //            else
            //            {
            //                str += ", " + checkedListBox1.CheckedItems[i].ToString();
            //            }
            //        }
            //        MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            //        conn.Open();
            //        MySqlCommand cmd = new MySqlCommand("Insert Into raiz_logging(prob1)values(@prob1)", conn);
            //        cmd.Parameters.AddWithValue("@prob1", str);
            //        cmd.ExecuteNonQuery();
            //        MessageBox.Show("Save");
            //    }
            //    else
            //    {
            //        //MessageBox.Show("Please Select");
            //    }
            //    while (checkedListBox1.CheckedItems.Count > 0)
            //    {
            //        checkedListBox1.SetItemChecked(checkedListBox1.CheckedIndices[0], false);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message + ex.ToString());
            //}
        }
        public void savechildren()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from children where id ='" + txtid.Text + "'", conn);
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
                        cmd.CommandText = "Insert Into children(id,name,nameofchildren1,nameofchildren2,nameofchildren3,nameofchildren4,nameofchildren5,nameofchildren6,nameofchildren7,nameofchildren8,nameofchildren9,nameofchildren10,sex1,sex2,sex3,sex4,sex5,sex6,sex7,sex8,sex9,sex10,age1,age2,age3,age4,age5,age6,age7,age8,age9,age10,status1,status2,status3,status4,status5,status6,status7,status8,status9,status10)Values('" + txtid.Text.ToUpper() + "','" + txtname.Text.ToUpper() + "','" + txtname1.Text.ToUpper() + "','" + txtname2.Text.ToUpper() + "','" + txtname3.Text.ToUpper() + "','" + txtname4.Text.ToUpper() + "','" + txtname5.Text.ToUpper() + "','" + txtname6.Text.ToUpper() + "','" + txtname7.Text.ToUpper() + "','" + txtname8.Text.ToUpper() + "','" + txtname9.Text.ToUpper() + "','" + txtname10.Text.ToUpper() + "','" + cmbsex1.Text.ToUpper() + "','" + cmbsex2.Text.ToUpper() + "','" + cmbsex3.Text.ToUpper() + "','" + cmbsex4.Text.ToUpper() + "','" + cmbsex5.Text.ToUpper() + "','" + cmbsex6.Text.ToUpper() + "','" + cmbsex7.Text.ToUpper() + "','" + cmbsex8.Text.ToUpper() + "','" + cmbsex9.Text.ToUpper() + "','" + cmbsex10.Text.ToUpper() + "','" + txtage1.Text + "','" + txtage2.Text + "','" + txtage3.Text + "','" + txtage4.Text + "','" + txtage5.Text + "','" + txtage6.Text + "','" + txtage7.Text + "','" + txtage8.Text + "','" + txtage9.Text + "','" + txtage10.Text + "','" + cmbstat1.Text.ToUpper() + "','" + cmbstat2.Text.ToUpper() + "','" + cmbstat3.Text.ToUpper() + "','" + cmbstat4.Text.ToUpper() + "','" + cmbstat5.Text.ToUpper() + "','" + cmbstat6.Text.ToUpper() + "','" + cmbstat7.Text.ToUpper() + "','" + cmbstat8.Text.ToUpper() + "','" + cmbstat9.Text.ToUpper() + "','" + cmbstat10.Text.ToUpper() + "')";
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        //MessageBox.Show("Information Saved!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        //MessageBox.Show("Information Already Exist!", "Save Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //var f = new frmRetrievedata();
                        //f.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtlname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtnoofchildren_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        public void numberlength()
        {
            t();
        }
        public void t()
        {
            if (txtnoofchildren.Text == "10")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = true;
                cmbsex4.Visible = true;
                txtage4.Visible = true;
                cmbstat4.Visible = true;

                txtname5.Visible = true;
                cmbsex5.Visible = true;
                txtage5.Visible = true;
                cmbstat5.Visible = true;

                txtname6.Visible = true;
                cmbsex6.Visible = true;
                txtage6.Visible = true;
                cmbstat6.Visible = true;

                txtname7.Visible = true;
                cmbsex7.Visible = true;
                txtage7.Visible = true;
                cmbstat7.Visible = true;

                txtname8.Visible = true;
                cmbsex8.Visible = true;
                txtage8.Visible = true;
                cmbstat8.Visible = true;

                txtname9.Visible = true;
                cmbsex9.Visible = true;
                txtage9.Visible = true;
                cmbstat9.Visible = true;

                txtname10.Visible = true;
                cmbsex10.Visible = true;
                txtage10.Visible = true;
                cmbstat10.Visible = true;
            }
            if (txtnoofchildren.Text == "9")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = true;
                cmbsex4.Visible = true;
                txtage4.Visible = true;
                cmbstat4.Visible = true;

                txtname5.Visible = true;
                cmbsex5.Visible = true;
                txtage5.Visible = true;
                cmbstat5.Visible = true;

                txtname6.Visible = true;
                cmbsex6.Visible = true;
                txtage6.Visible = true;
                cmbstat6.Visible = true;

                txtname7.Visible = true;
                cmbsex7.Visible = true;
                txtage7.Visible = true;
                cmbstat7.Visible = true;

                txtname8.Visible = true;
                cmbsex8.Visible = true;
                txtage8.Visible = true;
                cmbstat8.Visible = true;

                txtname9.Visible = true;
                cmbsex9.Visible = true;
                txtage9.Visible = true;
                cmbstat9.Visible = true;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            if (txtnoofchildren.Text == "8")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = true;
                cmbsex4.Visible = true;
                txtage4.Visible = true;
                cmbstat4.Visible = true;

                txtname5.Visible = true;
                cmbsex5.Visible = true;
                txtage5.Visible = true;
                cmbstat5.Visible = true;

                txtname6.Visible = true;
                cmbsex6.Visible = true;
                txtage6.Visible = true;
                cmbstat6.Visible = true;

                txtname7.Visible = true;
                cmbsex7.Visible = true;
                txtage7.Visible = true;
                cmbstat7.Visible = true;

                txtname8.Visible = true;
                cmbsex8.Visible = true;
                txtage8.Visible = true;
                cmbstat8.Visible = true;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            if (txtnoofchildren.Text == "7")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = true;
                cmbsex4.Visible = true;
                txtage4.Visible = true;
                cmbstat4.Visible = true;

                txtname5.Visible = true;
                cmbsex5.Visible = true;
                txtage5.Visible = true;
                cmbstat5.Visible = true;

                txtname6.Visible = true;
                cmbsex6.Visible = true;
                txtage6.Visible = true;
                cmbstat6.Visible = true;

                txtname7.Visible = true;
                cmbsex7.Visible = true;
                txtage7.Visible = true;
                cmbstat7.Visible = true;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            if (txtnoofchildren.Text == "6")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = true;
                cmbsex4.Visible = true;
                txtage4.Visible = true;
                cmbstat4.Visible = true;

                txtname5.Visible = true;
                cmbsex5.Visible = true;
                txtage5.Visible = true;
                cmbstat5.Visible = true;

                txtname6.Visible = true;
                cmbsex6.Visible = true;
                txtage6.Visible = true;
                cmbstat6.Visible = true;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }

            if (txtnoofchildren.Text == "5")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = true;
                cmbsex4.Visible = true;
                txtage4.Visible = true;
                cmbstat4.Visible = true;

                txtname5.Visible = true;
                cmbsex5.Visible = true;
                txtage5.Visible = true;
                cmbstat5.Visible = true;

                txtname6.Visible = false;
                cmbsex6.Visible = false;
                txtage6.Visible = false;
                cmbstat6.Visible = false;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            else if (txtnoofchildren.Text == "4")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = true;
                cmbsex4.Visible = true;
                txtage4.Visible = true;
                cmbstat4.Visible = true;

                txtname5.Visible = false;
                cmbsex5.Visible = false;
                txtage5.Visible = false;
                cmbstat5.Visible = false;

                txtname6.Visible = false;
                cmbsex6.Visible = false;
                txtage6.Visible = false;
                cmbstat6.Visible = false;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            else if (txtnoofchildren.Text == "3")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = true;
                cmbsex3.Visible = true;
                txtage3.Visible = true;
                cmbstat3.Visible = true;

                txtname4.Visible = false;
                cmbsex4.Visible = false;
                txtage4.Visible = false;
                cmbstat4.Visible = false;

                txtname5.Visible = false;
                cmbsex5.Visible = false;
                txtage5.Visible = false;
                cmbstat5.Visible = false;

                txtname6.Visible = false;
                cmbsex6.Visible = false;
                txtage6.Visible = false;
                cmbstat6.Visible = false;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            else if (txtnoofchildren.Text == "2")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = true;
                cmbsex2.Visible = true;
                txtage2.Visible = true;
                cmbstat2.Visible = true;

                txtname3.Visible = false;
                cmbsex3.Visible = false;
                txtage3.Visible = false;
                cmbstat3.Visible = false;

                txtname4.Visible = false;
                cmbsex4.Visible = false;
                txtage4.Visible = false;
                cmbstat4.Visible = false;

                txtname5.Visible = false;
                cmbsex5.Visible = false;
                txtage5.Visible = false;
                cmbstat5.Visible = false;

                txtname6.Visible = false;
                cmbsex6.Visible = false;
                txtage6.Visible = false;
                cmbstat6.Visible = false;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            else if (txtnoofchildren.Text == "1")
            {
                lblchildren.Visible = true;
                lblage.Visible = true;
                lblsex.Visible = true;
                lblstat.Visible = true;

                txtname1.Visible = true;
                cmbsex1.Visible = true;
                txtage1.Visible = true;
                cmbstat1.Visible = true;

                txtname2.Visible = false;
                cmbsex2.Visible = false;
                txtage2.Visible = false;
                cmbstat2.Visible = false;

                txtname3.Visible = false;
                cmbsex3.Visible = false;
                txtage3.Visible = false;
                cmbstat3.Visible = false;

                txtname4.Visible = false;
                cmbsex4.Visible = false;
                txtage4.Visible = false;
                cmbstat4.Visible = false;

                txtname5.Visible = false;
                cmbsex5.Visible = false;
                txtage5.Visible = false;
                cmbstat5.Visible = false;

                txtname6.Visible = false;
                cmbsex6.Visible = false;
                txtage6.Visible = false;
                cmbstat6.Visible = false;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            else if (txtnoofchildren.Text == "0")
            {
                lblchildren.Visible = false;
                lblage.Visible = false;
                lblsex.Visible = false;
                lblstat.Visible = false;

                txtname1.Visible = false;
                cmbsex1.Visible = false;
                txtage1.Visible = false;
                cmbstat1.Visible = false;

                txtname2.Visible = false;
                cmbsex2.Visible = false;
                txtage2.Visible = false;
                cmbstat2.Visible = false;

                txtname3.Visible = false;
                cmbsex3.Visible = false;
                txtage3.Visible = false;
                cmbstat3.Visible = false;

                txtname4.Visible = false;
                cmbsex4.Visible = false;
                txtage4.Visible = false;
                cmbstat4.Visible = false;

                txtname5.Visible = false;
                cmbsex5.Visible = false;
                txtage5.Visible = false;
                cmbstat5.Visible = false;

                txtname6.Visible = false;
                cmbsex6.Visible = false;
                txtage6.Visible = false;
                cmbstat6.Visible = false;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            else if (txtnoofchildren.Text == "")
            {
                lblchildren.Visible = false;
                lblage.Visible = false;
                lblsex.Visible = false;
                lblstat.Visible = false;

                txtname1.Visible = false;
                cmbsex1.Visible = false;
                txtage1.Visible = false;
                cmbstat1.Visible = false;

                txtname2.Visible = false;
                cmbsex2.Visible = false;
                txtage2.Visible = false;
                cmbstat2.Visible = false;

                txtname3.Visible = false;
                cmbsex3.Visible = false;
                txtage3.Visible = false;
                cmbstat3.Visible = false;

                txtname4.Visible = false;
                cmbsex4.Visible = false;
                txtage4.Visible = false;
                cmbstat4.Visible = false;

                txtname5.Visible = false;
                cmbsex5.Visible = false;
                txtage5.Visible = false;
                cmbstat5.Visible = false;

                txtname6.Visible = false;
                cmbsex6.Visible = false;
                txtage6.Visible = false;
                cmbstat6.Visible = false;

                txtname7.Visible = false;
                cmbsex7.Visible = false;
                txtage7.Visible = false;
                cmbstat7.Visible = false;

                txtname8.Visible = false;
                cmbsex8.Visible = false;
                txtage8.Visible = false;
                cmbstat8.Visible = false;

                txtname9.Visible = false;
                cmbsex9.Visible = false;
                txtage9.Visible = false;
                cmbstat9.Visible = false;

                txtname10.Visible = false;
                cmbsex10.Visible = false;
                txtage10.Visible = false;
                cmbstat10.Visible = false;
            }
            else if (txtnoofchildren.Text == "11")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "12")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "13")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "14")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "15")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "16")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "17")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "18")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "19")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
            else if (txtnoofchildren.Text == "20")
            {
                MessageBox.Show("This Item is Only Limited for 10 Persons", "Reminder", MessageBoxButtons.OK);
                txtnoofchildren.Text = "";
            }
        }
        private void txtnoofchildren_TextChanged(object sender, EventArgs e)
        {
            numberlength();
        }
        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
            yesno = "Yes";
        }

        private void radioButton25_CheckedChanged(object sender, EventArgs e)
        {
            yesno = "No";
        }
        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox29.Text + "" + textBox30.Text + "" + textBox31.Text;
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox29.Text + "" + textBox30.Text + "" + textBox31.Text;
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox29.Text + "" + textBox30.Text + "" + textBox31.Text;
        }
        public void status()
        {
            if (cmbstat.Text == "Single")
            {
                Single();
            }
            else if (cmbstat.Text == "Married")
            {
                Married(); 
            }
        }
        public void cleartext()
        {
            txtlname.Text = "";
            txtfname.Text = "";
            txtmi.Text = "";
            txtage.Text = "";
            txtmun1.Text = "";
            txtbar1.Text = "";
            txtsit1.Text = "";
            txtmun2.Text = "";
            txtbar2.Text = "";
            txtsit2.Text = "";
            cmbmonth.Text = "";
            cmbday.Text = "";
            cmbyear.Text = "";
            txtplacebirth.Text = "";
            cmbstat.Text = "";
            txtnameofhusbandwife.Text = "";
            txtnoofchildren.Text = "";
            cmboccupation.Text = "";
            txtcropplant.Text = "";
            cmblandfarmstat.Text = "";
            cmbworkstat.Text = "";
            cmbmonthlyincome.Text = "";
            txtname1.Text = "";
            txtname2.Text = "";
            txtname3.Text = "";
            txtname4.Text = "";
            txtname5.Text = "";
            txtname6.Text = "";
            txtname7.Text = "";
            txtname8.Text = "";
            txtname9.Text = "";
            txtname10.Text = "";
            cmbsex1.Text = "";
            cmbsex2.Text = "";
            cmbsex3.Text = "";
            cmbsex4.Text = "";
            cmbsex5.Text = "";
            cmbsex6.Text = "";
            cmbsex7.Text = "";
            cmbsex8.Text = "";
            cmbsex9.Text = "";
            cmbsex10.Text = "";
            txtage1.Text = "";
            txtage2.Text = "";
            txtage3.Text = "";
            txtage4.Text = "";
            txtage5.Text = "";
            txtage6.Text = "";
            txtage7.Text = "";
            txtage8.Text = "";
            txtage9.Text = "";
            txtage10.Text = "";
            cmbstat1.Text = "";
            cmbstat2.Text = "";
            cmbstat3.Text = "";
            cmbstat4.Text = "";
            cmbstat5.Text = "";
            cmbstat6.Text = "";
            cmbstat7.Text = "";
            cmbstat8.Text = "";
            cmbstat9.Text = "";
            cmbstat10.Text = "";
        }
        private void cmbstat_TextChanged(object sender, EventArgs e)
        {
            if (cmbstat.Text == "Single")
            {
                asas.Visible = false;
            }
            else if (cmbstat.Text == "Married")
            {
                asas.Visible = true;
            }
        }
        public void findchildren()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from children where name = '" + txtname.Text + "'", conn);
            MySqlDataReader dRead;

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    dRead = cmd.ExecuteReader();
                    if (dRead.Read())
                    {
                        txtname1.Text = dRead["nameofchildren1"].ToString();
                        txtname2.Text = dRead["nameofchildren2"].ToString();
                        txtname3.Text = dRead["nameofchildren3"].ToString();
                        txtname4.Text = dRead["nameofchildren4"].ToString();
                        txtname5.Text = dRead["nameofchildren5"].ToString();
                        txtname6.Text = dRead["nameofchildren6"].ToString();
                        txtname7.Text = dRead["nameofchildren7"].ToString();
                        txtname8.Text = dRead["nameofchildren8"].ToString();
                        txtname9.Text = dRead["nameofchildren9"].ToString();
                        txtname10.Text = dRead["nameofchildren10"].ToString();
                        cmbsex1.Text = dRead["sex1"].ToString();
                        cmbsex2.Text = dRead["sex2"].ToString();
                        cmbsex3.Text = dRead["sex3"].ToString();
                        cmbsex4.Text = dRead["sex4"].ToString();
                        cmbsex5.Text = dRead["sex5"].ToString();
                        cmbsex6.Text = dRead["sex6"].ToString();
                        cmbsex7.Text = dRead["sex7"].ToString();
                        cmbsex8.Text = dRead["sex8"].ToString();
                        cmbsex9.Text = dRead["sex9"].ToString();
                        cmbsex10.Text = dRead["sex10"].ToString();
                        txtage1.Text = dRead["age1"].ToString();
                        txtage2.Text = dRead["age2"].ToString();
                        txtage3.Text = dRead["age3"].ToString();
                        txtage4.Text = dRead["age4"].ToString();
                        txtage5.Text = dRead["age5"].ToString();
                        txtage6.Text = dRead["age6"].ToString();
                        txtage7.Text = dRead["age7"].ToString();
                        txtage8.Text = dRead["age8"].ToString();
                        txtage9.Text = dRead["age9"].ToString();
                        txtage10.Text = dRead["age10"].ToString();
                        cmbstat1.Text = dRead["status1"].ToString();
                        cmbstat2.Text = dRead["status2"].ToString();
                        cmbstat3.Text = dRead["status3"].ToString();
                        cmbstat4.Text = dRead["status4"].ToString();
                        cmbstat5.Text = dRead["status5"].ToString();
                        cmbstat6.Text = dRead["status6"].ToString();
                        cmbstat7.Text = dRead["status7"].ToString();
                        cmbstat8.Text = dRead["status8"].ToString();
                        cmbstat9.Text = dRead["status9"].ToString();
                        cmbstat10.Text = dRead["status10"].ToString();
                        dRead.Close();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    else
                    {
                        //MessageBox.Show("Record Not Found!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void findperson()
        {
            MySqlConnection conn = new MySqlConnection(DBconn.ConnectMe);
            MySqlCommand cmd = new MySqlCommand("Select * from raiz_logging where nameofinterviewee = '" + txtname.Text + "'", conn);
            MySqlDataReader dRead;

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    dRead = cmd.ExecuteReader();
                    if (dRead.Read())
                    {
                        txtsurveyno.Text = dRead["surveyno"].ToString();
                        dtpdate.Text = dRead["date"].ToString();
                        txtage.Text = dRead["age"].ToString();
                        txtpresentadd.Text = dRead["presentadd"].ToString();
                        txthomeadd.Text = dRead["homeadd"].ToString();
                        txtdateofbirth.Text = dRead["datebirth"].ToString();
                        txtplacebirth.Text = dRead["placebirth"].ToString();
                        cmbstat.Text = dRead["status"].ToString();
                        cmboccupation.Text = dRead["occupation"].ToString();
                        txtcropplant.Text = dRead["cropplanted"].ToString();
                        cmblandfarmstat.Text = dRead["farmedstat"].ToString();
                        cmbworkstat.Text = dRead["workstat"].ToString();
                        cmbmonthlyincome.Text = dRead["monthlyincome"].ToString();
                        txtnameofhusbandwife.Text = dRead["nameofhusband_wife"].ToString();
                        txtnoofchildren.Text = dRead["noofchildren"].ToString();
                        txtpresentadd.Visible = true;
                        txthomeadd.Visible = true;
                        txtdateofbirth.Visible = true;
                        label10.Visible = false;
                        label11.Visible = false;
                        label12.Visible = false;
                        lblmun1.Visible = false;
                        lblmun2.Visible = false;
                        lblbar1.Visible = false;
                        lblbar2.Visible = false;
                        lblsit1.Visible = false;
                        lblsit2.Visible = false;
                        label6.Visible = false;
                        label7.Visible = false;
                        label8.Visible = false;
                        txtname.Visible = true;
                        txtname.Focus();
                        dRead.Close();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        findchildren();
                        //findproblem();
                    }
                    else
                    {
                        //MessageBox.Show("Record Not Found!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (MySqlException ioe)
            {
                MessageBox.Show(ioe.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtname_TextChanged(object sender, EventArgs e)
        {
            if (txtname.Text == "")
            {
                txtpresentadd.Visible = false;
                txthomeadd.Visible = false;
                txtdateofbirth.Visible = false;
                txtname.Visible = false;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                lblmun1.Visible = true;
                lblmun2.Visible = true;
                lblbar1.Visible = true;
                lblbar2.Visible = true;
                lblsit1.Visible = true;
                lblsit2.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                getlastid();
                cleartext();
            }

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from raiz_logging where nameofinterviewee='" + txtname.Text.ToUpper() + "'", conn);
            MySqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string aa = dr["prob1"].ToString();
                string[] a = aa.Split(' ');
                foreach (Control cc in this.Controls)
                {
                    if (cc is CheckBox)
                    {
                        CheckBox b = (CheckBox)cc;
                        for (int j = 0; j < a.Length; j++)
                        {
                            if (a[j].ToString() == b.Text)
                            {
                                b.Checked = true;
                                findperson();
                            }
                        }
                    }
                }
            }
            conn.Close();
        }

        private void txtage1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void txtage9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
        private void txtage10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void refresh_Tick(object sender, EventArgs e)
        {
            getlastid();
        }
    }
}
