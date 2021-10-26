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
    public partial class routespage : Form
    {
        public routespage()
        {
            InitializeComponent();
            
            try
            {
                Connection.conn.DB();
                Function.fun.gen = "select driverid as ID from transportdriver where fullname = '" + Form1.name + "'";
                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                Function.fun.reader = Function.fun.command.ExecuteReader();

                if (Function.fun.reader.HasRows)
                {
                    Function.fun.reader.Read();
                    Form1.driverid = Function.fun.reader["ID"].ToString();
                    lbldriverid.Text = Form1.driverid;
                    lblname.Text = Form1.name;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Filldata1()
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

        private void routespage_Load(object sender, EventArgs e)
        {
            Filldata1();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                lblvname.Text = dataGridView1[0, e.RowIndex].Value.ToString();
                string todisplay = "";
                if (lblvname.Text == "--")
                {

                }
                else
                {
                    Connection.conn.DB();
                    Function.fun.gen = "select routestops as STOPS from routes where routename = '" + lblvname.Text + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.reader = Function.fun.command.ExecuteReader();

                    if (Function.fun.reader.HasRows)
                    {
                        Function.fun.reader.Read();
                        Form1.eachstops = Function.fun.reader["STOPS"].ToString();
                        Form1.splittedStops = Form1.eachstops.Split(',');
                        for (int i = 0; i < Form1.splittedStops.Length; i++)
                        {
                            todisplay += (i + 1) + " -> " + Form1.splittedStops[i] + "\n";
                        }
                        lblstops.Text = todisplay;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                if(lblvname.Text == "--")
                {
                    MessageBox.Show("Please choose your route code.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Connection.conn.DB();
                    Function.fun.gen = "update transportdriver set route = '" + lblvname.Text + "' where driverid = '"+Form1.driverid+"'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();

                    MessageBox.Show("Saved!", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    

                    Form1 fr = new Form1();
                    this.Visible = false;
                    fr.Show();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnb_Click(object sender, EventArgs e)
        {
            var val = MessageBox.Show("Are you sure? Your previous data will get deleted.", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(val == DialogResult.Yes)
            {
                Connection.conn.DB();
                Function.fun.gen = "Delete from transportdriver where driverid = '" + Form1.driverid + "'";
                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                Function.fun.command.ExecuteNonQuery();
                Connection.conn.connect.Close();

                registrationpage rp = new registrationpage();
                this.Visible = false;
                rp.Show();
            }
            else
            {
                //nothing happens
            }
        }
    }
}
