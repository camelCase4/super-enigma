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
    public partial class resignpagedriver : Form
    {
        public resignpagedriver()
        {
            InitializeComponent();
            lblname.Text = Form1.name;
        }

        private void btnproeedresign_Click(object sender, EventArgs e)
        {
            string mt = "";//para ma empty ang slot sa driver sa conductor
            if(tbletter.Text != "")
            {
                var val = MessageBox.Show("Are you sure? Your account, as well as your records will get deleted.", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (val == DialogResult.Yes)
                {
                    MessageBox.Show("Thank you for using us. Goodbye.", "SeroSete", MessageBoxButtons.OK);
                    Connection.conn.DB();
                    Function.fun.gen = "insert into resigneddrivers(driverid,name,letter)values('"+Form1.driverid+"','"+Form1.name+"','"+tbletter.Text+"')";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();
                    Connection.conn.connect.Close();

                    Connection.conn.DB();
                    Function.fun.gen = "update transportconductor set driver = '"+mt+"' where fullname = '"+Form1.conductorname+"'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();
                    Connection.conn.connect.Close();


                    Connection.conn.DB();
                    Function.fun.gen = "Delete from transportdriver where driverid = '" + Form1.driverid + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();
                    Connection.conn.connect.Close();

                    
                    

                    Form1 f = new Form1();
                    this.Visible = false;
                    f.Show();
                }
                else
                {
                    //do nothing.
                }
            }
            else
            {
                MessageBox.Show("Please offer as a reason, comply with the form above.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void lblhome_Click(object sender, EventArgs e)
        {
            driverbase ver = new driverbase();
            this.Visible = false;
            ver.Show();
        }

        private void lblconinfo_Click(object sender, EventArgs e)
        {
            conductorinfodriver con = new conductorinfodriver();
            this.Visible = false;
            con.Show();
        }

        private void lblboutus_Click(object sender, EventArgs e)
        {
            aboutusdriver abo = new aboutusdriver();
            this.Visible = false;
            abo.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            editpagedriver pag = new editpagedriver();
            this.Visible = false;
            pag.Show();
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
