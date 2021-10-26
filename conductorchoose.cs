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
    public partial class conductorchoose : Form
    {
        private string drivername = "";
        public conductorchoose()
        {
            InitializeComponent();
            try
            {
                Connection.conn.DB();
                Function.fun.gen = "select conductorid as ID from transportconductor where fullname = '" + Form1.name + "'";
                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                Function.fun.reader = Function.fun.command.ExecuteReader();

                if (Function.fun.reader.HasRows)
                {
                    Function.fun.reader.Read();
                    Form1.conductorid = Function.fun.reader["ID"].ToString();
                    lblconductorid.Text = Form1.conductorid;
                    lblname.Text = Form1.name;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Filldata()
        {
            try
            {

                Function.fun.gen = "select fullname as NAME from transportdriver where conductor is null";
                Function.fun.fill(Function.fun.gen, dataGridView1);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void conductorchoose_Load(object sender, EventArgs e)
        {
            Filldata();
            dataGridView1.Columns[0].Width = 127;
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                drivername = dataGridView1[0, e.RowIndex].Value.ToString();
                string acquiredroutecode = "";
                Connection.conn.DB();
                Function.fun.gen = "select route as CODE from transportdriver where fullname = '" + drivername + "'";
                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                Function.fun.reader = Function.fun.command.ExecuteReader();

                if(Function.fun.reader.HasRows)
                {
                    Function.fun.reader.Read();
                    acquiredroutecode = Function.fun.reader["CODE"].ToString();
                    lblvname.Text = acquiredroutecode;
                    try
                    {
                        string todisplay = "";
                        Connection.conn.DB();
                        Function.fun.gen = "select routestops as STOPS from routes where routename = '" + acquiredroutecode + "'";
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
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
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
                if (lblvname.Text == "--")
                {
                    MessageBox.Show("Please choose a driver.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Connection.conn.DB();
                    Function.fun.gen = "update transportconductor set route = '" + lblvname.Text + "', driver = '"+drivername+"' where conductorid = '" + Form1.conductorid + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();


                    Connection.conn.DB();
                    Function.fun.gen = "update transportdriver set conductor = '" + Form1.name + "' where fullname = '" + drivername + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();

                    MessageBox.Show("Saved!", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Form1 fr = new Form1();
                    this.Visible = false;
                    fr.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnb_Click(object sender, EventArgs e)
        {
            var val = MessageBox.Show("Are you sure? Your previous data will get deleted.", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (val == DialogResult.Yes)
            {
                Connection.conn.DB();
                Function.fun.gen = "Delete from transportconductor where conductorid = '" + Form1.conductorid + "'";
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
