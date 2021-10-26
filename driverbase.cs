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
    public partial class driverbase : Form
    {
        public driverbase()
        {
            InitializeComponent();
            
            lblname.Text = Form1.name;
        }

        private void driverbase_Load(object sender, EventArgs e)
        {

        }

        private void lblconinfo_Click(object sender, EventArgs e)
        {
            conductorinfodriver cid = new conductorinfodriver();
            this.Visible = false;
            cid.Show();
        }

        private void lblboutus_Click(object sender, EventArgs e)
        {
            aboutusdriver aud = new aboutusdriver();
            this.Visible = false;
            aud.Show();
        }

        private void lblresign_Click(object sender, EventArgs e)
        {
            resignpagedriver rpd = new resignpagedriver();
            this.Visible = false;
            rpd.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            editpagedriver epg = new editpagedriver();
            this.Visible = false;
            epg.Show();
        }

        private void lbllogout_Click(object sender, EventArgs e)
        {
            var val = MessageBox.Show("Are you sure?", "SeroSete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(val == DialogResult.Yes)
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
