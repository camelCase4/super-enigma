using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConductorAssistantSystem
{
    public partial class conductorinfodriver : Form
    {
        public conductorinfodriver()
        {
            InitializeComponent();
            lblname.Text = Form1.name;
            if(Form1.conductorname == "")
            {
                panel5.Enabled = false;
                lblpending.Visible = true;
                lblmore.Visible = true;
            }
        }

        private void lblmore_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You don't have a parter(Conductor) yet. Be patient.", "SeroSete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void lblhome_Click(object sender, EventArgs e)
        {
            driverbase d = new driverbase();
            this.Visible = false;
            d.Show();
        }

        private void lblboutus_Click(object sender, EventArgs e)
        {
            aboutusdriver ad = new aboutusdriver();
            this.Visible = false;
            ad.Show();
        }

        private void lblresign_Click(object sender, EventArgs e)
        {
            resignpagedriver rp = new resignpagedriver();
            this.Visible = false;
            rp.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            editpagedriver ep = new editpagedriver();
            this.Visible = false;
            ep.Show();
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
