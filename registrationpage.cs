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
    public partial class registrationpage : Form
    {
        private int roleid = 0;
        private string status = "ACTIVE";
        public registrationpage()
        {
            InitializeComponent();
            
        }

        private void registrationpage_Load(object sender, EventArgs e)
        {

        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            if (cmbrole.Text != "")
            {
                if (cmbrole.Text == "Admin")
                {

                    btnnext.Enabled = false;
                    tbfullname.Enabled = false;
                    tbemail.Enabled = false;
                    tbcelnum.Enabled = false;
                    tbusernamereg.Enabled = false;
                    tbpasswordreg.Enabled = false;
                    tbreenter.Enabled = false;
                    tbadminpass.Visible = true;
                    lbladminpass.Visible = true;
                    btnenter.Visible = true;
                    btncancel.Visible = true;
                    cmbrole.Enabled = false;

                }
                else if (cmbrole.Text == "Conductors")
                {
                    roleid = 1;
                    if (tbpasswordreg.Text == tbreenter.Text)
                    {
                        Form1.name = tbfullname.Text;
                        try
                        {
                            Connection.conn.DB();
                            Function.fun.gen = "insert into transportconductor(roleid,fullname,email,celnum,status,username,password)values('" + roleid + "','" + tbfullname.Text + "','" + tbemail.Text + "','" + tbcelnum.Text + "','" + status + "','" + tbusernamereg.Text + "','" + tbpasswordreg.Text + "')";
                            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                            Function.fun.command.ExecuteNonQuery();

                            conductorchoose cc = new conductorchoose();
                            this.Visible = false;
                            cc.Show();
                            //to be written

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password re-entered was a mismatch.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }

                }
                else
                {
                    roleid = 2;//drivers

                    if (tbpasswordreg.Text == tbreenter.Text)
                    {
                        Form1.name = tbfullname.Text;
                        try
                        {
                            Connection.conn.DB();
                            Function.fun.gen = "insert into transportdriver(roleid,fullname,email,celnum,status,username,password)values('" + roleid + "','" + tbfullname.Text + "','" + tbemail.Text + "','" + tbcelnum.Text + "','" + status + "','" + tbusernamereg.Text + "','" + tbpasswordreg.Text + "')";
                            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                            Function.fun.command.ExecuteNonQuery();



                            routespage r = new routespage();
                            this.Visible = false;
                            r.Show();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password re-entered was a mismatch.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    }
                }
            }
            else
            {
                MessageBox.Show("Comply with the DropdownList requirement in the upper-right corner.","SeroSete",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
            
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            if(tbadminpass.Text == Form1.adminkey)
            {
                roleid = 3;
                if (tbpasswordreg.Text == tbreenter.Text)
                {
                    Form1.name = tbfullname.Text;
                    try
                    {
                        Connection.conn.DB();
                        Function.fun.gen = "insert into transportadmin(roleid,fullname,email,celnum,status,username,password)values('" + roleid + "','" + tbfullname.Text + "','" + tbemail.Text + "','" + tbcelnum.Text + "','" + status + "','" + tbusernamereg.Text + "','" + tbpasswordreg.Text + "')";
                        Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                        Function.fun.command.ExecuteNonQuery();


                        MessageBox.Show("Saved!", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Connection.conn.connect.Close();
                        //to be written

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Password re-entered was a mismatch.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }
            else
            {
                MessageBox.Show("Incorrect Passkey.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                btnnext.Enabled = true;
                tbfullname.Enabled = true;
                tbemail.Enabled = true;
                tbcelnum.Enabled = true;
                tbusernamereg.Enabled = true;
                tbpasswordreg.Enabled = true;
                tbreenter.Enabled = true;
                tbadminpass.Visible = false;
                lbladminpass.Visible = false;
                btnenter.Visible = false;
                btncancel.Visible = false;
                cmbrole.Enabled = true;
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            btnnext.Enabled = true;
            tbfullname.Enabled = true;
            tbemail.Enabled = true;
            tbcelnum.Enabled = true;
            tbusernamereg.Enabled = true;
            tbpasswordreg.Enabled = true;
            tbreenter.Enabled = true;
            tbadminpass.Visible = false;
            lbladminpass.Visible = false;
            btnenter.Visible = false;
            btncancel.Visible = false;
            cmbrole.Enabled = true;
        }

        private void lblback_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Visible = false;
            f.Show();
        }
    }
}
