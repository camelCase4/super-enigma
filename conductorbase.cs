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
    public partial class conductorbase : Form
    {
        private bool ansclicked = false;
        private bool onreverse = false;
        private bool commendclicked = false;
        private bool reportclicked = false;
        private int min = 0;
        private int max = 0;
        private int passid = 0;
        private int forcounter = 0;
        public conductorbase()
        {
            InitializeComponent();
            lblname.Text = Form1.name;
            lblcondid.Text = Form1.conductorid;
            lblfullname.Text = Form1.name;
            lblemail.Text = Form1.email;
            lblcelnum.Text = Form1.phonenum;
            lblterminal.Text = Form1.splittedStops[0];
            lbldest.Text = Form1.splittedStops[Form1.splittedStops.Length - 1];
            lblcode.Text = Form1.routecode;
            timer1.Start();
            //to populate the combobox with stops
            for (int i = 0; i < Form1.splittedStops.Length; i++)
            {
                cmbtravelstops.Items.Add(Form1.splittedStops[i]);
            }
            cmbtravelstops.Items.Add("Unknown or Undecided Stop");

            lblfare.Text = Form1.splittedfares[Form1.indexoffareandstops].ToString();

            Connection.conn.DB();
            Function.fun.gen = "select count(report) as amount from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
            Function.fun.reader = Function.fun.command.ExecuteReader();

            if (Function.fun.reader.HasRows)
            {
                Function.fun.reader.Read();
                Form1.overallreports = Convert.ToInt32(Function.fun.reader["amount"]);

            }
            Connection.conn.DB();
            Function.fun.gen = "select count(commend) as amount from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
            Function.fun.reader = Function.fun.command.ExecuteReader();
            if (Function.fun.reader.HasRows)
            {
                Function.fun.reader.Read();
                Form1.overallcommends = Convert.ToInt32(Function.fun.reader["amount"]);

            }
            lblrep.Text = Form1.overallreports.ToString();
            lblcom.Text = Form1.overallcommends.ToString();

            //

            Connection.conn.DB();
            Function.fun.gen = "select min(passengerid) as pd from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
            Function.fun.reader = Function.fun.command.ExecuteReader();
            if (Function.fun.reader.HasRows)
            {
                Function.fun.reader.Read();
                try
                {
                    min = Convert.ToInt32(Function.fun.reader["pd"]);
                }
                catch (InvalidCastException)
                {
                    min = 0;
                }
            }
            Connection.conn.DB();
            Function.fun.gen = "select max(passengerid) as pd from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
            Function.fun.reader = Function.fun.command.ExecuteReader();
            if (Function.fun.reader.HasRows)
            {
                Function.fun.reader.Read();
                try
                {
                    max = Convert.ToInt32(Function.fun.reader["pd"]);
                }
                catch (InvalidCastException)
                {
                    max = 0;
                }
            }
            //

            //randoming what to dsplay in the feedback
            Random rm = new Random();
            passid = rm.Next(min, max + 1);
            //

            //for the passenger feedback comment
            Connection.conn.DB();
            Function.fun.gen = "select comment as fb, name as N from passengerfeedback where passengerid = '" + passid + "'";
            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
            Function.fun.reader = Function.fun.command.ExecuteReader();
            if (Function.fun.reader.HasRows)
            {
                Function.fun.reader.Read();
                tbforcomment.Text = Function.fun.reader["fb"].ToString();
                lblpassname.Text = Function.fun.reader["N"].ToString();
            

            }
            else
            {
                tbforcomment.Text = "---";
                lblpassname.Text = "...";
            }

        }
        public double Evaluate(string expression)
        {
            try
            {
                System.Data.DataTable table = new System.Data.DataTable();
                table.Columns.Add("expression", string.Empty.GetType(), expression);
                System.Data.DataRow row = table.NewRow();
                table.Rows.Add(row);
                return double.Parse((string)row["expression"]);
            }
            catch(Exception)
            {
                return 0.0;
            }
        }

        private void btnzero_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "0";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "0";
            }
        }

        private void btnone_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "1";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "1";
            }
        }

        private void btntwo_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "2";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "2";
            }
        }

        private void btnthree_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "3";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "3";
            }
        }

        private void btnfour_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "4";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "4";
            }
        }

        private void btnfive_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "5";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "5";
            }
        }

        private void btnsix_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "6";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "6";
            }
        }

        private void btnseven_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "7";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "7";
            }
        }

        private void btneight_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "8";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "8";
            }
        }

        private void btnnine_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "9";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "9";
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "+";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "+";
            }
        }

        private void btnmin_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "-";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "-";
            }
        }

        private void btndiv_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "/";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "/";
            }
        }

        private void btnmult_Click(object sender, EventArgs e)
        {
            if (ansclicked)
            {
                tbcalc.Text = "";
                tbcalc.Text += "*";
                ansclicked = false;
            }
            else
            {
                tbcalc.Text += "*";
            }
        }

        private void btnans_Click(object sender, EventArgs e)
        {

            double temp = Evaluate(tbcalc.Text);
            if (temp == 0.0)
            {
                tbcalc.Text = "Error";
                ansclicked = true;
            }
            else
            {
                tbcalc.Text = temp.ToString();
                ansclicked = true;
            }
        }

        private void panel3_MouseEnter(object sender, EventArgs e)
        {
            panel3.Focus();
        }

        private void lblclear_Click(object sender, EventArgs e)
        {
            tbcalc.Text = "";
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void lbladd_Click(object sender, EventArgs e)
        {
            try
            {
                lblpassdepart.Text = "";
                lblfaredisplay.Text = "";
                Form1.currentpassengers = 0;

                if (cmbtravelstops.Text != "Unknown or Undecided Stop")
                {
                    for (int i = 0; i < Form1.splittedStops.Length; i++)
                    {
                        if (cmbtravelstops.Text == Form1.splittedStops[i])
                        {
                            Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, Form1.splittedStops[i])] += int.Parse(tbinputamount.Text);
                        }
                    }
                }
                else
                {
                    Form1.passengerwithoutstop += int.Parse(tbinputamount.Text);
                    tbonboard.Text = Form1.passengerwithoutstop.ToString();
                }

                //pag display sa amount sa passenger and stops
                if (onreverse == false)
                {
                    for (int i = 0; i < Form1.splittedStops.Length; i++)
                    {
                        if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                        {
                            lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                            lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                        }
                        else
                        {
                            lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                            lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < Form1.splittedStops.Length; i++)
                    {

                        if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                        {
                            lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                            lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[Form1.splittedStops.Length - (i + 1)].ToString() + "\n\n";
                        }
                        else
                        {
                            lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                            lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[Form1.splittedStops.Length - (i + 1)].ToString() + "\n\n";
                        }


                    }
                }
                //the totalizing of passengers
                for (int i = 0; i < Form1.passengersInEachStops.Length; i++)
                {
                    Form1.currentpassengers += Form1.passengersInEachStops[i];
                }
                lblcp.Text = (Form1.currentpassengers + Form1.passengerwithoutstop).ToString();
            }
            catch(Exception)
            {
                MessageBox.Show("Number inputs only please.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void lbldrop_Click(object sender, EventArgs e)
        {
            
            if (tbdrop.Text != "0")
            {
                if (Form1.passengerwithoutstop >= int.Parse(tbdrop.Text))
                {
                   
                    var assure = MessageBox.Show("Are you sure?\nClaim: PHP" + (int.Parse(tbdrop.Text) * int.Parse(lblfare.Text)).ToString() + " to the passenger(s) with unidentified stop.", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (assure == DialogResult.Yes)
                    {
                        Form1.currentpassengers = 0;
                        Form1.passengerwithoutstop -= int.Parse(tbdrop.Text);
                        tbonboard.Text = Form1.passengerwithoutstop.ToString();
                        for (int i = 0; i < Form1.passengersInEachStops.Length; i++)
                        {
                            Form1.currentpassengers += Form1.passengersInEachStops[i];
                        }
                        lblcp.Text = (Form1.currentpassengers + Form1.passengerwithoutstop).ToString();
                        Form1.tobeaddedintotalearning += (int.Parse(tbdrop.Text) * int.Parse(lblfare.Text));
                        lblte.Text = Form1.tobeaddedintotalearning.ToString();
                    }
                    else
                    {
                        //nothing happens
                    }
                }
                else
                {
                    MessageBox.Show("Amount too big compared to the total passenger with no stops!", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("You haven't inputted the amount to drop. Zero is unacceptable.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void pbrestart_Click(object sender, EventArgs e)
        {
            Form1.currentpassengers = 0;
            lblpassdepart.Text = "";
            lblfaredisplay.Text = "";

            if (cmbtravelstops.Text != "Unknown or Undecided Stop")
            {
                for (int i = 0; i < Form1.splittedStops.Length; i++)
                {
                    if (cmbtravelstops.Text == Form1.splittedStops[i])
                    {

                        Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, Form1.splittedStops[i])] = 0;
                        
                    }
                }
            }
            else
            {
                Form1.passengerwithoutstop = 0;
                tbonboard.Text = Form1.passengerwithoutstop.ToString();
            }


            //pag display sa amount sa passenger and stops
            if (onreverse == false)
            {
                for (int i = 0; i < Form1.splittedStops.Length; i++)
                {
                    if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                    {
                        lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                        lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                    }
                    else
                    {
                        lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                        lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                    }

                }
            }
            else
            {
                for (int i = 0; i < Form1.splittedStops.Length; i++)
                {

                    if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                    {
                        lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                        lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[Form1.splittedStops.Length - (i + 1)].ToString() + "\n\n";
                    }
                    else
                    {
                        lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                        lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[Form1.splittedStops.Length - (i + 1)].ToString() + "\n\n";
                    }


                }
            }

            //the totalizing of passengers
            for (int i = 0; i < Form1.passengersInEachStops.Length; i++)
            {
                Form1.currentpassengers += Form1.passengersInEachStops[i];
            }
            lblcp.Text = (Form1.currentpassengers + Form1.passengerwithoutstop).ToString();
        }

        private void lblyes_Click(object sender, EventArgs e)
        {
           
            
                try
                {
                    if (Form1.reverser == false)
                    {
                        var val = MessageBox.Show("Are we at " + tbplaces.Text + "?\nClaim: PHP " + ((Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, tbplaces.Text)]) * int.Parse(lblfare.Text)).ToString(), "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                        if (val == DialogResult.Yes)
                        {
                            Form1.currentpassengers = 0;
                            lblpassdepart.Text = "";
                            lblfaredisplay.Text = "";
                            Form1.tobeaddedintotalearning += (Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, tbplaces.Text)]) * int.Parse(lblfare.Text);
                            lblte.Text = Form1.tobeaddedintotalearning.ToString();
                            Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, tbplaces.Text)] = 0;

                            //pag display sa amount sa passenger and stops
                            for (int i = 0; i < Form1.splittedStops.Length; i++)
                            {

                                if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                                {
                                    lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                                    lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                                }
                                else
                                {
                                    lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                                    lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                                }


                            }

                            //the totalizing of passengers
                            for (int i = 0; i < Form1.passengersInEachStops.Length; i++)
                            {
                                Form1.currentpassengers += Form1.passengersInEachStops[i];
                            }
                            lblcp.Text = (Form1.currentpassengers + Form1.passengerwithoutstop).ToString();


                            Form1.indexoffareandstops += 1;
                            tbplaces.Text = Form1.splittedStops[Form1.indexoffareandstops];
                            lblfare.Text = Form1.splittedfares[Form1.indexoffareandstops].ToString();
                        }
                        else
                        {
                            //do nothing
                        }


                    }
                    else
                    {
                        try
                        {

                            var val = MessageBox.Show("Are we at " + tbplaces.Text + "?\nClaim: PHP " + ((Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, tbplaces.Text)]) * int.Parse(lblfare.Text)).ToString(), "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            if (val == DialogResult.Yes)
                            {
                                Form1.currentpassengers = 0;
                                lblpassdepart.Text = "";
                                lblfaredisplay.Text = "";
                                Form1.tobeaddedintotalearning += (Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, tbplaces.Text)]) * int.Parse(lblfare.Text);
                                lblte.Text = Form1.tobeaddedintotalearning.ToString();
                                Form1.passengersInEachStops[Array.IndexOf(Form1.splittedStops, tbplaces.Text)] = 0;

                                //pag display sa amount sa passenger and stops
                                
                            //
                            for (int i = 0; i < Form1.splittedStops.Length; i++)
                            {

                                if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                                {
                                    lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                                    lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[Form1.splittedStops.Length - (i + 1)].ToString() + "\n\n";
                                }
                                else
                                {
                                    lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                                    lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[Form1.splittedStops.Length - (i + 1)].ToString() + "\n\n";
                                }


                            }
                            //the totalizing of passengers
                            for (int i = 0; i < Form1.passengersInEachStops.Length; i++)
                                {
                                    Form1.currentpassengers += Form1.passengersInEachStops[i];
                                }
                                lblcp.Text = (Form1.currentpassengers + Form1.passengerwithoutstop).ToString();


                                Form1.indexoffareandstops += 1;
                                tbplaces.Text = Form1.reverseSplittedStops[Form1.indexoffareandstops];
                                lblfare.Text = Form1.splittedfares[Form1.indexoffareandstops].ToString();
                            }
                            else
                            {
                                //do nothing
                            }


                        }
                        catch (Exception)
                        {
                            Form1.counterforrounds++;
                            onreverse = false;
                            lblfaredisplay.Text = "";
                            lblpassdepart.Text = "";
                            Form1.reverser = false;
                            Form1.indexoffareandstops = 1;
                            tbplaces.Text = Form1.splittedStops[Form1.indexoffareandstops];
                            lblfare.Text = Form1.splittedfares[Form1.indexoffareandstops].ToString();
                            MessageBox.Show("We arrived at our destination.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            lblterminal.Text = Form1.splittedStops[0];
                            lbldest.Text = Form1.splittedStops[Form1.splittedStops.Length - 1];
                            for (int i = 0; i < Form1.splittedStops.Length; i++)
                            {

                                if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                                {
                                    lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                                    lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                                }
                                else
                                {
                                    lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                                    lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[i].ToString() + "\n\n";
                                }


                            }
                            if(Form1.counterforrounds % 2 == 0)
                            {
                                Form1.tobeaddedinoverallround++;
                                lbltr.Text = Form1.tobeaddedinoverallround.ToString();
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    Form1.counterforrounds++;
                    onreverse = true;
                    lblfaredisplay.Text = "";
                    lblpassdepart.Text = "";
                    MessageBox.Show("We arrived at our destination.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Form1.reverser = true;
                    Form1.indexoffareandstops = 1;
                    tbplaces.Text = Form1.reverseSplittedStops[Form1.indexoffareandstops];
                    lblfare.Text = Form1.splittedfares[Form1.indexoffareandstops].ToString();
                    lbldest.Text = Form1.splittedStops[0];
                    lblterminal.Text = Form1.splittedStops[Form1.splittedStops.Length - 1];
                    
                    for (int i = 0; i < Form1.splittedStops.Length; i++)
                    {

                        if (Form1.splittedStops[i] != "Subangdaku Elementary School")
                        {
                            lblpassdepart.Text += Form1.splittedStops[i] + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                            lblfaredisplay.Text += "PHP\n" + Form1.splittedfares[Form1.splittedStops.Length-(i+1)].ToString() + "\n\n";
                        }
                        else
                        {
                            lblpassdepart.Text += "Subangdaku\nElementary\nSchool" + " \nPassenger(s) ----->    " + Form1.passengersInEachStops[i] + "\n\n";
                            lblfaredisplay.Text += "\n\nPHP\n" + Form1.splittedfares[Form1.splittedStops.Length-(i+1)].ToString() + "\n\n";
                        }


                    }
                }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString();
            forcounter++;
            if(forcounter % 7 == 0)
            {
                Connection.conn.DB();
                Function.fun.gen = "select min(passengerid) as pd from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                Function.fun.reader = Function.fun.command.ExecuteReader();
                if (Function.fun.reader.HasRows)
                {
                    Function.fun.reader.Read();
                    try
                    {
                        min = Convert.ToInt32(Function.fun.reader["pd"]);
                    }
                    catch (InvalidCastException)
                    {
                        min = 0;
                    }
                }
                Connection.conn.DB();
                Function.fun.gen = "select max(passengerid) as pd from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                Function.fun.reader = Function.fun.command.ExecuteReader();
                if (Function.fun.reader.HasRows)
                {
                    Function.fun.reader.Read();
                    try
                    {
                        max = Convert.ToInt32(Function.fun.reader["pd"]);
                    }
                    catch (InvalidCastException)
                    {
                        max = 0;
                    }
                }

                Random rm = new Random();
                passid = rm.Next(min, max + 1);
                //

                //for the passenger feedback comment
                Connection.conn.DB();
                Function.fun.gen = "select comment as fb, name as N from passengerfeedback where passengerid = '" + passid + "'";
                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                Function.fun.reader = Function.fun.command.ExecuteReader();
                if (Function.fun.reader.HasRows)
                {
                    Function.fun.reader.Read();
                    tbforcomment.Text = Function.fun.reader["fb"].ToString();
                    lblpassname.Text = Function.fun.reader["N"].ToString();


                }
                else
                {
                    tbforcomment.Text = "---";
                    lblpassname.Text = "...";
                }
            }

        }

        private void lblbegin_Click(object sender, EventArgs e)
        {
            tbplaces.Text = Form1.splittedStops[Form1.indexoffareandstops];
            lblyes.Enabled = true;
            lbladd.Enabled = true;

        }

        private void lblend_Click(object sender, EventArgs e)
        {
            var val = MessageBox.Show("Are you sure you want to end the duty for today?", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (val == DialogResult.Yes)
            {
                if (lblcp.Text == "0")
                {
                    timer1.Stop();
                    lbladd.Enabled = false;
                    lblyes.Enabled = false;

                }
                else
                {
                    MessageBox.Show("You still have passengers to drop off!", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btncommend_Click(object sender, EventArgs e)
        {
            commendclicked = true;
            reportclicked = false;
            panel9.Enabled = true;

        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            reportclicked = true;
            commendclicked = false;
            panel9.Enabled = true;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            reportclicked = false;
            commendclicked = false;
            panel9.Enabled = false;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            if (commendclicked)
            {
                try
                {
                    Connection.conn.DB();
                    Function.fun.gen = "insert into passengerfeedback(name,phonenum,comment,report,commend,conductorid)values('" + tbpassname.Text + "','" + tbcelnumpass.Text + "','" + tbcommentpass.Text + "',NULL,1,'" + Form1.conductorid + "')";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();

                    tbpassname.Text = "";
                    tbcelnumpass.Text = "";
                    tbcommentpass.Text = "";
                    panel9.Enabled = false;

                    Connection.conn.DB();
                    Function.fun.gen = "select count(report) as amount from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.reader = Function.fun.command.ExecuteReader();

                    if (Function.fun.reader.HasRows)
                    {
                        Function.fun.reader.Read();
                        Form1.overallreports = Convert.ToInt32(Function.fun.reader["amount"]);

                    }
                    Connection.conn.DB();
                    Function.fun.gen = "select count(commend) as amount from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.reader = Function.fun.command.ExecuteReader();
                    if (Function.fun.reader.HasRows)
                    {
                        Function.fun.reader.Read();
                        Form1.overallcommends = Convert.ToInt32(Function.fun.reader["amount"]);

                    }
                    lblrep.Text = Form1.overallreports.ToString();
                    lblcom.Text = Form1.overallcommends.ToString();
                    try
                    {
                        Connection.conn.DB();
                        Function.fun.gen = "update commendsandreports set commendamount='" + Form1.overallcommends + "',reportamount='" + Form1.overallreports + "' where conductorid = '" + Form1.conductorid + "'";
                        Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                        Function.fun.command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Saved! thanks for giving us your honest feedback.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    Connection.conn.DB();
                    Function.fun.gen = "insert into passengerfeedback(name,phonenum,comment,report,commend,conductorid)values('" + tbpassname.Text + "','" + tbcelnumpass.Text + "','" + tbcommentpass.Text + "',1,NULL,'" + Form1.conductorid + "')";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.command.ExecuteNonQuery();

                    tbpassname.Text = "";
                    tbcelnumpass.Text = "";
                    tbcommentpass.Text = "";
                    panel9.Enabled = false;

                    Connection.conn.DB();
                    Function.fun.gen = "select count(report) as amount from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.reader = Function.fun.command.ExecuteReader();

                    if (Function.fun.reader.HasRows)
                    {
                        Function.fun.reader.Read();
                        Form1.overallreports = Convert.ToInt32(Function.fun.reader["amount"]);

                    }
                    Connection.conn.DB();
                    Function.fun.gen = "select count(commend) as amount from passengerfeedback where conductorid = '" + Form1.conductorid + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.reader = Function.fun.command.ExecuteReader();
                    if (Function.fun.reader.HasRows)
                    {
                        Function.fun.reader.Read();
                        Form1.overallcommends = Convert.ToInt32(Function.fun.reader["amount"]);

                    }
                    lblrep.Text = Form1.overallreports.ToString();
                    lblcom.Text = Form1.overallcommends.ToString();
                    try
                    {
                        Connection.conn.DB();
                        Function.fun.gen = "update commendsandreports set commendamount='" + Form1.overallcommends + "',reportamount='" + Form1.overallreports + "' where conductorid = '" + Form1.conductorid + "'";
                        Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                        Function.fun.command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    MessageBox.Show("Saved! thanks for giving us your honest feedback.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Feel free to judge the conductor's performance.\nYour comment will get featured, to inform future passengers.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox28_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Here are some of the passenger's feedback.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update travel timeline in every stops we encounter.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("These are the passenger's that didn't have any stops.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox29_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You accept passengers here, and track the progress of your voyage.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
