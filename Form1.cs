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
    public partial class Form1 : Form
    {
        public static string eachstops;
        public static string[] splittedStops;
        public static string[] reverseSplittedStops;
        public static string routecode;
        public static string eachfares;
        public static int[] splittedfares;
        public static int[] passengersInEachStops;

        public static string displaystopandamount;
        public static int currentpassengers;
        public static int passengerwithoutstop;

        public static int indexoffareandstops = 1;
        public static bool reverser = false;

        public static string adminkey = "sering";

        public static string driverid;
        public static string conductorid;
        public static string adminid;

        public static string name;//for the current user
        public static string email;
        public static string phonenum;
        public static string status;
        public static string username;
        public static string password;

        public static string conductorname;
        public static string drivername;

        public static int counterforrounds = 0;
        public static int overallreports = 0;
        public static int overallcommends = 0;

        public static int tobeaddedintotalearning = 0;
        public static int tobeaddedinservedpas = 0;
        public static double tobeaddedinaveprofit = 0.0;
        public static double tobeaddedinavepass = 0.0;
        public static int tobeaddedinoverallround = 0;
        

        private string[] typesofuser = { "transportconductor","transportdriver","transportadmin" };
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsignup_Click(object sender, EventArgs e)
        {
            registrationpage rp = new registrationpage();
            this.Visible = false;
            rp.Show();
        }

        private void btnenter_Click(object sender, EventArgs e)
        {
            int roleid = 0;
            int found = 0;
            for(int i = 0; i < typesofuser.Length; i++)
            {
                try
                {
                    Connection.conn.DB();
                    Function.fun.gen = "select * from "+typesofuser[i]+" where username = '" + tbusername.Text + "' and password = '" + tbpass.Text + "'";
                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                    Function.fun.reader = Function.fun.command.ExecuteReader();

                    if(Function.fun.reader.HasRows)
                    {
                        found = 1;
                        int c = 0;
                        Function.fun.reader.Read();
                        roleid = Convert.ToInt32(Function.fun.reader["roleid"]);

                        if(roleid == 1)
                        {
                            name = Function.fun.reader["fullname"].ToString();
                            email = Function.fun.reader["email"].ToString();
                            phonenum = Function.fun.reader["celnum"].ToString();
                            status = Function.fun.reader["status"].ToString();
                            drivername = Function.fun.reader["driver"].ToString();
                            routecode = Function.fun.reader["route"].ToString();
                            conductorid = Function.fun.reader["conductorid"].ToString();
                            password = Function.fun.reader["password"].ToString();
                            username = Function.fun.reader["username"].ToString();

                            Connection.conn.DB();
                            Function.fun.gen = "select * from routes where routename = '" + routecode + "'";
                            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                            Function.fun.reader = Function.fun.command.ExecuteReader();

                            if (Function.fun.reader.HasRows)
                            {
                                Function.fun.reader.Read();
                                eachstops = Function.fun.reader["routestops"].ToString();
                                eachfares = Function.fun.reader["routefares"].ToString();
                                splittedStops = eachstops.Split(',');
                                splittedfares = new int[eachfares.Split(',').Length];
                                for (int x = 0; x < eachfares.Split(',').Length; x++)
                                {
                                    splittedfares[x] = int.Parse(eachfares.Split(',')[x]);
                                }
                                reverseSplittedStops = new string[splittedStops.Length];
                                for(int z = splittedStops.Length-1; z >= 0; z--)
                                {
                                    reverseSplittedStops[c] = splittedStops[z];
                                    c++;
                                }
                            }

                            Connection.conn.DB();
                            Function.fun.gen = "select count(report) as amount from passengerfeedback where conductorid = '" + conductorid + "'";
                            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                            Function.fun.reader = Function.fun.command.ExecuteReader();

                            if (Function.fun.reader.HasRows)
                            {
                                Function.fun.reader.Read();
                                overallreports = Convert.ToInt32(Function.fun.reader["amount"]);

                            }
                            Connection.conn.DB();
                            Function.fun.gen = "select count(commend) as amount from passengerfeedback where conductorid = '" + conductorid + "'";
                            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                            Function.fun.reader = Function.fun.command.ExecuteReader();

                            if (Function.fun.reader.HasRows)
                            {
                                Function.fun.reader.Read();
                                overallcommends = Convert.ToInt32(Function.fun.reader["amount"]);

                            }

                            try
                            {

                                Connection.conn.DB();
                                Function.fun.gen = "select conductorid from commendsandreports where conductorid='" + conductorid + "'";
                                Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                                Function.fun.reader = Function.fun.command.ExecuteReader();

                                if (Function.fun.reader.HasRows)
                                {
                                    // do nothing
                                }
                                else
                                {
                                    Connection.conn.DB();
                                    Function.fun.gen = "insert into commendsandreports(conductorid,condname,commendamount,reportamount)values('" + conductorid + "','" + name + "','" + overallcommends + "','" + overallreports + "')";
                                    Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                                    Function.fun.command.ExecuteNonQuery();
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }



                            passengersInEachStops = new int[splittedStops.Length];
                            for (int y = 0; y < passengersInEachStops.Length; y++)
                            {
                                passengersInEachStops[y] = 0;
                            }
                            conductorbase cb = new conductorbase();
                            this.Visible = false;
                            cb.Show();
                        }
                        else if(roleid == 2)
                        {
                            name = Function.fun.reader["fullname"].ToString();
                            email = Function.fun.reader["email"].ToString();
                            phonenum = Function.fun.reader["celnum"].ToString();
                            status = Function.fun.reader["status"].ToString();
                            conductorname = Function.fun.reader["conductor"].ToString();
                            routecode = Function.fun.reader["route"].ToString();
                            driverid = Function.fun.reader["driverid"].ToString();
                            password = Function.fun.reader["password"].ToString();
                            username = Function.fun.reader["username"].ToString();

                            Connection.conn.DB();
                            Function.fun.gen = "select * from routes where routename = '" + routecode + "'";
                            Function.fun.command = new SqlCommand(Function.fun.gen, Connection.conn.connect);
                            Function.fun.reader = Function.fun.command.ExecuteReader();

                            if(Function.fun.reader.HasRows)
                            {
                                Function.fun.reader.Read();
                                eachstops = Function.fun.reader["routestops"].ToString();
                                eachfares = Function.fun.reader["routefares"].ToString();
                                splittedStops = eachstops.Split(',');
                                splittedfares = new int[eachfares.Split(',').Length];
                                for(int x = 0; x < eachfares.Split(',').Length; x++)
                                {
                                    splittedfares[x] = int.Parse(eachfares.Split(',')[x]);
                                }
                            }
                            driverbase d = new driverbase();
                            this.Visible = false;
                            d.Show();
                        }
                        else
                        {
                            //admin page
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (found == 0)
            {
                MessageBox.Show("No existing credentials. Try again.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
    }
}
