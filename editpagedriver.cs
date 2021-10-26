using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ConductorAssistantSystem
{
    public partial class editpagedriver : Form
    {
        private bool editclicked = false;
        public editpagedriver()
        {
            InitializeComponent();
            lblname.Text = Form1.name;
            tbfullnameedit.Text = Form1.name;
            tbemailedit.Text = Form1.email;
            tbcelnumedit.Text = Form1.phonenum;
            tbusernameedit.Text = Form1.username;
            tbpasswordedit.Text = Form1.password;
            tbroutecodeedit.Text = Form1.routecode;
            string earlydisplaystops = "";
            string earlydisplayfares = "";
            for(int i = 0; i < Form1.splittedStops.Length; i++)
            {
                earlydisplaystops += (i + 1) + " - " + Form1.splittedStops[i] + " ->\n";
            }
            for(int i = 0; i < Form1.splittedfares.Length; i++)
            {
                earlydisplayfares += "PHP " + Form1.splittedfares[i].ToString() + "\n";
            }
            lblvname.Text = tbroutecodeedit.Text;
            lblstops.Text = earlydisplaystops;
            lblfare.Text = earlydisplayfares;
        }
        public void Filldata()
        {
            try
            {

                Function.fun.gen = "select routename as ROUTES from routes";
                Function.fun.fill(Function.fun.gen, dataGridView1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void editpagedriver_Load(object sender, EventArgs e)
        {
            Filldata();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (editclicked)
            {
                try
                {
                    lblvname.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                    tbroutecodeedit.Text = lblvname.Text;
                    string todisplaystops = "";
                    string[] todisplaystopssplit;
                    string toshowstops = "";
                    string todisplayfares = "";
                    string[] faresdisplaysplit;
                    string toshowfares = "";
                    if (lblvname.Text == "--")
                    {

                    }
                    else
                    {
                        Connection.conn.DB();
                        Function.fun.gen = "select * from routes where routename = '" + lblvname.Text + "'";
                        Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                        Function.fun.reader = Function.fun.command.ExecuteReader();

                        if (Function.fun.reader.HasRows)
                        {
                            Function.fun.reader.Read();
                            todisplaystops = Function.fun.reader["routestops"].ToString();
                            todisplayfares = Function.fun.reader["routefares"].ToString();
                            todisplaystopssplit = todisplaystops.Split(',');
                            faresdisplaysplit = todisplayfares.Split(',');

                            for (int i = 0; i < todisplaystopssplit.Length; i++)
                            {
                                toshowstops += (i + 1) + " - " + todisplaystopssplit[i] + " ->\n";
                            }
                            for (int i = 0; i < faresdisplaysplit.Length; i++)
                            {
                                toshowfares += "PHP " + faresdisplaysplit[i] + "\n";
                            }
                            lblstops.Text = toshowstops;
                            lblfare.Text = toshowfares;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //do nothing.
            }
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel6.Focus();
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            resignpagedriver rd = new resignpagedriver();
            this.Visible = false;
            rd.Show();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            btnupdate.Enabled = true;
            btnedit.Enabled = false;
            tbfullnameedit.Enabled = true;
            tbemailedit.Enabled = true;
            tbcelnumedit.Enabled = true;
            tbusernameedit.Enabled = true;
            tbpasswordedit.Enabled = true;
            editclicked = true;
            panel6.Enabled = true;
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            var val = MessageBox.Show("Are all set? Double check. You will get automatically logged out afterwards.", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (val == DialogResult.Yes)
            {
                try
                {

                    Connection.conn.DB();
                    Function.fun.gen = "update transportdriver set fullname = '" + tbfullnameedit.Text + "', email = '" + tbemailedit.Text + "',celnum = '" + tbcelnumedit.Text + "',username = '" + tbusernameedit.Text + "', password = '" + tbpasswordedit.Text + "', route = '" + tbroutecodeedit.Text + "' where driverid = '" + Form1.driverid + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();

                    MessageBox.Show("Edited! Remember your changes!", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Form1 fr = new Form1();
                    this.Visible = false;
                    fr.Show();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //do nothing.
            }
        }

        private void lblhome_Click(object sender, EventArgs e)
        {
            driverbase se = new driverbase();
            this.Visible = false;
            se.Show();
        }

        private void lblconinfo_Click(object sender, EventArgs e)
        {
            conductorinfodriver duc = new conductorinfodriver();
            this.Visible = false;
            duc.Show();
        }

        private void lblboutus_Click(object sender, EventArgs e)
        {
            aboutusdriver a = new aboutusdriver();
            this.Visible = false;
            a.Show();
        }

        private void lblresign_Click(object sender, EventArgs e)
        {
            resignpagedriver r = new resignpagedriver();
            this.Visible = false;
            r.Show();
        }

        private void lbllogout_Click(object sender, EventArgs e)
        {
            var val = MessageBox.Show("Are you sure?", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (val == DialogResult.Yes)
            {
                Form1 frm = new Form1();
                this.Visible = false;
                frm.Show();
            }
            else
            {
                //do nothing.
            }
        }
    }
}
